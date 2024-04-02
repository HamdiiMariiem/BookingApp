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

namespace WindowsFormsApp1.Forms
{
    public partial class BookingInterface : DevExpress.XtraEditors.XtraForm
    {
        public WindowsFormsApp1.Model.ApplicationContext db;
        private static BookingInterface _BookingInterface;
        public static BookingInterface InstanceBooking
        {
            get
            {
                if (_BookingInterface == null)
                    _BookingInterface = new BookingInterface();
                return _BookingInterface;
            }
        }
        public BookingInterface()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

     
        private void XtraForm1_Load(object sender, EventArgs e)
        {

        }

        private void BookingInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            _BookingInterface = null;
        }

     
    }
}