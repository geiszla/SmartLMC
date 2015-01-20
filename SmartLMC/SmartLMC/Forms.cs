using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SmartLMC.SmartLMC
{
    class Forms
    {
        public static Label CreateLabel(string name, string text, int[] position)
        {
            Label newLabel = new Label();
            newLabel.Name = name;
            newLabel.Text = text;

            newLabel.Left = position[0];
            newLabel.Top = position[1];
            newLabel.AutoSize = true;

            return newLabel;
        }

        public static TextBox CreateTextBox(string name, string text, int[] position)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Name = name;
            newTextBox.Text = text;

            newTextBox.Left = position[0];
            newTextBox.Top = position[1];
            newTextBox.Width = 30;
            newTextBox.ReadOnly = true;
            newTextBox.TextAlign = HorizontalAlignment.Center;

            return newTextBox;
        }

        public static DataTable createProgramTable()
        {
            DataTable programTable = new DataTable();
            programTable.Columns.Add("#", typeof(string));
            programTable.Columns.Add("Code", typeof(string));

            for (int i = 0; i < Form1.currCode.Lines.Length; i++)
            {
                programTable.Rows.Add(i.ToString("00"), Form1.currCode.Lines[i].Text);
            }

            return programTable;
        }

        public static DataTable createStepsTable()
        {
            DataTable programTable = new DataTable();
            programTable.Columns.Add("#", typeof(string));
            programTable.Columns.Add("Line", typeof(string));
            programTable.Columns.Add("Code", typeof(string));

            for (int i = 0; i < Form1.currCode.Steps.Count; i++)
            {
                programTable.Rows.Add(i.ToString("00"), Form1.currCode.Steps[i].LineNumber.ToString("00"), Form1.currCode.Lines[Form1.currCode.Steps[i].LineNumber].Text);
            }

            return programTable;
        }
    }
}
