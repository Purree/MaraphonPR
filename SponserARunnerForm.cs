using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace InteractiveMap
{
    public partial class SponserARunnerForm : Form
    {
        public SponserARunnerForm()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = "$" + numericUpDown2.Value;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            change_panel_visible();
        }

        private void change_panel_visible()
        {
            panel3.Visible = !panel3.Visible;
            label15.Visible = !panel3.Visible;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            change_panel_visible();
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

        private string registrationId = "";
        private string runnerName = "";
        private string runnerCountry = "";
        private string charityName = "";

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void SponserARunnerForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.User". При необходимости она может быть перемещена или удалена.
            this.userTableAdapter.Fill(this.maraphonDataSet.User);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Runner". При необходимости она может быть перемещена или удалена.
            this.runnerTableAdapter.Fill(this.maraphonDataSet.Runner);
            
            string sqlQuery = "SELECT        Charity.CharityName, Charity.CharityId, Charity.CharityDescription, Charity.CharityLogo, Registration.RunnerId, Registration.RegistrationId, Registration.RaceKitOptionId, Registration.RegistrationDateTime, Registration.RegistrationStatusId, Registration.Cost, Registration.CharityId AS Expr1, Registration.SponsorshipTarget, Runner.RunnerId AS Expr2, Runner.Email, Runner.Gender, Runner.DateOfBirth, Runner.CountryCode, [User].Email AS Expr3, [User].Password, [User].FirstName, [User].LastName, [User].RoleId FROM Runner INNER JOIN [User] ON Runner.Email = [User].Email INNER JOIN Charity INNER JOIN Registration ON Charity.CharityId = Registration.CharityId ON Runner.RunnerId = Registration.RunnerId";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            foreach (DataRow data in dataTable.Rows)
            {
                comboBox1.Items.Add(data["FirstName"].ToString() + " " + data["LastName"].ToString() + " " + data["RegistrationId"]);
            }

            label15.Visible = label7.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            registrationId = (comboBox1.SelectedItem.ToString().Split(' ').Last());

            string sqlQuery = @"SELECT        Charity.CharityId, Charity.CharityName, Charity.CharityDescription, Charity.CharityLogo, Registration.RegistrationId, Registration.RegistrationDateTime, Registration.RaceKitOptionId, Registration.RegistrationStatusId, 
                         Registration.Cost, Registration.CharityId AS Expr1, Registration.SponsorshipTarget, Country.*, Runner.*
FROM            Runner INNER JOIN
                         Country ON Runner.CountryCode = Country.CountryCode INNER JOIN
                         Charity INNER JOIN
                         Registration ON Charity.CharityId = Registration.CharityId ON Runner.RunnerId = Registration.RunnerId WHERE Registration.RegistrationId = " + registrationId;
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();


            DataRow charityAndRunner = dataTable.Rows[0];
            label7.Text = label19.Text = charityAndRunner["CharityName"].ToString();
            label18.Text = charityAndRunner["CharityDescription"].ToString();
            pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charityAndRunner["CharityLogo"].ToString());
            label15.Visible = label7.Visible = true;

            charityName = charityAndRunner["CharityName"].ToString();
            runnerName = comboBox1.SelectedItem.ToString().Split(' ')[0].ToString() + comboBox1.SelectedItem.ToString().Split(' ')[1].ToString();
            runnerCountry = charityAndRunner["CountryName"].ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox3.Text == "" || !(maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull) || numericUpDown2.Value <= 0)
                {
                    throw new Exception("Не заполненно");
                }

                DataRow drSponsorship = this.maraphonDataSet.Sponsorship.NewRow();
                drSponsorship["SponsorName"] = textBox1.Text;
                drSponsorship["RegistrationId"] = registrationId;
                drSponsorship["Amount"] = numericUpDown2.Value;
                this.maraphonDataSet.Sponsorship.Rows.Add(drSponsorship);
                this.sponsorshipTableAdapter1.Update(this.maraphonDataSet.Sponsorship);

                SponsorDTO.DonateAmount = numericUpDown2.Value.ToString();
                SponsorDTO.RunnerRegistrationId = registrationId;
                SponsorDTO.RunnerName = runnerName;
                SponsorDTO.RunnerCharity = charityName;
                SponsorDTO.RunnerCountry = runnerCountry;

                Close();
                SponsorshipConfirmation form = new SponsorshipConfirmation();
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполнены данные");
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
                this.sponsorshipTableAdapter1.Fill(this.maraphonDataSet.Sponsorship);
            }
        }

    }
}
