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
    public partial class ListOfCharitiesForm : Form
    {
        public ListOfCharitiesForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            FindOutMoreInformationForm form = new FindOutMoreInformationForm();
            form.Show();
        }

        private void ListOfCharitiesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.Charity". При необходимости она может быть перемещена или удалена.
            this.charityTableAdapter.Fill(this.maraphonDataSet.Charity);
            int charitiesCount = 0;

            foreach (DataRow charity in this.charityTableAdapter.GetData())
            {
                charitiesCount++;

                PictureBox pictureBox = this.Controls.Find("pictureBox" + charitiesCount, true).First() as PictureBox;
                pictureBox.Image = Image.FromFile(@"D:\Download\desktopBackup\Колледж\удАЛЁНКА\Системное Программирование\InteractiveMap\charities\" + charity["CharityLogo"].ToString());
                pictureBox.Visible = true;
                Label charityName = this.Controls.Find("charityName" + charitiesCount, true).First() as Label;
                charityName.Text = charity["CharityName"].ToString();
                Label charityDescription = this.Controls.Find("charityDescription" + charitiesCount, true).First() as Label;
                charityDescription.Text = charity["CharityDescription"].ToString();

                if (charitiesCount >= 3)
                {
                    break;
                }
            }
        }
    }
}
