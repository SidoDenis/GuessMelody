using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Kursovaja
{
    public partial class fMessage : Form
    {
        int timeAnswer = 5;

        public fMessage()
        {
            InitializeComponent();
        }

        private void fMessage_Load(object sender, EventArgs e)
        {
            timeAnswer = 5;
            timer1.Start();
            lbltimer.Text = timeAnswer.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeAnswer--;
            lbltimer.Text = timeAnswer.ToString();
            if (timeAnswer == 0)
            {
                timer1.Stop();
                SoundPlayer sp = new SoundPlayer("Properties\\5050.wav");
                sp.Play();
            }
        }

        private void fMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void lblShowAnswer_Click(object sender, EventArgs e)
        {
            var mp3file = TagLib.File.Create(Victorina.answer);

            lblShowAnswer.Text = mp3file.Tag.FirstPerformer + "-" + mp3file.Tag.Title;
        }
    }
}
