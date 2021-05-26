using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPlayer
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string playWavPath = @"C:\Windows\Media\Windows Ding.wav";
            if (args != null && args.Length > 0)
            {
                playWavPath = args[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MiPlayerForm(playWavPath));
        }
    }
}
