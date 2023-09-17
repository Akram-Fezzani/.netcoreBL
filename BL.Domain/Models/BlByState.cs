using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Domain.Models
{
   public class BlByState
    {
        public IList<Boolean> State { get; set; }
        public IList<int> Bls { get; set; }
    }
}
