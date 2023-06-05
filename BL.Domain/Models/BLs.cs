using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BL.Domain.Models
{
   public class BLs
    {
        public Guid BLId { get; set; }
        public int NumBL { get; set; }
        public int NumBE { get; set; }
        public int DateBE { get; set; }
        public String Chauffeur { get; set; }
        public String NumPlombage { get; set; }
        public String TypeBL { get; set; }
        public Boolean Status { get; set; }
        public String DateLivraison { get; set; }


        public Guid BEId { get; set; }

        public BE BE { get; set; }
    }
}
