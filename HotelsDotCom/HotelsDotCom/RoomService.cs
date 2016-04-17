using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class RoomService:Decorator
    {
        private Decorator rsv;
        public RoomService(Decorator rsv)
        {
            this.rsv = rsv;
        }
        public decimal cost()
        {
            return rsv.cost()+49;
        }
        public String specialRequirement()
        {
            return rsv.specialRequirement() + " Room Service ";
        }
    }
}