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
    public partial class ManageCharitiesForm : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public ManageCharitiesForm()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(listView1);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(3);
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

        private void button8_Click(object sender, EventArgs e)
        {
            EditPDO.editedCharityName = "";
            Close();
            AddEditCharityForm form = new AddEditCharityForm();
            form.Show();
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            EditPDO.editedCharityName = e.Item.SubItems[1].Text;
            Close();
            AddEditCharityForm form = new AddEditCharityForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            AddEditCharityForm form = new AddEditCharityForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            AddEditCharityForm form = new AddEditCharityForm();
            form.Show();
        }

        private void ManageCharitiesForm_Load(object sender, EventArgs e)
        {
            foreach (DataRow charity in this.charityTableAdapter1.GetData())
            {
                imageList1.Images.Add(charity["CharityLogo"].ToString(), Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charity["CharityLogo"].ToString()));
                ListViewItem lvi = new ListViewItem();
                int currentId = int.Parse(charity["CharityId"].ToString()) - 1;
                lvi.ImageKey = charity["CharityLogo"].ToString();
                listView1.Items.Add(lvi);
                listView1.Items[currentId].SubItems.Add(charity["CharityName"].ToString());
                listView1.Items[currentId].SubItems.Add(charity["CharityDescription"].ToString());
                listView1.Items[currentId].SubItems.Add("Edit");
            }

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }
    }
}
