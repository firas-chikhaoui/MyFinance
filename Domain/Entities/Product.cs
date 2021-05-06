using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        [StringLength(25, ErrorMessage = "max Lenghth is 25")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]

        public double Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be positive")]
        public int Quantity { get; set; }
        public string imageName { get; set; }
        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }
        //foreign Key properties


        public int? CategoryId { get; set; }
        //navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }

    }
}
