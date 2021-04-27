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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendFrame = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.cboSpecialTask.Items.Add("Connect");
            this.cboSpecialTask.Items.Add("Change passwords");
            this.cboSpecialTask.Items.Add("End test mode");
            this.cboSpecialTask.Items.Add("Disconnect");
            this.cboSpecialTask.Items.Add("Demand reset");
            this.cboSpecialTask.Items.Add("Get date/time");
            this.cboSpecialTask.Items.Add("Set date/time");
            this.cboSpecialTask.Items.Add("Start test mode");
            this.cboSpecialTask.Location = new System.Drawing.Point(7, 26);
            this.cboSpecialTask.Name = "cboSpecialTask";
            this.cboSpecialTask.Size = new System.Drawing.Size(226, 22);
            this.cboSpecialTask.TabIndex = 21;
            this.cboSpecialTask.SelectedIndexChanged += new System.EventHandler(this.cboSpecialTask_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Procedure";
            // 
            // btnSendFrame
            // 
            this.btnSendFrame.Enabled = false;
            this.btnSendFrame.ForeColor = System.Drawing.Color.Black;
            this.btnSendFrame.Location = new System.Drawing.Point(170, 56);
            this.btnSendFrame.Name = "btnSendFrame";
            this.btnSendFrame.Size = new System.Drawing.Size(62, 20);
            this.btnSendFrame.TabIndex = 22;
            this.btnSendFrame.Text = "Go";
            this.btnSendFrame.Click += new System.EventHandler(this.btnSendFrame_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.Location = new System.Drawing.Point(7, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 184);
            this.listBox1.TabIndex = 23;
            // 
            // Procedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSendFrame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSpecialTask);
            this.Menu = this.mainMenu1;
            this.Name = "Procedures";
            this.Text = "Procedures";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.ComboBox cboSpecialTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendFrame;
        public System.Windows.Forms.ListBox listBox1;
    }
}