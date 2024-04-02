using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
  public  class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public Boolean Admin { get; set; }

        public bool GererArticle { get; set; }
        public bool Gerercategorie { get; set; }
        public bool GererBonSortie { get; set; }
        public bool GererUtilisateur { get; set; }
        public bool GererEmployeur { get; set; }
        public bool GererStock { get; set; }



    }
}
