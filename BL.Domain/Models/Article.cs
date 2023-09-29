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

        public Guid Fk_BE { get; set; }
        public BE BE { get; set; }

    }
}