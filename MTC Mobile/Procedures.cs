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
            //*Cursor.Current = Cursors.WaitCursor;
            //Cursor.Show();

            Index frmIndex = new Index();
            frmIndex.ShowDialog();

            this.Close();
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btnSendFrame_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboSpecialTask.SelectedItem != null)
                {
                    Interface.Meter Procedure = new MTC_Mobile.Interface.Meter();
                    bool response = false;
                    string strResponse = "";
                    string strCanceled = "";
                    DialogResult message = MessageBox.Show("Are you sure you want to run this procedure?", "Procedures", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (message.Equals(DialogResult.Yes))
                    {
                        Procedure.TablesProcedure.Clear();
                        switch (cboSpecialTask.SelectedItem.ToString())
                        {
                            case "Connect":
                                response = Procedure.relayProcedure(Program.gblPort.PortName, "Close", Program.Security, 0x00);
                                break;
                            case "Disconnect":
                                response = Procedure.relayProcedure(Program.gblPort.PortName, "Open", Program.Security, 0x00);
                                break;
                            case "Demand reset":
                                response = Procedure.runProcedure(Program.gblPort.PortName, Program.Security, 101, 0x00);
                                break;
                            case "Start test mode":
                                response = Procedure.runProcedure(Program.gblPort.PortName, Program.Security, 5, 0x00);
                                break;
                            case "End test mode":
                                response = Procedure.runProcedure(Program.gblPort.PortName, Program.Security, 6, 0x00);
                                break;
                            case "Get date/time":
                                string[] tables = new string[2];
                                tables = Procedure.getDateTime(Program.gblPort.PortName, Program.Security, 0x00);
                                if (tables != null)
                                {
                                    string strDateYime = "Date Time UTC: " + tables[0] + Environment.NewLine + "Date Time GMT: " + tables[2] + Environment.NewLine + "Time Zone: " + Convert.ToInt16(tables[1]) / 60 + " " + tables[3];
                                    // MessageBox.Show(strDateYime, "Date Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MessageBox.Show(strDateYime);
                                    strResponse = "get";
                                }
                                else
                                {
                                    MessageBox.Show("Error in procedure executed", "Relay");
                                }
                                break;
                            case "Set date/time":
                                Business.SetDateTime dateTime = new Business.SetDateTime(0x00);
                                dateTime.ShowDialog();
                                if (dateTime.DateTime.Equals(false))
                                {
                                    if (dateTime.Canceled.Equals(true))
                                    {
                                        strCanceled = "Canceled";
                                    }
                                    response = dateTime.DateTime;
                                }
                                else
                                {
                                    response = dateTime.DateTime;
                                }
                                break;
                            case "Change passwords":
                                strResponse = "Change passwords";
                                break;
                        }
                    }
                    if (strResponse.Equals(""))
                    {
                        if (response.Equals(true))
                        {
                            MessageBox.Show("Procedure executed successfully", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);

                        }
                        else
                        {
                            if (!strCanceled.Equals("Canceled"))
                            {
                                MessageBox.Show("Error in procedure executed", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else if (strResponse.Equals("Change passwords"))
                    {
                        Security security = new Security();
                        security.Show();
                        listBox1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a option task", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " when " + cboSpecialTask.SelectedItem.ToString(), "Procedure", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void cboSpecialTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSpecialTask.SelectedIndex > -1)
            {
                btnSendFrame.Enabled = true;
            }
        }
    }
}