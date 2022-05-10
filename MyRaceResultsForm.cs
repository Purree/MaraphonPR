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
    public partial class MyRaceResultsForm : Form
    {
        public MyRaceResultsForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            RunnerMenuForm form = new RunnerMenuForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            PreviousRaceResultsForm form = new PreviousRaceResultsForm();
            form.Show();
        }

        private void registrationEventBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.registrationEventBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.maraphonDataSet);

        }

        private void MyRaceResultsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "maraphonDataSet.RegistrationEvent". При необходимости она может быть перемещена или удалена.
            this.registrationEventTableAdapter.Fill(this.maraphonDataSet.RegistrationEvent);
            int countOfMaraphons = 0;

            foreach (DataRow registration in this.registrationTableAdapter1.GetData().Select("[RunnerId] = " + RunnerDTO.Id + " AND [RegistrationStatusId] = 4")) 
            {
                countOfMaraphons++;

                DataRow registrationEvent = this.registrationEventTableAdapter.GetData().Select("[RegistrationId] = '" + registration["RegistrationId"].ToString() + "'").Last();
                DataRow fullEvent = this.eventTableAdapter1.GetData().Select("[EventId] = '" + registrationEvent["EventId"] + "'").Last();
                string eventType = this.eventTypeTableAdapter1.GetData().Select("[EventTypeId] = '" + fullEvent["EventTypeId"].ToString() + "'").Last()["EventTypeName"].ToString();

                Label EventTypelabel = this.Controls.Find("EventType" + countOfMaraphons, true).First() as Label;
                EventTypelabel.Text = eventType;
                Label registrationIdlabel = this.Controls.Find("registrationId" + countOfMaraphons, true).First() as Label;
                registrationIdlabel.Text = registration["RegistrationId"].ToString();
                Label BibNumberlabel = this.Controls.Find("BibNumber" + countOfMaraphons, true).First() as Label;
                BibNumberlabel.Text = registrationEvent["BibNumber"].ToString();
                Label RaceTimelabel = this.Controls.Find("RaceTime" + countOfMaraphons, true).First() as Label;
                RaceTimelabel.Text = TimeSpan.FromSeconds(Double.Parse(registrationEvent["RaceTime"].ToString())).ToString("hh':'mm':'ss");
                Label maraphonNamelabel = this.Controls.Find("maraphonName" + countOfMaraphons, true).First() as Label;
                maraphonNamelabel.Text = fullEvent["EventName"].ToString();


                if (countOfMaraphons >= 4)
                {
                    break;
                }
            };

            if (RunnerDTO.currentRunner["Gender"].ToString() == "Male")
            {
                label7.Text = "Мужской";
            } else
            {
                label7.Text = "Женский";
            }
        }
    }
}
