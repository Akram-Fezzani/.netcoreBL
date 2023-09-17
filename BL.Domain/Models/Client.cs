using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BL.Domain.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Telephone { get; set; }
        public int CommandNbr { get; set; }
        public ICollection<BE> BEs { get; set; }

        public Guid SocieteId { get; set; }

    }
}