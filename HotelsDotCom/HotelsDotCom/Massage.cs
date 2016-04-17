using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class Massage:Decorator
    {
        private Decorator rsv;
        public Massage(Decorator rsv)
        {
            this.rsv = rsv;
        }
        public decimal cost()
        {
            return rsv.cost()+99;
        }
        public String specialRequirement()
        {
            return rsv.specialRequirement() + " Massage ";
        }
    }
}