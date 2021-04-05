using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class ViewFormattedPerson
    {
        public int PersonId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string PhoneticValues { get; set; }
        public string Birthdate { get; set; }
    }
}
