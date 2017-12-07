using System;
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

<<<<<<< HEAD
=======
            // Application.Run(p);
>>>>>>> a99e1d99940a2248cc67871b1734d6cdb7d0ba82
            playView = new PlayView();
            cueEdit = new Cue_Editor();
            cueEdit.Hide();
            motorConf = new MotorConfiguration();
            motorConf.Hide();
            Application.Run(playView);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a99e1d99940a2248cc67871b1734d6cdb7d0ba82
