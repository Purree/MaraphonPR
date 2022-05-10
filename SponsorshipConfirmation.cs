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
    public partial class SponsorshipConfirmation : Form
    {
        public SponsorshipConfirmation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void SponsorshipConfirmation_Load(object sender, EventArgs e)
        {
            label5.Text = SponsorDTO.RunnerName + "(" + SponsorDTO.RunnerRegistrationId + ") из " + SponsorDTO.RunnerCountry;
            label6.Text = SponsorDTO.RunnerCharity;
            label7.Text = "$" + SponsorDTO.DonateAmount.ToString();
        }
    }
}
