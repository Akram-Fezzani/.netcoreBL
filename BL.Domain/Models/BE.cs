using BL.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BL.Domain.Models
{
    public class BE
    {
        public Guid BEId { get; set; }
        public int NumBE { get; set; }
        public DateTime DateBe { get; set; }
        public String MatriculeVehicule { get; set; }
        public String TypeBE { get; set; }
        public int NumPlombage { get; set; }
        public Boolean Status { get; set; }
        public Guid ClientId { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Guid BlId { get; set; }
        public Guid VehiculeId { get; set; }
        public Guid ChauffeurId { get; set; }
        public Guid CenterId { get; set; }

        
    }
}