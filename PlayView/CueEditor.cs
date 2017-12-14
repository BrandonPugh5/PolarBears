using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using ModbusTCP;
using ModbusTester;
using System.Net;
using System.Timers;
using System.Diagnostics;

namespace PolarBearsProgram
{
    public partial class Cue_Editor : Form
    {
        public static List<Cue> newCueList = new List<Cue>();
        LogForm log = new LogForm();
        String plc;
        String motor;
        bool pause;
        string direction;
        int rotation;
        int acceleration;
        int deceleration;
        int velocity;
        int time;
        bool Delete = false;
        Thread t;
        public int previous = 0; //keeps track of the last tested velocity

        private Master MBmaster = new Master("192.168.10.4", 502);
        private TextBox txtData;
        private Label labData;
        private byte[] data = new Byte[12];
        private byte[] result;

        public Stopwatch stopwatch = new Stopwatch();

        public Cue_Editor()
        {
            InitializeComponent();
            comboBoxAccel.SelectedIndex = 0; //accel as default
            comboBoxCW.SelectedIndex = 0;   //CW as default
            comboBoxMovement.SelectedIndex = 1; //velocity by time
            comboBox3.SelectedIndex = 0; //Unit of Measurement
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Que_Editor_Load(object sender, EventArgs e)
        {
            foreach (Motor motors in MotorConfiguration.motors)
            {
                comboBox1.Items.Add(motors);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Create_cue
        {

            String objectname = Microsoft.VisualBasic.Interaction.InputBox("What would you like to name this Cue", "Creating Cue", "Please give a meaningful name", -1, -1);
            Cue c = new Cue(objectname);
            log.AddRow("Created cue " + objectname);
            newCueList.Add(c);

            Created_Cues.Items.Add(c);
        }

        private void Created_Cues_SelectedIndexChanged(object sender, EventArgs e)
        {

            Cue selected = (Cue)Created_Cues.SelectedItem;
            dataGridView1.Rows.Clear();

            if (Delete == false)
            {
                foreach (Triggers tevent in selected.ReturnTrigger())
                {
                    dataGridView1.Rows.Add(tevent.PLC(), tevent.Motor(), tevent.Pause(),tevent.Direction(), tevent.Rotation(), tevent.Acceleration(),tevent.Deceleration(), tevent.Velocity(), tevent.Time());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Pause_10_CheckedChanged(object sender, EventArgs e)
        {
            if (Pause_10.Checked)
            {
                textBoxCW.Text = "";
                textBoxCW.Enabled = false;
                textBoxAccel.Text = "";
                textBoxAccel.Enabled = false;
                textBoxVel.Text = "";
                textBoxVel.Enabled = false;
            }

            else
            {
                textBoxCW.Enabled = true;
                textBoxAccel.Enabled = true;
                textBoxVel.Enabled = true;
            }

        }

        //add trigger to datagrid
        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Add Button");
            if (textBoxTime.Text == "")
                time = 0;
            else
                time = int.Parse(textBoxTime.Text);
            if (Created_Cues.SelectedItem == null)
                MessageBox.Show("Must select a Cue!");
            else if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                Cue selected = (Cue)Created_Cues.SelectedItem;
                if (textBoxCW.Text == "")
                    textBoxCW.Text = "0";
                if (textBoxAccel.Text == "")
                    textBoxAccel.Text = "0";
                if (textBoxVel.Text == "")
                    textBoxVel.Text = "0";

                plc = comboBox2.Text;
                motor = comboBox1.Text;
                pause = Pause_10.Checked;


                direction = comboBoxCW.SelectedItem.ToString();
                rotation = int.Parse(textBoxCW.Text);
                if (comboBoxAccel.SelectedItem.ToString() == "Acceleration")
                {
                    acceleration = int.Parse(textBoxAccel.Text);
                    deceleration = 0;
                }
                else
                {
                    acceleration = 0;
                    deceleration = int.Parse(textBoxAccel.Text);
                }
                velocity = int.Parse(textBoxVel.Text);

                if (comboBox3.SelectedIndex == 1) //Feet
                {
                    acceleration = (int)(acceleration * .305);
                    deceleration = (int)(deceleration * .305);
                    velocity = (int)(velocity * .305);
                }
                if(comboBox3.SelectedIndex == 2) //Inches
                {
                    acceleration = (int)(acceleration * .0254);
                    deceleration = (int)(deceleration * .0254);
                    velocity = (int)(velocity * .0254);
                }
                Console.WriteLine("Accel:" + acceleration);
                Console.WriteLine("Decel:" + deceleration);
                if (comboBoxMovement.SelectedItem.ToString() != "Degrees by Velocity") ;
                time = time + int.Parse(textBoxAccelDecelTime.Text);

                DialogResult result = MessageBox.Show("Are you sure you want to add these values to cue " + selected + "?\n" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees\n Acceleration: " + acceleration + " m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (ValidateLimits(rotation, acceleration, deceleration, velocity)) //validates data
                    {
                        dataGridView1.Rows.Add(plc, motor, pause, direction, rotation, acceleration, deceleration, velocity, time);

                        textBoxCW.Text = "";
                        textBoxAccel.Text = "";
                        textBoxVel.Text = "";
                        textBoxTime.Text = "";
                        // textBox1.Text = "";
                    }
                }
            }
            else
                MessageBox.Show("Must select a motor!");
        }
        
        //Save Button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save these changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int datarows = 0;
                Cue selected = (Cue)Created_Cues.SelectedItem;
                if (selected.trigs == null)
                {

                }
                else
                {
                    selected.trigs.Clear();
                }
                
                //counts rows in dataGrid
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    datarows = datarows + 1;
                int counter = 0;
              
                //Turns datarows into Triggers
                while (counter != (datarows))
                {
                    motor= dataGridView1.Rows[counter].Cells[1].Value.ToString();
                    String pauseValue = dataGridView1.Rows[counter].Cells[2].Value.ToString();
                    if (pauseValue == "True")
                        pause = true;
                    else
                        pause = false;

                    direction= dataGridView1.Rows[counter].Cells[3].Value.ToString();
                    rotation = int.Parse(dataGridView1.Rows[counter].Cells[4].Value.ToString());
                    acceleration = int.Parse(dataGridView1.Rows[counter].Cells[5].Value.ToString());
                    deceleration = int.Parse(dataGridView1.Rows[counter].Cells[6].Value.ToString());
                    velocity = int.Parse(dataGridView1.Rows[counter].Cells[7].Value.ToString());
                    time = int.Parse(dataGridView1.Rows[counter].Cells[8].Value.ToString());
                    selected.TriggerAdd(plc, motor, pause,direction, rotation, acceleration,deceleration, velocity, time);
                   
                    counter = counter + 1;

                }
                Console.WriteLine("nUMBER OF TRIGERS ADDED" + selected.trigs.Count());
            }
        }


        //Testing Button
        private void button3_Click(object sender, EventArgs e)
        {
             if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                if (textBoxCW.Text == "")
                    textBoxCW.Text = "0";
                if (textBoxAccel.Text == "")
                    textBoxAccel.Text = "0";
                if (textBoxVel.Text == "")
                    textBoxVel.Text = "0";
                if (textBoxTime.Text == "")
                    textBoxTime.Text = "0";

                plc = comboBox2.Text;
                motor = comboBox1.Text;
                pause = Pause_10.Checked;
                direction = comboBoxCW.SelectedItem.ToString();
                rotation = int.Parse(textBoxCW.Text);

                time = int.Parse(textBoxTime.Text);
                
                Console.WriteLine("Accel Box" + comboBoxAccel.SelectedItem.ToString());
                if (comboBoxAccel.SelectedItem.ToString() == "Acceleration")
                {
                    acceleration = int.Parse(textBoxAccel.Text);
                    deceleration = 0;
                }
                if (comboBoxAccel.SelectedItem.ToString() == "Deceleration") //should we test deceleration with a set acceleration or variable
                {
                    deceleration = int.Parse(textBoxAccel.Text);
                    acceleration = 0;
                }

                velocity = int.Parse(textBoxVel.Text);

                if (comboBox3.SelectedIndex == 1) //Feet
                {
                    acceleration = (int)(acceleration * .305);
                    deceleration = (int)(deceleration * .305);
                    velocity = (int)(velocity * .305);
                }
                else if(comboBox3.SelectedIndex == 2) //Inches
                {
                    acceleration = (int)(acceleration * .0254);
                    deceleration = (int)(deceleration * .0254);
                    velocity = (int)(velocity * .0254);
                }

                DialogResult result = MessageBox.Show("Are you sure you want to test these values?\n" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees " + direction + "\n Acceleration: " + acceleration + " m/s^2\n Deceleration: " + deceleration + "m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (t != null)
                        if (t.IsAlive)
                            t.Abort();
                    if (ValidateLimits(rotation, acceleration, deceleration, velocity)) //validates data
                    {
                        if (comboBoxAccel.SelectedItem.ToString() == "Acceleration")
                            log.AddRow("Testing this event" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees " + direction + "\n Acceleration: " + acceleration +/* " m/s²\n Deceleration:" + deceleration +*/ "m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor);
                        t = new Thread(() => DoWork());
                        t.Start();
                    }
                }
            }
            else
                MessageBox.Show("Must select a motor!");
        }

        //DoWork Method runs the motor for testing
        public void DoWork()
        {
            String size = "12";
            int startAddress = 4;
            SetpointVelocity setPointVelocity = new SetpointVelocity();
            int acceleration = Convert.ToInt16(textBoxAccel.Text);

            this.Invoke((MethodInvoker)delegate ()
            {
                String direction = comboBoxCW.SelectedItem.ToString();
            });
            int rotation = Convert.ToInt16(textBoxCW.Text);
            float f;
            int runTime = Convert.ToInt16(textBoxTime.Text);
            stopwatch.Reset();

            if ((string.IsNullOrWhiteSpace(textBoxAccel.Text) || !float.TryParse(textBoxAccel.Text, out f) || Convert.ToInt16(textBoxAccel.Text) == 0 || acceleration == 0))
            {
                MessageBox.Show("Must input a non-zero decimal value for Acceleration!");
            }

            if (string.IsNullOrWhiteSpace(textBoxVel.Text) || !float.TryParse(textBoxVel.Text, out f))
            {
                MessageBox.Show("Must input a decimal value for velocity!");
            }
            else if (acceleration != 0)
            {
                setPointVelocity.GetSetValue = Convert.ToInt16(textBoxVel.Text);
            }

            ushort ID = 8;
            byte unit = 0;
            ushort StartAddress = Convert.ToUInt16(startAddress); //ReadStartAdr();           

            data = GetDataNew(Convert.ToByte(size));

            /*byte[] bytes = BitConverter.GetBytes(setPointVelocity.GetSetValue);
            byte[] bytes2 = BitConverter.GetBytes(acceleration);*/
            ControlWord_I3 wordi3 =new ControlWord_I3();
            
            if (direction.Equals("Clockwise"))
            {
                wordi3.Positive = false;
                wordi3.Negative = true;
            }
            else
            {
                wordi3.Positive = true;
                wordi3.Negative = false;
            }

            data[0] = 0; //byte 0 of Control 1
            data[1] = 0; //byte 1 of Control 1
            data[2] = 0; //byte 0 of Binary Outputs
            data[3] = 0;  //byte 1 of Binary Outputs
            data[4] = BitConverter.GetBytes(wordi3.GetSetValue)[1];  //byte 0 of Control 3
            data[5] = BitConverter.GetBytes(wordi3.GetSetValue)[0];   //byte 1 of Control 3
            data[6] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[1];  // byte 1 of Velocity
            data[7] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[0];  // byte 0 of velocity
            data[8] = BitConverter.GetBytes(acceleration)[1];  // byte 1 of Velocity
            data[9] = BitConverter.GetBytes(acceleration)[0];  // byte 0 of velocity
            data[10] = BitConverter.GetBytes(deceleration)[1];
            data[11] = BitConverter.GetBytes(deceleration)[0];
            
            MBmaster.ReadWriteMultipleRegister(8, 0, Convert.ToUInt16(4), 12, Convert.ToUInt16(4), data, ref result);
            Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];

            float positionBefore = Program.playView.position.currentPosition;
            long position = Program.playView.position.currentPosition;
            Console.WriteLine("current pos " + Program.playView.position.currentPosition);
            if (rotation == 0)
            {
                Console.WriteLine("rotation = 0");
                if(textBoxAccelDecelTime.Text != "")
                {
                    if (deceleration == 0)
                    {
                        int time = Convert.ToInt16(textBoxAccelDecelTime.Text);
                    }
                    else
                    {
                        int decelTime = Math.Abs(previous - velocity) / deceleration;
                        time = decelTime;
                    }
                    stopwatch.Start();
                    while (stopwatch.Elapsed < TimeSpan.FromSeconds(runTime + time))
                    {
                        MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                        Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                        
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            textBox3.Text = Program.playView.position.Degrees().ToString();
                            textBox4.Text = Program.playView.position.currentPosition.ToString();
                        });
                    }
                    stopwatch.Reset();
                }
                else
                {
                    stopwatch.Start();
                    while (stopwatch.Elapsed < TimeSpan.FromSeconds(runTime))
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            textBox3.Text = Program.playView.position.Degrees().ToString();
                        });
                        this.Invoke((MethodInvoker)delegate ()
                        {

                            textBox4.Text = Program.playView.position.currentPosition.ToString();
                        });
                    }
                    int timeAfter = DateTime.Now.Second;
                    Console.WriteLine("time after " + timeAfter);
                    Console.WriteLine("finalpos " + position);
                    Console.WriteLine("Rate of position over time " + (position - positionBefore) / runTime);
                }
            }
            else //Movement by Rotation
            {
                MBmaster.ReadWriteMultipleRegister(8, 0, Convert.ToUInt16(4), 12, Convert.ToUInt16(4), data, ref result);
                Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];

                Console.WriteLine("rotation != 0 " + rotation);

                if (direction.Equals("Clockwise"))
                {
                    int degrees = Convert.ToInt16(textBoxCW.Text);
                    int positions = degrees * 2100;

                    // rotation = Convert.ToInt16(textBoxCW.Text) - Program.playView.position.turnedDegrees;

                    //cw
                    int startingPos = Program.playView.position.currentPosition;
                    Console.WriteLine("Starting pos: " + startingPos + "Ending Position: " + (startingPos - positions));
                    while (Program.playView.position.currentPosition > (startingPos - positions))
                    {
                        MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                        Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            textBox3.Text = Program.playView.position.Degrees().ToString();
                            textBox4.Text = Program.playView.position.currentPosition.ToString();
                        });
                    }
                }
                else//ccw
                {
                    int degrees = Convert.ToInt16(textBoxCW.Text);
                    int positions = degrees * 2100;
                    int startingPos = Program.playView.position.currentPosition;
                    while (Program.playView.position.currentPosition < (startingPos + positions))
                    {
                        MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                        Program.playView.position.currentPosition = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            textBox3.Text = Program.playView.position.Degrees().ToString();
                            textBox4.Text = Program.playView.position.currentPosition.ToString();
                        });
                    }
                }
            }
            previous = velocity;
            Console.WriteLine("previous " + previous);
        }

        //Move Up Button
        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow CurrentRow = dataGridView1.CurrentRow;
            DataGridViewRow Results = (DataGridViewRow)(CurrentRow.Clone());
            Int32 currentIndex = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(currentIndex);
            Int32 NewIndex = System.Convert.ToInt32(((currentIndex == 0) ? 0 : currentIndex - 1));
            for (Int32 Row = 0; Row < CurrentRow.Cells.Count; Row++)
            {
                Results.Cells[Row].Value = CurrentRow.Cells[Row].Value;
            }
            dataGridView1.Rows.Insert(NewIndex, Results);
        }

        //down button
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int totalRows = dataGridView1.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dataGridView1.SelectedCells[0].OwningColumn.Index;
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                dataGridView1.Rows.Remove(selectedRow);
                dataGridView1.Rows.Insert(rowIndex + 1, selectedRow);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch { }
        }

        //Delete Cue
        private void button6_Click(object sender, EventArgs e)
        {
            if (Created_Cues.SelectedItem != null)
            {
                Cue selected = (Cue)Created_Cues.SelectedItem;
                DialogResult result = MessageBox.Show("Are you sure you want to delete cue " + selected + "?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Delete = true;
                    Created_Cues.Items.Remove(selected);
                    newCueList.Remove(selected);
                }
                Delete = false;
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
        private void EStop_Click(object sender, EventArgs e)
        {
            if (t != null &&  t.IsAlive)
            {
                t.Suspend();
                log.AddRow("Emergency Stop Called");
            }
        }

        //Returns true if valid data
        public Boolean ValidateLimits(int Rotation, float Acceleration, float Deceleration, int Velocity)
        {
            Motor motorSelected = (Motor)comboBox1.SelectedItem;
            int valAcceleration = motorSelected.AccelLimit;
            int valDecel = motorSelected.DecelLimit;
            int valVelocity = motorSelected.VelocityLimit;
            int valAccelSoft = motorSelected.AccelSoftLimit;
            int valDecelSoft = motorSelected.DecelSoftLimit;
            int valVelocitySoft = motorSelected.VelocitySoftLimit;
            int valRotationSoft = motorSelected.RotationSoftLimit;
           // bool velocitySoftLimitMessagePoppedUp = false;
           // bool accelerationSoftLimitMessagePoppedUp = false;
           // bool decelerationSoftLimitMessagePoppedUp = false;
           /// bool rotationSoftLimitMessagePoppedUp = false;
         


            if (comboBoxAccel.SelectedItem.ToString() == "Acceleration")
            {
                if (Acceleration > valAcceleration)
                {
                    MessageBox.Show("You entered a Acceleration greater then the limit of " + valAcceleration, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.AddRow("Invalid Acceleration input");
                    return false;
                }
                if (valAccelSoft != 0 && valAccelSoft > int.Parse(textBoxAccel.Text))//&& !accelerationSoftLimitMessagePoppedUp)
                {
                    //MessageBox.Show("You can enter values greater than the Soft Limit, but a soft limit was set for a reason. Please consider using smaller values for acceleration.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // accelerationSoftLimitMessagePoppedUp = true;
                    MessageBox.Show("You entered a Acceleration less then the soft limit of " + valAccelSoft, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.AddRow("Invalid Acceleration input");
                    return false;
                }
               
            }

            if (comboBoxAccel.SelectedItem.ToString() == "Deceleration")
            {
                if (Deceleration > valDecel)
                {
                    MessageBox.Show("You entered a Deceleration greater then the limit of " + valDecel, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.AddRow("Invalid Deceleration input");
                    return false;
                }
                if (valDecelSoft != 0 && valDecelSoft > int.Parse(textBoxAccel.Text))// && !decelerationSoftLimitMessagePoppedUp)
                {
                    MessageBox.Show("You entered a Deceleration less then the limit of " + valDecelSoft, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.AddRow("Invalid Deceleration input");
                    return false;
                }
            }

             if (Velocity > valVelocity)
            {
                MessageBox.Show("You entered a Velocity greater then the limit of " + valVelocity, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Velocity input");
                return false;
            }
             if (Velocity < 0)
            {
                MessageBox.Show("You entered a Velocity less than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Velocity input");
                return false;
            }
             if (valVelocitySoft != 0 && valVelocitySoft > int.Parse(textBoxVel.Text) )//&& !velocitySoftLimitMessagePoppedUp)
            {
                MessageBox.Show("You entered a Velocity less then the limit of " + valVelocitySoft, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Velocity input");
                return false;
            }
            return true;
        }

        //PlayView Button
        private void button7_Click(object sender, EventArgs e)
        {
            Program.playView.Show();
            Hide();
        }

        //Motor Configuration Button
        private void button8_Click(object sender, EventArgs e)
        {
            Program.motorConf.Show();
            Hide();
        }

        //
        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (Motor motors in MotorConfiguration.motors)
            {
                if (!comboBox1.Items.Contains(motors))
                {
                    comboBox1.Items.Add(motors);
                }
            }
        }

        private void comboBoxMovement_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxTime.Text = "";
            textBoxAccel.Text = "";
            textBoxCW.Text = "";
            textBoxVel.Text = "";

            if (comboBoxMovement.SelectedItem.ToString()=="Degrees by Velocity")
            {
                textBoxTime.Enabled = false;
                textBoxAccel.Enabled = true;
                textBoxCW.Enabled = true;
                textBoxVel.Enabled = true;
            }
            if (comboBoxMovement.SelectedItem.ToString() == "Velocity by Time")
            {
                textBoxTime.Enabled = true;
                textBoxAccel.Enabled = true;
                textBoxCW.Enabled = false;
                textBoxVel.Enabled = true;
            }
        }

        private void textBoxVel_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxMovement.SelectedItem.ToString() == "Velocity by Time")
            {
                if(textBoxAccel.Text != "" && textBoxAccel.Text != "0")
                {
                    int vel = int.Parse(textBoxVel.Text);
                    int acc = int.Parse(textBoxAccel.Text);
                    textBoxAccelDecelTime.Text = (vel / acc).ToString();
                }
            }
        }

        private void textBoxAccel_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxMovement.SelectedItem.ToString() == "Velocity by Time")
            {
                if (textBoxVel.Text != "" && textBoxVel.Text !="0")
                {
                    if (textBoxAccel.Text != "" && textBoxAccel.Text != "0")
                    {
                        int vel = int.Parse(textBoxVel.Text);
                        Console.WriteLine(int.Parse(textBoxVel.Text));
                        Console.WriteLine(int.Parse(textBoxAccel.Text));
                        int acc = int.Parse(textBoxAccel.Text.ToString());
                        textBoxAccelDecelTime.Text = (vel / acc).ToString();
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex == 0)
            {
                label3.Text = "m/s²";
                label4.Text = "m/s";
            }
            else if(comboBox3.SelectedIndex == 1)
            {
                label3.Text = "ft/s²";
                label4.Text = "ft/s";
            }
            else
            {
                label3.Text = "in/s²";
                label4.Text = "in/s";
            }
        }
    }
}