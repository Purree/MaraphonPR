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
    public partial class FindOutMoreInformationForm : Form
    {
        public FindOutMoreInformationForm()
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
            BMRCalculator form = new BMRCalculator();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            BMICalculator form = new BMICalculator();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            ListOfCharitiesForm form = new ListOfCharitiesForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            PreviousRaceResultsForm form = new PreviousRaceResultsForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            AboutMarathonForm form = new AboutMarathonForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            HowLongIsAMarathonForm form = new HowLongIsAMarathonForm();
            form.Show();
        }
    }
}
