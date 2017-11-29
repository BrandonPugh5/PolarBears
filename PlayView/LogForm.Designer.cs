namespace PolarBearsProgram
{
    partial class LogForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExceptionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AngleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeCol,
            this.Action,
            this.ExceptionCol,
            this.MotorCol,
            this.AngleCol,
            this.VelocityCol});
            this.dataGridView1.Location = new System.Drawing.Point(15, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(713, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // TimeCol
            // 
            this.TimeCol.HeaderText = "Time";
            this.TimeCol.Name = "TimeCol";
            this.TimeCol.ReadOnly = true;
            this.TimeCol.Width = 200;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // ExceptionCol
            // 
            this.ExceptionCol.HeaderText = "Exceptions";
            this.ExceptionCol.Name = "ExceptionCol";
            this.ExceptionCol.ReadOnly = true;
            // 
            // MotorCol
            // 
            this.MotorCol.HeaderText = "Motor";
            this.MotorCol.Name = "MotorCol";
            this.MotorCol.ReadOnly = true;
            this.MotorCol.Width = 200;
            // 
            // AngleCol
            // 
            this.AngleCol.HeaderText = "Angle of Rotation";
            this.AngleCol.Name = "AngleCol";
            this.AngleCol.ReadOnly = true;
            this.AngleCol.Width = 200;
            // 
            // VelocityCol
            // 
            this.VelocityCol.HeaderText = "Velocity";
            this.VelocityCol.Name = "VelocityCol";
            this.VelocityCol.ReadOnly = true;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 311);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LogForm";
            this.Text = "Log File";
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExceptionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AngleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocityCol;
    }
}

