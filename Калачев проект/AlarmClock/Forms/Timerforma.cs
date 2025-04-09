using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock.Forms
{
    public partial class Timerforma : Form
    {
        private int seconds = 0;
        public Timerforma()
        {
            InitializeComponent();
            Timer2.Interval = 10;
            UpdateTimerDisplay();
        }
        private void UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            Timer1.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Timer2.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Timer2.Stop();
            UpdateTimerDisplay();
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            TimeSpan currentTime = TimeSpan.FromSeconds(seconds);
            string lapTime = currentTime.ToString(@"hh\:mm\:ss");

            // Добавляем круг в ListBox
            listBox1.Items.Add($"Круг {listBox1.Items.Count + 1}: {lapTime}");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            seconds = 0;
            listBox1.Items.Clear();
            UpdateTimerDisplay();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            UpdateTimerDisplay();
        }
    }
}
