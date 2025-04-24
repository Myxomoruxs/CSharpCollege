﻿using System;
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
    public partial class X : Form
    {
        private int seconds = 0;
        public X()
        {
            InitializeComponent();
            timerSec.Interval = 100;
            UpdateTimerDisplay();
        }
        private void UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            laiblSec.Text = time.ToString(@"hh\:mm\:ss");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timerSec.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerSec.Stop();
            UpdateTimerDisplay();
        }

        private void laiblSec_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void timelast_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void X_Load(object sender, EventArgs e)
        {

        }

        private void DisplayLabel_Click(object sender, EventArgs e)
        {
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            TimeSpan currentTime = TimeSpan.FromSeconds(seconds);
            string lapTime = currentTime.ToString(@"hh\:mm\:ss");

            
            timelast.Items.Add($"Круг {timelast.Items.Count + 1}: {lapTime}");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void timerSec_Tick_1(object sender, EventArgs e)
        {
            seconds++;
            UpdateTimerDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            TimeSpan currentTime = TimeSpan.FromSeconds(seconds);
            string lapTime = currentTime.ToString(@"hh\:mm\:ss");

            
           timelast.Items.Add($"Круг {timelast.Items.Count + 1}: {lapTime}");
        }


        private void listKrugi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSbros_Click(object sender, EventArgs e)
        {

            seconds = 0;
            timelast.Items.Clear();
            UpdateTimerDisplay();
        }

        private void buttonStar_Click(object sender, EventArgs e)
        {
            timerSec.Start();
        }

        private void buttonStop_Click_1(object sender, EventArgs e)
        {
            timerSec.Stop();
            UpdateTimerDisplay();
        }

        private void X_Load_1(object sender, EventArgs e)
        {

        }

        private void timelast_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

