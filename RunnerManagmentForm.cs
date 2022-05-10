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
    public partial class RunnerManagmentForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public RunnerManagmentForm()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(listView1);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(4);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

            extender.AddColumn(buttonAction);
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            EditPDO.editedRunnerEmail = e.Item.SubItems[2].Text;
            Close();
            ManageARunnerForm form = new ManageARunnerForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            CoordinatorMenuForm form = new CoordinatorMenuForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            CoordinatorMenuForm form = new CoordinatorMenuForm();
            form.Show();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void RunnerManagmentForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.EventType". При необходимости она может быть перемещена или удалена.
            this.eventTypeTableAdapter.Fill(this.maraphonDataSet.EventType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.RegistrationStatus". При необходимости она может быть перемещена или удалена.
            this.registrationStatusTableAdapter.Fill(this.maraphonDataSet.RegistrationStatus);

            updateTable();

            label10.Text = this.runnerTableAdapter1.GetData().Count.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.listView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.listView1.ListViewItemSorter = null;

            string filters = "";
            filters += "AND RegistrationStatus = '" + registrationStatusComboBox.Text + "' ";
            filters += "AND EventTypeName = '" + eventTypeNameComboBox.Text + "' ";

            updateTable(filters);

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        private void updateTable(string filters = "")
        {
            listView1.Items.Clear();

            try
            {
                string sqlQuery = @"SELECT        RegistrationEvent.RegistrationEventId, RegistrationEvent.RegistrationId, RegistrationEvent.EventId, RegistrationEvent.BibNumber, RegistrationEvent.RaceTime, Registration.RegistrationId AS Expr1, Registration.RunnerId, 
                             Registration.RegistrationDateTime, Registration.RaceKitOptionId AS Expr7, Registration.RegistrationStatusId AS Expr9, Registration.Cost AS Expr8, Registration.CharityId, Registration.SponsorshipTarget, 
                             Event.EventId AS Expr2, Event.EventName, Event.EventTypeId, Event.MarathonId, Event.StartDateTime, Event.Cost AS Expr3, Event.MaxParticipants, EventType.EventTypeId AS Expr4, EventType.EventTypeName, 
                             Runner.RunnerId AS Expr5, Runner.Email, Runner.Gender, Runner.DateOfBirth, Runner.CountryCode, [User].Email AS Expr6, [User].Password, [User].FirstName, [User].LastName, [User].RoleId, RaceKitOption.RaceKitOptionId, 
                             RaceKitOption.RaceKitOption, RaceKitOption.Cost, RegistrationStatus.*
    FROM            Registration INNER JOIN
                             [User] INNER JOIN
                             Runner ON [User].Email = Runner.Email ON Registration.RunnerId = Runner.RunnerId INNER JOIN
                             RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId INNER JOIN
                             Event INNER JOIN
                             EventType ON Event.EventTypeId = EventType.EventTypeId ON RegistrationEvent.EventId = Event.EventId INNER JOIN
                             RaceKitOption ON Registration.RaceKitOptionId = RaceKitOption.RaceKitOptionId INNER JOIN
                             RegistrationStatus ON Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId WHERE 1=1 " + filters;
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

                foreach (DataRow data in dataTable.Rows)
                {
                    ListViewItem item = listView1.Items.Add(data["FirstName"].ToString());
                    item.SubItems.Add(data["LastName"].ToString());
                    item.SubItems.Add(data["Email"].ToString());
                    item.SubItems.Add(data["RegistrationStatus"].ToString());
                    item.SubItems.Add("Edit");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("По вашему запросу бегунов нет");
                if (sqlConnection.State.ToString() == "Open")
                {
                    sqlConnection.Close();
                }
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int column = comboBox1.SelectedIndex;

            // Determine if clicked column is already the column that is being sorted.
            if (column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
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
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}
