using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace WindowsFormsApp1.Forms
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public WindowsFormsApp1.Model.ApplicationContext db;
        private static Dashboard _Dashboard;
        public static Dashboard InstanceBooking
        {
            get
            {
                if (_Dashboard == null)
                    _Dashboard = new Dashboard();
                return _Dashboard;
            }
        }
        public Dashboard()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }


        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Dashboard = null;
        }

        private void BtnBooking_Click(object sender, EventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.Booking.InstanceBooking);
            this.Close();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.Dashboard.InstanceBooking);
        }
        public void Formshow(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            frm.MdiParent = WindowsFormsApp1.MainRibbonForm.ActiveForm;
            frm.Show();
            frm.Activate();
        }

        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.Report.InstanceBooking);
        }

        private void BtnConfiguration_Click(object sender, EventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.Configuration.InstanceBooking);
        }
    }
}