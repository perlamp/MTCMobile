using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MTC_Mobile
{
    public partial class Procedures : Form
    {

        //Business.ReadFile readFile = new Business.ReadFile();

        public Procedures()
        {
            InitializeComponent();
        }

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
        private void pcbSelectedSpecialTask_Click(object sender, EventArgs e)
        {
            try
            {
                Business.MessageResponse messageResponse;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " when " + cboSpecialTask.SelectedItem.ToString(), "Procedure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
    }
}