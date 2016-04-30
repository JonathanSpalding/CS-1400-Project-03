// Author: Jonathan Spalding
// Assignment: Project 03
// Instructor Roger deBry
// Clas: CS 1400
// Date Written: 2/7/2016
//
// "I declare that the following source code was written solely by me. I understand that copying any source code, in whole or in part, constitutes cheating, and that I will receive a zero on this project if I am found in violation of this policy."
//----------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // The button1_Click Method
        // Purpose: To add 25% transit time for a delivery in military time.
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void button1_Click(object sender, EventArgs e)
        {
            //State All Constants
            const int HUN_PART = 100;
            const double DELAY = .25;
            const int HOUR = 60;
            //convert input from a string to integers.
            int oldStart = int.Parse(startTime.Text);
            int oldEnd = int.Parse(endTime.Text);
            //split the hours and minutes for the start time, and convert the hours into minutes, then add it together.
            int oldStartHours = (oldStart / HUN_PART) * HOUR;
            int oldStartMins = oldStart % HUN_PART;
            int oldStartTotal = oldStartHours + oldStartMins;
            //repeat for the oldEndHours.
            int oldEndHours = (oldEnd / HUN_PART) * HOUR;
            int oldEndMins = oldEnd % HUN_PART;
            int oldEndTotal = oldEndHours + oldEndMins;
            //subtract the arrival time from the time left to find how long the transit is.
            int arrivalTransit = oldEndTotal - oldStartTotal;
            //multiply by .25 to add 25% delay.
            int delayTime = Convert.ToInt32(Math.Floor(arrivalTransit * DELAY)); //I had to round down or else my answer was always 1 higher than the example program.
            // add the delay plus the transit to the left time to find the new arrival time.
            int arrivalTimeTotal = arrivalTransit + delayTime + oldStartTotal;
            //to put it back in the military time format, divide it by 60, then multiply by 100, and then add on the minutes. (This is the opposite of what you do to split the minutes and hours before.
            int total = arrivalTimeTotal / HOUR * HUN_PART + arrivalTimeTotal % HOUR;
            //convert to a string, then output in the output box
            string outStr = $"{total:D4}";
            arrivalTime.Text = outStr;
        }
        // The exitToolStripMenuItem1_Click Method
        // Purpose: Display a pop up box when you click About
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // The aboutToolStripMenuItem_Click Method
        // Purpose: Display a pop up box when you click About
        // Parameters: The sending object, and the event arguments
        // Returns: none
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jonathan Spalding\nCS1400\nProjecct 03");
        }
    }
}