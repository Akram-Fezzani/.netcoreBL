using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Domain.Models
{
   public class CammandByClient
    {

        public IList<String> client { get; set; }
        public IList<int> nbr { get; set; }
    }
}
