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
    public partial class FrmEmployeur : DevExpress.XtraEditors.XtraForm
    {
        public WindowsFormsApp1.Model.ApplicationContext db;
        private static FrmEmployeur _FrmEmployeur;
        public static FrmEmployeur InstanceFrmEmployeur
        {
            get
            {
                if (_FrmEmployeur == null)
                    _FrmEmployeur = new FrmEmployeur();
                return _FrmEmployeur;
            }
        }

        public FrmEmployeur()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }


        private void FrmEmployeur_Load(object sender, EventArgs e)
        {
            employeurBindingSource.DataSource = db.Employeurs.ToList();
        }







        private void btnsupp_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("voulez vous supprimer cet élément ?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                var emp = gridView1.GetFocusedRow() as Employeur;
                var empDb = db.Employeurs.Find(emp.Id);
                db.Employeurs.Remove(empDb);
                db.SaveChanges();
                /***************************** reload DataGridView ***********************************/
                employeurBindingSource.DataSource = db.Employeurs.ToList();
                /***************************** reload DataGridView  ***********************************/
                XtraMessageBox.Show("l'Employeur a été supprimé avec Succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                XtraMessageBox.Show("La suppression été annulé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            db = new Model.ApplicationContext();
            Employeur E = gridView1.GetFocusedRow() as Employeur;
            var EmployeurDB = db.Employeurs.Find(E.Id);

            EmployeurDB.Nom = E.Nom;
            EmployeurDB.Prenom = E.Prenom;
            EmployeurDB.Matricule = E.Matricule;
            db.SaveChanges();
            /***************************** reload DataGridView ***********************************/
            employeurBindingSource.DataSource = db.Employeurs.ToList();
            /***************************** reload DataGridView  ***********************************/
            // XtraMessageBox.Show("la mise à jour a été effectuée avec succès", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnEnregistrer_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtNom.Text))
            {
                TxtNom.ErrorText = "Nom est obligatoire";
                return;
            }

            if (String.IsNullOrEmpty(TxtPrenom.Text))
            {
                TxtNom.ErrorText = "Prénom est obligatoire";
                return;
            }

            if (String.IsNullOrEmpty(TxtMatricule.Text))
            {
                TxtNom.ErrorText = "‎Matricule est obligatoire";
                return;
            }
            Employeur emp = new Employeur();
            emp.Nom = TxtNom.Text;
            emp.Prenom = TxtPrenom.Text;
            emp.Matricule = TxtMatricule.Text;
            db.Employeurs.Add(emp);
            db.SaveChanges();
            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
            TxtMatricule.Text = string.Empty;
            XtraMessageBox.Show("Enregistrement terminé", "Application Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            employeurBindingSource.DataSource = db.Employeurs.ToList();
        }

        private void FrmEmployeur_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            _FrmEmployeur = null;
        }
    }
}
