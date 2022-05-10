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
    public partial class ManageARunnerForm : Form
    {
        public ManageARunnerForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            RunnerManagmentForm form = new RunnerManagmentForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            RunnerManagmentForm form = new RunnerManagmentForm();
            form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void ManageARunnerForm_Load(object sender, EventArgs e)
        {
            string sqlQuery = @"SELECT        Charity.*, Sponsorship.*, EventType.*, RegistrationStatus.*, RegistrationEvent.*, Registration.*, Event.*, [User].*, Runner.*
FROM            Runner INNER JOIN
                         [User] ON Runner.Email = [User].Email INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId INNER JOIN
                         RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId INNER JOIN
                         Event ON RegistrationEvent.EventId = Event.EventId INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Charity ON Registration.CharityId = Charity.CharityId LEFT JOIN
                         Sponsorship ON Registration.RegistrationId = Sponsorship.RegistrationId WHERE [User].Email = '" + EditPDO.editedRunnerEmail + "'";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            DataRow data = dataTable.Rows[0]; 

            label10.Text = EditPDO.editedRunnerEmail;
            label11.Text = data["FirstName"].ToString();
            label13.Text = data["LastName"].ToString();
            label15.Text = data["Gender"].ToString();
            label17.Text = data["DateOfBirth"].ToString();
            label19.Text = data["CountryCode"].ToString();
            label21.Text = data["CharityName"].ToString();
            label23.Text = (data["Amount"].ToString() != "" ? data["Amount"] : 0).ToString() + "$";
            label25.Text = data["EventTypeName"].ToString();
            pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + data["CharityLogo"].ToString());
            
            for (int i = 1; i <= int.Parse(data["RegistrationStatusId"].ToString()); i++)
            {
                PictureBox statusBox = this.Controls.Find("statusBox" + i, true).First() as PictureBox;
                statusBox.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\yes.png");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            EditRunnerProfileManageForm form = new EditRunnerProfileManageForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            CertificatePreviewForm form = new CertificatePreviewForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            CertificatePreviewForm form = new CertificatePreviewForm();
            form.Show();
        }
    }
}
