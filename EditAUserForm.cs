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
    public partial class EditAUserForm : Form
    {
        public EditAUserForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow user = this.maraphonDataSet.User.Select("Email = '" + EditPDO.editedUserEmail + "'").Last();
                user["FirstName"] = textBox1.Text;
                user["LastName"] = textBox2.Text;
                user["RoleId"] = comboBox1.Text[0];

                if (textBox4.Text != "" || textBox3.Text != "")
                {
                    if (textBox4.Text != textBox3.Text)
                        throw new Exception("Неверно заполнено");
                    else
                        user["Password"] = textBox4.Text;
                }

                this.userTableAdapter1.Update(this.maraphonDataSet.User);

                Close();
                UserManagementForm form = new UserManagementForm();
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполненно");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);
        private void EditAUserForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Role". При необходимости она может быть перемещена или удалена.
            this.roleTableAdapter.Fill(this.maraphonDataSet.Role);
            this.userTableAdapter1.Fill(this.maraphonDataSet.User);

            string sqlQuery = @"SELECT     Role.*, [User].*
    FROM            [User] INNER JOIN
                             Role ON [User].RoleId = Role.RoleId WHERE Email = '" + EditPDO.editedUserEmail + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            DataRow data = dataTable.Rows[0];

            label9.Text = data["Email"].ToString();
            textBox1.Text = data["FirstName"].ToString();
            textBox2.Text = data["LastName"].ToString();
            comboBox1.Text = data["RoleName"].ToString();
        }
    }
}
