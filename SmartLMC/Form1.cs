using SmartLMC.SmartLMC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartLMC
{
    public partial class Form1 : Form
    {
        #region Variables
        public static Code CurrCode;
        public static string SourceCode;

        int selectedRow;
        List<Control> highlightedMemoryBoxes = new List<Control>();
        int highlightedLine = -1;

        int RunStatus = 0;

        Color lightRed = ColorTranslator.FromHtml("#FF7070");
        Color lightYellow = ColorTranslator.FromHtml("#FFF070");
        Color lightGreen = ColorTranslator.FromHtml("#69C669");
        Color lightBlue = ColorTranslator.FromHtml("#3399ff");
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int rowNumber = (i) / 10 + 1;
                int columnNumber = i % 10 + 1;

                memoryGroup.Controls.Add(Forms.CreateLabel("memoryTitle" + i, i.ToString("00"),new int[2] { columnNumber * 38 - 20, rowNumber * 48 - 20 }));
                memoryGroup.Controls.Add(Forms.CreateTextBox("memoryValue" + i, "000", new int[2] { columnNumber * 38 - 25, rowNumber * 48 - 2 }));
            }

            selectionColorBox.BackColor = lightBlue;
            modifiedColorBox.BackColor = lightRed;
            sourceColorBox.BackColor = lightYellow;
            targetColorBox.BackColor = lightGreen;
        }

        private void sourceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sourceTextBox.Text != "")
            {
                compileButton.Enabled = true;
            }

            else
            {
                compileButton.Enabled = false;
            }
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            string exampleText = "INP\r\nSTA FIRST\r\nINP\r\nSTA SECOND\r\nSUB FIRST\r\nBRP HIGHER\r\nLDA FIRST\r\nBRA DONE\r\nHIGHER LDA SECOND\r\nDONE OUT\r\nHLT\r\nFIRST DAT\r\nSECOND DAT";
            sourceTextBox.Text = exampleText;
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            accumulatorBox.Text = "000";
            counterBox.Text = "00";
            addressBox.Text = "00";
            instructionBox.Text = "0";
            inputBox.Value = 0;
            outputBox.Text = "";

            SourceCode = sourceTextBox.Text;
            CurrCode = new Code(SourceCode);

            stepsTable.CurrentCellChanged -= stepsTable_CurrentCellChanged;
            highlightImportant(0, true);

            compileButton.Text = "Compiling...";
            if (CurrCode.Compile())
            {
                editButton.Enabled = true;
                sourceGroup.Enabled = false;
                programGroup.Enabled = true;

                compileButton.Text = "Recompile ->";

                applyMemory(0);
                applyProgram(programTable, Forms.createProgramTable());
                programTable.Visible = true;

                RunStatus = CurrCode.Run(0);
                if (RunStatus != 0)
                {
                    getInput(RunStatus - 1);
                }

                else
                {
                    afterRun();
                }
            }

            else
            {
                compileButton.Text = "Compile ->";
                sourceTextBox.Focus();
                sourceTextBox.Select(CurrCode.ErrorSelection[0], CurrCode.ErrorSelection[1]);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editButton.Enabled = false;
            sourceGroup.Enabled = true;
            programGroup.Enabled = false;
            programTable.Visible = false;

            compileButton.Text = "Compile ->";
        }

        private void stepsTable_CurrentCellChanged(object sender, EventArgs e)
        {
            int selectedIndex = stepsTable.CurrentRow.Index;

            applyMemory(selectedIndex);
            accumulatorBox.Text = CurrCode.Steps[selectedIndex].Accumulator.ToString("000");
            outputBox.Text = CurrCode.getOutput(selectedIndex);

            int lineNumber = CurrCode.Steps[selectedIndex].LineNumber;

            counterBox.Text = lineNumber.ToString("00");
            if (Instruction.Instructions[CurrCode.Lines[lineNumber].Instruction] != "DAT")
            {
                MemoryAllocation currTarget = CurrCode.Lines[lineNumber].Target;
                addressBox.Text = currTarget != null ? CurrCode.Lines[lineNumber].Target.Address.ToString("00") : "00";
                instructionBox.Text = Math.Floor(CurrCode.getMemoryFromChanges(selectedIndex)[lineNumber] / 100.0).ToString();
            }

            programTable.Rows[CurrCode.Steps[selectedIndex].LineNumber].Selected = true;

            highlightImportant(selectedIndex, false);
            changeSelectedLabel();

            setHelpStrip(selectedIndex);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendButton.Enabled = false;

            if (RunStatus != 0)
            {
                CurrCode.Steps[RunStatus - 1].Accumulator = Convert.ToInt32(inputBox.Value);
                RunStatus = CurrCode.Run(RunStatus);
            }

            inputBox.Enabled = false;
            inputBox.Value = 0;

            if (RunStatus != 0)
            {
                getInput(RunStatus - 1);
            }

            else
            {
                afterRun();
            }
        }
        #endregion

        #region Functions
        private void insertCommand(object sender, EventArgs e)
        {
            Button commandButton = (Button)sender;
            string currCommand = commandButton.Name.Substring(0, 3).ToUpper();

            string[] sourceText = sourceTextBox.Text.Split('\n');
            int lineNumber = sourceText.Length;
            bool lastEmpty = sourceText[lineNumber - 1].Replace(" ", "") == "";
            if (lastEmpty)
            {
                sourceText[lineNumber - 1] = currCommand;
            }

            sourceTextBox.Text = string.Join("\n", sourceText) + (!lastEmpty ? ("\r\n" + currCommand) : "");
            sourceTextBox.Focus();
            sourceTextBox.Select(sourceTextBox.Text.Length, 0);
        }

        private void applyProgram(DataGridView outputTable, DataTable tableSource)
        {
            outputTable.DataSource = tableSource;

            for (int i = 0; i < outputTable.ColumnCount; i++)
            {
                outputTable.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            outputTable.Columns[0].Width = 25;
            accumulatorBox.Text = CurrCode.Steps.Count != 0 ? CurrCode.Steps[CurrCode.Steps.Count - 1].Accumulator.ToString("000") : "000";
        }

        void applyMemory(int stepNumber)
        {
            int[] currMem = CurrCode.getMemoryFromChanges(stepNumber);
            for (int i = 0; i < CurrCode.Memory.Length; i++)
            {
                Control currMemLabel = Controls.Find("memoryValue" + i, true)[0];
                if (currMemLabel.Text != currMem[i].ToString("000"))
                {
                    currMemLabel.Text = currMem[i].ToString("000");
                }
            }
        }

        public void afterRun()
        {
            programTable.CurrentCell = programTable.Rows[programTable.Rows.Count - 1].Cells[0];

            applyProgram(stepsTable, Forms.createStepsTable());
            stepsTable.CurrentCellChanged += stepsTable_CurrentCellChanged;

            applyMemory(stepsTable.CurrentCell.RowIndex);
            stepsTable.CurrentCell = stepsTable.Rows[CurrCode.Steps.Count - 1].Cells[0];
            outputBox.Text = CurrCode.getOutput(stepsTable.CurrentCell.RowIndex);

            changeSelectedLabel();
            highlightImportant(CurrCode.Steps.Count - 1, false);
            checkForInactiveRows();
        }

        public void getInput(int stepNumber)
        {
            applyProgram(stepsTable, Forms.createStepsTable());
            stepsTable.CurrentCell = stepsTable.Rows[CurrCode.Steps.Count - 1].Cells[0];
            programTable.CurrentCell = programTable.Rows[CurrCode.Steps[CurrCode.Steps.Count - 1].LineNumber].Cells[0];
            changeSelectedLabel();

            MessageBox.Show("Please write in a number for \"INP\" instruction (on line " + stepNumber + ") to the input box below.", "Input Required",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            inputBox.Enabled = true;
            sendButton.Enabled = true;
            inputBox.Focus();
        }

        void changeSelectedLabel()
        {
            if (stepsTable.CurrentCell != null)
            {
                int currSelectedRow = CurrCode.Steps[stepsTable.CurrentCell.RowIndex].LineNumber;

                Control previousLabel = Controls.Find("memoryTitle" + selectedRow, true)[0];
                Control previousTextBox = Controls.Find("memoryValue" + selectedRow, true)[0];
                Control currLabel = Controls.Find("memoryTitle" + currSelectedRow, true)[0];
                Control currTextBox = Controls.Find("memoryValue" + currSelectedRow, true)[0];

                previousLabel.Font = new Font(currLabel.Font, FontStyle.Regular);
                currTextBox.ForeColor = Color.Black;

                bool isFound = false;
                foreach (Control currMemoryBox in highlightedMemoryBoxes)
                {
                    if (currMemoryBox == previousTextBox)
                    {
                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    previousTextBox.Font = new Font(previousTextBox.Font, FontStyle.Regular);
                    previousTextBox.BackColor = Color.Empty;
                }

                previousTextBox.ForeColor = Color.Black;
                currLabel.Font = new Font(currLabel.Font, FontStyle.Bold);
                currTextBox.BackColor = lightBlue;
                currTextBox.ForeColor = Color.White;

                selectedRow = currSelectedRow;
            }
        }

        private void highlightImportant(int selectedIndex, bool removeHighlighting)
        {
            foreach (Control currMemoryBox in highlightedMemoryBoxes)
            {
                currMemoryBox.BackColor = Color.Empty;
                currMemoryBox.Font = new Font(currMemoryBox.Font, FontStyle.Regular);
            }

            highlightedMemoryBoxes = new List<Control>();

            accumulatorBox.BackColor = Color.Empty;
            accumulatorBox.Font = new Font(accumulatorBox.Font, FontStyle.Regular);
            inputBox.BackColor = Color.Empty;
            inputBox.Font = new Font(inputBox.Font, FontStyle.Regular);
            outputBox.BackColor = Color.Empty;
            outputBox.Font = new Font(outputBox.Font, FontStyle.Regular);

            if (highlightedLine < programTable.Rows.Count && highlightedLine != -1)
            {
                programTable.Rows[highlightedLine].DefaultCellStyle.BackColor = Color.Empty;
            }

            if (!removeHighlighting)
            {
                Line currLine = CurrCode.Lines[CurrCode.Steps[selectedIndex].LineNumber];
                string currInstruction = Instruction.Instructions[currLine.Instruction];

                if (currInstruction == "INP")
                {
                    inputBox.BackColor = lightYellow;
                    inputBox.Font = new Font(inputBox.Font, FontStyle.Bold);

                    inputBox.Value = CurrCode.Steps[selectedIndex].Accumulator;
                }

                else if (currInstruction == "STA")
                {
                    accumulatorBox.BackColor = lightYellow;
                }

                else if (currInstruction == "OUT")
                {
                    accumulatorBox.BackColor = lightYellow;
                }

                // Accumulator
                if (Instruction.AccumulatorChange[currLine.Instruction])
                {
                    accumulatorBox.BackColor = lightRed;
                    accumulatorBox.Font = new Font(accumulatorBox.Font, FontStyle.Bold);
                }

                // Memory
                if (CurrCode.Steps[selectedIndex].MemoryChange != null)
                {
                    Control currMemoryBox = Controls.Find("memoryValue" + CurrCode.Steps[selectedIndex].MemoryChange[0], true)[0];
                    highlightedMemoryBoxes.Add(currMemoryBox);

                    currMemoryBox.BackColor = lightRed;
                    currMemoryBox.Font = new Font(currMemoryBox.Font, FontStyle.Bold);
                }

                // Output
                if ((selectedIndex == 0 && CurrCode.Steps[selectedIndex].Output != null)
                    || (selectedIndex != 0 && CurrCode.getOutput(selectedIndex) != CurrCode.getOutput(selectedIndex - 1)))
                {
                    outputBox.BackColor = lightRed;
                    outputBox.Font = new Font(outputBox.Font, FontStyle.Bold);
                }

                // Branching & Others
                MemoryAllocation currTarget = currLine.Target;
                if (currTarget != null)
                {
                    Control currMemoryBox = Controls.Find("memoryValue" + currTarget.Address, true)[0];

                    if (currInstruction == "BRA" || currInstruction == "BRZ" || currInstruction == "BRP")
                    {
                        Control currControl = Controls.Find("memoryValue" + CurrCode.Steps[selectedIndex].LineNumber, true)[0];
                        highlightedMemoryBoxes.Add(currControl);

                        currControl.BackColor = lightYellow;

                        if (CurrCode.Steps[selectedIndex + 1].LineNumber == currLine.Target.Address)
                        {
                            highlightedMemoryBoxes.Add(currMemoryBox);
                            currMemoryBox.BackColor = lightGreen;

                            programTable.Rows[currLine.Target.Address].DefaultCellStyle.BackColor = lightGreen;
                            highlightedLine = currLine.Target.Address;
                        }
                    }

                    else if (currMemoryBox.BackColor != lightRed)
                    {
                        highlightedMemoryBoxes.Add(currMemoryBox);
                        currMemoryBox.BackColor = lightYellow;
                    }
                }
            }
        }

        void checkForInactiveRows()
        {
            for (int i = 0; i < CurrCode.Lines.Length; i++)
            {
                bool isFound = false;
                foreach (Step currStep in CurrCode.Steps)
                {
                    if (currStep.LineNumber == i)
                    {
                        isFound = true;
                    }
                }

                if (!isFound)
                {
                    programTable.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void setHelpStrip(int selectedIndex)
        {
            Step currStep = CurrCode.Steps[selectedIndex];
            Line currLine = CurrCode.Lines[currStep.LineNumber];
            string currInstruction = Instruction.Instructions[currLine.Instruction];

            int previousAccumulator = selectedIndex > 0 ? CurrCode.Steps[selectedIndex - 1].Accumulator : 0;

            int currTarget = 0;
            int targetMemoryValue = 0;
            int previousMemoryValue = 0;
            if (currLine.Target != null)
            {
                currTarget = currLine.Target.Address;
                targetMemoryValue = CurrCode.getMemoryFromChanges(selectedIndex)[currTarget];
                previousMemoryValue = CurrCode.Memory[currLine.Target.Address];
            }

            helpStatusLabel.Text = currInstruction + ": ";

            if (currInstruction == "ADD")
            {
                helpStatusLabel.Text += "Takes the value \"" + targetMemoryValue.ToString("000")
                    + "\" from memory with address \"" + currTarget.ToString("00") + "\" " + (currLine.Target.Name != null ? ("(label: " + currLine.Target.Name + ") ") : "")
                    + "and adds it to the accumulator: " + previousAccumulator.ToString("000") + " + " + targetMemoryValue.ToString("000") + " => " + (previousAccumulator + targetMemoryValue).ToString("000");
            }

            else if (currInstruction == "SUB")
            {
                helpStatusLabel.Text += "Takes the value \"" + targetMemoryValue.ToString("000")
                    + "\" from memory with address \"" + currTarget.ToString("00") + "\" " + (currLine.Target.Name != null ? ("(label: " + currLine.Target.Name + ") ") : "")
                    + "and subtracts it from the accumulator: " + previousAccumulator.ToString("000") + " - " + targetMemoryValue.ToString("000") + " => " + (previousAccumulator - targetMemoryValue).ToString("000");
            }

            else if (currInstruction == "STA")
            {
                helpStatusLabel.Text += "Takes the value \"" + previousAccumulator.ToString("000")
                    + "\" from the accumulator and stores it in the memory with address \"" + currTarget.ToString("00") + "\" " + (currLine.Target.Name != null ? ("(label: " + currLine.Target.Name + ") ") : "")
                    + ": " + previousMemoryValue.ToString("000") + " => " + currStep.Accumulator.ToString("000");
            }

            else if (currInstruction == "LDA")
            {
                helpStatusLabel.Text += "Takes the value \"" + targetMemoryValue.ToString("000")
                    + "\" from memory with address \"" + currTarget.ToString("00") + "\" " + (currLine.Target.Name != null ? ("(label: " + currLine.Target.Name + ") ") : "")
                    + "and loads it into the accumulator: " + previousAccumulator.ToString("000") + " => " + targetMemoryValue.ToString("000");
            }

            else if (currInstruction == "BRA" || currInstruction == "BRZ" || currInstruction == "BRP")
            {
                string takenText = "";
                if (currInstruction == "BRZ")
                {
                    helpStatusLabel.Text += "If the accumulator value \"" + currStep.Accumulator.ToString("000") + "\" is 000, s";
                    takenText = (currStep.Accumulator == 0 ? "" : "not ") + "taken";
                }

                if (currInstruction == "BRP")
                {
                    helpStatusLabel.Text += "If the accumulator value \"" + currStep.Accumulator.ToString("000") + "\" is poitive or 000, s";
                    takenText = (currStep.Accumulator >= 0 ? "" : "not ") + "taken";
                }

                else
                {
                    helpStatusLabel.Text += "S";
                    
                }

                helpStatusLabel.Text += "ets the program counter to the target address \""+ currLine.Target.Address.ToString("00") + "\" "
                    + "(jumps to the given line). -> "  + (currLine.Target.Address == CurrCode.Steps[selectedIndex + 1].LineNumber ? "taken" : "not taken");
            }

            else if (currInstruction == "INP")
            {
                helpStatusLabel.Text += "Asks the user for an input (" + currStep.Accumulator.ToString("000")
                    + "), and loads it into the accumulator: " + previousAccumulator.ToString("000") + " => " + currStep.Accumulator.ToString("000");
            }

            else if (currInstruction == "OUT")
            {
                helpStatusLabel.Text += "Takes the value \"" + currStep.Accumulator.ToString("000") + "\" from the accumulator"
                    + " and outputs it to the user.";
            }

            else if (currInstruction == "HLT")
            {
                helpStatusLabel.Text += "Terminates the program.";
            }

            else if (currInstruction == "DAT")
            {
                helpStatusLabel.Text += "Allocates the current memory box (with address \"" + currStep.LineNumber.ToString("00") + "\") for the label \"" + currLine.Name + "\".";
            }

            helpStrip.Refresh();
        }
        #endregion
    }
}
