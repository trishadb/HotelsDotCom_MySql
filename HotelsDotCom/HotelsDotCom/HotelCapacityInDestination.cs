using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelsDotCom
{
    public class HotelCapacityInDestination
    {
        private List<HotelRoomQuantity> lstHotelCapacity;

        public HotelCapacityInDestination(String destination)
        {
            DBMgr dbm = DBMgr.getInstance();

            lstHotelCapacity = dbm.getHotelCapacityByDes(destination);

        }

        public List<HotelRoomQuantity> getHotelCapacityByDestination()
        {
            return lstHotelCapacity;
        }
    }
}
