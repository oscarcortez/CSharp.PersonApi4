using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class VwFormattedPerson
    {
        public int PersonId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string PhoneticValues { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
