using System;
using System.Collections.Generic;

#nullable disable

namespace PersonApi4.Models
{
    public partial class Rol
    {
        public int RolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
