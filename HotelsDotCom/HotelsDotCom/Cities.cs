using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class Cities
    {
        private static ArrayList cities;


        public static ArrayList getCities()
        {
            if (cities == null)
            {
                DBMgr db = DBMgr.getInstance();
                cities = db.getCities();
            }

            return cities;
        }
    }
}