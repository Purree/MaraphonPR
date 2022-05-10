
namespace InteractiveMap
{
    partial class ListOfCharitiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfCharitiesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.charityDescription1 = new System.Windows.Forms.Label();
            this.charityName1 = new System.Windows.Forms.Label();
            this.charityDescription2 = new System.Windows.Forms.Label();
            this.charityName2 = new System.Windows.Forms.Label();
            this.charityDescription3 = new System.Windows.Forms.Label();
            this.charityName3 = new System.Windows.Forms.Label();
            this.maraphonDataSet = new InteractiveMap.MaraphonDataSet();
            this.volunteerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.volunteerTableAdapter = new InteractiveMap.MaraphonDataSetTableAdapters.VolunteerTableAdapter();
            this.charityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.charityTableAdapter = new InteractiveMap.MaraphonDataSetTableAdapters.CharityTableAdapter();
            this.tableAdapterManager = new InteractiveMap.MaraphonDataSetTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maraphonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volunteerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 241;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(246, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "MARATHON SKILLS 2035";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 488);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 35);
            this.panel2.TabIndex = 242;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(137, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(573, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "12 лет 8 дней 7 часов 13 минут 37 секунд до старта марафона!";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(744, 32);
            this.label3.TabIndex = 243;
            this.label3.Text = "Меню бегуна";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(754, 54);
            this.label2.TabIndex = 244;
            this.label2.Text = "Это - список благотворительных учреждений, которые поддерживаются в Marathon Skil" +
    "ls 2016. Спасибо за помощь вы поддерживаете их, спонсируя бегунов!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(39, 368);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 88);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 247;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(39, 274);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 246;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 245;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // charityDescription1
            // 
            this.charityDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityDescription1.Location = new System.Drawing.Point(145, 214);
            this.charityDescription1.Name = "charityDescription1";
            this.charityDescription1.Size = new System.Drawing.Size(630, 54);
            this.charityDescription1.TabIndex = 249;
            this.charityDescription1.Text = " ";
            this.charityDescription1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // charityName1
            // 
            this.charityName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityName1.Location = new System.Drawing.Point(145, 182);
            this.charityName1.Name = "charityName1";
            this.charityName1.Size = new System.Drawing.Size(630, 32);
            this.charityName1.TabIndex = 248;
            this.charityName1.Text = " ";
            this.charityName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // charityDescription2
            // 
            this.charityDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityDescription2.Location = new System.Drawing.Point(149, 308);
            this.charityDescription2.Name = "charityDescription2";
            this.charityDescription2.Size = new System.Drawing.Size(630, 60);
            this.charityDescription2.TabIndex = 251;
            this.charityDescription2.Text = " ";
            this.charityDescription2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // charityName2
            // 
            this.charityName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityName2.Location = new System.Drawing.Point(149, 276);
            this.charityName2.Name = "charityName2";
            this.charityName2.Size = new System.Drawing.Size(630, 32);
            this.charityName2.TabIndex = 250;
            this.charityName2.Text = " ";
            this.charityName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // charityDescription3
            // 
            this.charityDescription3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityDescription3.Location = new System.Drawing.Point(149, 400);
            this.charityDescription3.Name = "charityDescription3";
            this.charityDescription3.Size = new System.Drawing.Size(630, 68);
            this.charityDescription3.TabIndex = 253;
            this.charityDescription3.Text = " ";
            this.charityDescription3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // charityName3
            // 
            this.charityName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.charityName3.Location = new System.Drawing.Point(149, 368);
            this.charityName3.Name = "charityName3";
            this.charityName3.Size = new System.Drawing.Size(630, 32);
            this.charityName3.TabIndex = 252;
            this.charityName3.Text = " ";
            this.charityName3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maraphonDataSet
            // 
            this.maraphonDataSet.DataSetName = "MaraphonDataSet";
            this.maraphonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // volunteerBindingSource
            // 
            this.volunteerBindingSource.DataMember = "Volunteer";
            this.volunteerBindingSource.DataSource = this.maraphonDataSet;
            // 
            // volunteerTableAdapter
            // 
            this.volunteerTableAdapter.ClearBeforeFill = true;
            // 
            // charityBindingSource
            // 
            this.charityBindingSource.DataMember = "Charity";
            this.charityBindingSource.DataSource = this.maraphonDataSet;
            // 
            // charityTableAdapter
            // 
            this.charityTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CharityTableAdapter = this.charityTableAdapter;
            this.tableAdapterManager.CountryTableAdapter = null;
            this.tableAdapterManager.EventTableAdapter = null;
            this.tableAdapterManager.EventTypeTableAdapter = null;
            this.tableAdapterManager.GenderTableAdapter = null;
            this.tableAdapterManager.MarathonTableAdapter = null;
            this.tableAdapterManager.RaceKitOptionTableAdapter = null;
            this.tableAdapterManager.RegistrationEventTableAdapter = null;
            this.tableAdapterManager.RegistrationStatusTableAdapter = null;
            this.tableAdapterManager.RegistrationTableAdapter = null;
            this.tableAdapterManager.RoleTableAdapter = null;
            this.tableAdapterManager.RunnerTableAdapter = null;
            this.tableAdapterManager.SponsorshipTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = InteractiveMap.MaraphonDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UserTableAdapter = null;
            this.tableAdapterManager.VolunteerTableAdapter = this.volunteerTableAdapter;
            // 
            // ListOfCharitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.charityDescription3);
            this.Controls.Add(this.charityName3);
            this.Controls.Add(this.charityDescription2);
            this.Controls.Add(this.charityName2);
            this.Controls.Add(this.charityDescription1);
            this.Controls.Add(this.charityName1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ListOfCharitiesForm";
            this.Text = "ListOfCharitiesForm";
            this.Load += new System.EventHandler(this.ListOfCharitiesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maraphonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volunteerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label charityDescription1;
        private System.Windows.Forms.Label charityName1;
        private System.Windows.Forms.Label charityDescription2;
        private System.Windows.Forms.Label charityName2;
        private System.Windows.Forms.Label charityDescription3;
        private System.Windows.Forms.Label charityName3;
        private MaraphonDataSet maraphonDataSet;
        private System.Windows.Forms.BindingSource volunteerBindingSource;
        private MaraphonDataSetTableAdapters.VolunteerTableAdapter volunteerTableAdapter;
        private System.Windows.Forms.BindingSource charityBindingSource;
        private MaraphonDataSetTableAdapters.CharityTableAdapter charityTableAdapter;
        private MaraphonDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}