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
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.Created_Cues = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PLCCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PauseCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RotationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccelerationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_decel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox9 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(232, 15);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(484, 33);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Welcome to the Cue Editor! Here you may build and edit cues";
            // 
            // Create_cue
            // 
            this.Create_cue.Location = new System.Drawing.Point(24, 292);
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
            this.richTextBox2.Location = new System.Drawing.Point(314, 292);
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
            this.richTextBox3.Location = new System.Drawing.Point(415, 292);
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
            this.Pause_10.Location = new System.Drawing.Point(422, 319);
            this.Pause_10.Margin = new System.Windows.Forms.Padding(2);
            this.Pause_10.Name = "Pause_10";
            this.Pause_10.Size = new System.Drawing.Size(15, 14);
            this.Pause_10.TabIndex = 26;
            this.Pause_10.UseVisualStyleBackColor = true;
            this.Pause_10.CheckedChanged += new System.EventHandler(this.Pause_10_CheckedChanged);
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Enabled = false;
            this.richTextBox4.Location = new System.Drawing.Point(458, 292);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox4.Size = new System.Drawing.Size(55, 17);
            this.richTextBox4.TabIndex = 27;
            this.richTextBox4.Text = "Rotation";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(453, 313);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(53, 20);
            this.textBox8.TabIndex = 37;
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Enabled = false;
            this.richTextBox5.Location = new System.Drawing.Point(541, 292);
            this.richTextBox5.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox5.Size = new System.Drawing.Size(66, 17);
            this.richTextBox5.TabIndex = 38;
            this.richTextBox5.Text = "Acceleration";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(541, 313);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(53, 20);
            this.textBox9.TabIndex = 48;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(741, 313);
            this.textBox19.Margin = new System.Windows.Forms.Padding(2);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(53, 20);
            this.textBox19.TabIndex = 58;
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Enabled = false;
            this.richTextBox6.Location = new System.Drawing.Point(741, 292);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox6.Size = new System.Drawing.Size(66, 17);
            this.richTextBox6.TabIndex = 59;
            this.richTextBox6.Text = "Velocity";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(514, 366);
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
            this.richTextBox7.Location = new System.Drawing.Point(829, 292);
            this.richTextBox7.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox7.Size = new System.Drawing.Size(66, 17);
            this.richTextBox7.TabIndex = 61;
            this.richTextBox7.Text = "Time";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(829, 316);
            this.textBox29.Margin = new System.Windows.Forms.Padding(2);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(53, 20);
            this.textBox29.TabIndex = 71;
            // 
            // Created_Cues
            // 
            this.Created_Cues.FormattingEnabled = true;
            this.Created_Cues.Location = new System.Drawing.Point(24, 54);
            this.Created_Cues.Margin = new System.Windows.Forms.Padding(2);
            this.Created_Cues.Name = "Created_Cues";
            this.Created_Cues.Size = new System.Drawing.Size(185, 225);
            this.Created_Cues.TabIndex = 72;
            this.Created_Cues.SelectedIndexChanged += new System.EventHandler(this.Created_Cues_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PLCCol,
            this.MotorCol,
            this.PauseCol,
            this.RotationCol,
            this.AccelerationCol,
            this.column_decel,
            this.VelocityCol,
            this.TimeCol});
            this.dataGridView1.Location = new System.Drawing.Point(232, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(599, 229);
            this.dataGridView1.TabIndex = 73;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // richTextBox8
            // 
            this.richTextBox8.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox8.Enabled = false;
            this.richTextBox8.Location = new System.Drawing.Point(232, 292);
            this.richTextBox8.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.Size = new System.Drawing.Size(50, 21);
            this.richTextBox8.TabIndex = 74;
            this.richTextBox8.Text = "PLC";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 366);
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
            this.label1.Location = new System.Drawing.Point(511, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "deg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "m/s^2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "m/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(887, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "sec";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(725, 366);
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
            this.button4.Location = new System.Drawing.Point(844, 96);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 38);
            this.button4.TabIndex = 84;
            this.button4.Text = "Move Up";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(844, 202);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 38);
            this.button5.TabIndex = 85;
            this.button5.Text = "Move Down";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(124, 292);
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
            this.EStop.Location = new System.Drawing.Point(820, 342);
            this.EStop.Name = "EStop";
            this.EStop.Size = new System.Drawing.Size(75, 52);
            this.EStop.TabIndex = 87;
            this.EStop.Text = "Emergency Stop";
            this.EStop.UseVisualStyleBackColor = false;
            this.EStop.Click += new System.EventHandler(this.EStop_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(24, 13);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 36);
            this.button7.TabIndex = 88;
            this.button7.Text = "Play View";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(124, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 36);
            this.button8.TabIndex = 89;
            this.button8.Text = "Motor Configuration";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(314, 311);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 91;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(232, 311);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(76, 21);
            this.comboBox2.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(703, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "m/s^2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(645, 314);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 94;
            // 
            // richTextBox9
            // 
            this.richTextBox9.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox9.Enabled = false;
            this.richTextBox9.Location = new System.Drawing.Point(641, 292);
            this.richTextBox9.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox9.Size = new System.Drawing.Size(66, 17);
            this.richTextBox9.TabIndex = 93;
            this.richTextBox9.Text = "Deceleration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Accel/Decel Time";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(563, 342);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 97;
            // 
            // Cue_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(944, 415);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox9);
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
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.richTextBox4);
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
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.TextBox textBox29;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox9;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLCCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PauseCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RotationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccelerationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_decel;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
    }
}

