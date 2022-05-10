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
    public partial class BMICalculator : Form
    {
        private Image female_icon = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\female-icon.png");
        private Image male_icon = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\male-icon.png");
        private Color inactive_color = Color.FromArgb(0, 255, 255, 255);
        private Color active_color = Color.FromArgb(0, 0, 0, 0);
        
        public int current_gender { 
            get => current_gender;
            private set 
            { 
                // 1 - male, 0 - female
                if (value == 1) {
                    change_active_button(button1, button2, male_icon);
                }

                if (value == 0)
                {
                    change_active_button(button2, button1, female_icon);
                }
            } 
        }

        public BMICalculator()
        {
            InitializeComponent();
        }

        private void BMICalculator_Load(object sender, EventArgs e)
        {

            this.button1.Image = (Image)(new Bitmap(male_icon, new Size(32, 64)));
            this.button2.Image = (Image)(new Bitmap(female_icon, new Size(32, 64)));

            this.button1.BackColor = this.button2.BackColor = this.panel1.BackColor = Color.LightGray;

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
            if (!float.TryParse(textBox1.Text, out value)) {
                textBox1.Text = ""; }
        }

        private void change_active_button(Button activeButton, Button inactiveButton, Image active_image)
        {
            activeButton.FlatAppearance.BorderSize = 2;
            activeButton.ForeColor = active_color;

            inactiveButton.FlatAppearance.BorderSize = 1;
            inactiveButton.ForeColor = inactive_color;

            pictureBox1.Image = active_image;
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
            float.TryParse(textBox1.Text, out growth);
            float.TryParse(textBox2.Text, out weight);

            growth /= 100;

            if (weight == 0 || growth == 0)
            {
                label5.Text = "Вес или рост не заполнен";
                timer1.Start();
                return;
            }

            float BMI = (weight / (growth * growth));
            label7.Text = BMI.ToString();
            label6.Text = get_BMI_status(BMI);

            trackBar1.Value = BMI >= 30 ? 30 : (int)BMI;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            label5.Text = "BMI калькулятор";
        }

        private string get_BMI_status(float BMI)
        {
            if (BMI < 18.5)
            {
                return "Недостаточный";
            }

            if (BMI < 24.9)
            {
                return "Здоровый";
            }

            if (BMI < 29.9)
            {
                return "Избыточный";
            }

            return "Ожирение";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            StartedForm form = new StartedForm();
            form.Show();
        }
    }
}
