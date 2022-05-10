using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveMap
{
    public partial class EditRunnerProfileManageForm : Form
    {
        public EditRunnerProfileManageForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            ManageARunnerForm form = new ManageARunnerForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            ManageARunnerForm form = new ManageARunnerForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                DataRow user = this.maraphonDataSet.User.Select("Email = '" + EditPDO.editedRunnerEmail + "'").Last();
                DataRow runner = this.maraphonDataSet.Runner.Select("Email = '" + EditPDO.editedRunnerEmail + "'").Last();
                DataRow registration = this.maraphonDataSet.Registration.Select("RunnerId = " + runner["RunnerId"].ToString()).Last();

                user["FirstName"] = textBox4.Text;
                user["LastName"] = textBox5.Text;
                
                runner["Gender"] = comboBox1.Text;
                runner["DateOfBirth"] = dateTimePicker1.Value;
                runner["CountryCode"] = comboBox2.Text;

                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    if (textBox2.Text != textBox3.Text)
                        throw new Exception("Неверный пароль");
                    else
                        user["Password"] = textBox2.Text;
                }

                registration["RegistrationStatusId"] = comboBox3.SelectedIndex+1;

                this.userTableAdapter1.Update(this.maraphonDataSet.User);
                this.runnerTableAdapter1.Update(this.maraphonDataSet.Runner);
                this.registrationTableAdapter1.Update(this.maraphonDataSet.Registration);


                Close();
                ManageARunnerForm form = new ManageARunnerForm();
                form.Show();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно введены данные");
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            ManageARunnerForm form = new ManageARunnerForm();
            form.Show();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void EditRunnerProfileManageForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.maraphonDataSet.Gender);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.maraphonDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.RegistrationStatus". При необходимости она может быть перемещена или удалена.
            this.registrationStatusTableAdapter.Fill(this.maraphonDataSet.RegistrationStatus);
            this.runnerTableAdapter1.Fill(this.maraphonDataSet.Runner);
            this.userTableAdapter1.Fill(this.maraphonDataSet.User);
            this.registrationTableAdapter1.Fill(this.maraphonDataSet.Registration);


            string sqlQuery = @"SELECT        Registration.*, [User].*, Runner.*, RegistrationStatus.*
FROM            Runner INNER JOIN
                         [User] ON Runner.Email = [User].Email INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId WHERE [User].Email = '" + EditPDO.editedRunnerEmail + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            DataRow data = dataTable.Rows[0];

            label2.Text = data["Email"].ToString();
            textBox4.Text = data["FirstName"].ToString();
            textBox5.Text = data["LastName"].ToString();
            comboBox1.Text = data["Gender"].ToString();
            dateTimePicker1.Value = DateTime.Parse(data["DateOfBirth"].ToString());
            comboBox3.Text = data["RegistrationStatus"].ToString();
        }
    }
}
