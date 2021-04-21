using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Object;
using System.Data.SQLite;
using System.Windows.Forms;
using MTC_Mobile.Util;

namespace MTC_Mobile
{
    public partial class Security : Form
    {
        SecurityHandler_DB db = new SecurityHandler_DB();
        static BAL_ENCRYPTER cypher = new BAL_ENCRYPTER();

        public Security()
        {
            InitializeComponent();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("You want to change the new passwords in the current user?", "Write Passwords", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (result.Equals(DialogResult.Yes))
                {
                    SecurityHandler_DB db = new SecurityHandler_DB();
                    bool saved = db.UpdatePasswords((cbx_rol.SelectedIndex + 1).ToString(), txt_oldPassword.Text, txt_newPassword.Text);

                    if (saved)
                    {
                        MessageBox.Show("Successfully written passwords in the user role", "Information", MessageBoxButtons.OK, MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Failed written passwords in the user role", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                //btnNew.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txt_newPassword.Enabled = true;
            txt_oldPassword.Enabled = false;
            txt_oldPassword.Text = txt_newPassword.Text;
            txt_newPassword.Text = "";
            txt_newPassword.Focus();
        }
    }
}