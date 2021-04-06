namespace MTC_Mobile
{
    partial class Readings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnu_back = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.tab_readings = new System.Windows.Forms.TabControl();
            this.tab_read = new System.Windows.Forms.TabPage();
            this.pnl_reading_options = new System.Windows.Forms.Panel();
            this.lbl_options = new System.Windows.Forms.Label();
            this.rdo_weeks = new System.Windows.Forms.RadioButton();
            this.rdo_days = new System.Windows.Forms.RadioButton();
            this.rdo_nothing = new System.Windows.Forms.RadioButton();
            this.cbo_weeks = new System.Windows.Forms.ComboBox();
            this.cbo_days = new System.Windows.Forms.ComboBox();
            this.rdo_edf = new System.Windows.Forms.RadioButton();
            this.rdo_xml = new System.Windows.Forms.RadioButton();
            this.cbo_readings = new System.Windows.Forms.ComboBox();
            this.btn_readings = new System.Windows.Forms.Button();
            this.tab_config = new System.Windows.Forms.TabPage();
            this.btn_newFolder = new System.Windows.Forms.Button();
            this.txt_currDir = new System.Windows.Forms.TextBox();
            this.btn_backDir = new System.Windows.Forms.Button();
            this.btn_openDir = new System.Windows.Forms.Button();
            this.lst_directory = new System.Windows.Forms.ListBox();
            this.btn_setDirectory = new System.Windows.Forms.Button();
            this.lbl_directoryTitle = new System.Windows.Forms.Label();
            this.lbl_currentDir = new System.Windows.Forms.Label();
            this.tab_readings.SuspendLayout();
            this.tab_read.SuspendLayout();
            this.pnl_reading_options.SuspendLayout();
            this.tab_config.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnu_back);
            this.mainMenu1.MenuItems.Add(this.mnu_exit);
            // 
            // mnu_back
            // 
            this.mnu_back.Text = "Atrás";
            this.mnu_back.Click += new System.EventHandler(this.mnu_back_Click);
            // 
            // mnu_exit
            // 
            this.mnu_exit.Text = "Salir";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
            // 
            // tab_readings
            // 
            this.tab_readings.Controls.Add(this.tab_read);
            this.tab_readings.Controls.Add(this.tab_config);
            this.tab_readings.Location = new System.Drawing.Point(0, 0);
            this.tab_readings.Name = "tab_readings";
            this.tab_readings.SelectedIndex = 0;
            this.tab_readings.Size = new System.Drawing.Size(240, 265);
            this.tab_readings.TabIndex = 0;
            this.tab_readings.SelectedIndexChanged += new System.EventHandler(this.tab_readings_SelectedIndexChanged);
            // 
            // tab_read
            // 
            this.tab_read.Controls.Add(this.pnl_reading_options);
            this.tab_read.Controls.Add(this.rdo_edf);
            this.tab_read.Controls.Add(this.rdo_xml);
            this.tab_read.Controls.Add(this.cbo_readings);
            this.tab_read.Controls.Add(this.btn_readings);
            this.tab_read.Location = new System.Drawing.Point(0, 0);
            this.tab_read.Name = "tab_read";
            this.tab_read.Size = new System.Drawing.Size(240, 242);
            this.tab_read.Text = "Lecturas";
            // 
            // pnl_reading_options
            // 
            this.pnl_reading_options.Controls.Add(this.lbl_options);
            this.pnl_reading_options.Controls.Add(this.rdo_weeks);
            this.pnl_reading_options.Controls.Add(this.rdo_days);
            this.pnl_reading_options.Controls.Add(this.rdo_nothing);
            this.pnl_reading_options.Controls.Add(this.cbo_weeks);
            this.pnl_reading_options.Controls.Add(this.cbo_days);
            this.pnl_reading_options.Location = new System.Drawing.Point(7, 55);
            this.pnl_reading_options.Name = "pnl_reading_options";
            this.pnl_reading_options.Size = new System.Drawing.Size(225, 122);
            this.pnl_reading_options.Visible = false;
            // 
            // lbl_options
            // 
            this.lbl_options.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_options.Location = new System.Drawing.Point(6, 9);
            this.lbl_options.Name = "lbl_options";
            this.lbl_options.Size = new System.Drawing.Size(216, 20);
            this.lbl_options.Text = "Opciones de lectura";
            this.lbl_options.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rdo_weeks
            // 
            this.rdo_weeks.Location = new System.Drawing.Point(122, 84);
            this.rdo_weeks.Name = "rdo_weeks";
            this.rdo_weeks.Size = new System.Drawing.Size(100, 20);
            this.rdo_weeks.TabIndex = 6;
            this.rdo_weeks.Text = "Semanas";
            this.rdo_weeks.CheckedChanged += new System.EventHandler(this.rdo_weeks_CheckedChanged);
            // 
            // rdo_days
            // 
            this.rdo_days.Location = new System.Drawing.Point(122, 58);
            this.rdo_days.Name = "rdo_days";
            this.rdo_days.Size = new System.Drawing.Size(100, 20);
            this.rdo_days.TabIndex = 5;
            this.rdo_days.Text = "Días";
            this.rdo_days.CheckedChanged += new System.EventHandler(this.rdo_days_CheckedChanged);
            // 
            // rdo_nothing
            // 
            this.rdo_nothing.Location = new System.Drawing.Point(122, 32);
            this.rdo_nothing.Name = "rdo_nothing";
            this.rdo_nothing.Size = new System.Drawing.Size(100, 20);
            this.rdo_nothing.TabIndex = 4;
            this.rdo_nothing.Text = "Nada";
            this.rdo_nothing.CheckedChanged += new System.EventHandler(this.rdo_nothing_CheckedChanged);
            // 
            // cbo_weeks
            // 
            this.cbo_weeks.Items.Add("1");
            this.cbo_weeks.Items.Add("2");
            this.cbo_weeks.Items.Add("3");
            this.cbo_weeks.Items.Add("4");
            this.cbo_weeks.Location = new System.Drawing.Point(16, 82);
            this.cbo_weeks.Name = "cbo_weeks";
            this.cbo_weeks.Size = new System.Drawing.Size(100, 22);
            this.cbo_weeks.TabIndex = 3;
            // 
            // cbo_days
            // 
            this.cbo_days.Items.Add("1");
            this.cbo_days.Items.Add("2");
            this.cbo_days.Items.Add("3");
            this.cbo_days.Items.Add("4");
            this.cbo_days.Items.Add("5");
            this.cbo_days.Items.Add("6");
            this.cbo_days.Location = new System.Drawing.Point(16, 56);
            this.cbo_days.Name = "cbo_days";
            this.cbo_days.Size = new System.Drawing.Size(100, 22);
            this.cbo_days.TabIndex = 2;
            // 
            // rdo_edf
            // 
            this.rdo_edf.Location = new System.Drawing.Point(129, 31);
            this.rdo_edf.Name = "rdo_edf";
            this.rdo_edf.Size = new System.Drawing.Size(100, 20);
            this.rdo_edf.TabIndex = 5;
            this.rdo_edf.TabStop = false;
            this.rdo_edf.Text = "EDF";
            // 
            // rdo_xml
            // 
            this.rdo_xml.Checked = true;
            this.rdo_xml.Location = new System.Drawing.Point(23, 29);
            this.rdo_xml.Name = "rdo_xml";
            this.rdo_xml.Size = new System.Drawing.Size(100, 20);
            this.rdo_xml.TabIndex = 4;
            this.rdo_xml.Text = "XML";
            // 
            // cbo_readings
            // 
            this.cbo_readings.Items.Add("General Configuration");
            this.cbo_readings.Items.Add("Data Source");
            this.cbo_readings.Items.Add("Register Tables");
            this.cbo_readings.Items.Add("Time of Use");
            this.cbo_readings.Items.Add("Load Profiles");
            this.cbo_readings.Items.Add("History and Event Logs");
            this.cbo_readings.Items.Add("EOS");
            this.cbo_readings.Location = new System.Drawing.Point(7, 3);
            this.cbo_readings.Name = "cbo_readings";
            this.cbo_readings.Size = new System.Drawing.Size(226, 22);
            this.cbo_readings.TabIndex = 3;
            this.cbo_readings.SelectedIndexChanged += new System.EventHandler(this.cbo_readings_SelectedIndexChanged);
            // 
            // btn_readings
            // 
            this.btn_readings.Location = new System.Drawing.Point(161, 219);
            this.btn_readings.Name = "btn_readings";
            this.btn_readings.Size = new System.Drawing.Size(72, 20);
            this.btn_readings.TabIndex = 2;
            this.btn_readings.Text = "Leer";
            this.btn_readings.Click += new System.EventHandler(this.btn_readings_Click);
            // 
            // tab_config
            // 
            this.tab_config.Controls.Add(this.btn_newFolder);
            this.tab_config.Controls.Add(this.txt_currDir);
            this.tab_config.Controls.Add(this.btn_backDir);
            this.tab_config.Controls.Add(this.btn_openDir);
            this.tab_config.Controls.Add(this.lst_directory);
            this.tab_config.Controls.Add(this.btn_setDirectory);
            this.tab_config.Controls.Add(this.lbl_directoryTitle);
            this.tab_config.Controls.Add(this.lbl_currentDir);
            this.tab_config.Location = new System.Drawing.Point(0, 0);
            this.tab_config.Name = "tab_config";
            this.tab_config.Size = new System.Drawing.Size(240, 242);
            this.tab_config.Text = "Configuración";
            // 
            // btn_newFolder
            // 
            this.btn_newFolder.Location = new System.Drawing.Point(163, 155);
            this.btn_newFolder.Name = "btn_newFolder";
            this.btn_newFolder.Size = new System.Drawing.Size(72, 20);
            this.btn_newFolder.TabIndex = 38;
            this.btn_newFolder.Text = "Nuevo";
            this.btn_newFolder.Click += new System.EventHandler(this.btn_newFolder_Click);
            // 
            // txt_currDir
            // 
            this.txt_currDir.Enabled = false;
            this.txt_currDir.Location = new System.Drawing.Point(5, 218);
            this.txt_currDir.Name = "txt_currDir";
            this.txt_currDir.Size = new System.Drawing.Size(228, 21);
            this.txt_currDir.TabIndex = 37;
            // 
            // btn_backDir
            // 
            this.btn_backDir.Location = new System.Drawing.Point(9, 180);
            this.btn_backDir.Name = "btn_backDir";
            this.btn_backDir.Size = new System.Drawing.Size(72, 20);
            this.btn_backDir.TabIndex = 36;
            this.btn_backDir.Text = "Atras";
            this.btn_backDir.Click += new System.EventHandler(this.btn_backDir_Click);
            // 
            // btn_openDir
            // 
            this.btn_openDir.Location = new System.Drawing.Point(9, 154);
            this.btn_openDir.Name = "btn_openDir";
            this.btn_openDir.Size = new System.Drawing.Size(72, 20);
            this.btn_openDir.TabIndex = 35;
            this.btn_openDir.Text = "Abrir";
            this.btn_openDir.Click += new System.EventHandler(this.btn_openDir_Click);
            // 
            // lst_directory
            // 
            this.lst_directory.Location = new System.Drawing.Point(9, 63);
            this.lst_directory.Name = "lst_directory";
            this.lst_directory.Size = new System.Drawing.Size(226, 86);
            this.lst_directory.TabIndex = 34;
            // 
            // btn_setDirectory
            // 
            this.btn_setDirectory.Location = new System.Drawing.Point(163, 180);
            this.btn_setDirectory.Name = "btn_setDirectory";
            this.btn_setDirectory.Size = new System.Drawing.Size(72, 20);
            this.btn_setDirectory.TabIndex = 33;
            this.btn_setDirectory.Text = "Establecer";
            this.btn_setDirectory.Click += new System.EventHandler(this.btn_setDirectory_Click);
            // 
            // lbl_directoryTitle
            // 
            this.lbl_directoryTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_directoryTitle.Location = new System.Drawing.Point(9, 4);
            this.lbl_directoryTitle.Name = "lbl_directoryTitle";
            this.lbl_directoryTitle.Size = new System.Drawing.Size(226, 20);
            this.lbl_directoryTitle.Text = "Directorio almacenamiento de XML";
            // 
            // lbl_currentDir
            // 
            this.lbl_currentDir.Location = new System.Drawing.Point(9, 24);
            this.lbl_currentDir.Name = "lbl_currentDir";
            this.lbl_currentDir.Size = new System.Drawing.Size(226, 36);
            this.lbl_currentDir.Text = "Actual:";
            // 
            // Readings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tab_readings);
            this.Menu = this.mainMenu1;
            this.Name = "Readings";
            this.Text = "Readings";
            this.tab_readings.ResumeLayout(false);
            this.tab_read.ResumeLayout(false);
            this.pnl_reading_options.ResumeLayout(false);
            this.tab_config.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.TabControl tab_readings;
        private System.Windows.Forms.TabPage tab_read;
        private System.Windows.Forms.TabPage tab_config;
        private System.Windows.Forms.ComboBox cbo_readings;
        private System.Windows.Forms.Button btn_readings;
        private System.Windows.Forms.Button btn_newFolder;
        private System.Windows.Forms.TextBox txt_currDir;
        private System.Windows.Forms.Button btn_backDir;
        private System.Windows.Forms.Button btn_openDir;
        private System.Windows.Forms.ListBox lst_directory;
        private System.Windows.Forms.Button btn_setDirectory;
        private System.Windows.Forms.Label lbl_directoryTitle;
        private System.Windows.Forms.Label lbl_currentDir;
        private System.Windows.Forms.RadioButton rdo_edf;
        private System.Windows.Forms.RadioButton rdo_xml;
        private System.Windows.Forms.Panel pnl_reading_options;
        private System.Windows.Forms.ComboBox cbo_weeks;
        private System.Windows.Forms.ComboBox cbo_days;
        private System.Windows.Forms.RadioButton rdo_weeks;
        private System.Windows.Forms.RadioButton rdo_days;
        private System.Windows.Forms.RadioButton rdo_nothing;
        private System.Windows.Forms.Label lbl_options;
    }
}