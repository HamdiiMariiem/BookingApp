using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraWaitForm;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Forms;


namespace WindowsFormsApp1
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Model.ApplicationContext db;
        public MainRibbonForm()
        {
            InitializeComponent();
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
            frm.MdiParent = this;
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


        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Formshow(WindowsFormsApp1.Booking.InstanceBooking);
        }

        private void BtnCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
          //  FormshowNotParent(WindowsFormsApp1.Forms.FrmAjouterCategorie.InstanceFrmAjouterCategorie);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(WindowsFormsApp1.Booking.InstanceBooking);

            //db = new Model.ApplicationContext();
            //var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            //if (Utilisateur.GererArticle)
            //{
               
            //}
            //else
            //{
            //    XtraMessageBox.Show("Licence Article est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
            //  MessageBoxIcon.Information);
            //}


        }

        private void btnStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererStock)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmStock.InstanceFrmStock);
            }
            else
            {
                XtraMessageBox.Show("Licence Stock est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }

        }

        private void barBtnListeCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.Gerercategorie)
            {
              //  Formshow(WindowsFormsApp1.Forms.FrmListeCategories.InstanceFrmListeCategories);
            }
            else
            {
                XtraMessageBox.Show("Licence Catégorie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }


        }


        private void barBtnAddBonSortie_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererBonSortie)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmCreeBonDeSorties.InstanceFrmCreeBonDeSorties);
            }
            else
            {
                XtraMessageBox.Show("Licence Bon Sortie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }


        }

        private void barBtnListeBonSorties_ItemClick(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererBonSortie)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmListeBonDeSorties.InstanceFrmListeBonDeSorties);
            }
            else
            {
                XtraMessageBox.Show("Licence Bon Sortie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }


        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.Gerercategorie)
            {
              //  FormshowNotParent(WindowsFormsApp1.Forms.FrmAjouterCategorie.InstanceFrmAjouterCategorie);
            }
            else
            {
                XtraMessageBox.Show("Licence Catégorie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }


        }

        private void barBtnGestionUtilisateur_ItemClick(object sender, ItemClickEventArgs e)
        {

            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererUtilisateur)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmUtilisateur.InstanceFrmUtilisateur);
            }
            else
            {
                XtraMessageBox.Show("Licence Utilisateur est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }

        }

        private void barBtnEmployeur_ItemClick(object sender, ItemClickEventArgs e)
        {

            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererEmployeur)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmEmployeur.InstanceFrmEmployeur);
            }
            else
            {
                XtraMessageBox.Show("Licence Employeur est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }


        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}