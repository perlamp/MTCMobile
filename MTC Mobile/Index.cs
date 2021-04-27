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

namespace MTC_Mobile
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();

            showOptions();

            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }

        private void showOptions()
        {
            IDao<Settings> settingsDao = new SettingsDao();
            Settings settings = settingsDao.GetById(1);
            int userId = (int)settings.getUserId();

            IDao<User> userDao = new UserDao();
            User user = userDao.GetById(userId);
            AccessLevel usrAccesLvl = user.getAccessLevel();

            IDao<Module> moduleDao = new ModuleDao();

            Module moduleRead = moduleDao.GetList("name", "Readings")[0];
            List<AccessLevel> accessLvlRead = moduleRead.getAccessLevels();
            if (accessLvlRead.Any(item => item.getId() == usrAccesLvl.getId()))
            {
                pnl_readings.Show();
            }

            Module moduleProcedures = moduleDao.GetList("name", "Procedures")[0];
            List<AccessLevel> accessLvlProcedures = moduleProcedures.getAccessLevels();
            if (accessLvlProcedures.Any(item =>item.getId() == usrAccesLvl.getId()))
            {
                pnl_procedures.Show();
            }

            Module moduleUsers = moduleDao.GetList("name", "Users")[0];
            List<AccessLevel> accessLvlUsers = moduleUsers.getAccessLevels();
            if (accessLvlUsers.Any(item => item.getId() == usrAccesLvl.getId()))
            {
                pnl_users.Show();
            }
        }

        private void btn_readings_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            Readings frmReadings = new Readings();
            frmReadings.ShowDialog();

            this.Close();
        }

        private void btn_procedures_Click(object sender, EventArgs e)
        {

            Procedures frmProcedures = new Procedures();
            frmProcedures.ShowDialog();

            this.Close();
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            Users frmUsers = new Users();
            frmUsers.ShowDialog();

            this.Close();
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnu_closeSession_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();

            Home frmHome = new Home();
            frmHome.ShowDialog();

            this.Close();
        }

    }
}