using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace naukaKolokwiumAPDB.DTOs
{
    public class AnimalRequest
    {


        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public int IdOwner { get; set; }


    }
}
