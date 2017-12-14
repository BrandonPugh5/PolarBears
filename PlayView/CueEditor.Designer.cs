namespace PolarBearsProgram
{
    partial class Cue_Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Create_cue = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.Pause_10 = new System.Windows.Forms.CheckBox();
            this.textBoxCW = new System.Windows.Forms.TextBox();
            this.textBoxAccel = new System.Windows.Forms.TextBox();
            this.textBoxVel = new System.Windows.Forms.TextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.Created_Cues = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.EStop = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAccelDecelTime = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBoxAccel = new System.Windows.Forms.ComboBox();
            this.comboBoxCW = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMovement = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PLCCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PauseCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RotationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccelerationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_decel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(329, 22);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(602, 33);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Welcome to the Cue Editor! Here you may build and edit cues.";
            // 
            // Create_cue
            // 
            this.Create_cue.Location = new System.Drawing.Point(24, 492);
            this.Create_cue.Margin = new System.Windows.Forms.Padding(2);
            this.Create_cue.Name = "Create_cue";
            this.Create_cue.Size = new System.Drawing.Size(82, 29);
            this.Create_cue.TabIndex = 2;
            this.Create_cue.Text = "Create New";
            this.Create_cue.UseVisualStyleBackColor = true;
            this.Create_cue.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(479, 423);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(88, 17);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "Motor";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Enabled = false;
            this.richTextBox3.Location = new System.Drawing.Point(579, 423);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox3.Size = new System.Drawing.Size(88, 17);
            this.richTextBox3.TabIndex = 16;
            this.richTextBox3.Text = "Pause";
            // 
            // Pause_10
            // 
            this.Pause_10.AutoSize = true;
            this.Pause_10.Location = new System.Drawing.Point(588, 450);
            this.Pause_10.Margin = new System.Windows.Forms.Padding(2);
            this.Pause_10.Name = "Pause_10";
            this.Pause_10.Size = new System.Drawing.Size(15, 14);
            this.Pause_10.TabIndex = 26;
            this.Pause_10.UseVisualStyleBackColor = true;
            this.Pause_10.CheckedChanged += new System.EventHandler(this.Pause_10_CheckedChanged);
            // 
            // textBoxCW
            // 
            this.textBoxCW.Location = new System.Drawing.Point(619, 444);
            this.textBoxCW.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCW.Name = "textBoxCW";
            this.textBoxCW.Size = new System.Drawing.Size(53, 20);
            this.textBoxCW.TabIndex = 37;
            // 
            // textBoxAccel
            // 
            this.textBoxAccel.Location = new System.Drawing.Point(744, 445);
            this.textBoxAccel.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAccel.Name = "textBoxAccel";
            this.textBoxAccel.Size = new System.Drawing.Size(53, 20);
            this.textBoxAccel.TabIndex = 48;
            this.textBoxAccel.TextChanged += new System.EventHandler(this.textBoxAccel_TextChanged);
            // 
            // textBoxVel
            // 
            this.textBoxVel.Location = new System.Drawing.Point(866, 444);
            this.textBoxVel.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxVel.Name = "textBoxVel";
            this.textBoxVel.Size = new System.Drawing.Size(53, 20);
            this.textBoxVel.TabIndex = 58;
            this.textBoxVel.TextChanged += new System.EventHandler(this.textBoxVel_TextChanged);
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Enabled = false;
            this.richTextBox6.Location = new System.Drawing.Point(865, 423);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox6.Size = new System.Drawing.Size(66, 17);
            this.richTextBox6.TabIndex = 59;
            this.richTextBox6.Text = "Velocity";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(659, 526);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 28);
            this.button2.TabIndex = 60;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox7
            // 
            this.richTextBox7.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox7.Enabled = false;
            this.richTextBox7.Location = new System.Drawing.Point(956, 423);
            this.richTextBox7.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox7.Size = new System.Drawing.Size(66, 17);
            this.richTextBox7.TabIndex = 61;
            this.richTextBox7.Text = "Time";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(954, 447);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(53, 20);
            this.textBoxTime.TabIndex = 71;
            // 
            // Created_Cues
            // 
            this.Created_Cues.FormattingEnabled = true;
            this.Created_Cues.Location = new System.Drawing.Point(13, 80);
            this.Created_Cues.Margin = new System.Windows.Forms.Padding(2);
            this.Created_Cues.Name = "Created_Cues";
            this.Created_Cues.Size = new System.Drawing.Size(185, 394);
            this.Created_Cues.TabIndex = 72;
            this.Created_Cues.SelectedIndexChanged += new System.EventHandler(this.Created_Cues_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PLCCol,
            this.MotorCol,
            this.PauseCol,
            this.Dir,
            this.RotationCol,
            this.AccelerationCol,
            this.column_decel,
            this.VelocityCol,
            this.TimeCol});
            this.dataGridView1.Location = new System.Drawing.Point(216, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(781, 336);
            this.dataGridView1.TabIndex = 73;
            // 
            // richTextBox8
            // 
            this.richTextBox8.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox8.Enabled = false;
            this.richTextBox8.Location = new System.Drawing.Point(396, 423);
            this.richTextBox8.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(50, 21);
            this.richTextBox8.TabIndex = 74;
            this.richTextBox8.Text = "PLC";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(750, 526);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
            this.button1.TabIndex = 77;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "deg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(802, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "m/s²";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(924, 450);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "m/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1012, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "sec";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(851, 526);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 28);
            this.button3.TabIndex = 83;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1006, 155);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 38);
            this.button4.TabIndex = 84;
            this.button4.Text = " ▲";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1006, 261);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 38);
            this.button5.TabIndex = 85;
            this.button5.Text = "▼";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(124, 492);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 29);
            this.button6.TabIndex = 86;
            this.button6.Text = "Delete Cue";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // EStop
            // 
            this.EStop.BackColor = System.Drawing.Color.DarkRed;
            this.EStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EStop.Location = new System.Drawing.Point(936, 502);
            this.EStop.Name = "EStop";
            this.EStop.Size = new System.Drawing.Size(75, 52);
            this.EStop.TabIndex = 87;
            this.EStop.Text = "Emergency Stop";
            this.EStop.UseVisualStyleBackColor = false;
            this.EStop.Click += new System.EventHandler(this.EStop_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(15, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 45);
            this.button7.TabIndex = 88;
            this.button7.Text = "Play View";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(157, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 45);
            this.button8.TabIndex = 89;
            this.button8.Text = "Motor Configuration";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(478, 442);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 91;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(396, 442);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(76, 21);
            this.comboBox2.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(746, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Accel/Decel Time";
            // 
            // textBoxAccelDecelTime
            // 
            this.textBoxAccelDecelTime.Enabled = false;
            this.textBoxAccelDecelTime.Location = new System.Drawing.Point(746, 493);
            this.textBoxAccelDecelTime.Name = "textBoxAccelDecelTime";
            this.textBoxAccelDecelTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxAccelDecelTime.TabIndex = 97;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(533, 530);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Current Rotation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "CurrentPosition";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(336, 531);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 101;
            // 
            // comboBoxAccel
            // 
            this.comboBoxAccel.AllowDrop = true;
            this.comboBoxAccel.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxAccel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBoxAccel.FormattingEnabled = true;
            this.comboBoxAccel.Items.AddRange(new object[] {
            "Acceleration",
            "Deceleration"});
            this.comboBoxAccel.Location = new System.Drawing.Point(744, 421);
            this.comboBoxAccel.MaxDropDownItems = 2;
            this.comboBoxAccel.Name = "comboBoxAccel";
            this.comboBoxAccel.Size = new System.Drawing.Size(95, 21);
            this.comboBoxAccel.TabIndex = 102;
            this.comboBoxAccel.Text = "Accel/Decel";
            // 
            // comboBoxCW
            // 
            this.comboBoxCW.FormattingEnabled = true;
            this.comboBoxCW.Items.AddRange(new object[] {
            "Clockwise",
            "Counter Clockwise"});
            this.comboBoxCW.Location = new System.Drawing.Point(619, 423);
            this.comboBoxCW.Name = "comboBoxCW";
            this.comboBoxCW.Size = new System.Drawing.Size(104, 21);
            this.comboBoxCW.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Desired Movement";
            // 
            // comboBoxMovement
            // 
            this.comboBoxMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMovement.FormattingEnabled = true;
            this.comboBoxMovement.Items.AddRange(new object[] {
            "Degrees by Velocity",
            "Velocity by Time"});
            this.comboBoxMovement.Location = new System.Drawing.Point(208, 441);
            this.comboBoxMovement.Name = "comboBoxMovement";
            this.comboBoxMovement.Size = new System.Drawing.Size(182, 21);
            this.comboBoxMovement.TabIndex = 105;
            this.comboBoxMovement.SelectedIndexChanged += new System.EventHandler(this.comboBoxMovement_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Meters",
            "Feet",
            "Inches"});
            this.comboBox3.Location = new System.Drawing.Point(533, 497);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 106;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(422, 500);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Unit of Measurement";
            // 
            // PLCCol
            // 
            this.PLCCol.HeaderText = "PLC";
            this.PLCCol.Name = "PLCCol";
            // 
            // MotorCol
            // 
            this.MotorCol.HeaderText = "Motor IP";
            this.MotorCol.Name = "MotorCol";
            // 
            // PauseCol
            // 
            this.PauseCol.HeaderText = "Pause";
            this.PauseCol.Name = "PauseCol";
            // 
            // Dir
            // 
            this.Dir.HeaderText = "Direction";
            this.Dir.Name = "Dir";
            // 
            // RotationCol
            // 
            this.RotationCol.HeaderText = "Rotation";
            this.RotationCol.Name = "RotationCol";
            // 
            // AccelerationCol
            // 
            this.AccelerationCol.HeaderText = "Acceleration";
            this.AccelerationCol.Name = "AccelerationCol";
            // 
            // column_decel
            // 
            this.column_decel.HeaderText = "Deceleration";
            this.column_decel.Name = "column_decel";
            // 
            // VelocityCol
            // 
            this.VelocityCol.HeaderText = "Velocity";
            this.VelocityCol.Name = "VelocityCol";
            // 
            // TimeCol
            // 
            this.TimeCol.HeaderText = "Time";
            this.TimeCol.Name = "TimeCol";
            // 
            // Cue_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1060, 581);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBoxMovement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCW);
            this.Controls.Add(this.comboBoxAccel);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBoxAccelDecelTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.EStop);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Created_Cues);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.textBoxVel);
            this.Controls.Add(this.textBoxAccel);
            this.Controls.Add(this.textBoxCW);
            this.Controls.Add(this.Pause_10);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.Create_cue);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cue_Editor";
            this.Text = "Queue Editor";
            this.Load += new System.EventHandler(this.Que_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Create_cue;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.CheckBox Pause_10;
        private System.Windows.Forms.TextBox textBoxCW;
        private System.Windows.Forms.TextBox textBoxAccel;
        private System.Windows.Forms.TextBox textBoxVel;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.ListBox Created_Cues;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button EStop;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAccelDecelTime;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBoxAccel;
        private System.Windows.Forms.ComboBox comboBoxCW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMovement;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLCCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PauseCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn RotationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccelerationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_decel;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
    }
}

