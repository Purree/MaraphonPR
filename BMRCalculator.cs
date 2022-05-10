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
    public partial class BMRCalculator : Form
    {
        private Image female_icon = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\female-icon.png");
        private Image male_icon = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\male-icon.png");
        private Color inactive_color = Color.FromArgb(0, 255, 255, 255);
        private Color active_color = Color.FromArgb(0, 0, 0, 0);
        private int gender = 1; // 1 - male, 0 - female

        public int current_gender
        {
            get => gender;
            private set
            {
                gender = value;
                if (value == 1)
                {
                    change_active_button(button1, button2, male_icon);
                }

                if (value == 0)
                {
                    change_active_button(button2, button1, female_icon);
                }
            }
        }

        public BMRCalculator()
        {
            InitializeComponent();
        }

        private void BMRCalculator_Load(object sender, EventArgs e)
        {
            this.button1.Image = (Image)(new Bitmap(male_icon, new Size(32, 64)));
            this.button2.Image = (Image)(new Bitmap(female_icon, new Size(32, 64)));

            this.button1.BackColor = this.button2.BackColor = Color.LightGray;

            current_gender = 1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                string textbox_text = (sender as TextBox).Text;
                if ((textbox_text + e.KeyChar).IndexOf(",") <= 0 || textbox_text.Count(x => x == ',') >= 1)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            float value;
            if (!float.TryParse(textBox1.Text, out value))
            {
                textBox1.Text = "";
            }
        }

        private void change_active_button(Button activeButton, Button inactiveButton, Image active_image)
        {
            activeButton.FlatAppearance.BorderSize = 2;
            activeButton.ForeColor = active_color;

            inactiveButton.FlatAppearance.BorderSize = 1;
            inactiveButton.ForeColor = inactive_color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current_gender = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            current_gender = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float weight = 0;
            float growth = 0;
            float age = 0;
            double BMR = 0;

            float.TryParse(textBox1.Text, out growth);
            float.TryParse(textBox2.Text, out weight);
            float.TryParse(textBox3.Text, out age);

            growth /= 100;

            if (weight == 0 || growth == 0 || age == 0)
            {
                label5.Text = "Вес, возраст или рост не заполнен";
                timer1.Start();
                return;
            }

            if (current_gender == 1)
            {
                BMR = 66 + (13.7 * weight) + (5 * growth) - (6.8 * age);
            } 
            else
            {
                BMR = 655 + (9.6 * weight) + (1.8 * growth) - (4.7 * age);
            }

            label9.Text = ((int)BMR).ToString();
            label16.Text = ((int)(BMR * 1.2)).ToString();
            label17.Text = ((int)(BMR * 1.375)).ToString();
            label18.Text = ((int)(BMR * 1.55)).ToString();
            label19.Text = ((int)(BMR * 1.725)).ToString();
            label20.Text = ((int)(BMR * 1.9)).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = "BMR калькулятор";
            timer1.Stop();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }
    }
}
