namespace MTC_Mobile
{
    partial class Index
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
            this.mnu_closeSession = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_readings_title = new System.Windows.Forms.Label();
            this.pnl_readings = new System.Windows.Forms.Panel();
            this.lbl_readings_description = new System.Windows.Forms.Label();
            this.btn_readings = new System.Windows.Forms.Button();
            this.pnl_procedures = new System.Windows.Forms.Panel();
            this.lbl_procedures_description = new System.Windows.Forms.Label();
            this.lbl_procedures_title = new System.Windows.Forms.Label();
            this.btn_procedures = new System.Windows.Forms.Button();
            this.pnl_users = new System.Windows.Forms.Panel();
            this.lbl_users_description = new System.Windows.Forms.Label();
            this.lbl_users_title = new System.Windows.Forms.Label();
            this.btn_users = new System.Windows.Forms.Button();
            this.pnl_readings.SuspendLayout();
            this.pnl_procedures.SuspendLayout();
            this.pnl_users.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnu_closeSession);
            this.mainMenu1.MenuItems.Add(this.mnu_exit);
            // 
            // mnu_closeSession
            // 
            this.mnu_closeSession.Text = "Cerrar Sesión";
            this.mnu_closeSession.Click += new System.EventHandler(this.mnu_closeSession_Click);
            // 
            // mnu_exit
            // 
            this.mnu_exit.Text = "Salir";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Bienvenido";
            // 
            // lbl_readings_title
            // 
            this.lbl_readings_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_readings_title.Location = new System.Drawing.Point(3, 5);
            this.lbl_readings_title.Name = "lbl_readings_title";
            this.lbl_readings_title.Size = new System.Drawing.Size(228, 20);
            this.lbl_readings_title.Text = "Lecturas";
            // 
            // pnl_readings
            // 
            this.pnl_readings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnl_readings.Controls.Add(this.lbl_readings_description);
            this.pnl_readings.Controls.Add(this.lbl_readings_title);
            this.pnl_readings.Controls.Add(this.btn_readings);
            this.pnl_readings.Location = new System.Drawing.Point(3, 33);
            this.pnl_readings.Name = "pnl_readings";
            this.pnl_readings.Size = new System.Drawing.Size(234, 73);
            this.pnl_readings.Visible = false;
            // 
            // lbl_readings_description
            // 
            this.lbl_readings_description.Location = new System.Drawing.Point(3, 25);
            this.lbl_readings_description.Name = "lbl_readings_description";
            this.lbl_readings_description.Size = new System.Drawing.Size(160, 40);
            this.lbl_readings_description.Text = "Leer datos del medidor y generar archivos xml y edf";
            // 
            // btn_readings
            // 
            this.btn_readings.Location = new System.Drawing.Point(169, 35);
            this.btn_readings.Name = "btn_readings";
            this.btn_readings.Size = new System.Drawing.Size(62, 20);
            this.btn_readings.TabIndex = 3;
            this.btn_readings.Text = "Entrar";
            this.btn_readings.Click += new System.EventHandler(this.btn_readings_Click);
            // 
            // pnl_procedures
            // 
            this.pnl_procedures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnl_procedures.Controls.Add(this.lbl_procedures_description);
            this.pnl_procedures.Controls.Add(this.lbl_procedures_title);
            this.pnl_procedures.Controls.Add(this.btn_procedures);
            this.pnl_procedures.Location = new System.Drawing.Point(3, 112);
            this.pnl_procedures.Name = "pnl_procedures";
            this.pnl_procedures.Size = new System.Drawing.Size(234, 73);
            this.pnl_procedures.Visible = false;
            // 
            // lbl_procedures_description
            // 
            this.lbl_procedures_description.Location = new System.Drawing.Point(3, 25);
            this.lbl_procedures_description.Name = "lbl_procedures_description";
            this.lbl_procedures_description.Size = new System.Drawing.Size(160, 41);
            this.lbl_procedures_description.Text = "Mandar comandos al medidor para que realice funciones";
            // 
            // lbl_procedures_title
            // 
            this.lbl_procedures_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_procedures_title.Location = new System.Drawing.Point(3, 5);
            this.lbl_procedures_title.Name = "lbl_procedures_title";
            this.lbl_procedures_title.Size = new System.Drawing.Size(228, 20);
            this.lbl_procedures_title.Text = "Procedimientos";
            // 
            // btn_procedures
            // 
            this.btn_procedures.Location = new System.Drawing.Point(169, 35);
            this.btn_procedures.Name = "btn_procedures";
            this.btn_procedures.Size = new System.Drawing.Size(62, 20);
            this.btn_procedures.TabIndex = 3;
            this.btn_procedures.Text = "Entrar";
            this.btn_procedures.Click += new System.EventHandler(this.btn_procedures_Click);
            // 
            // pnl_users
            // 
            this.pnl_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnl_users.Controls.Add(this.lbl_users_description);
            this.pnl_users.Controls.Add(this.lbl_users_title);
            this.pnl_users.Controls.Add(this.btn_users);
            this.pnl_users.Location = new System.Drawing.Point(3, 191);
            this.pnl_users.Name = "pnl_users";
            this.pnl_users.Size = new System.Drawing.Size(234, 73);
            this.pnl_users.Visible = false;
            // 
            // lbl_users_description
            // 
            this.lbl_users_description.Location = new System.Drawing.Point(3, 25);
            this.lbl_users_description.Name = "lbl_users_description";
            this.lbl_users_description.Size = new System.Drawing.Size(160, 41);
            this.lbl_users_description.Text = "Alta, editar y eliminar Usuarios de la aplicación";
            // 
            // lbl_users_title
            // 
            this.lbl_users_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_users_title.Location = new System.Drawing.Point(3, 5);
            this.lbl_users_title.Name = "lbl_users_title";
            this.lbl_users_title.Size = new System.Drawing.Size(228, 20);
            this.lbl_users_title.Text = "Gestión de Usuarios";
            // 
            // btn_users
            // 
            this.btn_users.Location = new System.Drawing.Point(169, 35);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(62, 20);
            this.btn_users.TabIndex = 3;
            this.btn_users.Text = "Entrar";
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnl_users);
            this.Controls.Add(this.pnl_procedures);
            this.Controls.Add(this.pnl_readings);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Index";
            this.Text = "Index";
            this.pnl_readings.ResumeLayout(false);
            this.pnl_procedures.ResumeLayout(false);
            this.pnl_users.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnu_closeSession;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_readings_title;
        private System.Windows.Forms.Panel pnl_readings;
        private System.Windows.Forms.Label lbl_readings_description;
        private System.Windows.Forms.Button btn_readings;
        private System.Windows.Forms.Panel pnl_procedures;
        private System.Windows.Forms.Label lbl_procedures_description;
        private System.Windows.Forms.Label lbl_procedures_title;
        private System.Windows.Forms.Button btn_procedures;
        private System.Windows.Forms.Panel pnl_users;
        private System.Windows.Forms.Label lbl_users_description;
        private System.Windows.Forms.Label lbl_users_title;
        private System.Windows.Forms.Button btn_users;
    }
}