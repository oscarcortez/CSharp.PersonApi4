using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class PersonBirthdate
    {
        public int PersonBirthdateId { get; set; }
        public int PersonId { get; set; }
        public int BirthdateId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Birthdate Birthdate { get; set; }
        public virtual Person Person { get; set; }
    }
}
