using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartLMC.SmartLMC
{
    public class Code
    {
        public string[][] Text;
        public Line[] Lines;
        public List<Step> Steps;
        public Instruction[] Instructions;
        public int[] Memory;
        public int[] ErrorSelection;

        public Code(string text)
        {
            string[] sourceText = text.Trim().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Text = new string[sourceText.Length][];

            for (int i = 0; i < sourceText.Length; i++)
            {
                if (sourceText[i] != "")
                {
                    Regex regex = new Regex(@"[ ]{2,}");
                    sourceText[i] = regex.Replace(sourceText[i], @" ").Trim();

                    Text[i] = sourceText[i].Split(' ');
                }
            }
        }

        #region Main Functions
        public bool Compile()
        {
            Lines = new Line[Text.Length];
            Steps = new List<Step>();

            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] != null)
                {
                    Lines[i] = new Line(string.Join(" ", Text[i]).ToUpper());

                    Line currLine = evaluateLine(i, Text[i], 0);
                    if (currLine != null)
                    {
                        Lines[i] = currLine;
                    }

                    else
                    {
                        return false;
                    }
                }
            }

            if (setMemory())
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public int Run(int startIndex)
        {
            int[] currMem = new int[100];
            for (int i = startIndex; i < Lines.Length; i++)
            {
                Step currStep = new Step(i);
                Steps.Add(currStep);
                string currInstruction = Instruction.Instructions[Lines[i].Instruction];

                int currAcc = currStep.Accumulator = (i != 0 ? Steps[Steps.Count - 2].Accumulator : 0);
                if (currInstruction == "ADD")
                {
                    currStep.Accumulator = currAcc + getMemoryFromChanges(Steps.Count - 1)[Lines[i].Target.Address];
                }

                else if (currInstruction == "SUB")
                {
                    currStep.Accumulator = currAcc - getMemoryFromChanges(Steps.Count - 1)[Lines[i].Target.Address];
                }

                else if (currInstruction == "STA")
                {
                    currStep.MemoryChange = new int[] { Lines[i].Target.Address, currAcc };
                    currMem[Lines[i].Target.Address] = currAcc;
                }

                else if (currInstruction == "LDA")
                {
                    currStep.Accumulator = getMemoryFromChanges(Steps.Count - 1)[Lines[i].Target.Address];
                }

                else if (currInstruction == "BRA" || (currInstruction == "BRZ" && currAcc == 0) || (currInstruction == "BRP" && currAcc >= 0))
                {
                    i = Lines[i].Target.Address - 1;
                }

                else if (currInstruction == "INP")
                {
                    return i + 1;
                }

                else if (currInstruction == "OUT")
                {
                    currStep.Output = currAcc.ToString();
                }

                else if (currInstruction == "HTL")
                {
                    return 0;
                }
            }

            return 0;
        }

        Line evaluateLine(int lineNumber, string[] lineParts, int partNumber)
        {
            int currInstruction = getInstructionByName(lineParts[partNumber]);

            if (lineParts.Length > 3)
            {
                MessageBox.Show("Line " + (lineNumber + 1) + " contains more parts than expected. Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorSelection = getErrorSelection(lineNumber);
                return null;
            }

            if (currInstruction != -1)
            {
                Lines[lineNumber].Instruction = currInstruction;

                if (partNumber + 1 < lineParts.Length)
                {
                    if (partNumber + 2 < lineParts.Length)
                    {
                        MessageBox.Show("\"" + lineParts[partNumber].ToUpper() + "\" instruction has more attributes than expected. Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorSelection = getErrorSelection(lineNumber);
                        return null;
                    }

                    int address;
                    if (Instruction.TargetRequirements[currInstruction])
                    {
                        Lines[lineNumber].Target = Lines[lineNumber].Target == null ? new MemoryAllocation() : Lines[lineNumber].Target;

                        if (int.TryParse(lineParts[partNumber + 1], out address))
                        {
                            Lines[lineNumber].Target.Address = address;
                        }

                        else
                        {
                            Lines[lineNumber].Target.Name = lineParts[partNumber + 1];

                            address = getAddressByName(lineParts[partNumber + 1]);
                            if (address != -1)
                            {
                                Lines[lineNumber].Target.Address = address;
                            }
                        }
                    }

                    else if (Instruction.Instructions[currInstruction] != "DAT")
                    {
                        MessageBox.Show("\"" + lineParts[partNumber].ToUpper() + "\" instruction has more attributes than expected. Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorSelection = getErrorSelection(lineNumber);
                        return null;
                    }

                    else if (int.TryParse(lineParts[partNumber + 1], out address))
                    {
                        Lines[lineNumber].Target = new MemoryAllocation();
                        Lines[lineNumber].Target.Address = address;
                    }

                    else
                    {
                        MessageBox.Show("Can't allocate memory for \"" + Lines[lineNumber].Name.ToUpper() + "\" label. Invalid memory value: \"" + lineParts[partNumber + 1].ToUpper() + "\". Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorSelection = getErrorSelection(lineNumber);
                        return null;
                    }
                }

                else if (Instruction.TargetRequirements[currInstruction])
                {
                    MessageBox.Show("\"" + lineParts[partNumber].ToUpper() + "\" instruction requires a target label or memory address. Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorSelection = getErrorSelection(lineNumber);
                    return null;
                }

                return Lines[lineNumber];
            }

            else if (partNumber == 0 && lineParts.Length > 1)
            {
                Lines[lineNumber].Name = lineParts[partNumber];
                setAddressByName(lineParts[partNumber], lineNumber);
                return evaluateLine(lineNumber, lineParts, partNumber + 1);
            }

            else if (partNumber == 1)
            {
                MessageBox.Show("\"" + lineParts[0].ToUpper() + "\" (or \"" + lineParts[1].ToUpper() + "\") is not a valid instruction. Please revise the source code!", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorSelection = getErrorSelection(lineNumber);
                return null;
            }

            else
            {
                MessageBox.Show("\"" + lineParts[0].ToUpper() + "\" is not a valid instruction. Please revise the source code! ", "Error (Line " + (lineNumber + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorSelection = getErrorSelection(lineNumber);
                return null;
            }
        }

        void buildInstructions()
        {

        }
        #endregion

        #region Helper Functions
        int getInstructionByName(string inputText)
        {
            string text = inputText.ToUpper();
            for (int i = 0; i < Instruction.Instructions.Length; i++)
            {
                if (Instruction.Instructions[i] == text)
                {
                    return i;
                }
            }

            return -1;
        }

        int getAddressByName(string name)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] == null)
                {
                    break;
                }

                if (Lines[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        void setAddressByName(string name, int address)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] == null)
                {
                    break;
                }

                if (Lines[i].Target != null && Lines[i].Target.Name == name)
                {
                    Lines[i].Target.Address = address;
                }
            }
        }

        bool setMemory()
        {
            Memory = new int[100];

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i] != null)
                {
                    Memory[i] = Instruction.Codes[Lines[i].Instruction];

                    if (Lines[i].Target != null)
                    {
                        if (Lines[i].Target.Address == -1)
                        {
                            MessageBox.Show("There is no memory allocated for \"" + Lines[i].Target.Name.ToUpper() + "\" label. Use \"DAT\" instruction to do that! ", "Error (Line " + (i + 1) + ")", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ErrorSelection = getErrorSelection(i);
                            return false;
                        }

                        else
                        {
                            Memory[i] += Lines[i].Target.Address - 1 + (Instruction.Instructions[Lines[i].Instruction] == "DAT" ? 1 : 0);
                        }
                    }
                }
            }

            return true;
        }

        int[] getErrorSelection(int rowNumber)
        {
            string[] splittedSource = Form1.SourceCode.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            int charCount = 0;
            for (int i = 0; i < rowNumber; i++)
            {
                charCount += splittedSource[i].Length + 2;
            }

            return new int[] { charCount, splittedSource[rowNumber].Length };
        }

        public int[] getMemoryFromChanges(int stepNumber)
        {
            if (Steps.Count != 0)
            {
                int[] memOut = (int[])Memory.Clone();
                for (int i = 0; i <= stepNumber; i++)
                {

                    if (Steps[i].MemoryChange != null)
                    {
                        memOut[Steps[i].MemoryChange[0]] = Steps[i].MemoryChange[1];
                    }
                }

                return memOut;
            }

            else
            {
                return Memory;
            }
        }

        public string getOutput(int stepNumber)
        {
            string output = "";
            for (int i = 0; i < stepNumber + 1; i++)
            {
                if (Steps[i].Output != null)
                {
                    output += Steps[i].Output + "\r\n";
                }
            }

            return output;
        }
        #endregion
    }
}
