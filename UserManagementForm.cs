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
    public partial class UserManagementForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);
        public UserManagementForm()
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
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            EditPDO.editedUserEmail = e.Item.SubItems[2].Text;
            Close();
            EditAUserForm form = new EditAUserForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            AddANewUserForm form = new AddANewUserForm();
            form.Show();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Role". При необходимости она может быть перемещена или удалена.
            this.roleTableAdapter.Fill(this.maraphonDataSet.Role);

            updateTable();
        }

        private void updateTable(string filters = "")
        {
            listView1.Items.Clear();

            try
            {
                string sqlQueryTotal = @"SELECT        Role.*, [User].*
    FROM            [User] INNER JOIN
                             Role ON [User].RoleId = Role.RoleId WHERE 1=1 ";
                SqlCommand sqlCommandTotal = new SqlCommand(sqlQueryTotal, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapterTotal = new SqlDataAdapter(sqlCommandTotal);
                DataTable dataTableTotal = new DataTable();
                sqlDataAdapterTotal.Fill(dataTableTotal);
                sqlConnection.Close();

                string sqlQuery = @"SELECT   TOP(1000)     Role.*, [User].*
    FROM            [User] INNER JOIN
                             Role ON [User].RoleId = Role.RoleId WHERE 1=1 " + filters;
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

                label10.Text = dataTableTotal.Rows.Count.ToString();

                foreach (DataRow data in dataTable.Rows)
                {
                    ListViewItem item = listView1.Items.Add(data["FirstName"].ToString());
                    item.SubItems.Add(data["LastName"].ToString());
                    item.SubItems.Add(data["Email"].ToString());
                    item.SubItems.Add(data["RoleName"].ToString());
                    item.SubItems.Add("Edit");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Таких пользователей не существует");
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int column = comboBox2.SelectedIndex;

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

        private void button5_Click(object sender, EventArgs e)
        {
            this.listView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.listView1.ListViewItemSorter = null;

            string filters = "";
            if (textBox1.Text != "")
            {
                filters += "AND [User].FirstName LIKE '%" + textBox1.Text + "%'";
            }

            filters += "AND [Role].RoleName = '" + comboBox3.Text + "'";

            updateTable(filters);

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }
    }
}
