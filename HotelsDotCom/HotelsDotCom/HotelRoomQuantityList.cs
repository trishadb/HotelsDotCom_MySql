using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsDotCom
{
    class HotelRoomQuantityList
    {
        List<HotelRoomQuantity> lst;
        public HotelRoomQuantityList()
        {
            //
            // TODO: Add constructor logic here
            //
            lst = new List<HotelRoomQuantity>();
        }

        public void add(HotelRoomQuantity hrq)
        {
            lst.Add(hrq);
        }

        public List<HotelRoomQuantity> getList()
        {
            return lst;
        }

    }
}
