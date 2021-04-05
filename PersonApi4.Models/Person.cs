using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonBirthdates = new HashSet<PersonBirthdate>();
            PersonIdentityValues = new HashSet<PersonIdentityValue>();
        }

        public int PersonId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<PersonBirthdate> PersonBirthdates { get; set; }
        public virtual ICollection<PersonIdentityValue> PersonIdentityValues { get; set; }
    }
}
