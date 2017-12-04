using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ModbusTCP;
using ModbusTester;
using System.Net;


namespace PolarBearsProgram
{
    public partial class PlayView : Form
    {
        int count = 1;
        Thread t;
        LogForm log = new LogForm();
        bool Estopped = true;

        private byte[] data = new Byte[12];
        private byte[] result;
        private ModbusTCP.Master MBmaster = new Master("192.168.10.4", 502);

        public PlayView()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Add Cue
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                queueBox.Items.Add(listBox1.SelectedItem);
                log.AddRow(listBox1.SelectedItem + " was added to queue");
            }
        }

        //Remove Cue
        private void button2_Click(object sender, EventArgs e)
        {
            if (queueBox.SelectedItem != null)
            {
                var confirm = MessageBox.Show("Are you sure you would like to remove the selected cue?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    queueBox.Items.Remove(queueBox.SelectedItem);
                    log.AddRow(listBox1.SelectedItem + " was removed from queue");
                }
            }
        }

        //Move Cue Up
        private void button3_Click(object sender, EventArgs e)
        {
            if (queueBox.SelectedIndex > 0)
            {
                Object item = queueBox.SelectedItem;
                int index = queueBox.SelectedIndex;
                queueBox.Items.Remove(queueBox.SelectedItem);
                queueBox.Items.Insert(index - 1, item);
            }
        }

        //Move Cue Down
        private void button5_Click(object sender, EventArgs e)
        {
            if (queueBox.SelectedIndex < (queueBox.Items.Count - 1) && queueBox.SelectedItem != null)
            {
                Object item = queueBox.SelectedItem;
                int index = queueBox.SelectedIndex;
                queueBox.Items.Remove(queueBox.SelectedItem);
                queueBox.Items.Insert(index + 1, item);
            }
        }

        //Play Button
        private void button6_Click(object sender, EventArgs e)
        {
            log.AddRow("Play Button Clicked");
            DialogResult result = MessageBox.Show("Are you sure you want to play?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                log.AddRow("Play Button Activated");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button4.Enabled = true;
                button4.ForeColor = Color.White;
                button4.BackColor = Color.DarkRed;

                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                
                    Cue activecue = (Cue)queueBox.SelectedItem;
                    List<Triggers> trigs = activecue.ReturnTrigger();
                    Console.WriteLine(trigs.Count);
                    int counter = 0;

                    t = new Thread(() => DoWork(trigs));
                    t.Start();
                
            }
        }

        //DoWork Method runs the motor for testing
        public void DoWork(List<Triggers> t)
        {
            foreach (Triggers trig in t)
            {
                log.AddRow("New trigger started");
                int accel = trig.Acceleration();
                int rvel = trig.Velocity();
                int time = trig.Time();
                int decel = trig.Deceleration();
                log.AddRow("Running this trigger" + " Pause: " + trig.Pause() + "\nAcceleration: " + accel + " m/s^2\n Deceleration:" + decel + "m/s^2\n Velocity: " + rvel + " m/s\n Time: " + time + " sec\n on motor" + trig.Motor());

                String size = "12";
                int startAddress = 4;
                //int acceleration = 0;
                SetpointVelocity setPointVelocity = new SetpointVelocity();
                int acceleration = Convert.ToInt16(accel);
                float f;
                int runTime = time;
                //System.Timers.Timer timer = new System.Timers.Timer(runTime);

                ushort ID = 8;
                byte unit = 0;
                ushort StartAddress = Convert.ToUInt16(startAddress); //ReadStartAdr();           

                data = GetDataNew(Convert.ToByte(size));

                byte[] bytes = BitConverter.GetBytes(setPointVelocity.GetSetValue);
                Console.WriteLine(bytes + " is set point velo");
                Console.WriteLine(rvel);
                byte[] bytes2 = BitConverter.GetBytes(acceleration);
                ControlWord_I3 wordi3 = new ControlWord_I3();

                data[0] = 0; //byte 0 of Control 1
                data[1] = 0; //byte 1 of Control 1
                data[2] = 0; //byte 0 of Binary Outputs
                data[3] = 0;  //byte 1 of Binary Outputs
                data[4] = 10;  //byte 0 of Control 3
                data[5] = 6;   //byte 1 of Control 3
                               // data[6] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[1];  // byte 1 of Velocity
                data[6] = BitConverter.GetBytes(rvel)[1];
                //data[7] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[0];  // byte 0 of velocity
                data[7] = BitConverter.GetBytes(rvel)[0];
                data[8] = BitConverter.GetBytes(acceleration)[1];  // byte 1 of Velocity
                data[9] = BitConverter.GetBytes(acceleration)[0];  // byte 0 of velocity
                data[10] = BitConverter.GetBytes(decel)[1];
                data[11] = BitConverter.GetBytes(decel)[0];


                int howLong = DateTime.Now.Second;
                int endTime = howLong + runTime;
                 while (howLong < endTime)
                 {
                     MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                     howLong = DateTime.Now.Second;
                 }
                 
               /* long position;
                while (howLong < endTime)
                {
                    MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                    howLong = DateTime.Now.Second;
                    position = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                    Console.WriteLine("Position is: " + position);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox1.Text = rvel.ToString();
                        textBox2.Text = "Counter Clockwise";
                        textBox3.Text = position.ToString();
                    });
                    
                }*/
            }
        }

        private byte[] GetDataNew(int size)
        {
            byte[] data = new Byte[size];
            int[] word = new int[size];

            data = new Byte[size * 2];
            for (int x = 0; x < size; x++)
            {
                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[x]));
                data[x * 2] = dat[0];
                data[x * 2 + 1] = dat[1];
            }
            return data;
        }

        //Emergency Stop
        private void button4_Click(object sender, EventArgs e)
        {
            if (Estopped == true)
            {
                t.Suspend();
                button4.BackColor = Color.Green;
                button4.Text = "Turn off E-Stop";
                Estopped = false;
                log.AddRow("Emergency Stop Activated");
            }
            else
            {
                DialogResult result = MessageBox.Show("Would you like to exit Emergency Stop mode? Note: this will not resume the motor function until play is hit again.?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                log.AddRow("Emergency Stop Deactivated");
                button4.BackColor = Color.Gray;
                button4.ForeColor = Color.Black;
                button4.Text = "Emergency Stop";
                button4.Enabled = false;
                Estopped = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.cueEdit.Show();
            Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Program.motorConf.Show();
            Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*foreach (Motor motors in MotorConfiguration.motors)
            {
                if (!comboBox1.Items.Contains(motors))
                {
                    comboBox1.Items.Add(motors);
                }
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (Cue cue in Cue_Editor.newCueList)
            {
                if (!listBox1.Items.Contains(cue))
                {
                    listBox1.Items.Add(cue);
                }
            }
        }
    }
}
