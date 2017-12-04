<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolarBearsProgram
{
    static class Program
    {
        public static PlayView playView;
        public static Cue_Editor cueEdit;
        public static MotorConfiguration motorConf;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(p);
            playView = new PlayView();
            cueEdit = new Cue_Editor();
            cueEdit.Hide();
            motorConf = new MotorConfiguration();
            motorConf.Hide();
            Application.Run(playView);
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolarBearsProgram
{
    static class Program
    {
        public static PlayView playView;
        public static Cue_Editor cueEdit;
        public static MotorConfiguration motorConf;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Application.Run(p);
            playView = new PlayView();
            cueEdit = new Cue_Editor();
            cueEdit.Hide();
            motorConf = new MotorConfiguration();
            motorConf.Hide();
            Application.Run(playView);
        }
    }
}
>>>>>>> 6365cdd4c77164fbc047a2045ed1878b9bafda58
