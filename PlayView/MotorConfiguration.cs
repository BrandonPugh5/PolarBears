using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolarBearsProgram
{
    public partial class MotorConfiguration : Form
    {
        Cue_Editor screen3;
        public static List<Motor> motors = new List<Motor>();
        String ip_1 = "192.168.10.4";
        int amount = 0;

        public MotorConfiguration()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        

        //Add Motor
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBoxVHL.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for velocity!");
            }
            if (string.IsNullOrWhiteSpace(maskedTextBoxAHL.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for acceleration!");
            }
            if (string.IsNullOrWhiteSpace(maskedTextBoxDHL.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for deceleration!");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Must input a name for the motor!");
            }

            if (!string.IsNullOrWhiteSpace(maskedTextBoxVHL.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxAHL.Text) && !string.IsNullOrWhiteSpace(maskedTextBoxDHL.Text) &&!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                motors.Add(new Motor(ip_1, textBox1.Text, int.Parse(maskedTextBoxAHL.Text),int.Parse(maskedTextBoxDHL.Text),int.Parse(maskedTextBoxVHL.Text),int.Parse(maskedTextBoxASL.Text), int.Parse(maskedTextBoxDSL.Text), int.Parse(maskedTextBoxVSL.Text)));
                dataGridView1.Rows.Clear();
                foreach(Motor motor in motors)
                {
                    dataGridView1.Rows.Add(motor, motor.IP(), motor.AccelLimit, motor.AccelSoftLimit, motor.DecelLimit, motor.DecelSoftLimit, motor.VelocityLimit, motor.VelocitySoftLimit);
                }
            }
        }

        //Cue Editor button
        private void button1_Click(object sender, EventArgs e)
        {
            Program.cueEdit.Show();
            Hide();
        }


        //PlayView Button
        private void button3_Click(object sender, EventArgs e)
        {
            Program.playView.Show();
            Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Rename Button
        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to save these changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int count = 0;
                foreach (Motor motor in motors)
                {
                    String name = motor.ToString();
                    if (name != dataGridView1.Rows[count].Cells[0].Value.ToString())
                    {
                        motor.serial = dataGridView1.Rows[count].Cells[0].Value.ToString();
                    }
                    count++;
                }

                dataGridView1.Rows.Clear();
                foreach (Motor motor in motors)
                {
                    dataGridView1.Rows.Add(motor, motor.IP(), motor.AccelLimit, motor.AccelSoftLimit, motor.DecelLimit,motor.DecelSoftLimit,motor.VelocityLimit,motor.VelocitySoftLimit);
                }
            }
        }

        //Delete Button
        private void button5_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            motors.RemoveAt(rowIndex);
            dataGridView1.Rows.Clear();
            foreach (Motor motor in motors)
            {
                dataGridView1.Rows.Add(motor, motor.IP(), motor.AccelLimit, motor.AccelSoftLimit, motor.DecelLimit, motor.DecelSoftLimit, motor.VelocityLimit, motor.VelocitySoftLimit);
            }
        }
    }
}