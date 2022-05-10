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
    public partial class InteractiveMapForm : Form
    {
        public InteractiveMapForm()
        {
            InitializeComponent();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location.ToString());
            if (e.Button.Equals(MouseButtons.Left))
            {
                Rectangle firstButton = new Rectangle(364, 24, 50, 55);
                Rectangle secondButton = new Rectangle(429, 191, 50, 55);
                Rectangle thirdButton = new Rectangle(419, 312, 50, 55);
                Rectangle fourthButton = new Rectangle(560, 445, 50, 55);
                Rectangle fifthButton = new Rectangle(332, 531, 50, 55);
                Rectangle sixthButton = new Rectangle(142, 469, 50, 55);
                Rectangle seventhButton = new Rectangle(85, 364, 50, 55);
                Rectangle eighthButton = new Rectangle(68, 185, 50, 55);

                if (firstButton.Contains(e.Location)) button_handle("Checkpoint 1", "Avenida Rudge", "✓", "✓", "✘", "✘", "✘");
                if (secondButton.Contains(e.Location)) button_handle("Checkpoint 2", "Theatro Municipal", "✓", "✓", "✓", "✓", "✓");
                if (thirdButton.Contains(e.Location)) button_handle("Checkpoint 3", "Parque do Ibirapuera", "✓", "✓", "✓", "✘", "✘");
                if (fourthButton.Contains(e.Location)) button_handle("Checkpoint 4", "Jardim Luzitania", "✓", "✓", "✓", "✘", "✓");
                if (fifthButton.Contains(e.Location)) button_handle("Checkpoint 5", "Iguatemi", "✓", "✓", "✓", "✓", "✘");
                if (sixthButton.Contains(e.Location)) button_handle("Checkpoint 6", "Rua Lisboa", "✓", "✓", "✓", "✘", "✘");
                if (seventhButton.Contains(e.Location)) button_handle("Checkpoint 7", "Cemitério da Consolação", "✓", "✓", "✓", "✓", "✓");
                if (eighthButton.Contains(e.Location)) button_handle("Checkpoint 8", "Cemitério da Consolação", "✓", "✓", "✓", "✓", "✓");
            }
        }

        private void button_handle(string checkpointNumber, string landmark, string drinksText, string energyBarsText, string toiletsText, string informationText, string medicalText)
        {
            label2.Text = checkpointNumber;
            label3.Text = landmark;
            panel2.Visible = true;
            drinks.Text = drinksText;
            toilets.Text = toiletsText;
            energyBars.Text = energyBarsText;
            information.Text = informationText;
            medical.Text = medicalText;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            BMICalculator calculator_form = new BMICalculator();
            calculator_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            BMRCalculator calculator_form = new BMRCalculator();
            calculator_form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            FindOutMoreInformationForm form = new FindOutMoreInformationForm();
            form.Show();
        }
    }
}
