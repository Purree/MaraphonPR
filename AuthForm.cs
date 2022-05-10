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
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            change_test_panel_visability();   
        }

        private void change_test_panel_visability()
        {
            panel4.Visible = panel3.Visible;
            panel3.Visible = !panel3.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthForm form = new AuthForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(500, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunnerDTO.Id = "102";
            RunnerDTO.currentRunner = this.runnerTableAdapter1.GetData().Select("[RunnerId] = " + RunnerDTO.Id).Last();
            RunnerDTO.currentUser = this.userTableAdapter1.GetData().Select("[Email] = '" + RunnerDTO.currentRunner["Email"].ToString() + "'").Last();

            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            Close();
            CoordinatorMenuForm form = new CoordinatorMenuForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            AdministratorMenuForm form = new AdministratorMenuForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }
    }
}
