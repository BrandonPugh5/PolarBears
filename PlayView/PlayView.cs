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
using System.Diagnostics;


namespace PolarBearsProgram
{
    public partial class PlayView : Form
    {
        int count = 1;
        Thread t, t2;
        LogForm log = new LogForm();
        bool Estopped = true;
        bool Paused = false;
        int previous = 0;

        private byte[] data = new Byte[12];
        private byte[] result;
        private Master MBmaster = new Master("192.168.10.4", 502);
        public Stopwatch stopwatch = new Stopwatch();
        public Rotation position;

        OpenFileDialog ofd = new OpenFileDialog();

        public PlayView()
        {
            data = testing(data);
            MBmaster.ReadWriteMultipleRegister(8, 0, Convert.ToUInt16(4), 12, Convert.ToUInt16(4), data, ref result);
            InitializeComponent();
            position = new Rotation(result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15]);
            position.initialPosition= result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
            
        
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
            if (AvailableQueues.SelectedItem != null)
            {
                SelectedQueues.Items.Add(AvailableQueues.SelectedItem);
                log.AddRow(AvailableQueues.SelectedItem + " was added to queue");
            }
        }

        //Remove Cue
        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedQueues.SelectedItem != null)
            {
                var confirm = MessageBox.Show("Are you sure you would like to remove the selected cue?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    SelectedQueues.Items.Remove(SelectedQueues.SelectedItem);
                    log.AddRow(AvailableQueues.SelectedItem + " was removed from queue");
                }
            }
        }

        //Move Cue Up
        private void button3_Click(object sender, EventArgs e)
        {
            if (SelectedQueues.SelectedIndex > 0)
            {
                Object item = SelectedQueues.SelectedItem;
                int index = SelectedQueues.SelectedIndex;
                SelectedQueues.Items.Remove(SelectedQueues.SelectedItem);
                SelectedQueues.Items.Insert(index - 1, item);
            }
        }

        //Move Cue Down
        private void button5_Click(object sender, EventArgs e)
        {
            if (SelectedQueues.SelectedIndex < (SelectedQueues.Items.Count - 1) && SelectedQueues.SelectedItem != null)
            {
                Object item = SelectedQueues.SelectedItem;
                int index = SelectedQueues.SelectedIndex;
                SelectedQueues.Items.Remove(SelectedQueues.SelectedItem);
                SelectedQueues.Items.Insert(index + 1, item);
            }
        }

        //Play/Pause Button
        private void button6_Click(object sender, EventArgs e)
        {
            log.AddRow("Play Button Clicked");
            if (Paused == true)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to resume? Note: This will pick up from where you had left off", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    t.Resume();
                    stopwatch.Start();
                    button6.Text = "Play/Pause";
                    Paused = false;
                    Estopped = true;
                    button4.Text = "E-Stop";
                    button4.Enabled = true;
                    button4.ForeColor = Color.White;
                    button4.BackColor = Color.DarkRed;
                    log.AddRow("Resumed Queue");
                }
            }
            else
            {
                if (t != null && t.IsAlive)
                {
                    t.Suspend();
                    stopwatch.Stop();
                    Paused = true;
                    button6.Text = "Resume";
                    log.AddRow("Paused Queue");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to play?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        log.AddRow("Queues selected to play");
                        foreach (Cue selected in SelectedQueues.Items)
                        {
                            log.AddRow("Triggers in " + selected);
                            foreach (Triggers trig in selected.trigs)
                            {
                                log.AddRow("", trig.PLC(), trig.Motor(), trig.Pause(),trig.Direction(), trig.Rotation(), trig.Acceleration(), trig.Deceleration(), trig.Velocity(), trig.Time());
                            }
                        }
                        log.AddRow("Play Button Activated");
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button5.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button4.Enabled = true;
                        button4.ForeColor = Color.White;
                        button4.BackColor = Color.DarkRed;

                        textBox1.Text = "0";
                        textBox2.Text = "0";
                        textBox3.Text = "0";

                        //   Cue activecue = (Cue)queueBox.SelectedItem;


                        t = new Thread(() => DoWork());
                        t.Start();
                    }
                }
            }
        }

        //DoWork Method runs the motor for testing
        public void DoWork()
        {
            foreach (Cue currentcue in SelectedQueues.Items)
            {
                Cue tmp = currentcue;
                List<Triggers> trigs = currentcue.ReturnTrigger();
                Console.WriteLine(trigs.Count());
                foreach (Triggers trig in trigs.ToList())
                {
                    log.AddRow("New trigger started");
                    int accel = trig.Acceleration();
                    int rvel = trig.Velocity();
                    int time = trig.Time();
                    int decel = trig.Deceleration();
                    bool rpause = trig.Pause();
                    String dir = trig.Direction();
                    int rot = trig.Rotation();
                    log.AddRow("Running this trigger" + " Pause: " + trig.Pause() + "\nRotation: "+rot+" "+dir+"\nAcceleration: " + accel + " m/s^2\n Deceleration:" + decel + "m/s^2\n Velocity: " + rvel + " m/s\n Time: " + time + " sec\n on motor" + trig.Motor());

                    String size = "12";
                    int startAddress = 4;
                    //int acceleration = 0;
                    SetpointVelocity setPointVelocity = new SetpointVelocity();
                    int acceleration = Convert.ToInt16(accel);
                    float f;
                    int runTime = time;
                    stopwatch.Reset();
                   
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

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        if (dir.Equals("Clockwise"))
                        {
                            wordi3.Positive = false;
                            wordi3.Negative = true;
                        }
                        else
                        {
                            wordi3.Positive = true;
                            wordi3.Negative = false;
                        }
                    });

                    data[0] = 0; //byte 0 of Control 1
                    data[1] = 0; //byte 1 of Control 1
                    data[2] = 0; //byte 0 of Binary Outputs
                    data[3] = 0;  //byte 1 of Binary Outputs
                    data[4] = BitConverter.GetBytes(wordi3.GetSetValue)[1];  //byte 0 of Control 3
                    data[5] = BitConverter.GetBytes(wordi3.GetSetValue)[0];   //byte 1 of Control 3                                     // data[6] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[1];  // byte 1 of Velocity
                    data[6] = BitConverter.GetBytes(rvel)[1];  // byte 1 of velocity
                    data[7] = BitConverter.GetBytes(rvel)[0]; // byte 0 of velocity
                    data[8] = BitConverter.GetBytes(acceleration)[1];  // byte 1 of Velocity
                    data[9] = BitConverter.GetBytes(acceleration)[0];  // byte 0 of velocity
                    data[10] = BitConverter.GetBytes(decel)[1];
                    data[11] = BitConverter.GetBytes(decel)[0];
                    
                    MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                    Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];

                    if (trig.Rotation() == 0) //Trigger by Time
                    {
                        if (trig.Deceleration() != 0)
                        {
                            runTime = trig.Time() + ((previous - trig.Velocity()) / trig.Deceleration());
                        }
                        stopwatch.Start();
                        Console.WriteLine("Running Trigger");
                        while (stopwatch.Elapsed < TimeSpan.FromSeconds(runTime))
                        {
                            
                            //Console.WriteLine(howLong + "  " + endTime);
                            if (!rpause)
                                MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);

                            //Console.WriteLine("working " + stopwatch.Elapsed.ToString());
                            // }
                            Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                            int velocity = result[6] * 256 + result[7];

                            this.Invoke((MethodInvoker)delegate ()
                            {
                                textBox1.Text = velocity.ToString(); ;
                                textBox2.Text = dir;
                                textBox3.Text = textBox3.Text = Program.playView.position.Degrees().ToString();
                            });
                        }
                        stopwatch.Stop();
                    }
                    else //Trigger by rotation
                    {
                        Console.WriteLine("rotation != 0 " + trig.Rotation());
                        Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];


                        if (trig.Direction().Equals("Clockwise"))
                        {
                            int degrees = trig.Rotation();
                            int positions = degrees * 2100;

                            // rotation = Convert.ToInt16(textBoxCW.Text) - Program.playView.position.turnedDegrees;

                            //cw
                            int startingPos = Program.playView.position.currentPosition;
                            Console.WriteLine("Starting pos: " + startingPos + "Ending Position: " + (startingPos - positions));
                            while (Program.playView.position.currentPosition > (startingPos - positions))
                            {
                                int velocity = result[6] * 256 + result[7];
                                MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                                Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    textBox1.Text = velocity.ToString(); ;
                                    textBox2.Text = dir;
                                    textBox3.Text = Program.playView.position.Degrees().ToString();
                                });
                               
                            }
                        }
                        else//ccw
                        {
                            int degrees = trig.Rotation();
                            int positions = degrees * 2100;
                            int startingPos = Program.playView.position.currentPosition;
                            while (Program.playView.position.currentPosition < (startingPos + positions))
                            {
                                int velocity = result[6] * 256 + result[7];
                                MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                                Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    textBox3.Text = Program.playView.position.Degrees().ToString();
                                    textBox1.Text = velocity.ToString(); ;
                                    textBox2.Text = dir;
                                });
                            }
                        }
                        previous = trig.Velocity();
                    }
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                log.AddRow("Queue Finished");
                button4.Enabled = false;
                button6.Text = "Play/Pause";
            });
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
                log.AddRow("Emergency Stop Activated");
                t.Suspend();
                button4.BackColor = Color.Green;
                button4.Text = "Turn off E-Stop";
                button6.Enabled = true;
                button6.Text = "Resume";
                Estopped = false;
                Paused = true;
            }
            else
            {
                DialogResult result = MessageBox.Show("Would you like to exit Emergency Stop mode? Note: this will not resume the motor function until play is hit again.?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
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
                    button6.Text = "Play/Pause";
                    button4.Enabled = false;
                    Estopped = true;
                    Paused = false;
                }
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

        private void button9_Click(object sender, EventArgs e)
        {
            AvailableQueues.Items.Clear();
            foreach (Cue cue in Cue_Editor.newCueList)
            {
                if (!AvailableQueues.Items.Contains(cue))
                {
                    AvailableQueues.Items.Add(cue);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (button11.Visible == true)
            {
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
            }
            else
            {
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
            }

        }

        private void button11_Click(object sender, EventArgs e)//about form
        {
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            MessageBox.Show("Software version: 1.5\nMade for Proof Productions\nPolar Bears 2017");
            
        }
        private void button12_Click(object sender, EventArgs e)//user doc
        {
            Process.Start("C:\\Users\\shop\\Desktop\\All Together Gui\\UserDocumentation.pdf", "UserDocumentation.pdf");
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)//log form
        {
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            ofd.Filter = "Log Files|*.txt";
            ofd.Title = "Select a log file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String fileName = ofd.FileName;
                String safeFileName = ofd.SafeFileName;

                System.Diagnostics.Process.Start(fileName, safeFileName);
            }
         
        }

        public byte[] testing(byte[] array)
        {
            int accel = 0;
            int rvel = 0;
            int time = 0;
            int decel = 0;
            bool rpause = false;

            String size = "12";
            int startAddress = 4;
            //int acceleration = 0;
            SetpointVelocity setPointVelocity = new SetpointVelocity();
            int acceleration = Convert.ToInt16(accel);
            float f;
            int runTime = time;
            stopwatch.Reset();

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

            array = data;
            return array;
        }
    }
}
