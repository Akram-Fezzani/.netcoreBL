using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BL.Domain.Models
{
    public class BLs
    {
        public Guid BLsId { get; set; }
        public int NumBL { get; set; }
        public int NumBE { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateBE { get; set; }
        public String Chauffeur { get; set; }
        public String NumPlombage { get; set; }
        public String TypeBL { get; set; }
        public Boolean Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateLivraison { get; set; }
        [JsonIgnore]
        public Guid BEId { get; set; }
        public Guid CenterId { get; set; }
    }
}