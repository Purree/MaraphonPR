using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveMap
{
    public partial class RunnerMenuForm : Form
    {
        public RunnerMenuForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            RegisterForAnEvent form = new RegisterForAnEvent();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            change_panel_visiability();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            change_panel_visiability();
        }

        private void change_panel_visiability()
        {
            panel3.Visible = !panel3.Visible;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            EditRunnerProfileForm form = new EditRunnerProfileForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            MyRaceResultsForm form = new MyRaceResultsForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            MySponsorshipForm form = new MySponsorshipForm();
            form.Show();
        }
    }
}
