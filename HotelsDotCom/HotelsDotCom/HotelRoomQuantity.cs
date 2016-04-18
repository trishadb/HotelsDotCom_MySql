using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsDotCom
{
    public class HotelRoomQuantity
    {
        private String h_name;
        private String r_type;
        private int quantity;

        public HotelRoomQuantity()
        {
            //
            // TODO: Add constructor logic here
            //
            h_name = null;
            r_type = null;
            quantity = 0;
        }

        public String H_name { get; set; }
        public String R_type { get; set; }
        public int Quantity { get; set; }
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
    }
}
