using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Domain.Models
{
   public class Vehicule
    {
        public Guid VehiculeId { get; set; }
        public String Matricule { get; set; }
        public Guid Proprietaire { get; set; }
        public int capacite { get; set; }
        public Boolean State { get; set; }



    }
}
