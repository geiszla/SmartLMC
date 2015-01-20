﻿using SmartLMC.SmartLMC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartLMC
{
    public partial class Form1 : Form
    {
        int selectedRow;
        List<Control> highlightedMemoryBoxes = new List<Control>();
        int highlightedLine = -1;

        public static Code currCode;
        public static string sourceCode;

        int RunStatus = 0;

        Color lightRed = (Color)ColorTranslator.FromHtml("#FF7070");
        Color lightYellow = (Color)ColorTranslator.FromHtml("#FFF070");
        Color lightGreen = (Color)ColorTranslator.FromHtml("#69C669");
        Color lightBlue = (Color)ColorTranslator.FromHtml("#3399ff");

        public Form1()
        {
            InitializeComponent();
        }

        #region Events
        private void Form1_Load(object sender, System.EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int rowNumber = (i) / 10 + 1;
                int columnNumber = i % 10 + 1;

                memoryGroup.Controls.Add(SmartLMC.Forms.CreateLabel("memoryTitle" + i, i.ToString("00"), new int[2] { columnNumber * 38 - 20, rowNumber * 48 - 20 }));
                memoryGroup.Controls.Add(SmartLMC.Forms.CreateTextBox("memoryValue" + i, "000", new int[2] { columnNumber * 38 - 25, rowNumber * 48 - 2 }));
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
            accumulatorBox.Text = "0";
            counterBox.Text = "0";
            memAddressBox.Text = "00";
            memDataBox.Text = "000";
            inputBox.Value = 0;
            outputBox.Text = "";

            sourceCode = sourceTextBox.Text;
            currCode = new Code(sourceCode);

            stepsTable.CurrentCellChanged -= stepsTable_CurrentCellChanged;
            highlightImportant(0, true);

            compileButton.Text = "Compiling...";
            if (currCode.Compile())
            {
                editButton.Enabled = true;
                sourceGroup.Enabled = false;
                programGroup.Enabled = true;

                compileButton.Text = "Recompile ->";

                applyMemory(0);
                applyProgram(programTable, SmartLMC.Forms.createProgramTable());
                programTable.Visible = true;

                RunStatus = currCode.Run(0);
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
                sourceTextBox.Select(currCode.ErrorSelection[0], currCode.ErrorSelection[1]);
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
            accumulatorBox.Text = currCode.Steps[selectedIndex].Accumulator.ToString();
            outputBox.Text = currCode.getOutput(selectedIndex);
            counterBox.Text = selectedIndex.ToString();

            int lineNumber = currCode.Steps[selectedIndex].LineNumber;

            if (Instruction.Instructions[currCode.Lines[lineNumber].Instruction] != "DAT")
            {
                memAddressBox.Text = lineNumber.ToString("00");
                memDataBox.Text = currCode.Memory[lineNumber].ToString("000");
            }
            
            programTable.Rows[currCode.Steps[selectedIndex].LineNumber].Selected = true;

            highlightImportant(selectedIndex, false);
            changeSelectedLabel();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendButton.Enabled = false;

            if (RunStatus != 0)
            {
                currCode.Steps[RunStatus - 1].Accumulator = Convert.ToInt32(inputBox.Value);
                RunStatus = currCode.Run(RunStatus);
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

            sourceTextBox.Text = String.Join("\n", sourceText) + (!lastEmpty ? ("\r\n" + currCommand) : "");
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
            accumulatorBox.Text = currCode.Steps.Count != 0 ? currCode.Steps[currCode.Steps.Count - 1].Accumulator.ToString() : "0";
        }

        void applyMemory(int stepNumber)
        {
            int[] currMem = currCode.getMemoryFromChanges(stepNumber);
            for (int i = 0; i < currCode.Memory.Length; i++)
            {
                Control currMemLabel = this.Controls.Find("memoryValue" + i, true)[0];
                if (currMemLabel.Text != currMem[i].ToString("000"))
                {
                    currMemLabel.Text = currMem[i].ToString("000");
                }
            }
        }

        public void afterRun()
        {
            programTable.CurrentCell = programTable.Rows[programTable.Rows.Count - 1].Cells[0];

            applyProgram(stepsTable, SmartLMC.Forms.createStepsTable());
            stepsTable.CurrentCellChanged += stepsTable_CurrentCellChanged;

            applyMemory(stepsTable.CurrentCell.RowIndex);
            stepsTable.CurrentCell = stepsTable.Rows[currCode.Steps.Count - 1].Cells[0];
            outputBox.Text = currCode.getOutput(stepsTable.CurrentCell.RowIndex);

            changeSelectedLabel();
            highlightImportant(currCode.Steps.Count - 1, false);
            checkForInactiveRows();
        }

        public void getInput(int stepNumber)
        {
            applyProgram(stepsTable, SmartLMC.Forms.createStepsTable());
            stepsTable.CurrentCell = stepsTable.Rows[currCode.Steps.Count - 1].Cells[0];
            programTable.CurrentCell = programTable.Rows[currCode.Steps[currCode.Steps.Count - 1].LineNumber].Cells[0];
            changeSelectedLabel();

            MessageBox.Show("Please write in a number for \"INP\" instruction (on line " + stepNumber + ") to the input box below.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            inputBox.Enabled = true;
            sendButton.Enabled = true;
            inputBox.Focus();
        }

        void changeSelectedLabel()
        {
            if (stepsTable.CurrentCell != null)
            {
                int currSelectedRow = currCode.Steps[stepsTable.CurrentCell.RowIndex].LineNumber;

                Control previousLabel = this.Controls.Find("memoryTitle" + selectedRow, true)[0];
                Control previousTextBox = this.Controls.Find("memoryValue" + selectedRow, true)[0];
                Control currLabel = this.Controls.Find("memoryTitle" + currSelectedRow, true)[0];
                Control currTextBox = this.Controls.Find("memoryValue" + currSelectedRow, true)[0];

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
                Line currLine = currCode.Lines[currCode.Steps[selectedIndex].LineNumber];
                string currInstruction = Instruction.Instructions[currLine.Instruction];

                if (currInstruction == "INP")
                {
                    inputBox.BackColor = lightYellow;
                    inputBox.Font = new Font(inputBox.Font, FontStyle.Bold);

                    inputBox.Value = currCode.Steps[selectedIndex].Accumulator;
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
                if (currCode.Steps[selectedIndex].MemoryChange != null)
                {
                    Control currMemoryBox = this.Controls.Find("memoryValue" + currCode.Steps[selectedIndex].MemoryChange[0], true)[0];
                    highlightedMemoryBoxes.Add(currMemoryBox);

                    currMemoryBox.BackColor = lightRed;
                    currMemoryBox.Font = new Font(currMemoryBox.Font, FontStyle.Bold);
                }

                // Output
                if ((selectedIndex == 0 && currCode.Steps[selectedIndex].Output != null) || (selectedIndex != 0 && currCode.getOutput(selectedIndex) != currCode.getOutput(selectedIndex - 1)))
                {
                    outputBox.BackColor = lightRed;
                    outputBox.Font = new Font(outputBox.Font, FontStyle.Bold);
                }

                // Branching & Others
                MemoryAllocation currTarget = currLine.Target;
                if (currTarget != null)
                {
                    Control currMemoryBox = this.Controls.Find("memoryValue" + currTarget.Address, true)[0];

                    if (currInstruction == "BRA" || currInstruction == "BRZ" || currInstruction == "BRP")
                    {
                        Control currControl = Controls.Find("memoryValue" + currCode.Steps[selectedIndex].LineNumber, true)[0];
                        highlightedMemoryBoxes.Add(currControl);

                        currControl.BackColor = lightYellow;

                        if (currCode.Steps[selectedIndex + 1].LineNumber == currLine.Target.Address)
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
            for (int i = 0; i < currCode.Lines.Length; i++)
            {
                bool isFound = false;
                foreach (Step currStep in Form1.currCode.Steps)
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
        #endregion
    }
}
