using System;
using System.Collections.Generic;
using System.Text;
using ModbusTCP;
using ModbusTester;
using static System.Net.Mime.MediaTypeNames;

namespace ModbusTester
{

    class FieldbusInputData
    {

        public ControlWord_I1 Control_I1 { get; set; }
        public BinaryOutputs_I2 BinaryOut_I2 { get; set; }
        public ControlWord_I3 Control_I3 { get; set; }
        public SetpointVelocity SetpointVelocity { get; set; }       //Should this be of type SetpointVelocity?
        public Acceleration Acceleration { get; set; }
        public Deceleration Deceleration { get; set; }
        public Setpoint_Position Setpoint_Position { get; set; }
        public SubcontrolWord Subcontrol { get; set; }
        public BinaryOutputs_I10 BinaryOut_I10 { get; set; }
        public SetpointValue2 SetpointValue { get; set; }
        //data[0] = 0; //byte 0 of Control 1
        //data[1] = 0; //byte 1 of Control 1
        //data[2] = 0; //byte 0 of Binary Outputs
        //data[3] = 0;  //byte 1 of Binary Outputs
        //data[4] = 10;  //byte 0 of Control 3
        //data[5] = 6;   //byte 1 of Control 3
        //data[6] = BitConverter.GetBytes(velocity)[1];  // byte 1 of Velocity
        //data[7] = BitConverter.GetBytes(velocity)[0];  // byte 0 of velocity
        //data[8] = BitConverter.GetBytes(acceleration)[1];  // byte 1 of Velocity
        //data[9] = BitConverter.GetBytes(acceleration)[0];  // byte 0 of velocity
        //data[10] = 0;

        public byte[] GetValue
        {
            get
            {
                byte[] bytes = new byte[20];
                //when we return the setpoint velocity, acceleration and deceleration
                //make sure you swap the bytes
                bytes[0] = BitConverter.GetBytes(Control_I1.GetSetValue)[0];
                bytes[1] = BitConverter.GetBytes(Control_I1.GetSetValue)[1];
                bytes[2] = BitConverter.GetBytes(BinaryOut_I2.GetSetValue)[0];
                bytes[3] = BitConverter.GetBytes(BinaryOut_I2.GetSetValue)[1];
                bytes[4] = BitConverter.GetBytes(Control_I3.GetSetValue)[0];
                bytes[5] = BitConverter.GetBytes(Control_I3.GetSetValue)[1];
                bytes[6] = BitConverter.GetBytes(SetpointVelocity.GetSetValue)[1];
                bytes[7] = BitConverter.GetBytes(SetpointVelocity.GetSetValue)[0];
                bytes[8] = BitConverter.GetBytes(Acceleration.GetSetValue)[1];
                bytes[9] = BitConverter.GetBytes(Acceleration.GetSetValue)[0];
                bytes[10] = BitConverter.GetBytes(Deceleration.GetSetValue)[1];
                bytes[11] = BitConverter.GetBytes(Deceleration.GetSetValue)[0];
                bytes[12] = BitConverter.GetBytes(Setpoint_Position.GetSetValue)[1];
                bytes[13] = BitConverter.GetBytes(Setpoint_Position.GetSetValue)[0];
                bytes[14] = BitConverter.GetBytes(Subcontrol.GetSetValue)[0];
                bytes[15] = BitConverter.GetBytes(Subcontrol.GetSetValue)[1];
                bytes[16] = BitConverter.GetBytes(BinaryOut_I10.GetSetValue)[0];
                bytes[18] = BitConverter.GetBytes(BinaryOut_I10.GetSetValue)[1];
                bytes[19] = BitConverter.GetBytes(SetpointValue.GetSetValue)[1];
                bytes[20] = BitConverter.GetBytes(SetpointValue.GetSetValue)[0];
                //TODO - Continue this for the remainder of the data
                return bytes;
            }
        }

    }

    class FieldbusOutputData
    {
        public StatusWord_O1 Status_O1 { get; set; }
        public BinaryInputs_O2 Binary_O2 { get; set; }
        public Statusword_O3 Status_O3 { get; set; }
        public ActualVelocity ActualVelocity { get; set; }
        public OutputCurrent OutputCurrent { get; set; }
        public Reversed Reversed { get; set; }
        public Actual_Position Actual_Position { get; set; }
        public SubstatusWord substatusWord { get; set; }
        public BinaryInputs_O10 BinaryInputs_O10 { get; set; }
        public ActualValue_02 actualValue2 { get; set; }

        public byte[] GetValue
        {
            get
            {
                byte[] bytes = new byte[12];
                //when we return the setpoint velocity, acceleration and deceleration
                //make sure you swap the bytes
                bytes[0] = BitConverter.GetBytes(Status_O1.GetSetValue)[0];
                bytes[1] = BitConverter.GetBytes(Status_O1.GetSetValue)[1];
                bytes[2] = BitConverter.GetBytes(Binary_O2.GetSetValue)[0];
                bytes[3] = BitConverter.GetBytes(Binary_O2.GetSetValue)[1];
                bytes[4] = BitConverter.GetBytes(Status_O3.GetSetValue)[0];
                bytes[5] = BitConverter.GetBytes(Status_O3.GetSetValue)[1];
                bytes[6] = BitConverter.GetBytes(ActualVelocity.GetSetValue)[1];
                bytes[7] = BitConverter.GetBytes(ActualVelocity.GetSetValue)[0];
                bytes[8] = BitConverter.GetBytes(OutputCurrent.GetSetValue)[1];
                bytes[9] = BitConverter.GetBytes(OutputCurrent.GetSetValue)[0];
                bytes[10] = BitConverter.GetBytes(Reversed.GetSetValue)[1];
                bytes[11] = BitConverter.GetBytes(Reversed.GetSetValue)[0];
                bytes[12] = BitConverter.GetBytes(Actual_Position.GetSetValue)[1];
                bytes[13] = BitConverter.GetBytes(Actual_Position.GetSetValue)[0];
                bytes[14] = BitConverter.GetBytes(substatusWord.GetSetValue)[0];
                bytes[15] = BitConverter.GetBytes(substatusWord.GetSetValue)[1];
                bytes[16] = BitConverter.GetBytes(BinaryInputs_O10.GetSetValue)[0];
                bytes[18] = BitConverter.GetBytes(BinaryInputs_O10.GetSetValue)[1];
                bytes[19] = BitConverter.GetBytes(actualValue2.GetSetValue)[1];
                bytes[20] = BitConverter.GetBytes(actualValue2.GetSetValue)[0];
                //bytes[6] = BitConverter.GetBytes(ActualVelocity.GetSetValue)[0];
                //TODO - Continue this for the remainder of the data
                return bytes;
            }
        }
    }

    class ControlWord_I1
    {
        public ControlWord_I1()
        {

        }


        public bool Download_Dataset { get; set; }
        public bool Upload_Dataset { get; set; }
        public bool Upload_Dataset_And_Autoreload { get; set; }
        public bool Simulation_Mode_Off { get; set; }
        public bool Auto_Configuration_Off { get; set; }
        public bool Bit05 { get; set; }
        public bool Reboot_System { get; set; }
        public bool Bit07 { get; set; }
        public bool Bit08 { get; set; }
        public bool Bit09 { get; set; }
        public bool Bit10 { get; set; }
        public bool Bit11 { get; set; }
        public bool Bit12 { get; set; }
        public bool Bit13 { get; set; }
        public bool UserBit1 { get; set; }
        public bool UserBit2 { get; set; }

        //bit  0 : Controller Inhibit
        //bit  1 : Enable Rapid Start

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (Download_Dataset ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (Upload_Dataset ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (Upload_Dataset_And_Autoreload ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (Simulation_Mode_Off ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Auto_Configuration_Off ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (Bit05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (Reboot_System ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (Bit07 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (Bit08 ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (Bit09 ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (Bit10 ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (Bit11 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (Bit12 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (Bit13 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (UserBit1 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (UserBit2 ? 1 : 0)));
            }
            set
            {
                Download_Dataset = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                Upload_Dataset = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                Upload_Dataset_And_Autoreload = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                Simulation_Mode_Off = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                Auto_Configuration_Off = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                Bit05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                Reboot_System = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                Bit07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
                Bit08 = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                Bit09 = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                Bit10 = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                Bit11 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                Bit12 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                Bit13 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                UserBit1 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                UserBit2 = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    class BinaryOutputs_I2    //Second row
    {
        public bool DO00 { get; set; }
        public bool DO01 { get; set; }
        public bool DO02 { get; set; }
        public bool DO03 { get; set; }
        public bool DO04 { get; set; }
        public bool DO05 { get; set; }
        public bool DO06 { get; set; }
        public bool DO07 { get; set; }
        public bool DO08 { get; set; }
        public bool DO09 { get; set; }
        public bool DO10 { get; set; }
        public bool DO11 { get; set; }
        public bool DO12 { get; set; }
        public bool DO13 { get; set; }
        public bool DO14 { get; set; }
        public bool DO15 { get; set; }

        public BinaryOutputs_I2()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (DO00 ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (DO01 ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (DO02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (DO03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (DO04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (DO05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (DO06 ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (DO07 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (DO08 ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (DO09 ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (DO10 ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (DO11 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (DO12 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (DO13 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (DO14 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (DO15 ? 1 : 0)));
            }
            set
            {
                DO00 = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                DO01 = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                DO02 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                DO03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                DO04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                DO05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                DO06 = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                DO07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
                DO08 = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                DO09 = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                DO10 = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                DO11 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                DO12 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                DO13 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                DO14 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                DO15 = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    public class ControlWord_I3
    {


        public ControlWord_I3()
        {
            EnableStop = true;
            EnableRapidStop = true;
            Positive = true;
            Mode2tothe0 = true;
        }


        public bool ControllerInhibit { get; set; }
        public bool EnableRapidStop { get; set; }
        public bool EnableStop { get; set; }
        public bool Bit3 { get; set; }
        public bool Bit4 { get; set; }
        public bool RelBrake { get; set; }
        public bool ErrorReset { get; set; }
        public bool Bit7 { get; set; }
        public bool Start { get; set; }
        public bool Positive { get; set; }
        public bool Negative { get; set; }
        public bool Mode2tothe0 { get; set; }
        public bool Mode2tothe1 { get; set; }
        public bool Mode2tothe2 { get; set; }
        public bool Mode2tothe3 { get; set; }
        public bool SWLS { get; set; }

        //bit  0 : Controller Inhibit
        //bit  1 : Enable Rapid Start

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (ControllerInhibit ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (EnableRapidStop ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (EnableStop ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (Bit3 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Bit4 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (RelBrake ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (ErrorReset ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (Bit7 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (Start ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (Positive ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (Negative ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (Mode2tothe0 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (Mode2tothe1 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (Mode2tothe2 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (Mode2tothe3 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (SWLS ? 1 : 0)));
            }
            set
            {
                ControllerInhibit = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
               
                EnableRapidStop = ((value & (int)(Math.Pow(2, 1))).Equals(0) ? false : true);
                EnableStop = ((value & (int)(Math.Pow(2, 2))).Equals(0) ? false : true);
                Bit3 = ((value & (int)(Math.Pow(2, 3))).Equals(0) ? false : true);
                Bit4 = ((value & (int)(Math.Pow(2, 4))).Equals(0) ? false : true);
                RelBrake = ((value & (int)(Math.Pow(2, 5))).Equals(0) ? false : true);
                ErrorReset = ((value & (int)(Math.Pow(2, 6))).Equals(0) ? false : true);
                Bit7 = ((value & (int)(Math.Pow(2, 7))).Equals(0) ? false : true);
                Start = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                Positive = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                Negative = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                Mode2tothe0 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                Mode2tothe1 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                Mode2tothe2 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                Mode2tothe3 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                SWLS = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    //This Class belongs in a separate class file - overarching Control Class 


    //var cwordI1 = controlwordI1.GetSetValue()

    public class SetpointVelocity
    {

        int velocity;

        public SetpointVelocity()
        {
            velocity = 0;

        }



        public int GetSetValue
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
    }
    class Acceleration
    {

        int acceleration;

        public Acceleration()
        {
            acceleration = 0;

        }



        public int GetSetValue
        {
            get
            {
                return acceleration;
            }
            set
            {
                acceleration = value;
            }
        }
    }
    class Deceleration
    {

        int deceleration;

        public Deceleration()
        {
            deceleration = 0;

        }



        public int GetSetValue
        {
            get
            {
                return deceleration;
            }
            set
            {
                deceleration = value;
            }
        }
    }

    class Setpoint_Position
    {

        int setpoint;

        public Setpoint_Position()
        {
            setpoint = 0;

        }



        public int GetSetValue
        {
            get
            {
                return setpoint;
            }
            set
            {
                setpoint = value;
            }
        }
    }

    class SubcontrolWord
    {
        public bool ActivateTouchProbe { get; set; }
        public bool Bit01 { get; set; }
        public bool ActivateTorqueLimit { get; set; }
        public bool Bit03 { get; set; }
        public bool Bit04 { get; set; }
        public bool Bit05 { get; set; }
        public bool Bit06 { get; set; }
        public bool Bit07 { get; set; }

        //bit  0 : Controller Inhibit
        //bit  1 : Enable Rapid Start

        public SubcontrolWord()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (ActivateTouchProbe ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (Bit01 ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (ActivateTorqueLimit ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (Bit03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Bit04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (Bit05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (Bit06 ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (Bit07 ? 1 : 0)));
            }
            set
            {
                ActivateTouchProbe = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                Bit01 = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                ActivateTorqueLimit = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                Bit03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                Bit04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                Bit05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                Bit06 = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                Bit07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
            }
        }
    }

    class BinaryOutputs_I10
    {
        public bool DO00 { get; set; }
        public bool DO01 { get; set; }
        public bool DO02 { get; set; }
        public bool DO03 { get; set; }
        public bool DO04 { get; set; }
        public bool DO05 { get; set; }
        public bool DO06 { get; set; }
        public bool DO07 { get; set; }
        public bool DO10 { get; set; }
        public bool DO11 { get; set; }
        public bool DO12 { get; set; }
        public bool DO13 { get; set; }
        public bool DO14 { get; set; }
        public bool DO15 { get; set; }
        public bool DO16 { get; set; }
        public bool DO17 { get; set; }

        //bit  0 : Controller Inhibit
        //bit  1 : Enable Rapid Start

        public BinaryOutputs_I10()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0))* (DO00 ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (DO01 ? 1 : 0))
                        | ((int)(Math.Pow(2,2)) * (DO02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (DO03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (DO04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (DO05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6))* (DO06 ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (DO07 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (DO10 ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (DO11 ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (DO12 ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (DO13 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (DO14 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (DO15 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (DO16 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (DO17 ? 1 : 0));
            }
            set
            {
                DO00 = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                DO01 = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                DO02 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                DO03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                DO04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                DO05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                DO06 = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                DO07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
                DO10 = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                DO11 = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                DO12 = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                DO13 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                DO14 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                DO15 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                DO16 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                DO17 = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    class SetpointValue2
    {
        int value;

        public SetpointValue2()
        {

        }

        public int GetSetValue
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

    }


    class StatusWord_O1
    {
        public bool Maintenance_switch { get; set; }
        public bool Toggle { get; set; }
        public bool Bit02 { get; set; }
        public bool UserBit { get; set; }
        public bool Dataset_exists { get; set; }
        public bool Autoreload_config { get; set; }
        public bool Warning { get; set; }
        public bool Error { get; set; }

        public StatusWord_O1()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (Maintenance_switch ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (Toggle ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (Bit02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (UserBit ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Dataset_exists ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (Autoreload_config ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (Warning ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (Error ? 1 : 0)));
            }
            set
            {
                Maintenance_switch = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                Toggle = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                Bit02 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                UserBit = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                Dataset_exists = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                Autoreload_config = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                Warning = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                Error = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
            }
        }
    }

    class BinaryInputs_O2
    {
        public bool DI00 { get; set; }
        public bool DI01 { get; set; }
        public bool DI02 { get; set; }
        public bool DI03 { get; set; }
        public bool DI04 { get; set; }
        public bool DI05 { get; set; }
        public bool DI06 { get; set; }
        public bool DI07 { get; set; }
        public bool DI08 { get; set; }
        public bool DI09 { get; set; }
        public bool DI10 { get; set; }
        public bool DI11 { get; set; }
        public bool DI12 { get; set; }
        public bool DI13 { get; set; }
        public bool DI14 { get; set; }
        public bool DI15 { get; set; }

        public BinaryInputs_O2()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (DI00 ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (DI01 ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (DI02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (DI03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (DI04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (DI05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (DI06 ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (DI07 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (DI08 ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (DI09 ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (DI10 ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (DI11 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (DI12 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (DI13 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (DI14 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (DI15 ? 1 : 0)));
            }
            set
            {
                DI00 = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                DI01 = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                DI02 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                DI03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                DI04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                DI05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                DI06 = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                DI07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
                DI08 = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                DI09 = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                DI10 = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                DI11 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                DI12 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                DI13 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                DI14 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                DI15 = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    class Statusword_O3
    {
        public bool Motor_turning { get; set; }
        public bool Inverter_ready { get; set; }
        public bool Referenced { get; set; }
        public bool Setpoint_value_reached { get; set; }
        public bool Brake_released { get; set; }
        public bool Error_FC { get; set; }
        public bool Warning { get; set; }
        public bool Error_Application { get; set; }

        public Statusword_O3()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (Motor_turning ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (Inverter_ready ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (Referenced ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (Setpoint_value_reached ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Brake_released ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (Error_FC ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (Warning ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (Error_Application ? 1 : 0)));
            }
            set
            {
                Motor_turning = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                Inverter_ready = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                Referenced = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                Setpoint_value_reached = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                Brake_released = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                Error_FC = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                Warning = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                Error_Application = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
            }
        }
    }

    public class ActualVelocity
    {
        int velocity;

        public ActualVelocity()
        {
            velocity = 0;

        }

        public int GetSetValue
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
    }

    class OutputCurrent
    {

        int current;

        public OutputCurrent()
        {
            current = 0;

        }

        public int GetSetValue
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }
    }

    class Reversed
    {

        int reversed;

        public Reversed()
        {
            reversed = 0;

        }

        public int GetSetValue
        {
            get
            {
                return reversed;
            }
            set
            {
                reversed = value;
            }
        }
    }

    class Actual_Position
    {

        int actual_position;

        public Actual_Position()
        {
            actual_position = 0;

        }

        public int GetSetValue
        {
            get
            {
                return actual_position;
            }
            set
            {
                actual_position = value;
            }
        }
    }

    class SubstatusWord
    {
        public bool TouchProbe_active { get; set; }
        public bool TouchProbe_detected { get; set; }
        public bool Bit02 { get; set; }
        public bool Bit03 { get; set; }
        public bool Bit04 { get; set; }
        public bool Bit05 { get; set; }
        public bool HWLSpos { get; set; }
        public bool HWLSneg { get; set; }

        public SubstatusWord()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (TouchProbe_active ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (TouchProbe_detected ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (Bit02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (Bit03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (Bit04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (Bit05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (HWLSpos ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (HWLSneg ? 1 : 0)));
            }
            set
            {
                TouchProbe_active = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                TouchProbe_detected = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                Bit03 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                Bit03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                Bit04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                Bit05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                HWLSpos = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                HWLSneg = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
            }
        }
    }

    class BinaryInputs_O10
    {
        public bool DI00 { get; set; }
        public bool DI01 { get; set; }
        public bool DI02 { get; set; }
        public bool DI03 { get; set; }
        public bool DI04 { get; set; }
        public bool DI05 { get; set; }
        public bool DI06 { get; set; }
        public bool DI07 { get; set; }
        public bool DI10 { get; set; }
        public bool DI11 { get; set; }
        public bool DI12 { get; set; }
        public bool DI13 { get; set; }
        public bool DI14 { get; set; }
        public bool DI15 { get; set; }
        public bool DI16 { get; set; }
        public bool DI17 { get; set; }

        public BinaryInputs_O10()
        {

        }

        public int GetSetValue
        {
            get
            {
                return ((int)(Math.Pow(2,0)) * (DI00 ? 1 : 0)) | ((int)(Math.Pow(2,1)) * (DI01 ? 1 : 0)
                        | ((int)(Math.Pow(2,2)) * (DI02 ? 1 : 0)) | ((int)(Math.Pow(2,3)) * (DI03 ? 1 : 0))
                        | ((int)(Math.Pow(2,4)) * (DI04 ? 1 : 0)) | ((int)(Math.Pow(2,5)) * (DI05 ? 1 : 0))
                        | ((int)(Math.Pow(2,6)) * (DI06 ? 1 : 0)) | ((int)(Math.Pow(2,7)) * (DI07 ? 1 : 0))
                        | ((int)(Math.Pow(2,8)) * (DI10 ? 1 : 0)) | ((int)(Math.Pow(2,9)) * (DI11 ? 1 : 0))
                        | ((int)(Math.Pow(2,10)) * (DI12 ? 1 : 0)) | ((int)(Math.Pow(2,11)) * (DI13 ? 1 : 0))
                        | ((int)(Math.Pow(2,12)) * (DI14 ? 1 : 0)) | ((int)(Math.Pow(2,13)) * (DI15 ? 1 : 0))
                        | ((int)(Math.Pow(2,14)) * (DI16 ? 1 : 0)) | ((int)(Math.Pow(2,15)) * (DI17 ? 1 : 0)));
            }
            set
            {
                DI00 = ((value & (int)(Math.Pow(2,0))).Equals(0) ? false : true);
                DI01 = ((value & (int)(Math.Pow(2,1))).Equals(0) ? false : true);
                DI02 = ((value & (int)(Math.Pow(2,2))).Equals(0) ? false : true);
                DI03 = ((value & (int)(Math.Pow(2,3))).Equals(0) ? false : true);
                DI04 = ((value & (int)(Math.Pow(2,4))).Equals(0) ? false : true);
                DI05 = ((value & (int)(Math.Pow(2,5))).Equals(0) ? false : true);
                DI06 = ((value & (int)(Math.Pow(2,6))).Equals(0) ? false : true);
                DI07 = ((value & (int)(Math.Pow(2,7))).Equals(0) ? false : true);
                DI10 = ((value & (int)(Math.Pow(2,8))).Equals(0) ? false : true);
                DI11 = ((value & (int)(Math.Pow(2,9))).Equals(0) ? false : true);
                DI12 = ((value & (int)(Math.Pow(2,10))).Equals(0) ? false : true);
                DI13 = ((value & (int)(Math.Pow(2,11))).Equals(0) ? false : true);
                DI14 = ((value & (int)(Math.Pow(2,12))).Equals(0) ? false : true);
                DI15 = ((value & (int)(Math.Pow(2,13))).Equals(0) ? false : true);
                DI16 = ((value & (int)(Math.Pow(2,14))).Equals(0) ? false : true);
                DI17 = ((value & (int)(Math.Pow(2,15))).Equals(0) ? false : true);
            }
        }
    }

    class ActualValue_02
    {
        int value;

        public ActualValue_02()
        {

        }

        public int GetSetValue
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

    }

    class Controller
    {
        string name;
        MotorControl motorCtrl;
        ReadBack readback;

        class MotorControl
        {
            //Copy and paste from FieldInput data fields - controlword_i1...etc.
            public ControlWord_I1 Control_I1;
            public BinaryOutputs_I2 BinaryOut_I2;
            public ControlWord_I3 Control_I3;
            public SetpointVelocity SetpointVelocity;       //Should this be of type SetpointVelocity?
            public Acceleration Acceleration;
            public Deceleration Deceleration;
            public Setpoint_Position Setpoint_Position;
            public SubcontrolWord Subcontrol;
            public BinaryOutputs_I10 BinaryOut_I10;
            public SetpointValue2 SetpointValue;
        }

        class ReadBack
        {
            public StatusWord_O1 Status_O1 { get; set; }
            public BinaryInputs_O2 Binary_O2 { get; set; }
            public Statusword_O3 Status_O3 { get; set; }
            public ActualVelocity ActualVelocity { get; set; }
            public OutputCurrent OutputCurrent { get; set; }
            public Reversed Reversed { get; set; }
            public Actual_Position Actual_Position { get; set; }
            public SubstatusWord substatusWord { get; set; }
            public BinaryInputs_O10 BinaryInputs_O10 { get; set; }
            public ActualValue_02 actualValue2 { get; set; }
        }
    }
}