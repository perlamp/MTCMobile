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

        //private void pcbSelectedSpecialTask_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Business.MessageResponse messageResponse;
        //        pnlWorkArea.Controls.Clear();
        //        pnlWorkArea.BackColor = Color.FromArgb(60, 60, 60);

        //        if (cboSpecialTask.SelectedItem != null)
        //        {
        //            Interface.Meter procedure = new Interface.Meter();
        //            bool response = false;
        //            string strCanceled = "";

        //            Business.MessageDialog message = new Business.MessageDialog();
        //            message.ShowDialog();

        //            byte identity = (byte)cboSocketId.SelectedIndex;

        //            if (message.DialogResult.Equals(DialogResult.OK))
        //            {
        //                Program.Security = readFile.selectSecurity(Program.loggedUser, identity);
        //                if (!Program.Security[0].Equals(0))
        //                {
        //                    procedure.TablesProcedure.Clear();
        //                    switch (cboSpecialTask.SelectedItem.ToString())
        //                    {
        //                        case "Demand Reset":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 101, identity);
        //                            break;
        //                        /*case "Cold Start":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 0, identity);
        //                            break;*/
        //                        case "Connect Service":
        //                            response = procedure.relayProcedure(Program.gblPort.PortName, "Close", Program.Security, identity);
        //                            break;
        //                        case "Disconnect Service":
        //                            response = procedure.relayProcedure(Program.gblPort.PortName, "Open", Program.Security, identity);
        //                            break;
        //                        /*case "Warm Start":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 1, identity);
        //                            break;
        //                        case "Start Test Mode":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 5, identity);
        //                            break;
        //                        case "End Test Mode":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 6, identity);
        //                            break;*/
        //                        case "Clear Standard Status Flags":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 7, identity);
        //                            break;
        //                        case "Clear Manufacturer Status Flags":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 8, identity);
        //                            break;
        //                        /*case "Clear History Log":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 50, identity);
        //                            break;
        //                        case "Clear Event Log":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 51, identity);
        //                            break;
        //                        case "Enable KWh Pulse Output Mode":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 37, identity);
        //                            break;
        //                        case "Enable KVARh Pulse Output Mode":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 38, identity);
        //                            break;*/
        //                        case "Reset Passwords":
        //                            response = procedure.runProcedure(Program.gblPort.PortName, Program.Security, 3, identity);
        //                            break;
        //                        case "Set Date/Time":
        //                            Business.SetDateTime dateTime = new Business.SetDateTime((byte)cboSocketId.SelectedIndex);
        //                            dateTime.ShowDialog();
        //                            if (dateTime.DateTime.Equals(false))
        //                            {
        //                                if (dateTime.Canceled.Equals(true))
        //                                {
        //                                    strCanceled = "Canceled";
        //                                }
        //                                response = dateTime.DateTime;
        //                            }
        //                            else
        //                            {
        //                                response = dateTime.DateTime;
        //                            }
        //                            break;
        //                        case "Write Passwords to Meter":
        //                            // response = readFile.writePassinMeter("C:\\PLive\\mm\\password\\passwordGral.xml", Program.loggedUser);
        //                            break;

        //                        /*case "Set Voltage Thresholds":
        //                            Program.SetVoltageThresHold = false;
        //                            Business.SetVoltageThresholds setVoltage = new Business.SetVoltageThresholds((byte)cboSocketId.SelectedIndex);
        //                            setVoltage.ShowDialog();
        //                            if (Program.SetVoltageThresHold)
        //                            {
        //                                response = Program.SetVoltageThresHold;
        //                            }
        //                            else
        //                            {
        //                                return;
        //                            }

        //                            break;

        //                        case "Set Test Mode Time":
        //                            Program.SetTimeThresHold = false;
        //                            Business.SetTimeTestMode timeTestMode = new Business.SetTimeTestMode((byte)cboSocketId.SelectedIndex);
        //                            timeTestMode.ShowDialog();
        //                            if (Program.SetTimeThresHold)
        //                            {
        //                                response = Program.SetTimeThresHold;
        //                            }
        //                            else
        //                            {
        //                                return;
        //                            }
        //                            break;*/
        //                    }
        //                }
        //                else
        //                {
        //                    messageResponse = new Business.MessageResponse("Can not access the meter, invalid passwords");
        //                    messageResponse.ShowDialog();
        //                }
        //                if (response.Equals(true))
        //                {
        //                    messageResponse = new Business.MessageResponse("Procedure executed successfully");
        //                    messageResponse.ShowDialog();
        //                }
        //                else
        //                {
        //                    if (!strCanceled.Equals("Canceled"))
        //                    {
        //                        messageResponse = new Business.MessageResponse("Error in procedure executed");
        //                        messageResponse.ShowDialog();
        //                    }
        //                }

        //                //mostrar tablas leidas
        //                if (!procedure.TablesProcedure.Count.Equals(0))
        //                {
        //                    /*forms.TablesFail tables = new forms.TablesFail(procedure.TablesProcedure);
        //                    tables.ShowDialog();*/
        //                }
        //            }
        //            else
        //            {
        //                message.Dispose();
        //            }
        //        }
        //        else
        //        {
        //            System.Windows.Forms.MessageBox.Show("Please select a option task", "Procedures", MessageBoxButtons.OK);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message + " when " + cboSpecialTask.SelectedItem.ToString(), "Procedure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}