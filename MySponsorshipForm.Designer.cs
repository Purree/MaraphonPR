
namespace InteractiveMap
{
    partial class MySponsorshipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySponsorshipForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SponsorName1 = new System.Windows.Forms.Label();
            this.SponsorName2 = new System.Windows.Forms.Label();
            this.SponsorName3 = new System.Windows.Forms.Label();
            this.SponsorName4 = new System.Windows.Forms.Label();
            this.SponsorName5 = new System.Windows.Forms.Label();
            this.SponsorMoney1 = new System.Windows.Forms.Label();
            this.SponsorMoney2 = new System.Windows.Forms.Label();
            this.SponsorMoney3 = new System.Windows.Forms.Label();
            this.SponsorMoney4 = new System.Windows.Forms.Label();
            this.SponsorMoney5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.registrationTableAdapter1 = new InteractiveMap.MaraphonDataSetTableAdapters.RegistrationTableAdapter();
            this.charityTableAdapter1 = new InteractiveMap.MaraphonDataSetTableAdapters.CharityTableAdapter();
            this.sponsorshipTableAdapter1 = new InteractiveMap.MaraphonDataSetTableAdapters.SponsorshipTableAdapter();
            this.totalCost = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 35);
            this.panel2.TabIndex = 233;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 232;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(711, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 29);
            this.button4.TabIndex = 2;
            this.button4.Text = "Выйти";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(25, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(744, 32);
            this.label3.TabIndex = 246;
            this.label3.Text = "Мои спонсоры";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(203, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 19);
            this.label2.TabIndex = 247;
            this.label2.Text = "Здаесь показаны все ваши спонсоры в Marathin Skills 2016.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(94, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 248;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(29, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 32);
            this.label6.TabIndex = 249;
            this.label6.Text = "Подари жизнь";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(26, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 98);
            this.label5.TabIndex = 250;
            this.label5.Text = "Это было бы длинным описанием благотворительности. Это могло пойти для нескольких" +
    " параграфов. Это - больше описания здесь, и это - ещё часть описания также.";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(711, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 251;
            this.label7.Text = "Взнос";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(556, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 252;
            this.label8.Text = "Спонсор";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SponsorName1
            // 
            this.SponsorName1.Location = new System.Drawing.Point(563, 211);
            this.SponsorName1.Name = "SponsorName1";
            this.SponsorName1.Size = new System.Drawing.Size(159, 13);
            this.SponsorName1.TabIndex = 253;
            // 
            // SponsorName2
            // 
            this.SponsorName2.Location = new System.Drawing.Point(563, 239);
            this.SponsorName2.Name = "SponsorName2";
            this.SponsorName2.Size = new System.Drawing.Size(159, 13);
            this.SponsorName2.TabIndex = 254;
            // 
            // SponsorName3
            // 
            this.SponsorName3.Location = new System.Drawing.Point(563, 266);
            this.SponsorName3.Name = "SponsorName3";
            this.SponsorName3.Size = new System.Drawing.Size(159, 13);
            this.SponsorName3.TabIndex = 255;
            // 
            // SponsorName4
            // 
            this.SponsorName4.Location = new System.Drawing.Point(563, 294);
            this.SponsorName4.Name = "SponsorName4";
            this.SponsorName4.Size = new System.Drawing.Size(159, 13);
            this.SponsorName4.TabIndex = 256;
            // 
            // SponsorName5
            // 
            this.SponsorName5.Location = new System.Drawing.Point(563, 322);
            this.SponsorName5.Name = "SponsorName5";
            this.SponsorName5.Size = new System.Drawing.Size(159, 13);
            this.SponsorName5.TabIndex = 257;
            // 
            // SponsorMoney1
            // 
            this.SponsorMoney1.Location = new System.Drawing.Point(728, 211);
            this.SponsorMoney1.Name = "SponsorMoney1";
            this.SponsorMoney1.Size = new System.Drawing.Size(47, 13);
            this.SponsorMoney1.TabIndex = 258;
            this.SponsorMoney1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SponsorMoney2
            // 
            this.SponsorMoney2.Location = new System.Drawing.Point(728, 239);
            this.SponsorMoney2.Name = "SponsorMoney2";
            this.SponsorMoney2.Size = new System.Drawing.Size(47, 13);
            this.SponsorMoney2.TabIndex = 259;
            this.SponsorMoney2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SponsorMoney2.Click += new System.EventHandler(this.SponsorMoney2_Click);
            // 
            // SponsorMoney3
            // 
            this.SponsorMoney3.Location = new System.Drawing.Point(728, 266);
            this.SponsorMoney3.Name = "SponsorMoney3";
            this.SponsorMoney3.Size = new System.Drawing.Size(47, 13);
            this.SponsorMoney3.TabIndex = 260;
            this.SponsorMoney3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SponsorMoney4
            // 
            this.SponsorMoney4.Location = new System.Drawing.Point(728, 294);
            this.SponsorMoney4.Name = "SponsorMoney4";
            this.SponsorMoney4.Size = new System.Drawing.Size(47, 13);
            this.SponsorMoney4.TabIndex = 261;
            this.SponsorMoney4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SponsorMoney5
            // 
            this.SponsorMoney5.Location = new System.Drawing.Point(728, 322);
            this.SponsorMoney5.Name = "SponsorMoney5";
            this.SponsorMoney5.Size = new System.Drawing.Size(47, 13);
            this.SponsorMoney5.TabIndex = 262;
            this.SponsorMoney5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(562, 361);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 25);
            this.label19.TabIndex = 263;
            this.label19.Text = "Всего";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registrationTableAdapter1
            // 
            this.registrationTableAdapter1.ClearBeforeFill = true;
            // 
            // charityTableAdapter1
            // 
            this.charityTableAdapter1.ClearBeforeFill = true;
            // 
            // sponsorshipTableAdapter1
            // 
            this.sponsorshipTableAdapter1.ClearBeforeFill = true;
            // 
            // totalCost
            // 
            this.totalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalCost.Location = new System.Drawing.Point(671, 361);
            this.totalCost.Name = "totalCost";
            this.totalCost.Size = new System.Drawing.Size(117, 25);
            this.totalCost.TabIndex = 264;
            this.totalCost.Text = "0$";
            this.totalCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MySponsorshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.totalCost);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.SponsorMoney5);
            this.Controls.Add(this.SponsorMoney4);
            this.Controls.Add(this.SponsorMoney3);
            this.Controls.Add(this.SponsorMoney2);
            this.Controls.Add(this.SponsorMoney1);
            this.Controls.Add(this.SponsorName5);
            this.Controls.Add(this.SponsorName4);
            this.Controls.Add(this.SponsorName3);
            this.Controls.Add(this.SponsorName2);
            this.Controls.Add(this.SponsorName1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MySponsorshipForm";
            this.Text = "MySponsorshipForm";
            this.Load += new System.EventHandler(this.MySponsorshipForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SponsorName1;
        private System.Windows.Forms.Label SponsorName2;
        private System.Windows.Forms.Label SponsorName3;
        private System.Windows.Forms.Label SponsorName4;
        private System.Windows.Forms.Label SponsorName5;
        private System.Windows.Forms.Label SponsorMoney1;
        private System.Windows.Forms.Label SponsorMoney2;
        private System.Windows.Forms.Label SponsorMoney3;
        private System.Windows.Forms.Label SponsorMoney4;
        private System.Windows.Forms.Label SponsorMoney5;
        private System.Windows.Forms.Label label19;
        private MaraphonDataSetTableAdapters.RegistrationTableAdapter registrationTableAdapter1;
        private MaraphonDataSetTableAdapters.CharityTableAdapter charityTableAdapter1;
        private MaraphonDataSetTableAdapters.SponsorshipTableAdapter sponsorshipTableAdapter1;
        private System.Windows.Forms.Label totalCost;
    }
}