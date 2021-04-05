using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class IdentityType
    {
        public IdentityType()
        {
            IdentityValues = new HashSet<IdentityValue>();
        }

        public int IdentityTypeId { get; set; }
        public string Value { get; set; }

        public virtual ICollection<IdentityValue> IdentityValues { get; set; }
    }
}
