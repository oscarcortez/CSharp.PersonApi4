using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class Birthdate
    {
        public Birthdate()
        {
            PersonBirthdates = new HashSet<PersonBirthdate>();
        }

        public int BirthdateId { get; set; }
        public DateTime? Value { get; set; }

        public virtual ICollection<PersonBirthdate> PersonBirthdates { get; set; }
    }
}
