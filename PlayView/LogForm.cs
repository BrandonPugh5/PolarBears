using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PolarBearsProgram
{
    public partial class LogForm : Form
    {
       
        public LogForm()
        {
            InitializeComponent(); 
        }
        

        public void AddRow(string action, string plc,string motor_name,Boolean pause, int angle_rotation,int accelerate, int velocity, int duration)
        {
            string logName = DateTime.Now.ToString("M-d-yyyy");
            string path = (@"C:\Users\shop\Desktop\All Together Gui\Log Files\"+logName+".txt");
            //string path = (@"C:\Users\Elisa\Desktop\Log Files\" + logName + ".txt");
            string time = DateTime.Now.ToString("h:mm:ss tt"); //gets current time
            string date = DateTime.Now.ToString("M/d/yyyy"); //gets current date

            if (!File.Exists(path))
            {
                //File.Create(path);
           
                TextWriter tw = new StreamWriter(File.Create(path));
                tw.WriteLine("Log File");
                tw.WriteLine((date + " " + time) + "; " + action + "; PLC:" + plc + "; Motor:" + motor_name + "; Pause:"+ pause +"; Rotation:" + angle_rotation + " degrees; Acceleration:"+accelerate+"m/s^2; Velocity: " + velocity+" m/s; Duration: "+duration +"sec");
                tw.Close();
            }

          

                else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine((date + " " + time) + "; " + action + "; PLC:" + plc+ "; Motor:" + motor_name + "; Pause:" + pause + "; Rotation:" + angle_rotation + " degrees; Acceleration:" + accelerate + "m/s^2; Velocity: " + velocity + " m/s; Duration: " + duration + "sec");
                    tw.Close();
                }
            }

            dataGridView1.Rows.Add((date + " " + time),action,plc, motor_name,pause, angle_rotation,accelerate,velocity);
        }


        public void AddRow(string action)
        {
            string logName = DateTime.Now.ToString("M-d-yyyy");
            string path = (@"C:\Users\shop\Desktop\All Together Gui\Log Files\" + logName + ".txt");
            //string path = (@"C:\Users\spug\Desktop\Log Files\" + logName + ".txt");
            string time = DateTime.Now.ToString("h:mm:ss tt"); //gets current time
            string date = DateTime.Now.ToString("M/d/yyyy"); //gets current date

            if (!File.Exists(path))
            {
                //File.Create(path);

                TextWriter tw = new StreamWriter(File.Create(path));
                tw.WriteLine("Log File");
                tw.WriteLine((date + " " + time) + "; " + action);
                tw.Close();
            }



            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine((date + " " + time) + "; " + action);
                    tw.Close();
                }
            }

            dataGridView1.Rows.Add((date + " " + time), action);
        }

        private void LogForm_Load(object sender, EventArgs e)
        {

        }
    }
}
