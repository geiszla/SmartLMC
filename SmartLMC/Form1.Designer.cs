namespace SmartLMC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.memoryGroup = new System.Windows.Forms.GroupBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.memoryCommandGroup = new System.Windows.Forms.GroupBox();
            this.datCommandButton = new System.Windows.Forms.Button();
            this.hltCommandButton = new System.Windows.Forms.Button();
            this.ldaCommandButton = new System.Windows.Forms.Button();
            this.staCommandButton = new System.Windows.Forms.Button();
            this.addCommandButton = new System.Windows.Forms.Button();
            this.subCommandButton = new System.Windows.Forms.Button();
            this.outCommandButton = new System.Windows.Forms.Button();
            this.brpCommandButton = new System.Windows.Forms.Button();
            this.inpCommandButton = new System.Windows.Forms.Button();
            this.braCommandButton = new System.Windows.Forms.Button();
            this.brzCommandButton = new System.Windows.Forms.Button();
            this.branchingCommandGroup = new System.Windows.Forms.GroupBox();
            this.ioCommandGroup = new System.Windows.Forms.GroupBox();
            this.compileButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.mathCommandGroup = new System.Windows.Forms.GroupBox();
            this.sourceGroup = new System.Windows.Forms.GroupBox();
            this.programTable = new System.Windows.Forms.DataGridView();
            this.exampleButton = new System.Windows.Forms.Button();
            this.programGroup = new System.Windows.Forms.GroupBox();
            this.stepsBox = new System.Windows.Forms.GroupBox();
            this.stepsTable = new System.Windows.Forms.DataGridView();
            this.ioGroup = new System.Windows.Forms.GroupBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.outputTitle = new System.Windows.Forms.Label();
            this.inputTitle = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.NumericUpDown();
            this.registersGroup = new System.Windows.Forms.GroupBox();
            this.memAddressBox = new System.Windows.Forms.TextBox();
            this.memDataBox = new System.Windows.Forms.TextBox();
            this.memDataTitle = new System.Windows.Forms.Label();
            this.memAddressTitle = new System.Windows.Forms.Label();
            this.accumulatorBox = new System.Windows.Forms.TextBox();
            this.counterBox = new System.Windows.Forms.TextBox();
            this.counterLabel = new System.Windows.Forms.Label();
            this.accumulatorTitle = new System.Windows.Forms.Label();
            this.modifiedColorBox = new System.Windows.Forms.TextBox();
            this.sourceColorBox = new System.Windows.Forms.TextBox();
            this.targetColorBox = new System.Windows.Forms.TextBox();
            this.colorsGroup = new System.Windows.Forms.GroupBox();
            this.selectionColorBox = new System.Windows.Forms.TextBox();
            this.memoryCommandGroup.SuspendLayout();
            this.branchingCommandGroup.SuspendLayout();
            this.ioCommandGroup.SuspendLayout();
            this.mathCommandGroup.SuspendLayout();
            this.sourceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programTable)).BeginInit();
            this.programGroup.SuspendLayout();
            this.stepsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepsTable)).BeginInit();
            this.ioGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputBox)).BeginInit();
            this.registersGroup.SuspendLayout();
            this.colorsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryGroup
            // 
            this.memoryGroup.Location = new System.Drawing.Point(275, 19);
            this.memoryGroup.Name = "memoryGroup";
            this.memoryGroup.Size = new System.Drawing.Size(406, 521);
            this.memoryGroup.TabIndex = 2;
            this.memoryGroup.TabStop = false;
            this.memoryGroup.Text = "Memory";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceTextBox.Location = new System.Drawing.Point(6, 19);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceTextBox.Size = new System.Drawing.Size(242, 521);
            this.sourceTextBox.TabIndex = 0;
            this.sourceTextBox.TextChanged += new System.EventHandler(this.sourceTextBox_TextChanged);
            // 
            // memoryCommandGroup
            // 
            this.memoryCommandGroup.Controls.Add(this.datCommandButton);
            this.memoryCommandGroup.Controls.Add(this.hltCommandButton);
            this.memoryCommandGroup.Controls.Add(this.ldaCommandButton);
            this.memoryCommandGroup.Controls.Add(this.staCommandButton);
            this.memoryCommandGroup.Location = new System.Drawing.Point(254, 19);
            this.memoryCommandGroup.Name = "memoryCommandGroup";
            this.memoryCommandGroup.Size = new System.Drawing.Size(92, 144);
            this.memoryCommandGroup.TabIndex = 4;
            this.memoryCommandGroup.TabStop = false;
            this.memoryCommandGroup.Text = "Memory";
            // 
            // datCommandButton
            // 
            this.datCommandButton.Location = new System.Drawing.Point(7, 106);
            this.datCommandButton.Name = "datCommandButton";
            this.datCommandButton.Size = new System.Drawing.Size(75, 23);
            this.datCommandButton.TabIndex = 5;
            this.datCommandButton.Text = "DAT";
            this.datCommandButton.UseVisualStyleBackColor = true;
            this.datCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // hltCommandButton
            // 
            this.hltCommandButton.Location = new System.Drawing.Point(7, 77);
            this.hltCommandButton.Name = "hltCommandButton";
            this.hltCommandButton.Size = new System.Drawing.Size(75, 23);
            this.hltCommandButton.TabIndex = 4;
            this.hltCommandButton.Text = "HLT";
            this.hltCommandButton.UseVisualStyleBackColor = true;
            this.hltCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // ldaCommandButton
            // 
            this.ldaCommandButton.Location = new System.Drawing.Point(7, 48);
            this.ldaCommandButton.Name = "ldaCommandButton";
            this.ldaCommandButton.Size = new System.Drawing.Size(75, 23);
            this.ldaCommandButton.TabIndex = 3;
            this.ldaCommandButton.Text = "LDA";
            this.ldaCommandButton.UseVisualStyleBackColor = true;
            this.ldaCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // staCommandButton
            // 
            this.staCommandButton.Location = new System.Drawing.Point(7, 19);
            this.staCommandButton.Name = "staCommandButton";
            this.staCommandButton.Size = new System.Drawing.Size(75, 23);
            this.staCommandButton.TabIndex = 2;
            this.staCommandButton.Text = "STA";
            this.staCommandButton.UseVisualStyleBackColor = true;
            this.staCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // addCommandButton
            // 
            this.addCommandButton.Location = new System.Drawing.Point(6, 19);
            this.addCommandButton.Name = "addCommandButton";
            this.addCommandButton.Size = new System.Drawing.Size(75, 23);
            this.addCommandButton.TabIndex = 0;
            this.addCommandButton.Text = "ADD";
            this.addCommandButton.UseVisualStyleBackColor = true;
            this.addCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // subCommandButton
            // 
            this.subCommandButton.Location = new System.Drawing.Point(6, 48);
            this.subCommandButton.Name = "subCommandButton";
            this.subCommandButton.Size = new System.Drawing.Size(75, 23);
            this.subCommandButton.TabIndex = 1;
            this.subCommandButton.Text = "SUB";
            this.subCommandButton.UseVisualStyleBackColor = true;
            this.subCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // outCommandButton
            // 
            this.outCommandButton.Location = new System.Drawing.Point(6, 48);
            this.outCommandButton.Name = "outCommandButton";
            this.outCommandButton.Size = new System.Drawing.Size(75, 23);
            this.outCommandButton.TabIndex = 6;
            this.outCommandButton.Text = "OUT";
            this.outCommandButton.UseVisualStyleBackColor = true;
            this.outCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // brpCommandButton
            // 
            this.brpCommandButton.Location = new System.Drawing.Point(6, 79);
            this.brpCommandButton.Name = "brpCommandButton";
            this.brpCommandButton.Size = new System.Drawing.Size(75, 23);
            this.brpCommandButton.TabIndex = 7;
            this.brpCommandButton.Text = "BRP";
            this.brpCommandButton.UseVisualStyleBackColor = true;
            this.brpCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // inpCommandButton
            // 
            this.inpCommandButton.Location = new System.Drawing.Point(6, 19);
            this.inpCommandButton.Name = "inpCommandButton";
            this.inpCommandButton.Size = new System.Drawing.Size(75, 23);
            this.inpCommandButton.TabIndex = 8;
            this.inpCommandButton.Text = "INP";
            this.inpCommandButton.UseVisualStyleBackColor = true;
            this.inpCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // braCommandButton
            // 
            this.braCommandButton.Location = new System.Drawing.Point(6, 21);
            this.braCommandButton.Name = "braCommandButton";
            this.braCommandButton.Size = new System.Drawing.Size(75, 23);
            this.braCommandButton.TabIndex = 9;
            this.braCommandButton.Text = "BRA";
            this.braCommandButton.UseVisualStyleBackColor = true;
            this.braCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // brzCommandButton
            // 
            this.brzCommandButton.Location = new System.Drawing.Point(6, 50);
            this.brzCommandButton.Name = "brzCommandButton";
            this.brzCommandButton.Size = new System.Drawing.Size(75, 23);
            this.brzCommandButton.TabIndex = 10;
            this.brzCommandButton.Text = "BRZ";
            this.brzCommandButton.UseVisualStyleBackColor = true;
            this.brzCommandButton.Click += new System.EventHandler(this.insertCommand);
            // 
            // branchingCommandGroup
            // 
            this.branchingCommandGroup.Controls.Add(this.braCommandButton);
            this.branchingCommandGroup.Controls.Add(this.brpCommandButton);
            this.branchingCommandGroup.Controls.Add(this.brzCommandButton);
            this.branchingCommandGroup.Location = new System.Drawing.Point(254, 256);
            this.branchingCommandGroup.Name = "branchingCommandGroup";
            this.branchingCommandGroup.Size = new System.Drawing.Size(88, 113);
            this.branchingCommandGroup.TabIndex = 11;
            this.branchingCommandGroup.TabStop = false;
            this.branchingCommandGroup.Text = "Branching";
            // 
            // ioCommandGroup
            // 
            this.ioCommandGroup.Controls.Add(this.inpCommandButton);
            this.ioCommandGroup.Controls.Add(this.outCommandButton);
            this.ioCommandGroup.Location = new System.Drawing.Point(254, 375);
            this.ioCommandGroup.Name = "ioCommandGroup";
            this.ioCommandGroup.Size = new System.Drawing.Size(89, 84);
            this.ioCommandGroup.TabIndex = 12;
            this.ioCommandGroup.TabStop = false;
            this.ioCommandGroup.Text = "I/O";
            // 
            // compileButton
            // 
            this.compileButton.Enabled = false;
            this.compileButton.Location = new System.Drawing.Point(368, 229);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(119, 23);
            this.compileButton.TabIndex = 7;
            this.compileButton.Text = "Compile ->";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(368, 268);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(119, 23);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "<- Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // mathCommandGroup
            // 
            this.mathCommandGroup.Controls.Add(this.subCommandButton);
            this.mathCommandGroup.Controls.Add(this.addCommandButton);
            this.mathCommandGroup.Location = new System.Drawing.Point(254, 169);
            this.mathCommandGroup.Name = "mathCommandGroup";
            this.mathCommandGroup.Size = new System.Drawing.Size(91, 81);
            this.mathCommandGroup.TabIndex = 6;
            this.mathCommandGroup.TabStop = false;
            this.mathCommandGroup.Text = "Math";
            // 
            // sourceGroup
            // 
            this.sourceGroup.Controls.Add(this.programTable);
            this.sourceGroup.Controls.Add(this.exampleButton);
            this.sourceGroup.Controls.Add(this.sourceTextBox);
            this.sourceGroup.Controls.Add(this.memoryCommandGroup);
            this.sourceGroup.Controls.Add(this.mathCommandGroup);
            this.sourceGroup.Controls.Add(this.branchingCommandGroup);
            this.sourceGroup.Controls.Add(this.ioCommandGroup);
            this.sourceGroup.Location = new System.Drawing.Point(12, 12);
            this.sourceGroup.Name = "sourceGroup";
            this.sourceGroup.Size = new System.Drawing.Size(350, 551);
            this.sourceGroup.TabIndex = 13;
            this.sourceGroup.TabStop = false;
            this.sourceGroup.Text = "Source Code";
            // 
            // programTable
            // 
            this.programTable.AllowUserToAddRows = false;
            this.programTable.AllowUserToDeleteRows = false;
            this.programTable.AllowUserToResizeColumns = false;
            this.programTable.AllowUserToResizeRows = false;
            this.programTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.programTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.programTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.programTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.programTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.programTable.Location = new System.Drawing.Point(6, 20);
            this.programTable.MultiSelect = false;
            this.programTable.Name = "programTable";
            this.programTable.ReadOnly = true;
            this.programTable.RowHeadersVisible = false;
            this.programTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.programTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.programTable.Size = new System.Drawing.Size(242, 520);
            this.programTable.TabIndex = 6;
            this.programTable.Visible = false;
            // 
            // exampleButton
            // 
            this.exampleButton.Location = new System.Drawing.Point(254, 490);
            this.exampleButton.Name = "exampleButton";
            this.exampleButton.Size = new System.Drawing.Size(88, 23);
            this.exampleButton.TabIndex = 13;
            this.exampleButton.Text = "Example";
            this.exampleButton.UseVisualStyleBackColor = true;
            this.exampleButton.Click += new System.EventHandler(this.exampleButton_Click);
            // 
            // programGroup
            // 
            this.programGroup.Controls.Add(this.stepsBox);
            this.programGroup.Controls.Add(this.ioGroup);
            this.programGroup.Controls.Add(this.registersGroup);
            this.programGroup.Controls.Add(this.memoryGroup);
            this.programGroup.Enabled = false;
            this.programGroup.Location = new System.Drawing.Point(493, 12);
            this.programGroup.Name = "programGroup";
            this.programGroup.Size = new System.Drawing.Size(687, 551);
            this.programGroup.TabIndex = 14;
            this.programGroup.TabStop = false;
            this.programGroup.Text = "Program";
            // 
            // stepsBox
            // 
            this.stepsBox.Controls.Add(this.stepsTable);
            this.stepsBox.Location = new System.Drawing.Point(7, 154);
            this.stepsBox.Name = "stepsBox";
            this.stepsBox.Size = new System.Drawing.Size(262, 263);
            this.stepsBox.TabIndex = 15;
            this.stepsBox.TabStop = false;
            this.stepsBox.Text = "Steps";
            // 
            // stepsTable
            // 
            this.stepsTable.AllowUserToAddRows = false;
            this.stepsTable.AllowUserToDeleteRows = false;
            this.stepsTable.AllowUserToResizeRows = false;
            this.stepsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stepsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stepsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.stepsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stepsTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.stepsTable.Location = new System.Drawing.Point(6, 19);
            this.stepsTable.MultiSelect = false;
            this.stepsTable.Name = "stepsTable";
            this.stepsTable.ReadOnly = true;
            this.stepsTable.RowHeadersVisible = false;
            this.stepsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.stepsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stepsTable.Size = new System.Drawing.Size(250, 238);
            this.stepsTable.TabIndex = 14;
            // 
            // ioGroup
            // 
            this.ioGroup.Controls.Add(this.sendButton);
            this.ioGroup.Controls.Add(this.outputBox);
            this.ioGroup.Controls.Add(this.outputTitle);
            this.ioGroup.Controls.Add(this.inputTitle);
            this.ioGroup.Controls.Add(this.inputBox);
            this.ioGroup.Location = new System.Drawing.Point(7, 423);
            this.ioGroup.Name = "ioGroup";
            this.ioGroup.Size = new System.Drawing.Size(262, 117);
            this.ioGroup.TabIndex = 5;
            this.ioGroup.TabStop = false;
            this.ioGroup.Text = "I/O";
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(26, 71);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(121, 32);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(135, 79);
            this.outputBox.TabIndex = 3;
            // 
            // outputTitle
            // 
            this.outputTitle.AutoSize = true;
            this.outputTitle.Location = new System.Drawing.Point(166, 16);
            this.outputTitle.Name = "outputTitle";
            this.outputTitle.Size = new System.Drawing.Size(39, 13);
            this.outputTitle.TabIndex = 2;
            this.outputTitle.Text = "Output";
            // 
            // inputTitle
            // 
            this.inputTitle.AutoSize = true;
            this.inputTitle.Location = new System.Drawing.Point(48, 16);
            this.inputTitle.Name = "inputTitle";
            this.inputTitle.Size = new System.Drawing.Size(31, 13);
            this.inputTitle.TabIndex = 1;
            this.inputTitle.Text = "Input";
            // 
            // inputBox
            // 
            this.inputBox.Enabled = false;
            this.inputBox.Location = new System.Drawing.Point(20, 45);
            this.inputBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.inputBox.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(88, 20);
            this.inputBox.TabIndex = 0;
            // 
            // registersGroup
            // 
            this.registersGroup.Controls.Add(this.memAddressBox);
            this.registersGroup.Controls.Add(this.memDataBox);
            this.registersGroup.Controls.Add(this.memDataTitle);
            this.registersGroup.Controls.Add(this.memAddressTitle);
            this.registersGroup.Controls.Add(this.accumulatorBox);
            this.registersGroup.Controls.Add(this.counterBox);
            this.registersGroup.Controls.Add(this.counterLabel);
            this.registersGroup.Controls.Add(this.accumulatorTitle);
            this.registersGroup.Location = new System.Drawing.Point(7, 20);
            this.registersGroup.Name = "registersGroup";
            this.registersGroup.Size = new System.Drawing.Size(262, 128);
            this.registersGroup.TabIndex = 4;
            this.registersGroup.TabStop = false;
            this.registersGroup.Text = "Registers";
            // 
            // memAddressBox
            // 
            this.memAddressBox.Location = new System.Drawing.Point(31, 96);
            this.memAddressBox.Name = "memAddressBox";
            this.memAddressBox.ReadOnly = true;
            this.memAddressBox.Size = new System.Drawing.Size(66, 20);
            this.memAddressBox.TabIndex = 7;
            this.memAddressBox.Text = "00";
            this.memAddressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // memDataBox
            // 
            this.memDataBox.Location = new System.Drawing.Point(145, 96);
            this.memDataBox.Name = "memDataBox";
            this.memDataBox.ReadOnly = true;
            this.memDataBox.Size = new System.Drawing.Size(86, 20);
            this.memDataBox.TabIndex = 6;
            this.memDataBox.Text = "000";
            this.memDataBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // memDataTitle
            // 
            this.memDataTitle.AutoSize = true;
            this.memDataTitle.Location = new System.Drawing.Point(152, 80);
            this.memDataTitle.Name = "memDataTitle";
            this.memDataTitle.Size = new System.Drawing.Size(70, 13);
            this.memDataTitle.TabIndex = 5;
            this.memDataTitle.Text = "Memory Data";
            // 
            // memAddressTitle
            // 
            this.memAddressTitle.AutoSize = true;
            this.memAddressTitle.Location = new System.Drawing.Point(23, 80);
            this.memAddressTitle.Name = "memAddressTitle";
            this.memAddressTitle.Size = new System.Drawing.Size(85, 13);
            this.memAddressTitle.TabIndex = 4;
            this.memAddressTitle.Text = "Memory Address";
            // 
            // accumulatorBox
            // 
            this.accumulatorBox.Location = new System.Drawing.Point(31, 38);
            this.accumulatorBox.Name = "accumulatorBox";
            this.accumulatorBox.ReadOnly = true;
            this.accumulatorBox.Size = new System.Drawing.Size(66, 20);
            this.accumulatorBox.TabIndex = 3;
            this.accumulatorBox.Text = "0";
            this.accumulatorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // counterBox
            // 
            this.counterBox.Location = new System.Drawing.Point(145, 38);
            this.counterBox.Name = "counterBox";
            this.counterBox.ReadOnly = true;
            this.counterBox.Size = new System.Drawing.Size(86, 20);
            this.counterBox.TabIndex = 2;
            this.counterBox.Text = "0";
            this.counterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Location = new System.Drawing.Point(143, 22);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(86, 13);
            this.counterLabel.TabIndex = 1;
            this.counterLabel.Text = "Program Counter";
            // 
            // accumulatorTitle
            // 
            this.accumulatorTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.accumulatorTitle.AutoSize = true;
            this.accumulatorTitle.Location = new System.Drawing.Point(31, 22);
            this.accumulatorTitle.Name = "accumulatorTitle";
            this.accumulatorTitle.Size = new System.Drawing.Size(66, 13);
            this.accumulatorTitle.TabIndex = 0;
            this.accumulatorTitle.Text = "Accumulator";
            // 
            // modifiedColorBox
            // 
            this.modifiedColorBox.Location = new System.Drawing.Point(6, 45);
            this.modifiedColorBox.Name = "modifiedColorBox";
            this.modifiedColorBox.ReadOnly = true;
            this.modifiedColorBox.Size = new System.Drawing.Size(87, 20);
            this.modifiedColorBox.TabIndex = 11;
            this.modifiedColorBox.Text = "Modified";
            this.modifiedColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sourceColorBox
            // 
            this.sourceColorBox.Location = new System.Drawing.Point(6, 71);
            this.sourceColorBox.Name = "sourceColorBox";
            this.sourceColorBox.ReadOnly = true;
            this.sourceColorBox.Size = new System.Drawing.Size(87, 20);
            this.sourceColorBox.TabIndex = 15;
            this.sourceColorBox.Text = "Source";
            this.sourceColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // targetColorBox
            // 
            this.targetColorBox.Location = new System.Drawing.Point(6, 97);
            this.targetColorBox.Name = "targetColorBox";
            this.targetColorBox.ReadOnly = true;
            this.targetColorBox.Size = new System.Drawing.Size(87, 20);
            this.targetColorBox.TabIndex = 16;
            this.targetColorBox.Text = "Target";
            this.targetColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colorsGroup
            // 
            this.colorsGroup.Controls.Add(this.selectionColorBox);
            this.colorsGroup.Controls.Add(this.modifiedColorBox);
            this.colorsGroup.Controls.Add(this.targetColorBox);
            this.colorsGroup.Controls.Add(this.sourceColorBox);
            this.colorsGroup.Location = new System.Drawing.Point(376, 329);
            this.colorsGroup.Name = "colorsGroup";
            this.colorsGroup.Size = new System.Drawing.Size(101, 127);
            this.colorsGroup.TabIndex = 17;
            this.colorsGroup.TabStop = false;
            this.colorsGroup.Text = "Colors";
            // 
            // selectionColorBox
            // 
            this.selectionColorBox.ForeColor = System.Drawing.Color.White;
            this.selectionColorBox.Location = new System.Drawing.Point(6, 19);
            this.selectionColorBox.Name = "selectionColorBox";
            this.selectionColorBox.ReadOnly = true;
            this.selectionColorBox.Size = new System.Drawing.Size(87, 20);
            this.selectionColorBox.TabIndex = 17;
            this.selectionColorBox.Text = "Selection";
            this.selectionColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 574);
            this.Controls.Add(this.colorsGroup);
            this.Controls.Add(this.programGroup);
            this.Controls.Add(this.sourceGroup);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.compileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart LMC Compiler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.memoryCommandGroup.ResumeLayout(false);
            this.branchingCommandGroup.ResumeLayout(false);
            this.ioCommandGroup.ResumeLayout(false);
            this.mathCommandGroup.ResumeLayout(false);
            this.sourceGroup.ResumeLayout(false);
            this.sourceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programTable)).EndInit();
            this.programGroup.ResumeLayout(false);
            this.stepsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepsTable)).EndInit();
            this.ioGroup.ResumeLayout(false);
            this.ioGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputBox)).EndInit();
            this.registersGroup.ResumeLayout(false);
            this.registersGroup.PerformLayout();
            this.colorsGroup.ResumeLayout(false);
            this.colorsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox memoryGroup;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.GroupBox memoryCommandGroup;
        private System.Windows.Forms.Button datCommandButton;
        private System.Windows.Forms.Button hltCommandButton;
        private System.Windows.Forms.Button ldaCommandButton;
        private System.Windows.Forms.Button staCommandButton;
        private System.Windows.Forms.Button addCommandButton;
        private System.Windows.Forms.Button subCommandButton;
        private System.Windows.Forms.Button outCommandButton;
        private System.Windows.Forms.Button brpCommandButton;
        private System.Windows.Forms.Button inpCommandButton;
        private System.Windows.Forms.Button braCommandButton;
        private System.Windows.Forms.Button brzCommandButton;
        private System.Windows.Forms.GroupBox branchingCommandGroup;
        private System.Windows.Forms.GroupBox ioCommandGroup;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.GroupBox mathCommandGroup;
        private System.Windows.Forms.GroupBox sourceGroup;
        private System.Windows.Forms.GroupBox programGroup;
        private System.Windows.Forms.GroupBox registersGroup;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.Label accumulatorTitle;
        private System.Windows.Forms.TextBox memAddressBox;
        private System.Windows.Forms.TextBox memDataBox;
        private System.Windows.Forms.Label memDataTitle;
        private System.Windows.Forms.Label memAddressTitle;
        private System.Windows.Forms.TextBox accumulatorBox;
        private System.Windows.Forms.TextBox counterBox;
        private System.Windows.Forms.Button exampleButton;
        private System.Windows.Forms.GroupBox ioGroup;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label outputTitle;
        private System.Windows.Forms.Label inputTitle;
        private System.Windows.Forms.NumericUpDown inputBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridView programTable;
        private System.Windows.Forms.DataGridView stepsTable;
        private System.Windows.Forms.GroupBox stepsBox;
        private System.Windows.Forms.TextBox modifiedColorBox;
        private System.Windows.Forms.TextBox sourceColorBox;
        private System.Windows.Forms.TextBox targetColorBox;
        private System.Windows.Forms.GroupBox colorsGroup;
        private System.Windows.Forms.TextBox selectionColorBox;
    }
}

