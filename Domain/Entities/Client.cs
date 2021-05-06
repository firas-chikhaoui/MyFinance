using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        [Key]
        public int CIN { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        public string Mail { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }


        public virtual ICollection<Facture> Factures { get; set; }


    }
}
