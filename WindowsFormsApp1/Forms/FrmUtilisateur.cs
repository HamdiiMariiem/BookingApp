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
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Forms
{
    public partial class FrmUtilisateur : DevExpress.XtraEditors.XtraForm
    {
        public WindowsFormsApp1.Model.ApplicationContext db;
        private static FrmUtilisateur _FrmUtilisateur;
        public static FrmUtilisateur InstanceFrmUtilisateur
        {
            get
            {
                if (_FrmUtilisateur == null)
                    _FrmUtilisateur = new FrmUtilisateur();
                return _FrmUtilisateur;
            }
        }

        public FrmUtilisateur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }


        private void FrmUtilisateur_Load(object sender, EventArgs e)
        {
            utilisateurBindingSource.DataSource = db.Utilisateurs.ToList();
        }

        private void FrmUtilisateur_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmUtilisateur = null;

        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtLogin.Text))
            {
                TxtLogin.ErrorText = "Login est obligatoire";
                return;
            }

            if (String.IsNullOrEmpty(TxtPassword.Text))
            {
                TxtLogin.ErrorText = "Mot de passe est obligatoire";
                return;
            }



            Utilisateur user = new Utilisateur();
            user.Login = TxtLogin.Text;
            user.Password = TxtPassword.Text;

            db.Utilisateurs.Add(user);

        
           
            if (checkBoxStock.Checked)
            {
                user.GererStock = true;
            }
            else
            {
                user.GererStock = false;
            }
            db.SaveChanges();
            TxtLogin.Text = string.Empty;
            TxtPassword.Text = string.Empty;
         
            checkBoxStock.Checked = false;

            XtraMessageBox.Show("Enregistrement terminé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            utilisateurBindingSource.DataSource = db.Utilisateurs.ToList();
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                var User = gridView1.GetFocusedRow() as Utilisateur;
                var UserDb = db.Utilisateurs.Find(User.Id);
                db.Utilisateurs.Remove(UserDb);
                db.SaveChanges();
                /***************************** reload DataGridView ***********************************/
                utilisateurBindingSource.DataSource = db.Utilisateurs.ToList();
                /***************************** reload DataGridView  ***********************************/
                XtraMessageBox.Show("l'utilisateur a été supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
            else
            {

                XtraMessageBox.Show("La suppression a été annulée", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            Utilisateur U = gridView1.GetFocusedRow() as Utilisateur;
            var UtilisateurDB = db.Utilisateurs.Find(U.Id);


            UtilisateurDB.Login = U.Login;
            UtilisateurDB.Password = U.Password;
            db.SaveChanges();
            /***************************** reload DataGridView ***********************************/
            utilisateurBindingSource.DataSource = db.Utilisateurs.ToList();
            /***************************** reload DataGridView  ***********************************/
            // XtraMessageBox.Show("la mise à jour a été effectuée avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}