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
    public partial class CoordinatorMenuForm : Form
    {
        public CoordinatorMenuForm()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            SponsorshipOverviewForm form = new SponsorshipOverviewForm();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
            RunnerManagmentForm form = new RunnerManagmentForm();
            form.Show();
        }
    }
}
