﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adress
    {
        public string StreetAdress { get; set;}
        [Required]
        public string City { get; set; }




    }
}
