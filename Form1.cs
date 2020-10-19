using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalColorClock
{
    public partial class Form1 : Form
    {
        int dsec = 0;
        int sec = 0;
        int min = 0;
        int hou = 0;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();            
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            dsec += 1;
            if(dsec == 10)
            {
                dsec = 0;
                sec += 1;
                ChangeBackgroundColor();
            }
            if(sec == 60)
            {
                sec = 0;
                min += 1;
            }
            if(min == 60)
            {
                min = 0;
                hou += 1;
            }
            if(hou == 24)
            {
                hou = 0;
            }            
            UpdateClockDisplay();
        }

        private void UpdateClockDisplay()
        {
            string timeText;
            timeText = hou.ToString("00") + ":";
            timeText += min.ToString("00") + ":";
            timeText += sec.ToString("00") + ":";
            timeText += dsec.ToString("0");
            ClockDisplay.Text = timeText;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ClockTimer.Start();
            StartButton.Text = "Start";
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            ClockTimer.Stop();
            StartButton.Text = "Resume";
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClockTimer.Stop();
            dsec = 0;
            sec = 0;
            min = 0;
            hou = 0;
            UpdateClockDisplay();
            StartButton.Text = "Start";
        }

        private void ChangeBackgroundColor()
        {
            int redValue = rand.Next(0, 256);
            int greenValue = rand.Next(0, 256);
            int blueValue = rand.Next(0, 256);
            this.BackColor = Color.FromArgb(redValue, greenValue, blueValue);
        }
    }
}
