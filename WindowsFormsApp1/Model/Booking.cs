using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
  public  class Booking
    {
        public Booking()
        {
            Date = DateTime.Now;
        }
        [Key]
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string  PersoneName { get; set; }
        public int Hours { get; set; }
        public string Activity { get; set; }
        public string Job { get; set; }
        public string ChangePackage { get; set; }
        public string Departement { get; set; }
        public string Subjob { get; set; }
    }
}
