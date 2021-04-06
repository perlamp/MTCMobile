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
            this.mnu_back = new System.Windows.Forms.MenuItem();
            this.mnu_exit = new System.Windows.Forms.MenuItem();
            this.cboSpecialTask = new System.Windows.Forms.ComboBox();
            this.btn_procedures = new System.Windows.Forms.Button();
            this.cboSocketId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // cboSpecialTask
            // 
            this.cboSpecialTask.Items.Add("Reinicio de Demanda");
            this.cboSpecialTask.Items.Add("Sincronizar reloj");
            this.cboSpecialTask.Items.Add("Reconfigurar Tarifa Horaria");
            this.cboSpecialTask.Items.Add("Cambio de Claves");
            this.cboSpecialTask.Items.Add("Corte y Reconexión");
            this.cboSpecialTask.Location = new System.Drawing.Point(7, 36);
            this.cboSpecialTask.Name = "cboSpecialTask";
            this.cboSpecialTask.Size = new System.Drawing.Size(226, 22);
            this.cboSpecialTask.TabIndex = 21;
            this.cboSpecialTask.SelectedIndexChanged += new System.EventHandler(this.pcbSelectedSpecialTask_Click);
            // 
            // btn_procedures
            // 
            this.btn_procedures.Location = new System.Drawing.Point(161, 232);
            this.btn_procedures.Name = "btn_procedures";
            this.btn_procedures.Size = new System.Drawing.Size(72, 20);
            this.btn_procedures.TabIndex = 20;
            this.btn_procedures.Text = "Ejecutar";
            // 
            // cboSocketId
            // 
            this.cboSocketId.Items.Add("1");
            this.cboSocketId.Items.Add("2");
            this.cboSocketId.Items.Add("3");
            this.cboSocketId.Items.Add("4");
            this.cboSocketId.Items.Add("5");
            this.cboSocketId.Items.Add("6");
            this.cboSocketId.Items.Add("7");
            this.cboSocketId.Items.Add("8");
            this.cboSocketId.Items.Add("9");
            this.cboSocketId.Items.Add("10");
            this.cboSocketId.Items.Add("11");
            this.cboSocketId.Items.Add("12");
            this.cboSocketId.Items.Add("13");
            this.cboSocketId.Items.Add("14");
            this.cboSocketId.Items.Add("15");
            this.cboSocketId.Items.Add("16");
            this.cboSocketId.Items.Add("17");
            this.cboSocketId.Items.Add("18");
            this.cboSocketId.Items.Add("19");
            this.cboSocketId.Items.Add("20");
            this.cboSocketId.Items.Add("21");
            this.cboSocketId.Items.Add("22");
            this.cboSocketId.Items.Add("23");
            this.cboSocketId.Items.Add("24");
            this.cboSocketId.Location = new System.Drawing.Point(7, 92);
            this.cboSocketId.Name = "cboSocketId";
            this.cboSocketId.Size = new System.Drawing.Size(226, 22);
            this.cboSocketId.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Procedure";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Socket";
            // 
            // Procedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSocketId);
            this.Controls.Add(this.cboSpecialTask);
            this.Controls.Add(this.btn_procedures);
            this.Menu = this.mainMenu1;
            this.Name = "Procedures";
            this.Text = "Procedures";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_procedures;
        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.ComboBox cboSpecialTask;
        private System.Windows.Forms.ComboBox cboSocketId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}