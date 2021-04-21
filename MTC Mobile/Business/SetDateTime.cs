using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MTC_Mobile.Business
{
    public partial class SetDateTime : Form
    {
        public byte Identity;

        public SetDateTime()
        {
            InitializeComponent();
        }

        public SetDateTime(byte identity)
        {
            InitializeComponent();
            Identity = identity;
            //populateTimeZones();
        }

        /*public void populateTimeZones()
        //{

            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                if (z.StandardName == TimeZone.CurrentTimeZone.StandardName)
                    zone_index = zone_count;
                cbo_timeZone.Items.Add("(UTC " + z.BaseUtcOffset + ")  " + z.Id);
                cbo_timeZone_1.Items.Add("(UTC " + z.BaseUtcOffset + ")  " + z.Id);
                zone_count++;
            }
            cbo_timeZone.SelectedIndex = zone_index;
            cbo_timeZone_1.SelectedIndex = zone_index;
        }*/

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