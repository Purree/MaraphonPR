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
    public partial class PreviousRaceResultsForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public PreviousRaceResultsForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            FindOutMoreInformationForm form = new FindOutMoreInformationForm();
            form.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void PreviousRaceResultsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.maraphonDataSet.Gender);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Event". При необходимости она может быть перемещена или удалена.
            this.eventTableAdapter.Fill(this.maraphonDataSet.Event);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.EventType". При необходимости она может быть перемещена или удалена.
            this.eventTypeTableAdapter.Fill(this.maraphonDataSet.EventType);

            redrawTable();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            this.listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.listView1.ListViewItemSorter = null;

            string filters = "";
            filters += " AND [EventName] = '" + comboBox1.Text + "' ";
            filters += "AND [EventTypeName] = '" + comboBox2.Text + "' ";
            filters += "AND Runner.Gender = '" + comboBox3.Text + "' ";

            if (comboBox4.Text != "")
            {
                DateTime minDate = DateTime.Now;
                DateTime maxDate = DateTime.Now;


                switch (comboBox4.SelectedIndex)
                {
                    case 0:
                        minDate = minDate.AddYears(-18);
                        maxDate = maxDate.AddYears(-29);
                        break;
                    case 1:
                        minDate = minDate.AddYears(-30);
                        maxDate = maxDate.AddYears(-59);
                        break;
                    default:
                        minDate = minDate.AddYears(-60);
                        maxDate = maxDate.AddYears(-110);
                        break;
                }

                filters += "AND DateOfBirth > '" + maxDate.ToString() + "' AND DateOfBirth < '" + minDate.ToString() + "' ";
            }

            redrawTable(filters);

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void redrawTable(string filters = "")
        {
            listView1.Items.Clear();

            SqlCommand sqlCommandTotal = new SqlCommand(@"SELECT        RegistrationEvent.*, Registration.*, Gender.*, Runner.*, [User].*, Event.*, EventType.*
FROM            [User] INNER JOIN
                         Runner ON [User].Email = Runner.Email INNER JOIN
                         Gender ON Runner.Gender = Gender.Gender INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId CROSS JOIN
                         Event INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Marathon ON Event.MarathonId = Marathon.MarathonId WHERE 1=1" + filters, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapterUseless = new SqlDataAdapter(sqlCommandTotal);
            DataTable dataTableTotal = new DataTable();
            sqlDataAdapterUseless.Fill(dataTableTotal);
            sqlConnection.Close();
            

            string sqlQueryAvarange = @"SELECT        AVG(RaceTime) as AVG
FROM            [User] INNER JOIN
                         Runner ON [User].Email = Runner.Email INNER JOIN
                         Gender ON Runner.Gender = Gender.Gender INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId CROSS JOIN
                         Event INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Marathon ON Event.MarathonId = Marathon.MarathonId WHERE RaceTime IS NOT NULL AND RaceTime <> 0" + filters;

            SqlCommand sqlCommandAvarange = new SqlCommand(sqlQueryAvarange, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapterAvarange = new SqlDataAdapter(sqlCommandAvarange);
            DataTable dataTableAvarange = new DataTable();
            sqlDataAdapterAvarange.Fill(dataTableAvarange);
            sqlConnection.Close();

            string sqlQuery = @"SELECT TOP(500)       Event.EventId as EventId, RegistrationEvent.*, Registration.*, Gender.*, Runner.*, [User].*, Event.*, EventType.*
FROM            [User] INNER JOIN
                         Runner ON [User].Email = Runner.Email INNER JOIN
                         Gender ON Runner.Gender = Gender.Gender INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId CROSS JOIN
                         Event INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Marathon ON Event.MarathonId = Marathon.MarathonId WHERE RaceTime IS NOT NULL AND RaceTime <> 0" + filters + " ORDER BY RaceTime";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            string sqlQueryFinished = @"SELECT      Event.EventId as EventId, RegistrationEvent.*, Registration.*, Gender.*, Runner.*, [User].*, Event.*, EventType.*
FROM            [User] INNER JOIN
                         Runner ON [User].Email = Runner.Email INNER JOIN
                         Gender ON Runner.Gender = Gender.Gender INNER JOIN
                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN
                         RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId CROSS JOIN
                         Event INNER JOIN
                         EventType ON Event.EventTypeId = EventType.EventTypeId INNER JOIN
                         Marathon ON Event.MarathonId = Marathon.MarathonId WHERE RaceTime IS NOT NULL AND RaceTime <> 0" + filters + " ORDER BY RaceTime";
            SqlCommand sqlCommandFinished = new SqlCommand(sqlQueryFinished, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapterFinished = new SqlDataAdapter(sqlCommandFinished);
            DataTable dataTableFinished = new DataTable();
            sqlDataAdapterFinished.Fill(dataTableFinished);
            sqlConnection.Close();

            int totalRunners = dataTableTotal.Rows.Count;
            int totalRunnersFinished = dataTableFinished.Rows.Count;
            try
            {

                int averageTime = int.Parse(dataTableAvarange.Rows[0]["AVG"].ToString());

                int index = 0;

                Dictionary<string, int> finalists = new Dictionary<string, int> { };

                foreach (DataRow data in dataTable.Rows)
                {
                    if (finalists.ContainsKey(data["EventId"].ToString()))
                    {
                        finalists[data["EventId"].ToString()]++;
                    } else
                    {
                        finalists.Add(data["EventId"].ToString(), 0);
                    }

                    listView1.Items.Add(finalists[data["EventId"].ToString()].ToString());
                    listView1.Items[index].SubItems.Add(TimeSpan.FromSeconds(Double.Parse(data["RaceTime"].ToString())).ToString("hh':'mm':'ss"));
                    listView1.Items[index].SubItems.Add(data["FirstName"].ToString() + " " + data["LastName"].ToString());
                    listView1.Items[index].SubItems.Add(data["CountryCode"].ToString());

                    index++;
                }

                label43.Text = totalRunners.ToString();
                label44.Text = totalRunnersFinished.ToString();
                label45.Text = TimeSpan.FromSeconds(Double.Parse(averageTime.ToString())).ToString("hh':'mm':'ss");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("По вашему запросу бегунов не существует");
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
