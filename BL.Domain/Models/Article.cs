using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BL.Domain.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public int HSC { get; set; }

        public int CodeGb { get; set; }
        public int CodeELV { get; set; }

        public String LibArticle { get; set; }

        public Guid BEId { get; set; }

        public BE BE { get; set; }


    }
}
