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
        int rotation;
        int acceleration;
        int deceleration;
        int velocity;
        int time;
        bool Delete = false;
        Thread t;

        private ModbusTCP.Master MBmaster = new Master("192.168.10.4", 502);
        private TextBox txtData;
        private Label labData;
        private byte[] data = new Byte[12];
        private byte[] result;

        

        public Cue_Editor()
        {
            InitializeComponent();
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
                    dataGridView1.Rows.Add(tevent.PLC(), tevent.Motor(), tevent.Pause(), tevent.Rotation(), tevent.Acceleration(), tevent.Velocity(), tevent.Time());
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
                textBox8.Text = "";
                textBox8.Enabled = false;
                textBox9.Text = "";
                textBox9.Enabled = false;
                textBox19.Text = "";
                textBox19.Enabled = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
            }

            else
            {
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox19.Enabled = true;
                textBox1.Enabled = true;
            }

        }

        //add trigger to datagrid
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Created_Cues.SelectedItem != null)
            {
                 if (!string.IsNullOrWhiteSpace(comboBox1.Text))
                    {
                    Cue selected = (Cue)Created_Cues.SelectedItem;
                    if (textBox8.Text == "")
                        textBox8.Text = "0";
                    if (textBox9.Text == "")
                        textBox9.Text = "0";
                    if (textBox19.Text == "")
                        textBox19.Text = "0";
                    if (textBox1.Text == "")
                        textBox1.Text = "0";

                    plc = comboBox2.Text;
                    motor = comboBox1.Text;
                    pause = Pause_10.Checked;
                    rotation = int.Parse(textBox8.Text);
                    acceleration = int.Parse(textBox9.Text);
                    deceleration = int.Parse(textBox1.Text);
                    velocity = int.Parse(textBox19.Text);
                    time = int.Parse(textBox29.Text);
                    DialogResult result = MessageBox.Show("Are you sure you want to add these values to cue " + selected + "?\n" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees\n Acceleration: " + acceleration + " m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (ValidateLimits(rotation, acceleration, deceleration, velocity)) //validates data
                        {
                            dataGridView1.Rows.Add(plc, motor, pause, rotation, acceleration, deceleration, velocity, time);


                            textBox8.Text = "";
                            textBox9.Text = "";
                            textBox19.Text = "";
                            textBox29.Text = "";
                            textBox1.Text = "";
                        }
                    }
                }

                else
                    MessageBox.Show("Must select a motor!");
            }

            else
                MessageBox.Show("Must select a Cue!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                
                //int trigCounter;
                //counts rows in dataGrid
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    datarows = datarows + 1;
                int counter = 0;
                // if (!selected.trigs.Any()) //if List of trigs is empty
                //       trigCounter = 0;
                //  else
                //    trigCounter = selected.trigs.Count;
                //Turns datarows into Triggers
                while (counter != (datarows - 1))
                {
                    String pauseValue = dataGridView1.Rows[counter].Cells[2].Value.ToString();
                    if (pauseValue == "True")
                        pause = true;

                    else
                        pause = false;

                    rotation = int.Parse(dataGridView1.Rows[counter].Cells[3].Value.ToString());
                    acceleration = int.Parse(dataGridView1.Rows[counter].Cells[4].Value.ToString());
                    deceleration = int.Parse(dataGridView1.Rows[counter].Cells[5].Value.ToString());
                    velocity = int.Parse(dataGridView1.Rows[counter].Cells[6].Value.ToString());
                    time = int.Parse(dataGridView1.Rows[counter].Cells[7].Value.ToString());
                    selected.TriggerAdd(plc, motor, pause, rotation, acceleration,deceleration, velocity, time);
                    /*
                    if ((counter+1) > trigCounter || trigCounter ==0) //if first item in list or new item
                    {
                        selected.TriggerAdd(plc, motor, pause, rotation, acceleration, velocity, time);
                        log.AddRow("Added trigger to cue " + selected, "plc", "motor", pause, rotation, acceleration, velocity, time);
                    }
                   else //changing edited rows
                    {
                        if (selected.trigs[counter].PLC() != plc)
                            selected.trigs[counter].rplc = plc;
                        if (selected.trigs[counter].Motor() != motor)
                            selected.trigs[counter].rmotor = motor;
                        if (selected.trigs[counter].Pause() != pause)
                            selected.trigs[counter].rpause = pause;
                        if (selected.trigs[counter].Rotation() != rotation)
                            selected.trigs[counter].rrotation = rotation;
                        if (selected.trigs[counter].Acceleration() != acceleration)
                            selected.trigs[counter].raccel = acceleration;
                        if (selected.trigs[counter].Velocity() != velocity)
                            selected.trigs[counter].rvel = velocity;
                        if (selected.trigs[counter].Time() != time)
                            selected.trigs[counter].rtime = time;
                    }
                    */
                    counter = counter + 1;

                }
            }
        }


        //Testing Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                if (textBox8.Text == "")
                    textBox8.Text = "0";
                if (textBox9.Text == "")
                    textBox9.Text = "0";
                if (textBox19.Text == "")
                    textBox19.Text = "0";
                if (textBox29.Text == "")
                    textBox29.Text = "0";
                if (textBox1.Text == "")
                    textBox1.Text = "0";

                plc = comboBox2.Text;
                motor = comboBox1.Text;
                pause = Pause_10.Checked;
                rotation = int.Parse(textBox8.Text);
                acceleration = int.Parse(textBox9.Text);
                deceleration = int.Parse(textBox1.Text);
                velocity = int.Parse(textBox19.Text);
                time = int.Parse(textBox29.Text);

                DialogResult result = MessageBox.Show("Are you sure you want to test these values?\n" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees\n Acceleration: " + acceleration + " m/s^2\n Deceleration: " + deceleration + "m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (ValidateLimits(rotation, acceleration, deceleration, velocity)) //validates data
                    {
                        log.AddRow("Testing this event" + " Pause: " + pause + "\n Rotation: " + rotation + " degrees\n Acceleration: " + acceleration + " m/s^2\n Deceleration:" + deceleration + "m/s^2\n Velocity: " + velocity + " m/s\n Time: " + time + " sec\n on motor" + motor);
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
            //int acceleration = 0;
            SetpointVelocity setPointVelocity = new SetpointVelocity();
            int acceleration = Convert.ToInt16(textBox9.Text);
            float f;
            int runTime = Convert.ToInt16(textBox29.Text);
            //System.Timers.Timer timer = new System.Timers.Timer(runTime);

            if (string.IsNullOrWhiteSpace(textBox9.Text) || !float.TryParse(textBox9.Text, out f) || Convert.ToInt16(textBox9.Text) == 0 || acceleration == 0)
            {
                MessageBox.Show("Must input a non-zero decimal value for acceleration!");
            }
            else
            {
                acceleration = Convert.ToInt16(textBox9.Text);
                //logForm.AddRow("Changed acceleration to " + accelerationTextBox.Text, "", "", 0, setPointVelocity.GetSetValue);
            }
            if (string.IsNullOrWhiteSpace(textBox19.Text) || !float.TryParse(textBox19.Text, out f))
            {
                MessageBox.Show("Must input a decimal value for velocity!");
            }
            else if (acceleration != 0)
            {
                setPointVelocity.GetSetValue = Convert.ToInt16(textBox19.Text);
            }

            ushort ID = 8;
            byte unit = 0;
            ushort StartAddress = Convert.ToUInt16(startAddress); //ReadStartAdr();           

            data = GetDataNew(Convert.ToByte(size));

            byte[] bytes = BitConverter.GetBytes(setPointVelocity.GetSetValue);
            byte[] bytes2 = BitConverter.GetBytes(acceleration);
            ControlWord_I3 wordi3 =new ControlWord_I3();
            
            Console.WriteLine(wordi3.GetSetValue);
            data[0] = 0; //byte 0 of Control 1
            data[1] = 0; //byte 1 of Control 1
            data[2] = 0; //byte 0 of Binary Outputs
            data[3] = 0;  //byte 1 of Binary Outputs
            data[4] = 10;  //byte 0 of Control 3
            data[5] = 6;   //byte 1 of Control 3
            Console.WriteLine(data[4] + " " + data[5]);
             data[6] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[1];  // byte 1 of Velocity
           
            data[7] = BitConverter.GetBytes(setPointVelocity.GetSetValue)[0];  // byte 0 of velocity
            data[8] = BitConverter.GetBytes(acceleration)[1];  // byte 1 of Velocity
            data[9] = BitConverter.GetBytes(acceleration)[0];  // byte 0 of velocity
            data[10] = BitConverter.GetBytes(deceleration)[1];
            data[11] = BitConverter.GetBytes(deceleration)[0];

            int start = DateTime.Now.Second;
            int counter = start+1;
            int howLong = start;
            int endTime = howLong + runTime;

            while (howLong < endTime)
            {
                MBmaster.ReadWriteMultipleRegister(ID, unit, StartAddress, 12, StartAddress, data, ref result);
                howLong = DateTime.Now.Second;
                if (howLong == counter)
                {
                    log.AddRow("velocity is " + result[6] + "" + result[7]);// + result[7]);
                    long position = result[12] * 256 * 256 * 256 + result[13] * 256 * 256 + result[14] * 256 + result[15];
                    log.AddRow("Position is: " + position);
                    counter++;
                }
            }
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
            //dataGridView1.CurrentCell = dataGridView1(0, NewIndex);
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
            if (t != null)
            {
                t.Suspend();
                log.AddRow("Emergency Stop Called");
            }
        }

        //Returns true if valid data
        public Boolean ValidateLimits(int Rotation, int Acceleration,int Deceleration, int Velocity)
        {
            Motor motorSelected = (Motor)comboBox1.SelectedItem;
            //int valRotate = motorSelected.Rotation_Limit();
            int valAcceleration = motorSelected.Acceleration_Limit();
            int valDecel = motorSelected.Deceleration_Limit();
            int valVelocity = motorSelected.Velocity_Limit();
            if (Acceleration <= valAcceleration && Velocity <= valVelocity && Velocity >= 0 && Acceleration >=0 && Deceleration <= valDecel)
            {
                return true;
            }

            // if (Rotation > valRotate)
            //   MessageBox.Show("You entered a Rotation greater then the limit of " + valRotate, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (Acceleration > valAcceleration)
            {
                MessageBox.Show("You entered a Acceleration greater then the limit of " + valAcceleration, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Acceleration input");
            }
            if (Deceleration > valDecel)
            {
                MessageBox.Show("You entered a Deceleration greater then the limit of " + valDecel, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Deceleration input");
            }
            if (Velocity < 0)
            {
                MessageBox.Show("You entered a Acceleration less than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Acceleration input");
            }
            if (Velocity > valVelocity)
            {
                MessageBox.Show("You entered a Velocity greater then the limit of " + valVelocity, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Velocity input");
            }
            if (Velocity < 0)
            {
                MessageBox.Show("You entered a Velocity less than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                log.AddRow("Invalid Velocity input");
            }
            return false;
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

        private void comboBox1_Click(object sender, EventArgs e)
        {
            foreach (Motor motors in MotorConfiguration.motors)
            {
                if (!comboBox1.Items.Contains(motors))
                {
                    comboBox1.Items.Add(motors);
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}