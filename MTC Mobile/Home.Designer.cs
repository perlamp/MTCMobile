namespace MTC_Mobile
{
    partial class Home
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.btn_exit = new System.Windows.Forms.MenuItem();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.dst_settings = new System.Data.DataSet();
            this.tbl_settings = new System.Data.DataTable();
            this.col_xmlPath = new System.Data.DataColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dst_settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_settings)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.btn_exit);
            // 
            // menuItem1
            // 
            this.menuItem1.Enabled = false;
            this.menuItem1.Text = "";
            // 
            // btn_exit
            // 
            this.btn_exit.Text = "Salir";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(165, 57);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(72, 20);
            this.btn_connect.TabIndex = 10;
            this.btn_connect.Text = "Conectar";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(137, 30);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 21);
            this.txt_password.TabIndex = 9;
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(137, 3);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(100, 21);
            this.txt_user.TabIndex = 8;
            // 
            // lbl_password
            // 
            this.lbl_password.Location = new System.Drawing.Point(11, 31);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(100, 20);
            this.lbl_password.Text = "Contraseña:";
            this.lbl_password.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_user
            // 
            this.lbl_user.Location = new System.Drawing.Point(11, 4);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(100, 20);
            this.lbl_user.Text = "Usuario:";
            this.lbl_user.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dst_settings
            // 
            this.dst_settings.DataSetName = "DataSetSettings";
            this.dst_settings.Namespace = "";
            this.dst_settings.Prefix = "";
            this.dst_settings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_settings
            // 
            this.tbl_settings.Columns.AddRange(new System.Data.DataColumn[] {
            this.col_xmlPath});
            this.tbl_settings.DisplayExpression = "";
            this.tbl_settings.Prefix = "";
            this.tbl_settings.TableName = "tbl_settings";
            // 
            // col_xmlPath
            // 
            this.col_xmlPath.ColumnMapping = System.Data.MappingType.Element;
            this.col_xmlPath.ColumnName = "xmlPath";
            this.col_xmlPath.DataType = typeof(string);
            this.col_xmlPath.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;
            this.col_xmlPath.Expression = "";
            this.col_xmlPath.Prefix = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_user);
            this.Menu = this.mainMenu1;
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.dst_settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_settings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem btn_exit;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_user;
        private System.Data.DataSet dst_settings;
        private System.Data.DataTable tbl_settings;
        private System.Data.DataColumn col_xmlPath;
        private System.Windows.Forms.Button button1;
    }
}