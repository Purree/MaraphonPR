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
    public partial class RegisterForAnEvent : Form
    {
        public RegisterForAnEvent()
        {
            InitializeComponent();
        }

        private void RegisterForAnEvent_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Charity". При необходимости она может быть перемещена или удалена.
            this.charityTableAdapter.Fill(this.maraphonDataSet.Charity);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(500, 200);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            change_panel_visible();
        }

        private void change_panel_visible()
        {
            panel3.Visible = !panel3.Visible;
            label15.Visible = !panel3.Visible;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            label12.Text = charityNameComboBox.Text;
            string description = (this.charityBindingSource.Current as DataRowView).Row["CharityDescription"] as string;
            label13.Text = description;
            string imageName = (this.charityBindingSource.Current as DataRowView).Row["CharityLogo"] as string;
            pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + imageName);

            change_panel_visible();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void RegisterForAnEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private int cost = 0;
        private char kitId = 'A';
        private List<string> races = new List<string> { };

        private void recalculate_cost()
        {
            cost = 0;
            races.Clear();

            if (checkBox1.Checked)
            {
                races.Add("FM");
                cost += 145;
            }

            if (checkBox2.Checked)
            {
                Console.WriteLine(races);
                races.Add("HM");
                Console.WriteLine(races);
                cost += 75;
            }

            if (checkBox3.Checked)
            {
                races.Add("FR");
                cost += 20;
            }

            if (radioButton1.Checked)
            {
                cost += 0;
                kitId = 'A';
            }

            if (radioButton2.Checked)
            {
                cost += 20;
                kitId = 'B';
            }
            
            if (radioButton3.Checked)
            {
                cost += 45;
                kitId = 'C';
            }

            label11.Text = "$" + cost.ToString();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            recalculate_cost();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
                {
                    throw new Exception("Ни одна трасса не выбрана");
                }

                if (!(checkBox3.Checked || checkBox2.Checked || checkBox1.Checked))
                {
                    throw new Exception("Ни один компонент не выбрана");
                }

                DataRow drRegistration = this.maraphonDataSet.Registration.NewRow();
                drRegistration["RunnerId"] = RunnerDTO.Id;
                drRegistration["RegistrationDateTime"] = DateTime.Now;
                drRegistration["RaceKitOptionId"] = kitId;
                drRegistration["RegistrationStatusId"] = 1;
                drRegistration["Cost"] = cost;
                drRegistration["CharityId"] = (this.charityBindingSource.Current as DataRowView).Row["CharityId"];
                drRegistration["SponsorshipTarget"] = numericUpDown1.Value;
                this.maraphonDataSet.Registration.Rows.Add(drRegistration);
                this.registrationTableAdapter1.Update(this.maraphonDataSet.Registration);

                foreach (string race in races)
                {
                    DataRow drRegistrationEvent = this.maraphonDataSet.RegistrationEvent.NewRow();
                    drRegistrationEvent["RegistrationId"] = drRegistration["RegistrationId"];
                    drRegistrationEvent["EventId"] = "15_5" + race;
                    drRegistrationEvent["BibNumber"] = Int16.Parse(this.registrationEventTableAdapter1.GetData().Select("[EventId] = '15_5" + race + "'").Last()["BibNumber"].ToString())+1;
                    drRegistrationEvent["RaceTime"] = 0;

                    this.maraphonDataSet.RegistrationEvent.Rows.Add(drRegistrationEvent);
                    this.registrationEventTableAdapter1.Update(this.maraphonDataSet.RegistrationEvent);
                }

                Close();
                RegistrationConfirmationForm form = new RegistrationConfirmationForm();
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполнено");
                this.registrationEventTableAdapter1.Fill(this.maraphonDataSet.RegistrationEvent);
                this.registrationTableAdapter1.Fill(this.maraphonDataSet.Registration);
            }
        }

        private void charityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.charityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.maraphonDataSet);

        }
    }
}
