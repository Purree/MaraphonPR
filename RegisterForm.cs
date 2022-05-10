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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != textBox3.Text)
                {
                    throw new Exception("Пароли не совпадают");
                }

                DataRow drRunner = this.maraphonDataSet.Runner.NewRow();
                drRunner["Email"] = textBox1.Text;
                drRunner["Gender"] = genderComboBox.Text;
                drRunner["DateOfBirth"] = dateTimePicker1.Text;
                drRunner["CountryCode"] = comboBox1.Text;


                DataRow drUser = this.maraphonDataSet.User.NewRow();
                drUser["Email"] = textBox1.Text;
                drUser["Password"] = textBox2.Text;
                drUser["FirstName"] = textBox4.Text;
                drUser["LastName"] = textBox5.Text;
                drUser["RoleId"] = "R";

                this.maraphonDataSet.Runner.Rows.Add(drRunner);
                this.maraphonDataSet.User.Rows.Add(drUser);
                this.userTableAdapter.Update(this.maraphonDataSet.User);
                this.runnerTableAdapter1.Update(this.maraphonDataSet.Runner);
                Console.WriteLine("_________________________1_");
                Console.WriteLine(drRunner["RunnerId"].ToString());
                RunnerDTO.Id = drRunner["RunnerId"].ToString();
                Console.WriteLine(RunnerDTO.Id);
                Console.WriteLine("_________________________2_");
                RunnerDTO.currentRunner = this.runnerTableAdapter1.GetData().Select("[RunnerId] = " + RunnerDTO.Id).Last();
                RunnerDTO.currentUser = this.userTableAdapter1.GetData().Select("[Email] = '" + RunnerDTO.currentRunner["Email"].ToString() + "'").Last();


                this.Close();
                RegisterForAnEvent form = new RegisterForAnEvent();
                form.Show();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполнено");
                this.userTableAdapter1.Fill(this.maraphonDataSet.User);
                this.runnerTableAdapter1.Fill(this.maraphonDataSet.Runner);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.maraphonDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.User". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.maraphonDataSet.Gender);
        }

        private void userBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void genderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }
    }
}
