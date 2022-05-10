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
    public partial class MySponsorshipForm : Form
    {
        public MySponsorshipForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void MySponsorshipForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataRow registration = this.registrationTableAdapter1.GetData().Select("[RunnerId] = " + RunnerDTO.Id + " AND [RegistrationStatusId] = 4").Last();
                DataRow charity = this.charityTableAdapter1.GetData().Select("[CharityId] = '" + registration["CharityId"].ToString() + "'").First();

                List<string> allRegistrations = new List<string> { };

                foreach (DataRow registrationData in this.registrationTableAdapter1.GetData().Select("[RunnerId] = " + RunnerDTO.Id + " AND [RegistrationStatusId] = 4"))
                {
                    allRegistrations.Add(registrationData["RegistrationId"].ToString());
                }

                label6.Text = charity["CharityName"].ToString();
                label5.Text = charity["CharityDescription"].ToString();
                pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charity["CharityLogo"].ToString());

                int sponsorsCount = 0;
                float total = 0;

                foreach (DataRow sponsor in this.sponsorshipTableAdapter1.GetData().Select("[RegistrationId] IN (" + String.Join(", ", allRegistrations.ToArray()) + ")"))
                {
                    sponsorsCount++;
                    if (sponsorsCount <= 5)
                    {
                        Label SponsorName = this.Controls.Find("SponsorName" + sponsorsCount, true).First() as Label;
                        SponsorName.Text = sponsor["SponsorName"].ToString();
                        Label SponsorMoney = this.Controls.Find("SponsorMoney" + sponsorsCount, true).First() as Label;
                        SponsorMoney.Text = sponsor["Amount"].ToString();
                    }
                    total += float.Parse(sponsor["Amount"].ToString());
                }

                totalCost.Text = total.ToString() + "$";
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void SponsorMoney2_Click(object sender, EventArgs e)
        {

        }
    }
}
