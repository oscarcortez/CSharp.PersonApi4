using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class PersonIdentityValue
    {
        public int PersonIdentityValueId { get; set; }
        public int PersonId { get; set; }
        public int IdentityValueId { get; set; }
        public int OrderValue { get; set; }

        public virtual IdentityValue IdentityValue { get; set; }
        public virtual Person Person { get; set; }
    }
}
