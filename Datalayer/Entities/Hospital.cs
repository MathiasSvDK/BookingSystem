using System;
using System.Collections.Generic;

namespace Datalayer.Entities
{
    public partial class Hospital
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Beds { get; set; }
    }
}
