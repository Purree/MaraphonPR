using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveMap
{
    public partial class AddEditCharityForm : Form
    {
        private bool update;
        private string fileName;
        private DataRow charityToUpdate;

        public AddEditCharityForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            ManageCharitiesForm form = new ManageCharitiesForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            ManageCharitiesForm form = new ManageCharitiesForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ManageCharitiesForm form = new ManageCharitiesForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    throw new Exception("Не заполнено");

                DataRow drCharity = update ? charityToUpdate : this.maraphonDataSet.Charity.NewRow();

                drCharity["CharityName"] = textBox2.Text;
                drCharity["CharityDescription"] = textBox3.Text;
                drCharity["CharityLogo"] = fileName;

                if (!update)
                    this.maraphonDataSet.Charity.Rows.Add(drCharity);

                this.charityTableAdapter1.Update(this.maraphonDataSet.Charity);


                Close();
                ManageCharitiesForm form = new ManageCharitiesForm();
                form.Show();

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Неверно заполненно");
                this.charityTableAdapter1.Fill(this.maraphonDataSet.Charity);
            }

        }

        private void AddEditCharityForm_Load(object sender, EventArgs e)
        {
            this.charityTableAdapter1.Fill(this.maraphonDataSet.Charity);
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";


            if (EditPDO.editedCharityName == "")
            {
                update = false;
            } else
            {
                update = true;
                charityToUpdate = this.maraphonDataSet.Charity.Select("CharityName = '" + EditPDO.editedCharityName + "'").Last();
                pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charityToUpdate["CharityLogo"].ToString());
                textBox1.Text = @"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charityToUpdate["CharityLogo"].ToString();
                fileName = charityToUpdate["CharityLogo"].ToString();
                textBox2.Text = EditPDO.editedCharityName;
                textBox3.Text = charityToUpdate["CharityDescription"].ToString();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
            fileName = openFileDialog1.SafeFileName;
            File.Copy(openFileDialog1.FileName, Path.Combine("D:\\Download\\desktopBackup\\Колледж\\удАЛЁНКА\\Системное Программирование\\InteractiveMap\\charities\\", fileName));
            pictureBox1.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + fileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
