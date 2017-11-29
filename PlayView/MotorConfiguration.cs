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
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for velocity!");
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for acceleration!");
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox3.Text))
            {
                MessageBox.Show("Must input a non-zero decimal value for deceleration!");
            }
            if(!string.IsNullOrWhiteSpace(maskedTextBox1.Text) && !string.IsNullOrWhiteSpace(maskedTextBox2.Text) && !string.IsNullOrWhiteSpace(maskedTextBox3.Text))
            {
                motors.Add(new Motor(ip_1, "TestMotor" + ++amount, int.Parse(maskedTextBox2.Text),int.Parse(maskedTextBox1.Text), int.Parse(maskedTextBox1.Text)));
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
    }
}