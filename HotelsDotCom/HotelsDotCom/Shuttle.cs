using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class Shuttle:Decorator
    {
        private Decorator rsv;
        public Shuttle(Decorator rsv)
        {
            this.rsv = rsv;
        }
        public decimal cost()
        {
            return rsv.cost()+49;
        }
        public String specialRequirement()
        {
            return rsv.specialRequirement() + " Shuttle ";
        }
    }
}