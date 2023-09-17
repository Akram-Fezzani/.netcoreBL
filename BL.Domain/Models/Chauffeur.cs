using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Domain.Models
{
    public class Chauffeur
    {
        public Guid ChauffeurId { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Telephone { get; set; }
        public Boolean State { get; set; }
        public Guid BEId { get; set; }
        public Guid SocieteId { get; set; }

    }
}