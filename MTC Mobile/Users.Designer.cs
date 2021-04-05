namespace MTC_Mobile
{
    partial class Users
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
            this.label17 = new System.Windows.Forms.Label();
            this.cbo_readings = new System.Windows.Forms.ComboBox();
            this.btn_readings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tab_new = new System.Windows.Forms.TabPage();
            this.lbl_new_confirm = new System.Windows.Forms.Label();
            this.txt_new_confirm = new System.Windows.Forms.TextBox();
            this.lbl_new_title = new System.Windows.Forms.Label();
            this.btn_new_save = new System.Windows.Forms.Button();
            this.txt_new_password = new System.Windows.Forms.TextBox();
            this.txt_new_username = new System.Windows.Forms.TextBox();
            this.lbl_new_level = new System.Windows.Forms.Label();
            this.cbo_new_level = new System.Windows.Forms.ComboBox();
            this.lbl_new_password = new System.Windows.Forms.Label();
            this.lbl_new_username = new System.Windows.Forms.Label();
            this.tab_users = new System.Windows.Forms.TabControl();
            this.tab_search = new System.Windows.Forms.TabPage();
            this.lst_search_results = new System.Windows.Forms.ListBox();
            this.btn_search_edit = new System.Windows.Forms.Button();
            this.btn_search_delete = new System.Windows.Forms.Button();
            this.lbl_search_title = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search_username = new System.Windows.Forms.TextBox();
            this.lbl_search_level = new System.Windows.Forms.Label();
            this.cbo_search_level = new System.Windows.Forms.ComboBox();
            this.lbl_search_username = new System.Windows.Forms.Label();
            this.tab_edit = new System.Windows.Forms.TabPage();
            this.chk_edit_password = new System.Windows.Forms.CheckBox();
            this.lbl_edit_password_chk = new System.Windows.Forms.Label();
            this.txt_edit_confirm = new System.Windows.Forms.TextBox();
            this.lbl_edit_confirm = new System.Windows.Forms.Label();
            this.lbl_edit_select = new System.Windows.Forms.Label();
            this.lbl_edit_title = new System.Windows.Forms.Label();
            this.btn_edit_save = new System.Windows.Forms.Button();
            this.txt_edit_password = new System.Windows.Forms.TextBox();
            this.cbo_edit_user = new System.Windows.Forms.ComboBox();
            this.txt_edit_username = new System.Windows.Forms.TextBox();
            this.lbl_edit_level = new System.Windows.Forms.Label();
            this.cbo_edit_level = new System.Windows.Forms.ComboBox();
            this.lbl_edit_password = new System.Windows.Forms.Label();
            this.lbl_edit_username = new System.Windows.Forms.Label();
            this.tab_delete = new System.Windows.Forms.TabPage();
            this.chk_delete_confirm = new System.Windows.Forms.CheckBox();
            this.lbl_delete_confirm = new System.Windows.Forms.Label();
            this.lbl_delete_select = new System.Windows.Forms.Label();
            this.lbl_delete_title = new System.Windows.Forms.Label();
            this.btn_delete_save = new System.Windows.Forms.Button();
            this.cbo_delete_user = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tab_new.SuspendLayout();
            this.tab_users.SuspendLayout();
            this.tab_search.SuspendLayout();
            this.tab_edit.SuspendLayout();
            this.tab_delete.SuspendLayout();
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
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(7, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(213, 20);
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
            this.cbo_readings.TabIndex = 1;
            // 
            // btn_readings
            // 
            this.btn_readings.Location = new System.Drawing.Point(161, 219);
            this.btn_readings.Name = "btn_readings";
            this.btn_readings.Size = new System.Drawing.Size(72, 20);
            this.btn_readings.TabIndex = 0;
            this.btn_readings.Text = "Leer";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("General Configuration");
            this.comboBox1.Items.Add("Data Source");
            this.comboBox1.Items.Add("Register Tables");
            this.comboBox1.Items.Add("Time of Use");
            this.comboBox1.Items.Add("Load Profiles");
            this.comboBox1.Items.Add("History and Event Logs");
            this.comboBox1.Items.Add("EOS");
            this.comboBox1.Location = new System.Drawing.Point(7, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(226, 22);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leer";
            // 
            // tab_new
            // 
            this.tab_new.Controls.Add(this.lbl_new_confirm);
            this.tab_new.Controls.Add(this.txt_new_confirm);
            this.tab_new.Controls.Add(this.lbl_new_title);
            this.tab_new.Controls.Add(this.btn_new_save);
            this.tab_new.Controls.Add(this.txt_new_password);
            this.tab_new.Controls.Add(this.txt_new_username);
            this.tab_new.Controls.Add(this.lbl_new_level);
            this.tab_new.Controls.Add(this.cbo_new_level);
            this.tab_new.Controls.Add(this.lbl_new_password);
            this.tab_new.Controls.Add(this.lbl_new_username);
            this.tab_new.Location = new System.Drawing.Point(0, 0);
            this.tab_new.Name = "tab_new";
            this.tab_new.Size = new System.Drawing.Size(240, 242);
            this.tab_new.Text = "Nuevo";
            // 
            // lbl_new_confirm
            // 
            this.lbl_new_confirm.Location = new System.Drawing.Point(3, 111);
            this.lbl_new_confirm.Name = "lbl_new_confirm";
            this.lbl_new_confirm.Size = new System.Drawing.Size(128, 20);
            this.lbl_new_confirm.Text = "Confirmar contraseña:";
            this.lbl_new_confirm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_new_confirm
            // 
            this.txt_new_confirm.Location = new System.Drawing.Point(137, 110);
            this.txt_new_confirm.Name = "txt_new_confirm";
            this.txt_new_confirm.PasswordChar = '*';
            this.txt_new_confirm.Size = new System.Drawing.Size(100, 21);
            this.txt_new_confirm.TabIndex = 10;
            // 
            // lbl_new_title
            // 
            this.lbl_new_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_new_title.Location = new System.Drawing.Point(7, 4);
            this.lbl_new_title.Name = "lbl_new_title";
            this.lbl_new_title.Size = new System.Drawing.Size(230, 20);
            this.lbl_new_title.Text = "Nuevo Usuario";
            this.lbl_new_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_new_save
            // 
            this.btn_new_save.Location = new System.Drawing.Point(161, 219);
            this.btn_new_save.Name = "btn_new_save";
            this.btn_new_save.Size = new System.Drawing.Size(72, 20);
            this.btn_new_save.TabIndex = 11;
            this.btn_new_save.Text = "Crear";
            this.btn_new_save.Click += new System.EventHandler(this.btn_new_save_Click);
            // 
            // txt_new_password
            // 
            this.txt_new_password.Location = new System.Drawing.Point(137, 83);
            this.txt_new_password.Name = "txt_new_password";
            this.txt_new_password.PasswordChar = '*';
            this.txt_new_password.Size = new System.Drawing.Size(100, 21);
            this.txt_new_password.TabIndex = 9;
            // 
            // txt_new_username
            // 
            this.txt_new_username.Location = new System.Drawing.Point(137, 28);
            this.txt_new_username.Name = "txt_new_username";
            this.txt_new_username.Size = new System.Drawing.Size(100, 21);
            this.txt_new_username.TabIndex = 7;
            // 
            // lbl_new_level
            // 
            this.lbl_new_level.Location = new System.Drawing.Point(7, 57);
            this.lbl_new_level.Name = "lbl_new_level";
            this.lbl_new_level.Size = new System.Drawing.Size(128, 20);
            this.lbl_new_level.Text = "Nivel de acceso:";
            this.lbl_new_level.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbo_new_level
            // 
            this.cbo_new_level.Items.Add("1");
            this.cbo_new_level.Items.Add("2");
            this.cbo_new_level.Items.Add("3");
            this.cbo_new_level.Location = new System.Drawing.Point(137, 55);
            this.cbo_new_level.Name = "cbo_new_level";
            this.cbo_new_level.Size = new System.Drawing.Size(100, 22);
            this.cbo_new_level.TabIndex = 8;
            // 
            // lbl_new_password
            // 
            this.lbl_new_password.Location = new System.Drawing.Point(3, 84);
            this.lbl_new_password.Name = "lbl_new_password";
            this.lbl_new_password.Size = new System.Drawing.Size(128, 20);
            this.lbl_new_password.Text = "Contraseña:";
            this.lbl_new_password.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_new_username
            // 
            this.lbl_new_username.Location = new System.Drawing.Point(3, 29);
            this.lbl_new_username.Name = "lbl_new_username";
            this.lbl_new_username.Size = new System.Drawing.Size(128, 20);
            this.lbl_new_username.Text = "Nombre de Usuario:";
            this.lbl_new_username.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tab_users
            // 
            this.tab_users.Controls.Add(this.tab_search);
            this.tab_users.Controls.Add(this.tab_new);
            this.tab_users.Controls.Add(this.tab_edit);
            this.tab_users.Controls.Add(this.tab_delete);
            this.tab_users.Location = new System.Drawing.Point(0, 0);
            this.tab_users.Name = "tab_users";
            this.tab_users.SelectedIndex = 0;
            this.tab_users.Size = new System.Drawing.Size(240, 265);
            this.tab_users.TabIndex = 3;
            this.tab_users.SelectedIndexChanged += new System.EventHandler(this.tab_users_SelectedIndexChanged);
            // 
            // tab_search
            // 
            this.tab_search.Controls.Add(this.lst_search_results);
            this.tab_search.Controls.Add(this.btn_search_edit);
            this.tab_search.Controls.Add(this.btn_search_delete);
            this.tab_search.Controls.Add(this.lbl_search_title);
            this.tab_search.Controls.Add(this.btn_search);
            this.tab_search.Controls.Add(this.txt_search_username);
            this.tab_search.Controls.Add(this.lbl_search_level);
            this.tab_search.Controls.Add(this.cbo_search_level);
            this.tab_search.Controls.Add(this.lbl_search_username);
            this.tab_search.Location = new System.Drawing.Point(0, 0);
            this.tab_search.Name = "tab_search";
            this.tab_search.Size = new System.Drawing.Size(240, 242);
            this.tab_search.Text = "Busqueda";
            // 
            // lst_search_results
            // 
            this.lst_search_results.Location = new System.Drawing.Point(7, 82);
            this.lst_search_results.Name = "lst_search_results";
            this.lst_search_results.Size = new System.Drawing.Size(226, 128);
            this.lst_search_results.TabIndex = 4;
            // 
            // btn_search_edit
            // 
            this.btn_search_edit.Location = new System.Drawing.Point(7, 220);
            this.btn_search_edit.Name = "btn_search_edit";
            this.btn_search_edit.Size = new System.Drawing.Size(72, 20);
            this.btn_search_edit.TabIndex = 5;
            this.btn_search_edit.Text = "Editar";
            this.btn_search_edit.Click += new System.EventHandler(this.btn_search_edit_Click);
            // 
            // btn_search_delete
            // 
            this.btn_search_delete.Location = new System.Drawing.Point(161, 219);
            this.btn_search_delete.Name = "btn_search_delete";
            this.btn_search_delete.Size = new System.Drawing.Size(72, 20);
            this.btn_search_delete.TabIndex = 6;
            this.btn_search_delete.Text = "Eliminar";
            this.btn_search_delete.Click += new System.EventHandler(this.btn_search_delete_Click);
            // 
            // lbl_search_title
            // 
            this.lbl_search_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_search_title.Location = new System.Drawing.Point(7, 4);
            this.lbl_search_title.Name = "lbl_search_title";
            this.lbl_search_title.Size = new System.Drawing.Size(226, 20);
            this.lbl_search_title.Text = "Busqueda de Usuarios";
            this.lbl_search_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(165, 53);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(72, 20);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Buscar";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search_username
            // 
            this.txt_search_username.Location = new System.Drawing.Point(59, 26);
            this.txt_search_username.Name = "txt_search_username";
            this.txt_search_username.Size = new System.Drawing.Size(178, 21);
            this.txt_search_username.TabIndex = 1;
            // 
            // lbl_search_level
            // 
            this.lbl_search_level.Location = new System.Drawing.Point(3, 55);
            this.lbl_search_level.Name = "lbl_search_level";
            this.lbl_search_level.Size = new System.Drawing.Size(50, 20);
            this.lbl_search_level.Text = "Acceso:";
            this.lbl_search_level.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbo_search_level
            // 
            this.cbo_search_level.Items.Add("");
            this.cbo_search_level.Items.Add("1");
            this.cbo_search_level.Items.Add("2");
            this.cbo_search_level.Items.Add("3");
            this.cbo_search_level.Items.Add("4");
            this.cbo_search_level.Items.Add("5");
            this.cbo_search_level.Location = new System.Drawing.Point(59, 53);
            this.cbo_search_level.Name = "cbo_search_level";
            this.cbo_search_level.Size = new System.Drawing.Size(100, 22);
            this.cbo_search_level.TabIndex = 2;
            // 
            // lbl_search_username
            // 
            this.lbl_search_username.Location = new System.Drawing.Point(3, 27);
            this.lbl_search_username.Name = "lbl_search_username";
            this.lbl_search_username.Size = new System.Drawing.Size(50, 20);
            this.lbl_search_username.Text = "Usuario:";
            this.lbl_search_username.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tab_edit
            // 
            this.tab_edit.Controls.Add(this.chk_edit_password);
            this.tab_edit.Controls.Add(this.lbl_edit_password_chk);
            this.tab_edit.Controls.Add(this.txt_edit_confirm);
            this.tab_edit.Controls.Add(this.lbl_edit_confirm);
            this.tab_edit.Controls.Add(this.lbl_edit_select);
            this.tab_edit.Controls.Add(this.lbl_edit_title);
            this.tab_edit.Controls.Add(this.btn_edit_save);
            this.tab_edit.Controls.Add(this.txt_edit_password);
            this.tab_edit.Controls.Add(this.cbo_edit_user);
            this.tab_edit.Controls.Add(this.txt_edit_username);
            this.tab_edit.Controls.Add(this.lbl_edit_level);
            this.tab_edit.Controls.Add(this.cbo_edit_level);
            this.tab_edit.Controls.Add(this.lbl_edit_password);
            this.tab_edit.Controls.Add(this.lbl_edit_username);
            this.tab_edit.Location = new System.Drawing.Point(0, 0);
            this.tab_edit.Name = "tab_edit";
            this.tab_edit.Size = new System.Drawing.Size(240, 242);
            this.tab_edit.Text = "Editar";
            // 
            // chk_edit_password
            // 
            this.chk_edit_password.Location = new System.Drawing.Point(137, 113);
            this.chk_edit_password.Name = "chk_edit_password";
            this.chk_edit_password.Size = new System.Drawing.Size(100, 20);
            this.chk_edit_password.TabIndex = 15;
            this.chk_edit_password.CheckStateChanged += new System.EventHandler(this.chk_edit_password_CheckStateChanged);
            // 
            // lbl_edit_password_chk
            // 
            this.lbl_edit_password_chk.Location = new System.Drawing.Point(3, 113);
            this.lbl_edit_password_chk.Name = "lbl_edit_password_chk";
            this.lbl_edit_password_chk.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_password_chk.Text = "Cambiar Contraseña:";
            this.lbl_edit_password_chk.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_edit_confirm
            // 
            this.txt_edit_confirm.Location = new System.Drawing.Point(137, 168);
            this.txt_edit_confirm.Name = "txt_edit_confirm";
            this.txt_edit_confirm.PasswordChar = '*';
            this.txt_edit_confirm.Size = new System.Drawing.Size(100, 21);
            this.txt_edit_confirm.TabIndex = 17;
            this.txt_edit_confirm.Visible = false;
            // 
            // lbl_edit_confirm
            // 
            this.lbl_edit_confirm.Location = new System.Drawing.Point(3, 169);
            this.lbl_edit_confirm.Name = "lbl_edit_confirm";
            this.lbl_edit_confirm.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_confirm.Text = "Confirmar Contraseña:";
            this.lbl_edit_confirm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_edit_confirm.Visible = false;
            // 
            // lbl_edit_select
            // 
            this.lbl_edit_select.Location = new System.Drawing.Point(3, 29);
            this.lbl_edit_select.Name = "lbl_edit_select";
            this.lbl_edit_select.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_select.Text = "Seleccionar Usuario:";
            this.lbl_edit_select.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_edit_title
            // 
            this.lbl_edit_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_edit_title.Location = new System.Drawing.Point(3, 4);
            this.lbl_edit_title.Name = "lbl_edit_title";
            this.lbl_edit_title.Size = new System.Drawing.Size(230, 20);
            this.lbl_edit_title.Text = "Editar Usuario";
            this.lbl_edit_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_edit_save
            // 
            this.btn_edit_save.Location = new System.Drawing.Point(161, 219);
            this.btn_edit_save.Name = "btn_edit_save";
            this.btn_edit_save.Size = new System.Drawing.Size(72, 20);
            this.btn_edit_save.TabIndex = 18;
            this.btn_edit_save.Text = "Guardar";
            this.btn_edit_save.Click += new System.EventHandler(this.btn_edit_save_Click);
            // 
            // txt_edit_password
            // 
            this.txt_edit_password.Location = new System.Drawing.Point(137, 141);
            this.txt_edit_password.Name = "txt_edit_password";
            this.txt_edit_password.PasswordChar = '*';
            this.txt_edit_password.Size = new System.Drawing.Size(100, 21);
            this.txt_edit_password.TabIndex = 16;
            this.txt_edit_password.Visible = false;
            this.txt_edit_password.WordWrap = false;
            // 
            // cbo_edit_user
            // 
            this.cbo_edit_user.Items.Add("1");
            this.cbo_edit_user.Items.Add("2");
            this.cbo_edit_user.Items.Add("3");
            this.cbo_edit_user.Items.Add("4");
            this.cbo_edit_user.Items.Add("5");
            this.cbo_edit_user.Location = new System.Drawing.Point(137, 27);
            this.cbo_edit_user.Name = "cbo_edit_user";
            this.cbo_edit_user.Size = new System.Drawing.Size(100, 22);
            this.cbo_edit_user.TabIndex = 12;
            this.cbo_edit_user.SelectedIndexChanged += new System.EventHandler(this.cbo_edit_user_SelectedIndexChanged);
            // 
            // txt_edit_username
            // 
            this.txt_edit_username.Location = new System.Drawing.Point(137, 55);
            this.txt_edit_username.Name = "txt_edit_username";
            this.txt_edit_username.Size = new System.Drawing.Size(100, 21);
            this.txt_edit_username.TabIndex = 13;
            // 
            // lbl_edit_level
            // 
            this.lbl_edit_level.Location = new System.Drawing.Point(3, 84);
            this.lbl_edit_level.Name = "lbl_edit_level";
            this.lbl_edit_level.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_level.Text = "Nivel de acceso:";
            this.lbl_edit_level.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbo_edit_level
            // 
            this.cbo_edit_level.Items.Add("1");
            this.cbo_edit_level.Items.Add("2");
            this.cbo_edit_level.Items.Add("3");
            this.cbo_edit_level.Items.Add("4");
            this.cbo_edit_level.Items.Add("5");
            this.cbo_edit_level.Location = new System.Drawing.Point(137, 82);
            this.cbo_edit_level.Name = "cbo_edit_level";
            this.cbo_edit_level.Size = new System.Drawing.Size(100, 22);
            this.cbo_edit_level.TabIndex = 14;
            // 
            // lbl_edit_password
            // 
            this.lbl_edit_password.Location = new System.Drawing.Point(3, 142);
            this.lbl_edit_password.Name = "lbl_edit_password";
            this.lbl_edit_password.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_password.Text = "Nueva Contraseña:";
            this.lbl_edit_password.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_edit_password.Visible = false;
            // 
            // lbl_edit_username
            // 
            this.lbl_edit_username.Location = new System.Drawing.Point(3, 56);
            this.lbl_edit_username.Name = "lbl_edit_username";
            this.lbl_edit_username.Size = new System.Drawing.Size(128, 20);
            this.lbl_edit_username.Text = "Nombre de Usuario:";
            this.lbl_edit_username.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tab_delete
            // 
            this.tab_delete.Controls.Add(this.chk_delete_confirm);
            this.tab_delete.Controls.Add(this.lbl_delete_confirm);
            this.tab_delete.Controls.Add(this.lbl_delete_select);
            this.tab_delete.Controls.Add(this.lbl_delete_title);
            this.tab_delete.Controls.Add(this.btn_delete_save);
            this.tab_delete.Controls.Add(this.cbo_delete_user);
            this.tab_delete.Location = new System.Drawing.Point(0, 0);
            this.tab_delete.Name = "tab_delete";
            this.tab_delete.Size = new System.Drawing.Size(232, 239);
            this.tab_delete.Text = "Eliminar";
            // 
            // chk_delete_confirm
            // 
            this.chk_delete_confirm.Location = new System.Drawing.Point(137, 55);
            this.chk_delete_confirm.Name = "chk_delete_confirm";
            this.chk_delete_confirm.Size = new System.Drawing.Size(100, 20);
            this.chk_delete_confirm.TabIndex = 20;
            this.chk_delete_confirm.CheckStateChanged += new System.EventHandler(this.chk_delete_confirm_CheckStateChanged);
            // 
            // lbl_delete_confirm
            // 
            this.lbl_delete_confirm.Location = new System.Drawing.Point(3, 55);
            this.lbl_delete_confirm.Name = "lbl_delete_confirm";
            this.lbl_delete_confirm.Size = new System.Drawing.Size(128, 20);
            this.lbl_delete_confirm.Text = "Confirmar eliminar:";
            this.lbl_delete_confirm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_delete_select
            // 
            this.lbl_delete_select.Location = new System.Drawing.Point(3, 29);
            this.lbl_delete_select.Name = "lbl_delete_select";
            this.lbl_delete_select.Size = new System.Drawing.Size(128, 20);
            this.lbl_delete_select.Text = "Seleccionar Usuario:";
            this.lbl_delete_select.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_delete_title
            // 
            this.lbl_delete_title.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_delete_title.Location = new System.Drawing.Point(7, 4);
            this.lbl_delete_title.Name = "lbl_delete_title";
            this.lbl_delete_title.Size = new System.Drawing.Size(230, 20);
            this.lbl_delete_title.Text = "Eliminar Usuario";
            this.lbl_delete_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_delete_save
            // 
            this.btn_delete_save.Location = new System.Drawing.Point(161, 219);
            this.btn_delete_save.Name = "btn_delete_save";
            this.btn_delete_save.Size = new System.Drawing.Size(72, 20);
            this.btn_delete_save.TabIndex = 21;
            this.btn_delete_save.Text = "Eliminar";
            this.btn_delete_save.Visible = false;
            this.btn_delete_save.Click += new System.EventHandler(this.btn_delete_save_Click);
            // 
            // cbo_delete_user
            // 
            this.cbo_delete_user.Items.Add("1");
            this.cbo_delete_user.Items.Add("2");
            this.cbo_delete_user.Items.Add("3");
            this.cbo_delete_user.Items.Add("4");
            this.cbo_delete_user.Items.Add("5");
            this.cbo_delete_user.Location = new System.Drawing.Point(137, 27);
            this.cbo_delete_user.Name = "cbo_delete_user";
            this.cbo_delete_user.Size = new System.Drawing.Size(100, 22);
            this.cbo_delete_user.TabIndex = 19;
            this.cbo_delete_user.SelectedIndexChanged += new System.EventHandler(this.cbo_delete_user_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.Text = "label8";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(151, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 20);
            this.button4.TabIndex = 25;
            this.button4.Text = "Guardar";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(123, 97);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(123, 70);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(17, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.Text = "Nivel de acceso:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox6
            // 
            this.comboBox6.Items.Add("1");
            this.comboBox6.Items.Add("2");
            this.comboBox6.Items.Add("3");
            this.comboBox6.Items.Add("4");
            this.comboBox6.Items.Add("5");
            this.comboBox6.Location = new System.Drawing.Point(123, 124);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(100, 22);
            this.comboBox6.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(17, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.Text = "Contraseña:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(17, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.Text = "Usuario:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tab_users);
            this.Menu = this.mainMenu1;
            this.Name = "Users";
            this.Text = "Users";
            this.tab_new.ResumeLayout(false);
            this.tab_users.ResumeLayout(false);
            this.tab_search.ResumeLayout(false);
            this.tab_edit.ResumeLayout(false);
            this.tab_delete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbo_readings;
        private System.Windows.Forms.Button btn_readings;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuItem mnu_back;
        private System.Windows.Forms.MenuItem mnu_exit;
        private System.Windows.Forms.TabPage tab_new;
        private System.Windows.Forms.Button btn_new_save;
        private System.Windows.Forms.TextBox txt_new_password;
        private System.Windows.Forms.TextBox txt_new_username;
        private System.Windows.Forms.Label lbl_new_level;
        private System.Windows.Forms.ComboBox cbo_new_level;
        private System.Windows.Forms.Label lbl_new_password;
        private System.Windows.Forms.Label lbl_new_username;
        private System.Windows.Forms.TabControl tab_users;
        private System.Windows.Forms.TabPage tab_edit;
        private System.Windows.Forms.Button btn_edit_save;
        private System.Windows.Forms.TextBox txt_edit_password;
        private System.Windows.Forms.ComboBox cbo_edit_user;
        private System.Windows.Forms.TextBox txt_edit_username;
        private System.Windows.Forms.Label lbl_edit_level;
        private System.Windows.Forms.ComboBox cbo_edit_level;
        private System.Windows.Forms.Label lbl_edit_password;
        private System.Windows.Forms.Label lbl_edit_username;
        private System.Windows.Forms.TabPage tab_delete;
        private System.Windows.Forms.Button btn_delete_save;
        private System.Windows.Forms.ComboBox cbo_delete_user;
        private System.Windows.Forms.Label lbl_new_title;
        private System.Windows.Forms.TabPage tab_search;
        private System.Windows.Forms.Label lbl_search_title;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search_username;
        private System.Windows.Forms.Label lbl_search_level;
        private System.Windows.Forms.ComboBox cbo_search_level;
        private System.Windows.Forms.Label lbl_search_username;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_new_confirm;
        private System.Windows.Forms.TextBox txt_new_confirm;
        private System.Windows.Forms.Label lbl_edit_select;
        private System.Windows.Forms.Label lbl_edit_title;
        private System.Windows.Forms.CheckBox chk_edit_password;
        private System.Windows.Forms.Label lbl_edit_password_chk;
        private System.Windows.Forms.TextBox txt_edit_confirm;
        private System.Windows.Forms.Label lbl_edit_confirm;
        private System.Windows.Forms.Label lbl_delete_title;
        private System.Windows.Forms.Label lbl_delete_select;
        private System.Windows.Forms.CheckBox chk_delete_confirm;
        private System.Windows.Forms.Label lbl_delete_confirm;
        private System.Windows.Forms.ListBox lst_search_results;
        private System.Windows.Forms.Button btn_search_edit;
        private System.Windows.Forms.Button btn_search_delete;
    }
}