using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class Clone
    {
        private static List<HotelRoomQuantity> hotels = new List<HotelRoomQuantity>();

        public static List<HotelRoomQuantity> cloneHotels(List<HotelRoomQuantity> h)
        {
            foreach (HotelRoomQuantity hrq in h)
            {
                HotelRoomQuantity temp = new HotelRoomQuantity();
                temp.H_name = String.Copy(hrq.H_name);
                temp.R_type = String.Copy(hrq.R_type);
                temp.Quantity = hrq.Quantity;
                //temp.TotalRooms = hrq.TotalRooms;
                //temp.AvailableRooms = hrq.AvailableRooms;
                hotels.Add(temp);
            }
            return hotels;
        }

    }
}