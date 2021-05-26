using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MiPlayer
{
    public partial class MiPlayerForm : Form
    {
        [DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

        [Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        private string playWavPath = "";

        public MiPlayerForm(string path)
        {
            playWavPath = path;

            InitializeComponent();

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            Shown += MiPlayerForm_Shown;
        }

        private void MiPlayerForm_Shown(object sender, EventArgs e)
        {
            Hide();

            PlaySound(playWavPath, new IntPtr(),
                (PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_SYNC | PlaySoundFlags.SND_NODEFAULT));

            Close();
        }
    }
}
