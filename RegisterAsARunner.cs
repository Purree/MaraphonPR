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
    public partial class RegisterAsARunner : Form
    {
        public RegisterAsARunner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthForm form = new AuthForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterForm form = new RegisterForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthForm form = new AuthForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }

        private void RegisterAsARunner_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(500, 200);
        }
    }
}
