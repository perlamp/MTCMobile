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
            this.rdoDefaulDateTime = new System.Windows.Forms.RadioButton();
            this.rdoConfigDateTime = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.dt_date = new System.Windows.Forms.DateTimePicker();
            this.dt_time = new System.Windows.Forms.DateTimePicker();
            this.cbo_timeZone = new System.Windows.Forms.ComboBox();
            this.dt_date_1 = new System.Windows.Forms.DateTimePicker();
            this.dt_time_1 = new System.Windows.Forms.DateTimePicker();
            this.cbo_timeZone_1 = new System.Windows.Forms.ComboBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnu_back = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(162, 245);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(72, 20);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            // 
            // rdoDefaulDateTime
            // 
            this.rdoDefaulDateTime.Location = new System.Drawing.Point(4, 190);
            this.rdoDefaulDateTime.Name = "rdoDefaulDateTime";
            this.rdoDefaulDateTime.Size = new System.Drawing.Size(160, 20);
            this.rdoDefaulDateTime.TabIndex = 1;
            this.rdoDefaulDateTime.Text = "Default Date/Time";
            // 
            // rdoConfigDateTime
            // 
            this.rdoConfigDateTime.Location = new System.Drawing.Point(4, 216);
            this.rdoConfigDateTime.Name = "rdoConfigDateTime";
            this.rdoConfigDateTime.Size = new System.Drawing.Size(160, 20);
            this.rdoConfigDateTime.TabIndex = 2;
            this.rdoConfigDateTime.Text = "Configurate Date/Time";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.dt_date);
            this.panel1.Controls.Add(this.dt_time);
            this.panel1.Controls.Add(this.cbo_timeZone);
            this.panel1.Controls.Add(this.dt_date_1);
            this.panel1.Controls.Add(this.dt_time_1);
            this.panel1.Controls.Add(this.cbo_timeZone_1);
            this.panel1.Controls.Add(this.rdoConfigDateTime);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Controls.Add(this.rdoDefaulDateTime);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 268);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(4, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            // 
            // dt_date
            // 
            this.dt_date.Location = new System.Drawing.Point(133, 148);
            this.dt_date.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dt_date.Name = "dt_date";
            this.dt_date.Size = new System.Drawing.Size(98, 22);
            this.dt_date.TabIndex = 8;
            // 
            // dt_time
            // 
            this.dt_time.Location = new System.Drawing.Point(4, 148);
            this.dt_time.Name = "dt_time";
            this.dt_time.Size = new System.Drawing.Size(98, 22);
            this.dt_time.TabIndex = 7;
            // 
            // cbo_timeZone
            // 
            this.cbo_timeZone.Location = new System.Drawing.Point(105, 88);
            this.cbo_timeZone.Name = "cbo_timeZone";
            this.cbo_timeZone.Size = new System.Drawing.Size(132, 22);
            this.cbo_timeZone.TabIndex = 6;
            // 
            // dt_date_1
            // 
            this.dt_date_1.Location = new System.Drawing.Point(105, 32);
            this.dt_date_1.Name = "dt_date_1";
            this.dt_date_1.Size = new System.Drawing.Size(132, 22);
            this.dt_date_1.TabIndex = 5;
            // 
            // dt_time_1
            // 
            this.dt_time_1.Location = new System.Drawing.Point(105, 60);
            this.dt_time_1.Name = "dt_time_1";
            this.dt_time_1.Size = new System.Drawing.Size(132, 22);
            this.dt_time_1.TabIndex = 4;
            // 
            // cbo_timeZone_1
            // 
            this.cbo_timeZone_1.Location = new System.Drawing.Point(105, 3);
            this.cbo_timeZone_1.Name = "cbo_timeZone_1";
            this.cbo_timeZone_1.Size = new System.Drawing.Size(132, 22);
            this.cbo_timeZone_1.TabIndex = 3;
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Time Zone:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Set Date/Time";
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
        private System.Windows.Forms.RadioButton rdoDefaulDateTime;
        private System.Windows.Forms.RadioButton rdoConfigDateTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_timeZone_1;
        private System.Windows.Forms.DateTimePicker dt_date;
        private System.Windows.Forms.DateTimePicker dt_time;
        private System.Windows.Forms.ComboBox cbo_timeZone;
        private System.Windows.Forms.DateTimePicker dt_date_1;
        private System.Windows.Forms.DateTimePicker dt_time_1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}