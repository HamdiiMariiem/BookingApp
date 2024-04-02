using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Booking : Form
    {
        public WindowsFormsApp1.Model.ApplicationContext db;
        private static Booking _Booking;
        public static Booking InstanceBooking
        {
            get
            {
                if (_Booking == null)
                    _Booking = new Booking();
                return _Booking;
            }
        }
        public Booking()
        {
            InitializeComponent();
            db = new Model.ApplicationContext();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bookingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        private void Booking_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Booking = null;
        }
    }
}
