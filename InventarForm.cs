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
    public partial class InventarForm : Form
    {
        public InventarForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            AdministratorMenuForm form = new AdministratorMenuForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            AdministratorMenuForm form = new AdministratorMenuForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void showForm()
        {
            panel10.Visible = !panel10.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            InventarSecondForm form = new InventarSecondForm();
            form.Show();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void InventarForm_Load(object sender, EventArgs e)
        {
            string sqlQuery = @"SELECT        (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'A') as ACount,
			  (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'B') as BCount,
			  (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'C') as CCount,
			  (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'A') + (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'B') as ABCount,
			  (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'A') + (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'B') + (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'C') as ABCCount,
			  (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'B') + (SELECT COUNT(Registration.RaceKitOptionId) FROM Registration WHERE Registration.RaceKitOptionId = 'C') as BCCount
            ";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            DataRow counts = dataTable.Rows[0];
            label16.Text = label24.Text = label28.Text = counts["ACount"].ToString();
            label17.Text = label25.Text = label29.Text = counts["ABCount"].ToString();
            label33.Text = label37.Text = counts["BCount"].ToString();
            label18.Text = label19.Text = label26.Text = label20.Text = label30.Text = label21.Text = label64.Text = label62.Text = label69.Text = counts["ABCCount"].ToString();
            label34.Text = label22.Text = label38.Text = label41.Text = label60.Text = label65.Text = counts["BCCount"].ToString();
            label51.Text = label52.Text = label46.Text = label45.Text = label66.Text = label68.Text = counts["CCount"].ToString();
        }
    }
}
