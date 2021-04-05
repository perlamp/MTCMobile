namespace MTC_Mobile
{
    partial class Procedures
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
            this.cbo_procedures = new System.Windows.Forms.ComboBox();
            this.btn_procedures = new System.Windows.Forms.Button();
            this.mnu_back = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnu_back);
            this.mainMenu1.MenuItems.Add(this.mnu_exit);
            // 
            // cbo_procedures
            // 
            this.cbo_procedures.Items.Add("Reinicio de Demanda");
            this.cbo_procedures.Items.Add("Sincronizar reloj");
            this.cbo_procedures.Items.Add("Reconfigurar Tarifa Horaria");
            this.cbo_procedures.Items.Add("Cambio de Claves");
            this.cbo_procedures.Items.Add("Corte y Reconexión");
            this.cbo_procedures.Location = new System.Drawing.Point(7, 16);
            this.cbo_procedures.Name = "cbo_procedures";
            this.cbo_procedures.Size = new System.Drawing.Size(226, 22);
            this.cbo_procedures.TabIndex = 21;
            // 
            // btn_procedures
            // 
            this.btn_procedures.Location = new System.Drawing.Point(161, 232);
            this.btn_procedures.Name = "btn_procedures";
            this.btn_procedures.Size = new System.Drawing.Size(72, 20);
            this.btn_procedures.TabIndex = 20;
            this.btn_procedures.Text = "Ejecutar";
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
            // Procedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.cbo_procedures);
            this.Controls.Add(this.btn_procedures);
            this.Menu = this.mainMenu1;
            this.Name = "Procedures";
            this.Text = "Procedures";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_procedures;
        private System.Windows.Forms.Button btn_procedures;
        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
    }
}