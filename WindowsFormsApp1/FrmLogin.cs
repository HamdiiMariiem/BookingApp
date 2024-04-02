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
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private static FrmLogin _FrmLogin;

        public static FrmLogin InstancFrmLogin
        {
            get
            {
                if (_FrmLogin == null)
                    _FrmLogin = new FrmLogin();
                return _FrmLogin;
            }
        }

        public WindowsFormsApp1.Model.ApplicationContext Db;
        MainRibbonForm MainRibbon = new MainRibbonForm();
        public FrmLogin()
        {
            InitializeComponent();
            Db = new Model.ApplicationContext();


            //TxtLogin.EditValue = TxtLogin.Text;
            //TxtPassword.EditValue = TxtPassword.Text;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                TxtLogin.ErrorText = "Login  est obligatoire";
                return;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                TxtPassword.ErrorText = "Password  est obligatoire";
                return;
            }


           // var Utilisateur = ProcessLogin(TxtLogin.Text, TxtPassword.Text);


           // if (Utilisateur != null)
            {
             //   LoginInfo.UserID = Utilisateur.Id;
                MainRibbon.Show();
                this.Hide();
            }


        }



        private Utilisateur ProcessLogin(string Login, string password)
        {

            Utilisateur CurrentUser = Db.Utilisateurs.SingleOrDefault(a => a.Login.Equals(Login));
            if (CurrentUser != null)
            {
                if (CurrentUser.Password.Equals(password))
                {
                    return CurrentUser;
                }
                else
                {
                    TxtPassword.ErrorText = "Mot de passe invalide";
                    return null;
                }
            }
            else
            {
                TxtLogin.ErrorText = "Login  est  invalide";
                return null;
            }

        }
        public void FormshowNotParent(Form frm)
        {

            frm.Show();
            frm.Activate();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

            // initialiser l'allignement des icons des erreurs provider
            TxtLogin.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
            TxtPassword.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
#if DEBUG
            TxtLogin.Text = "Admin";
            TxtPassword.Text = "Admin";
#endif

        }



        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (string.IsNullOrEmpty(TxtLogin.Text))
                {
                    TxtLogin.ErrorText = "Login  est obligatoire";
                    return;
                }
                if (string.IsNullOrEmpty(TxtPassword.Text))
                {
                    TxtPassword.ErrorText = "Password  est obligatoire";
                    return;
                }


                var Utilisateur = ProcessLogin(TxtLogin.Text, TxtPassword.Text);


                if (Utilisateur != null)
                {
                    LoginInfo.UserID = Utilisateur.Id;
                    MainRibbon.Show();
                    this.Hide();
                }
            }


        }

        private void BtnAnnuler_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}