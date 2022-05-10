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
    public partial class EditRunnerProfileForm : Form
    {
        public EditRunnerProfileForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                if ((textBox2.Text != "" || textBox3.Text != "") && (textBox2.Text != textBox3.Text))
                {
                    throw new Exception("Неверный пароль");
                }


                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    RunnerDTO.currentUser["Password"] = textBox2.Text;
                }

                RunnerDTO.currentUser["FirstName"] = textBox4.Text;
                RunnerDTO.currentUser["LastName"] = textBox5.Text;
                this.userTableAdapter1.Update(RunnerDTO.currentUser);

                RunnerDTO.currentRunner["Gender"] = genderComboBox.Text;
                RunnerDTO.currentRunner["DateOfBirth"] = dateTimePicker1.Value;
                RunnerDTO.currentRunner["CountryCode"] = comboBox2.Text;
                this.runnerTableAdapter1.Update(RunnerDTO.currentRunner);
                
                Close();
                RunnerMenuForm form = new RunnerMenuForm();
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполнено");

            }

        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void EditRunnerProfileForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.maraphonDataSet.Country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.maraphonDataSet.Gender);


            label2.Text = RunnerDTO.currentRunner["Email"].ToString();
            textBox4.Text = RunnerDTO.currentUser["FirstName"].ToString();
            textBox5.Text = RunnerDTO.currentUser["LastName"].ToString();
            genderComboBox.SelectedIndex = RunnerDTO.currentRunner["Gender"].ToString() == "Male" ? 1 : 0;
            dateTimePicker1.Value = DateTime.Parse(RunnerDTO.currentRunner["DateOfBirth"].ToString());
            comboBox2.SelectedValue = RunnerDTO.currentRunner["CountryCode"].ToString();
        }

        private void genderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.genderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.maraphonDataSet);

        }
    }
}
