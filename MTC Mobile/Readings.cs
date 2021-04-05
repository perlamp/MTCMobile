using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using MTC_Mobile.Object;
using MTC_Mobile.Dao;
using MTC_Mobile.Util;

namespace MTC_Mobile
{
    public partial class Readings : Form
    {
        Interface.Meter Device = new MTC_Mobile.Interface.Meter();

        /* GENERAL */
        public Readings()
        {
            InitializeComponent();

            loadReadingOptions();

            readingOptions();

            loadStoragePath();

            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }

        private void loadReadingOptions()
        {
            IDao<Reading> readingDao = new ReadingDao();
            List<Reading> listReadings = readingDao.GetList();
            Dictionary<String, String> comboSource = new Dictionary<String, String>();
            foreach (Reading read in listReadings)
            {
                comboSource.Add(read.getId().ToString(), read.getName());
            }

            cbo_readings.DataSource = new BindingSource(comboSource, null);
            cbo_readings.DisplayMember = "Value";
            cbo_readings.ValueMember = "Key";
        }


        /* READINGS */

        private void cbo_readings_SelectedIndexChanged(object sender, EventArgs e)
        {

            readingOptions();
                
        }

        private void readingOptions()
        {
            string readingId = ((KeyValuePair<String, String>)cbo_readings.SelectedItem).Key;

            if (readingId.Equals("1") || readingId.Equals("4"))
            {
                rdo_nothing.Checked = true;

                cbo_days.SelectedIndex = 0;
                cbo_days.Enabled = false;

                cbo_weeks.SelectedIndex = 0;
                cbo_weeks.Enabled = false;
                    
                pnl_reading_options.Show();
            }
            else
            {
                pnl_reading_options.Hide();
            }
        }

        private void rdo_nothing_CheckedChanged(object sender, EventArgs e)
        {
            cbo_days.SelectedIndex = 0;
            cbo_days.Enabled = false;

            cbo_weeks.SelectedIndex = 0;
            cbo_weeks.Enabled = false;

        }

        private void rdo_days_CheckedChanged(object sender, EventArgs e)
        {
            cbo_days.SelectedIndex = 0;
            cbo_days.Enabled = true;

            cbo_weeks.SelectedIndex = 0;
            cbo_weeks.Enabled = false;
        }

        private void rdo_weeks_CheckedChanged(object sender, EventArgs e)
        {
            cbo_days.SelectedIndex = 0;
            cbo_days.Enabled = false;

            cbo_weeks.SelectedIndex = 0;
            cbo_weeks.Enabled = true;
        }

        private void btn_readings_Click(object sender, EventArgs e)
        {
            string result = "";
            string message = "";
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            if (Device.testConnection())
            {

                string readingId = ((KeyValuePair<String, String>)cbo_readings.SelectedItem).Key;
                
                IDao<Reading> readingDao = new ReadingDao();
                Reading reading = readingDao.GetById(Int32.Parse(readingId));
                List<Table> listTables = reading.getTables();

                Dictionary<String, List<String[]>> tablesData = readTables(listTables);

                Report report = new Report();
                Response response = null;
                if (rdo_xml.Checked)
                {
                    response = report.createXML(tablesData, reading.getName());
                }
                else
                {
                    response = report.createEDF(tablesData, reading.getName());
                }
                
                if (response.getResult())
                {
                    result = "Correcto";
                    message = "Archivo creado correctamente";
                }
                else
                {
                    result = "Error";
                    message = "No se pudo crear el archivo";
                }
            }
            else
            {
                result = "Error";
                message = "No se detecta un medidor conectado";
            }


            Cursor.Current = Cursors.Default;
            Cursor.Show();
            MessageBox.Show(message, result);
        }

        private Dictionary<String, List<String[]>> readTables(List<Table> listTables)
        {
            Dictionary<String, List<String[]>> tablesData = new Dictionary<String, List<String[]>>();

            foreach (Table table in listTables)
            {
                string decade = (table.getDecade() == null ? "MT" : table.getDecade().ToString());

                if (!tablesData.ContainsKey(decade))
                {
                    List<String[]> newList = new List<string[]>();
                    tablesData.Add(decade, newList);
                }

                string code = table.getCode();
                string data = Device.readTable(code);
                string[] dataTable = {code, data};

                List<String[]> decadeTables = tablesData[decade];
                decadeTables.Add(dataTable);
                tablesData[decade] = decadeTables;

            }

            return tablesData;
        }


        /* CONFIG */
        private void tab_readings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_readings.SelectedIndex == 0)
            {
                cbo_readings.SelectedIndex = 0;
            }
            else
            {
                loadStoragePath();
            }
        }

        private void loadStoragePath()
        {
            Boolean error = false;
            string programFolder = Path.GetDirectoryName(this.GetType().Assembly.GetModules()[0].FullyQualifiedName);
            IDao<Settings> settingsDao = new SettingsDao();
            Settings settings = settingsDao.GetById(1);
            if (settings == null)
            {
                settings = new Settings();
                settings.setStoragePath(programFolder);

                Response response = settingsDao.Insert(settings);
                if (response.getResult())
                {
                    settings.setId(Int32.Parse(response.getInfo()));
                }
                else
                {
                    error = true;
                }

            }
            else if (!Directory.Exists(settings.getStoragePath()))
            {
                settings.setStoragePath(programFolder);

                Response response = settingsDao.Update(settings);
                if (!response.getResult())
                {
                    error = true;
                }
            }

            if (!error)
            {
                lbl_currentDir.Text = "Directorio actual: " + settings.getStoragePath();
                txt_currDir.Text = settings.getStoragePath();
                openDir(false);
            }
            else
            {
                tab_readings.SelectedIndex = 0;
                MessageBox.Show("Existe un problema con la configuración del directorio de escritura"
                        + "\nLos archivos se guardaran en el directorio:\n" + programFolder, "Error");
            }
        }

        private void openDir(Boolean childDir)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            string path = txt_currDir.Text;
            if (childDir)
            {
                if (txt_currDir.Text.Equals("\\"))
                {
                    path += lst_directory.SelectedItem.ToString();
                }
                else
                {
                    path += "\\" + lst_directory.SelectedItem.ToString();
                }
            }

            lst_directory.Items.Clear();

            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                string[] arrDir = dir.Split('\\');
                lst_directory.Items.Add(arrDir[arrDir.Count() - 1]);
            }

            txt_currDir.Text = path;

            btn_backDir.Visible = true;

            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }

        private void btn_openDir_Click(object sender, EventArgs e)
        {
            if (lst_directory.SelectedItem != null)
            {
                openDir(true);
            }
        }

        private void btn_backDir_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            string path = txt_currDir.Text;

            string[] arrPath = path.Split('\\');
            arrPath = arrPath.Take(arrPath.Count() - 1).ToArray();

            string parentPath = string.Join("\\", arrPath);
            parentPath = (parentPath.Equals("") ? "\\" : parentPath);

            lst_directory.Items.Clear();

            string[] dirs = Directory.GetDirectories(parentPath);
            foreach (string dir in dirs)
            {
                string[] arrDir = dir.Split('\\');
                lst_directory.Items.Add(arrDir[arrDir.Count() - 1]);
            }

            txt_currDir.Text = parentPath;

            btn_backDir.Visible = !parentPath.Equals("\\");

            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }

        private void btn_newFolder_Click(object sender, EventArgs e)
        {
            string folderName = Interaction.InputBox("Favor de ingresar el nombre de la nueva carpeta", "Nueva Carpeta", "", -1, -1);
            if (folderName.Equals(""))
            {
                MessageBox.Show("No se ha creado carpeta");
            }
            else
            {
                string path = txt_currDir.Text;
                Directory.CreateDirectory(path + "\\" + folderName);
                MessageBox.Show("Carpeta " + folderName + "\ncreada en: " + path + ".");
                openDir(false);
            }
        }

        private void btn_setDirectory_Click(object sender, EventArgs e)
        {
            string path = txt_currDir.Text;
            if (txt_currDir.Text.Equals("\\"))
            {
                path += lst_directory.SelectedItem.ToString();
            }
            else
            {
                path += "\\" + lst_directory.SelectedItem.ToString();
            }

            if (setStoragePath(path))
            {
                lbl_currentDir.Text = "Ruta actual: " + path;
                txt_currDir.Text = path;
                openDir(false);
                MessageBox.Show("Directorio actualizado", "Correcto");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el directorio de escritura", "Error");
            }
        }

        private Boolean setStoragePath(string newPath)
        {
            IDao<Settings> settingsDao = new SettingsDao();

            Settings settings = settingsDao.GetById(1);
            settings.setStoragePath(newPath);

            Response response = settingsDao.Update(settings);
            return response.getResult();
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