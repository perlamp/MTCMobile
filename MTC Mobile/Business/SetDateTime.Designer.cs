namespace MTC_Mobile.Business
{
    partial class SetDateTime
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbo_timeZone = new System.Windows.Forms.ComboBox();
            this.dt_date_1 = new System.Windows.Forms.DateTimePicker();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnu_back = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.dt_time_1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(159, 193);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(72, 20);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Write";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dt_time_1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.cbo_timeZone);
            this.panel1.Controls.Add(this.dt_date_1);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 268);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.Text = "Time Zone:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(4, 193);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbo_timeZone
            // 
            this.cbo_timeZone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbo_timeZone.Items.Add("(UTC -08:00:00)  Pacific Standard Time (Mexico)");
            this.cbo_timeZone.Items.Add("(UTC -07:00:00)  Mountain Standard Time (Mexico)");
            this.cbo_timeZone.Items.Add("(UTC -06:00:00)  Central Standard Time (Mexico)");
            this.cbo_timeZone.Items.Add("(UTC -05:00:00)  Eastern Standard Time (Mexico)");
            this.cbo_timeZone.Location = new System.Drawing.Point(4, 140);
            this.cbo_timeZone.Name = "cbo_timeZone";
            this.cbo_timeZone.Size = new System.Drawing.Size(227, 20);
            this.cbo_timeZone.TabIndex = 6;
            // 
            // dt_date_1
            // 
            this.dt_date_1.Location = new System.Drawing.Point(4, 35);
            this.dt_date_1.Name = "dt_date_1";
            this.dt_date_1.Size = new System.Drawing.Size(227, 22);
            this.dt_date_1.TabIndex = 5;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnu_back);
            this.mainMenu1.MenuItems.Add(this.mnu_exit);
            // 
            // mnu_back
            // 
            this.mnu_back.Text = "Atrás";
            // 
            // mnu_exit
            // 
            this.mnu_exit.Text = "Salir";
            // 
            // dt_time_1
            // 
            this.dt_time_1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_time_1.Location = new System.Drawing.Point(48, 76);
            this.dt_time_1.Name = "dt_time_1";
            this.dt_time_1.Size = new System.Drawing.Size(132, 22);
            this.dt_time_1.TabIndex = 10;
            // 
            // SetDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "SetDateTime";
            this.Text = "SetDateTime";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_timeZone;
        private System.Windows.Forms.DateTimePicker dt_date_1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_time_1;
    }
}