using BL.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BL.Domain.Models
{
    public class BE
    {
        public Guid BEId { get; set; }

        public int NumBE { get; set; }

        public DateTime DateBe { get; set; }

        public string Chauffeur { get; set; }

        public String MatriculeVehicule { get; set; }

        public String TypeBE { get; set; }

        public int NumPlombage { get; set; }


        public Boolean Status { get; set; }
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Article> Articles { get; set; }

        public BLs Bl{ get; set; }




    }
}
