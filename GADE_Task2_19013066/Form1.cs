using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_Task2_19013066
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GameEngine Engine;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine = new GameEngine(20,10, txtUnitInfo, DisplayMap);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text = "Round" + Engine.Round.ToString();
            Engine.Update();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Engine.SaveRead();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Engine.Save();
        }

        private void lblRound_Click(object sender, EventArgs e)
        {

        }
    }
}
