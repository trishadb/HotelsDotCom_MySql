using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class Flower:Decorator
    {
        private Decorator rsv;
        public Flower(Decorator rsv)
        {
            this.rsv = rsv;
        }
        public decimal cost()
        {
            return rsv.cost()+29;
        }
        public String specialRequirement()
        {
            return rsv.specialRequirement() + " Flower ";
        }
    }
}