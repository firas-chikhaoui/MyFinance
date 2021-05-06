using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Matched")]
        public string ConfirmPassword { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }  // ?  nullable
        //navigation properties
        virtual public ICollection<Product> Products { get; set; }

    }
}
