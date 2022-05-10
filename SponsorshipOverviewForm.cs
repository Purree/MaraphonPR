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
    public partial class SponsorshipOverviewForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public SponsorshipOverviewForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void SponsorshipOverviewForm_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        SqlConnection sqlConnection = new SqlConnection(global::InteractiveMap.Properties.Settings.Default.MaraphonConnectionString);

        private void updateTable(string query = "")
        {
            float totalAmount = 0;
            int totalSponsors = 0;

            foreach (DataRow charity in this.charityTableAdapter1.GetData())
            {
                totalSponsors++;
                imageList1.Images.Add(charity["CharityLogo"].ToString(), Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charity["CharityLogo"].ToString()));
                ListViewItem lvi = new ListViewItem();
                int currentId = int.Parse(charity["CharityId"].ToString()) - 1;
                lvi.ImageKey = charity["CharityLogo"].ToString();
                listView1.Items.Add(lvi);
                listView1.Items[currentId].SubItems.Add(charity["CharityName"].ToString());
                

                string sqlQuery = @"SELECT        SUM(Sponsorship.Amount) as amount
                         FROM            Charity INNER JOIN
                         Registration ON Charity.CharityId = Registration.CharityId INNER JOIN
                         Sponsorship ON Registration.RegistrationId = Sponsorship.RegistrationId WHERE Registration.CharityId = " + charity["CharityId"].ToString();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                string amount = dataTable.Rows[0]["amount"].ToString() == "" ? "0" : dataTable.Rows[0]["amount"].ToString();
                totalAmount += float.Parse(amount);

                listView1.Items[currentId].SubItems.Add(amount);
            }

            label5.Text = "Всего спонсорских взносов: " + totalAmount.ToString();
            label3.Text = "Благотворительные организации: " + totalSponsors.ToString();
            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.Width = -2;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwColumnSorter.SortIntegers = e.Column != 1 ? true : false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            int column = comboBox1.SelectedIndex == 0 ? 2 : 1;

            lvwColumnSorter.SortIntegers = column != 1 ? true : false;

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
