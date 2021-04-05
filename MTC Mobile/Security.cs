using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MTC_Mobile
{
    public partial class Security : Form
    {
        static BAL_ENCRYPTER cypher = new BAL_ENCRYPTER();

        public Security()
        {
            InitializeComponent();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("You want to change the new passwords in the current user?", "Write Passwords", MessageBoxButtons.YesNo);
                if (result.Equals(DialogResult.Yes))
                {
                    bool saved = UpdatePasswords((cbx_rol.SelectedIndex + 1).ToString(), txt_newPassword.Text, txt_oldPassword.Text);

                    if (saved)
                    {
                        MessageBox.Show("Successfully written passwords in the user role", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed written passwords in the user role", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnNew.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }

        public bool UpdatePasswords(string idRol, string passwordNew, string passwordOld)
        {
            bool bResult = false;
            if (File.Exists(path + "Config\\MTCm.db"))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE PASSWORDS SET PASSWORD='" + cypher.EncryptDecrypt(passwordNew) + "',PASSWORD_OLD ='" + cypher.EncryptDecrypt(passwordOld) + "' WHERE LEVEL = " + idRol + ";";
                    SQLiteCommand command = new SQLiteCommand(sql, con);
                    command.ExecuteNonQuery();
                    bResult = true;
                    con.Close();
                }
                catch (SQLiteException ex)
                {
                    throw ex;
                }
            }

            return bResult;
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