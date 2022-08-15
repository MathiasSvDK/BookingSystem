using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Entities
{
    public class Available
    {
        public int AvailableId { get; set; }
        public DateTime Date { get; set; }
        public bool IsTaken { get; set; }

        public Booking Booking { get; set; }
    }
}
