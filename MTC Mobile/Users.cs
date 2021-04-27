using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MTC_Mobile.Object;
using MTC_Mobile.Dao;
using MTC_Mobile.Util;
using System.Threading;

namespace MTC_Mobile
{
    public partial class Users : Form
    {
        /* GENERAL */
        SecurityHandler_DB db = new SecurityHandler_DB();

        public Users()
        {
            InitializeComponent();

            IDao<AccessLevel> accessLvlDao = new AccessLevelDao();
            List<AccessLevel> listAccessLvl = accessLvlDao.GetList("assignable", "1");
            Dictionary<String, String> comboSource = new Dictionary<String, String>();
            comboSource.Add("", "");
            foreach (AccessLevel accessLvl in listAccessLvl)
            {
                comboSource.Add(accessLvl.getId().ToString(), accessLvl.getName());
            }
            cbo_search_level.DataSource = new BindingSource(comboSource, null);
            cbo_search_level.DisplayMember = "Value";
            cbo_search_level.ValueMember = "Key";

            cbo_new_level.DataSource = new BindingSource(comboSource, null);
            cbo_new_level.DisplayMember = "Value";
            cbo_new_level.ValueMember = "Key";

            cbo_edit_level.DataSource = new BindingSource(comboSource, null);
            cbo_edit_level.DisplayMember = "Value";
            cbo_edit_level.ValueMember = "Key";


            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }

        private void tab_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tab_users.SelectedIndex;
            
            switch(index)
            {
                case 0:
                    lst_search_results.Items.Clear();
                    break;
                case 1:
                    loadNew();
                    break;
                case 2:
                    loadEdit();
                    break;
                case 3:
                    loadDelete();
                    break;

            }
        }


        /* SEARCH */

        private void btn_search_Click(object sender, EventArgs e)
        {
            lst_search_results.Items.Clear();

            string username = txt_search_username.Text;
            string accessLvlId = ((KeyValuePair<String, String>)cbo_search_level.SelectedItem).Key;
                
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("username", username);
            parameters.Add("accessLvlId", accessLvlId);

            IDao<User> userDao = new UserDao();
            List<User> listUsers = userDao.Search(parameters);

            foreach (User usr in listUsers)
            {
                lst_search_results.Items.Add(usr.getUsername());
            }

        }

        private void btn_search_edit_Click(object sender, EventArgs e)
        {
            string username = lst_search_results.Text;

            tab_users.SelectedIndex = 2;

            int index = cbo_edit_user.Items.IndexOf(username);
            cbo_edit_user.SelectedIndex = index;

        }

        private void btn_search_delete_Click(object sender, EventArgs e)
        {
            string username = lst_search_results.Text;

            tab_users.SelectedIndex = 3;

            int index = cbo_delete_user.Items.IndexOf(username);
            cbo_delete_user.SelectedIndex = index;
        }


        /* SAVE */

        private void loadNew()
        {
            txt_new_username.Text = "";
            txt_new_password.Text = "";
            txt_new_confirm.Text = "";
            cbo_new_level.SelectedIndex = 0;
        }

        private void btn_new_save_Click(object sender, EventArgs e)
        {
            string username = txt_new_username.Text;
            string accessLvlKey = ((KeyValuePair<String, String>)cbo_new_level.SelectedItem).Key;
            string password = txt_new_password.Text;
            string confirm = txt_new_confirm.Text;

            string message = "";

            if (username.Equals("") || password.Equals("") || accessLvlKey.Equals(""))
            {
                message = "Favor de completar todos los campos";
            } 
            else if (!password.Equals(confirm))
            {
                message = "La confirmación de la contraseña es incorrecta";
            }
            else
            {
                int accessLvlId = System.Convert.ToInt32(accessLvlKey);

                IDao<User> userDao = new UserDao();

                if (userDao.GetList("username", username).Count > 0)
                {
                    message = "Ya existe un usuario con ese nombre";
                }
                else
                {
                    IDao<AccessLevel> accessLvlDao = new AccessLevelDao();
                    AccessLevel accessLvl = accessLvlDao.GetById(accessLvlId);

                    User user = new User(username, password, accessLvl);
                    Response res = userDao.Insert(user);
                    if (res.getResult())
                    {
                        message = "Usuario creado";
                        if (db.AddUser(txt_new_username.Text, txt_new_password.Text, cbo_new_level.Text))
                        {
                            message = "Usuario creado";
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        loadNew();
                    }
                    else
                    {
                        message = res.getMessage();
                    }
                }
            }

            MessageBox.Show(message);
        }



        /* EDIT */

        private void toggleEditAccess(Boolean access)
        {
            if (!access)
            {
                cbo_edit_user.SelectedIndex = -1;
            }

            lbl_edit_username.Visible = access;
            txt_edit_username.Visible = access;

            lbl_edit_level.Visible = access;
            cbo_edit_level.Visible = access;

            lbl_edit_password_chk.Visible = access;
            chk_edit_password.Visible = access;

            btn_edit_save.Visible = access;

            chk_edit_password.Checked = false;

            lbl_edit_password.Visible = false;
            txt_edit_password.Visible = false;

            lbl_edit_confirm.Visible = false;
            txt_edit_confirm.Visible = false;
        }

        private void loadEdit()
        {
            cbo_edit_user.Items.Clear();

            IDao<User> userDao = new UserDao();
            List<User> listUsers = userDao.GetList();

            foreach(User user in listUsers){
                if (user.getAccessLevel().isAssignable())
                {
                    cbo_edit_user.Items.Add(user.getUsername());
                }
            }

            toggleEditAccess(false);
        }
        
        private void cbo_edit_user_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo_edit_user.SelectedIndex > -1)
            {
                string username = cbo_edit_user.SelectedItem.ToString();

                IDao<User> userDao = new UserDao();
                List<User> listUser = userDao.GetList("username", username);
                User user = (listUser.Count > 0 ? listUser[0] : null);

                txt_edit_username.Text = user.getUsername();
                cbo_edit_level.SelectedValue = user.getAccessLevel().getId().ToString();
            }

            toggleEditAccess(cbo_edit_user.SelectedIndex != -1);

        }

        private void chk_edit_password_CheckStateChanged(object sender, EventArgs e)
        {

            if (chk_edit_password.Checked)
            {
                lbl_edit_password.Visible = true;
                txt_edit_password.Visible = true;

                lbl_edit_confirm.Visible = true;
                txt_edit_confirm.Visible = true;
            }
            else
            {
                lbl_edit_password.Visible = false;
                txt_edit_password.Visible = false;

                lbl_edit_confirm.Visible = false;
                txt_edit_confirm.Visible = false;
            }
        }

        private void btn_edit_save_Click(object sender, EventArgs e)
        {
            string username = cbo_edit_user.Text;
            string newUsername = txt_edit_username.Text;
            string accessLvlKey = ((KeyValuePair<String, String>)cbo_edit_level.SelectedItem).Key;
            Boolean changePassword = chk_edit_password.Checked;
            string password = txt_edit_password.Text;
            string confirm = txt_edit_confirm.Text;

            string message = "";

            if (username.Equals("") || password.Equals("") || accessLvlKey.Equals("") || (changePassword && password.Equals("")))
            {
                message = "Favor de completar todos los campos";
            }
            else if (changePassword && !password.Equals(confirm))
            {
                message = "La confirmación de la contraseña es incorrecta";
            }
            else
            {
                int accessLvlId = System.Convert.ToInt32(accessLvlKey);

                IDao<User> userDao = new UserDao();
                List<User> listUser = userDao.GetList("username", username);
                User user = (listUser.Count > 0 ? listUser[0] : null);

                if (!username.Equals(newUsername) && userDao.GetList("username", newUsername).Count > 0)
                {
                    message = "Ya existe un usuario con ese nombre";
                }
                else
                {
                    IDao<AccessLevel> accessLvlDao = new AccessLevelDao();
                    AccessLevel accessLvl = accessLvlDao.GetById(accessLvlId);

                    user.setUsername(newUsername);
                    user.setAccessLevel(accessLvl);
                    if (changePassword)
                    {
                        user.setPassword(password);
                    }

                    Response res = userDao.Update(user);
                    if (res.getResult())
                    {
                        message = "Usuario actualizado";
                        loadEdit();
                    }
                    else
                    {
                        message = res.getMessage();
                    }
                }
            }

            MessageBox.Show(message);

        }

        /* DELETE */

        private void toggleDeleteAccess(Boolean access)
        {

            lbl_delete_confirm.Visible = access;
            chk_delete_confirm.Visible = access;

            chk_delete_confirm.Checked = false;
            btn_delete_save.Visible = false;
        }

        private void loadDelete()
        {
            cbo_delete_user.Items.Clear();

            IDao<User> userDao = new UserDao();
            List<User> listUsers = userDao.GetList();

            foreach (User usr in listUsers)
            {
                cbo_delete_user.Items.Add(usr.getUsername());
            }

            toggleDeleteAccess(false);
        }

        private void cbo_delete_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleDeleteAccess(cbo_delete_user.SelectedIndex != 0);
        }

        private void chk_delete_confirm_CheckStateChanged(object sender, EventArgs e)
        {
            btn_delete_save.Visible = chk_delete_confirm.Checked;
        }

        private void btn_delete_save_Click(object sender, EventArgs e)
        {
            string username = cbo_delete_user.Text;
            string message = "";

            IDao<User> userDao = new UserDao();
            List<User> listUser = userDao.GetList("username", username);
            User user = (listUser.Count > 0 ? listUser[0] : null);

            Response res = userDao.Delete(user);
            if (res.getResult())
            {
                message = "Usuario eliminado";
                loadDelete();
            }
            else
            {
                message = res.getMessage();
            }

            MessageBox.Show(message);
        }


        /* MENU */

        private void mnu_back_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            Index frmIndex = new Index();
            frmIndex.ShowDialog();

            this.Close();
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}