using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class IdentityValue
    {
        public IdentityValue()
        {
            PersonIdentityValues = new HashSet<PersonIdentityValue>();
        }

        public int IdentityValueId { get; set; }
        public string Value { get; set; }
        public string PhoneticValue { get; set; }
        public int IdentityTypeId { get; set; }

        public virtual IdentityType IdentityType { get; set; }
        public virtual ICollection<PersonIdentityValue> PersonIdentityValues { get; set; }
    }
}
