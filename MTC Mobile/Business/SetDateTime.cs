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
        private bool dateTime = false;
        private bool canceled = false;

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

        public bool DateTime
        {
            get
            {
                return dateTime;
            }

            set
            {
                dateTime = value;
            }
        }

        public bool Canceled
        {
            get
            {
                return canceled;
            }

            set
            {
                canceled = value;
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Interface.Parser parser = new MTC_Mobile.Interface.Parser();
            Interface.Meter meter = new MTC_Mobile.Interface.Meter();
            string[] tablestoWrite = new string[3];
            Program.strSetDateTime = "";
            string value_time_zone = "";
            string value_time_zoneHEx = "";
            string frame_st53 = "";
            string strTZOffset = "";
            try
            {
                DateTime dtDate = dt_date_1.Value.Date + dt_time_1.Value.TimeOfDay;
                DateTime dt_write = dtDate.ToUniversalTime();

                TimeSpan tspan = (dt_write - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
                //TimeSpan tspan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
                Int32 unixTime = Convert.ToInt32(tspan.TotalSeconds);
                string clockCalendar = unixTime.ToString();

                string strHex = parser.decimalToHexadecimal(clockCalendar);
                strHex = parser.get_little_endian(parser.alignFrame(strHex));
                tablestoWrite[0] = "03 " + strHex + " 00";
                value_time_zone = cbo_timeZone.SelectedItem.ToString();
                string time_zone_aux = value_time_zone.Substring(5, 3);
                if (!time_zone_aux.StartsWith("-"))
                {
                    time_zone_aux = value_time_zone.Substring(5, 2);
                    value_time_zoneHEx = parser.decimalToHexadecimal(time_zone_aux);
                    frame_st53 = "20 1C 00 00 3C " + value_time_zoneHEx;
                }
                else
                {
                    int value = Convert.ToInt16(time_zone_aux) * 60;
                    value_time_zoneHEx = parser.decimalToHexadecimal(value.ToString());
                    int size_timeZone = value_time_zoneHEx.Length;
                    string aux_time_zone_a = value_time_zoneHEx.Substring(size_timeZone - 4, 2);
                    string aux_time_zone_b = value_time_zoneHEx.Substring(size_timeZone - 2, 2);

                    strTZOffset = aux_time_zone_b + " " + aux_time_zone_a;
                    frame_st53 = "20 1C 00 00 3C " + strTZOffset;
                }

                tablestoWrite[1] = "53";
                tablestoWrite[2] = frame_st53;
                if (meter.writeTimeZone(Program.gblPort.PortName, Program.Security, tablestoWrite, 0x00))
                {
                    DateTime = true;
                    Program.strSetDateTime = "true";
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}