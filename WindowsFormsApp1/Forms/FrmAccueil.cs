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
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Forms
{
    public partial class FrmAccueil : DevExpress.XtraEditors.XtraForm
    {
        public Model.ApplicationContext db { get; set; }
        private static FrmAccueil _FrmAccueil;
        public static FrmAccueil InstanceFrmAccueil
        {
            get
            {
                if (_FrmAccueil == null)
                    _FrmAccueil = new FrmAccueil();
                return _FrmAccueil;
            }
        }
        public FrmAccueil()
        {
            InitializeComponent();
        }

        private void FrmAccueil_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAccueil = null;
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
            frm.MdiParent = Application.OpenForms.OfType<MainRibbonForm>().First();
            frm.Show();
            frm.Activate();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
         //   Formshow(WindowsFormsApp1.Forms.FrmAjouterArticle.InstanceFrmAjouterArticle);
        }


        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {

            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererBonSortie)
            {
          //      Formshow(WindowsFormsApp1.Forms.FrmListeBonDeSorties.InstanceFrmListeBonDeSorties);
            }
            else
            {
                XtraMessageBox.Show("Licence Bon Sortie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }
        }

        private void StockItem_ItemClick(object sender, TileItemEventArgs e)
        {
          //  Formshow(WindowsFormsApp1.Forms.FrmStock.InstanceFrmStock);
        }

        private void GererArticle_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererArticle)
            {
            //    Formshow(WindowsFormsApp1.Forms.FrmAjouterArticle.InstanceFrmAjouterArticle);
            }
            else
            {
                XtraMessageBox.Show("Licence Bon sortie invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }
        }

        private void GererBonSortie_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.GererBonSortie)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmCreeBonDeSorties.InstanceFrmCreeBonDeSorties);
            }
            else
            {
                XtraMessageBox.Show("Licence Bon sortie invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }

        }

        private void AjouterCategorie_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.Gerercategorie)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmAjouterCategorie.InstanceFrmAjouterCategorie);
            }
            else
            {
                XtraMessageBox.Show("Licence Catégorie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }
        }

        private void ListeCategorie_ItemClick(object sender, TileItemEventArgs e)
        {
            db = new Model.ApplicationContext();
            var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            if (Utilisateur.Gerercategorie)
            {
             //   Formshow(WindowsFormsApp1.Forms.FrmListeCategories.InstanceFrmListeCategories);
            }
            else
            {
                XtraMessageBox.Show("Licence Catégorie est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }
        }

        private void gererUser_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.FrmUtilisateur.InstanceFrmUtilisateur);
            //db = new Model.ApplicationContext();
            //var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            //if (Utilisateur.GererUtilisateur)
            //{
              
            //}
            //else
            //{
            //    XtraMessageBox.Show("Licence Utilisateur est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
            //  MessageBoxIcon.Information);
            //}
        }

        private void gererEmp_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(WindowsFormsApp1.Forms.FrmEmployeur.InstanceFrmEmployeur);
            //db = new Model.ApplicationContext();
            //var Utilisateur = db.Utilisateurs.Find(LoginInfo.UserID);
            //if (Utilisateur.GererEmployeur)
            //{

            //}
            //else
            //{
            //    XtraMessageBox.Show("Licence Employeur est invalide!", "Application Gestion de bon de sortie ", MessageBoxButtons.OK,
            //  MessageBoxIcon.Information);
            //}

        }

        private void Stock_ItemClick(object sender, TileItemEventArgs e)
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

        private void FrmAccueil_Load(object sender, EventArgs e)
        {

        }
    }
}