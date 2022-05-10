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
    public partial class CertificatePreviewForm : Form
    {
        public CertificatePreviewForm()
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

        private void CertificatePreviewForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Event". При необходимости она может быть перемещена или удалена.
            this.eventTableAdapter.Fill(this.maraphonDataSet.Event);

            update_data();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void update_data(string filters = "")
        {
            

            try
            {

                string sqlQuery = @"SELECT        Charity.CharityId, Charity.CharityName, Charity.CharityDescription, Charity.CharityLogo, EventType.EventTypeId, EventType.EventTypeName, RegistrationStatus.RegistrationStatusId, RegistrationStatus.RegistrationStatus, 
                         RegistrationEvent.RegistrationEventId, RegistrationEvent.RegistrationId, RegistrationEvent.EventId, RegistrationEvent.BibNumber, RegistrationEvent.RaceTime, Registration.RegistrationId AS Expr1, Registration.RunnerId, 
                         Registration.RegistrationDateTime, Registration.RaceKitOptionId, Registration.RegistrationStatusId AS Expr2, Registration.Cost, Registration.CharityId AS Expr3, Registration.SponsorshipTarget, Event.EventId AS Expr4, 
                         Event.EventName, Event.EventTypeId AS Expr5, Event.MarathonId AS Expr9, Event.StartDateTime, Event.Cost AS Expr6, Event.MaxParticipants, [User].Email, [User].Password, [User].FirstName, [User].LastName, [User].RoleId, 
                         Runner.RunnerId AS Expr7, Runner.Email AS Expr8, Runner.Gender, Runner.DateOfBirth, Runner.CountryCode AS Expr10, Marathon.*
FROM            Runner INNER JOIN
                         [User] ON Runner.Email = [User].Email INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId INNER JOIN
                         RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId INNER JOIN
                         Event ON RegistrationEvent.EventId = Event.EventId INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Charity ON Registration.CharityId = Charity.CharityId INNER JOIN
                         Marathon ON Event.MarathonId = Marathon.MarathonId WHERE [User].Email = '" + EditPDO.editedRunnerEmail + "'" + filters;

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

                
                if (dataTable.Rows.Count == 1 || filters != "")
                {
                    DataRow activeUser = dataTable.Rows[0];
                    label10.Text = $"Поздравляем {activeUser["FirstName"].ToString()}{activeUser["LastName"].ToString()} с участием в {activeUser["EventTypeName"].ToString()}. " +
                        $"Ваши результаты: {(activeUser["RaceTime"].ToString() == "" || activeUser["RaceTime"].ToString() == "0" ? "Не финишировал" : TimeSpan.FromSeconds(Double.Parse(activeUser["RaceTime"].ToString())).ToString("hh':'mm':'ss")) .ToString()}!";
                    label5.Text = "в";
                    label6.Text = activeUser["MarathonName"].ToString();
                    label7.Text = activeUser["CityName"].ToString();

                } else
                {
                    comboBox2.Items.Clear();
                    foreach (DataRow data in dataTable.Rows)
                        comboBox2.Items.Add(data["EventName"]);

                    label10.Text = "Не найдено результатов, выберите событие в верхней части страницы";
                    label6.Text = label5.Text = label7.Text = "";
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполнены данные");
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_data("AND EventName = '" + comboBox2.Text + "' ");
        }
    }
}
