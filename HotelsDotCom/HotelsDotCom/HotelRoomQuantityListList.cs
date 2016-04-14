using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsDotCom
{
    class HotelRoomQuantityListList
    {
        List<HotelRoomQuantityList> lst;

        public HotelRoomQuantityListList()
        {
            //
            // TODO: Add constructor logic here
            //
            lst = new List<HotelRoomQuantityList>();

        }

        public void add(HotelRoomQuantityList hrq)
        {
            lst.Add(hrq);

        }

        public List<HotelRoomQuantityList> getList()
        {
            return lst;
        }

        public int getSize()
        {
            return lst.Count;
        }
    }
}
