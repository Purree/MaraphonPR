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
    public partial class AdministratorMenuForm : Form
    {
        public AdministratorMenuForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
            UserManagementForm form = new UserManagementForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            ManageCharitiesForm form = new ManageCharitiesForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            VolunteerManagementForm form = new VolunteerManagementForm();
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
            VolunteerManagementForm form = new VolunteerManagementForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            InventarForm form = new InventarForm();
            form.Show();
        }
    }
}
