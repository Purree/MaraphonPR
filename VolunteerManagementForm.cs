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
    public partial class VolunteerManagementForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public VolunteerManagementForm()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ImportVolunteersForm form = new ImportVolunteersForm();
            form.Show();
        }

        private void VolunteerManagementForm_Load(object sender, EventArgs e)
        {
            int totalVolunteer = 0;

            foreach (DataRow volunteer in this.volunteerTableAdapter1.GetData())
            {
                listView1.Items.Add(volunteer["LastName"].ToString());
                listView1.Items[totalVolunteer].SubItems.Add(volunteer["FirstName"].ToString());
                listView1.Items[totalVolunteer].SubItems.Add(volunteer["CountryCode"].ToString());
                listView1.Items[totalVolunteer].SubItems.Add(volunteer["Gender"].ToString());
                
                totalVolunteer++;
            }

            label8.Text = "Всего волонтёров: " + totalVolunteer.ToString();
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

        private void button5_Click(object sender, EventArgs e)
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
