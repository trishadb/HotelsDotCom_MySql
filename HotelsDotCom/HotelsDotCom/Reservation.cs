using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsDotCom
{
    public class Reservation: Decorator
    {
        public Reservation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int r_id { get; set; }
        public int c_id { get; set; }
        public string h_name { get; set; }
        public string r_type { get; set; }
        public string starting { get; set; }
        public string ending { get; set; }
        public int quantity { get; set; }
        public decimal spCost { get; set; }
        public String spDescription { get; set; }

        public decimal cost()
        {
            return 0;
        }

        public String specialRequirement()
        {
            return "";
        }
    }
}
