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
    public partial class AddANewUserForm : Form
    {
        public AddANewUserForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox4.Text != textBox3.Text)
                {
                    throw new Exception("Неверно заполненно");
                }

                if (comboBox1.Text == "Runner" && (comboBox2.Text == "" || comboBox3.Text == "")) 
                {
                    throw new Exception("Неверно заполненно");
                }

                DataRow drUser = this.maraphonDataSet.User.NewRow();
                drUser["Email"] = textBox5.Text;
                drUser["FirstName"] = textBox1.Text;
                drUser["LastName"] = textBox2.Text;
                drUser["Password"] = textBox4.Text;
                drUser["RoleId"] = comboBox1.Text[0];

                this.maraphonDataSet.User.Rows.Add(drUser);
                this.userTableAdapter1.Update(this.maraphonDataSet.User);

                if (drUser["RoleId"].ToString() == "R")
                {
                    DataRow drRunner = this.maraphonDataSet.Runner.NewRow();
                    drRunner["Email"] = textBox5.Text;
                    drRunner["Gender"] = comboBox2.Text;
                    drRunner["CountryCode"] = comboBox3.Text;
                    drRunner["DateOfBirth"] = dateTimePicker1.Value;


                    this.maraphonDataSet.Runner.Rows.Add(drRunner);
                    this.runnerTableAdapter1.Update(this.maraphonDataSet.Runner);
                }

                Close();
                UserManagementForm form = new UserManagementForm();
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполненно");
                this.userTableAdapter1.Fill(this.maraphonDataSet.User);
                this.runnerTableAdapter1.Fill(this.maraphonDataSet.Runner);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void AddANewUserForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.maraphonDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.maraphonDataSet.Gender);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Role". При необходимости она может быть перемещена или удалена.
            this.roleTableAdapter.Fill(this.maraphonDataSet.Role);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Visible = label11.Visible = label12.Visible = comboBox3.Visible = comboBox2.Visible = dateTimePicker1.Visible = comboBox1.Text == "Runner";
        }
    }
}
