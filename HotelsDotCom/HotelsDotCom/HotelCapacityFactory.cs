using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsDotCom
{
    public class HotelCapacityFactory
    {
        private Dictionary<String, HotelCapacityInDestination> dicDestination;
        private static HotelCapacityFactory factory;

        private HotelCapacityFactory()
        {
            dicDestination = new Dictionary<string, HotelCapacityInDestination>();
        }

        public static HotelCapacityFactory getFactory()
        {
            if (factory == null)
                factory = new HotelCapacityFactory();
            return factory;
        }

        public HotelCapacityInDestination getHotelsByDestination(String destination)
        {
            HotelCapacityInDestination obj = null;


            foreach (KeyValuePair<string, HotelCapacityInDestination> entry in dicDestination)
            {
                // do something with entry.Value or entry.Key
                if (entry.Key.Equals(destination))
                {
                    obj = entry.Value;
                    break;
                }
            }

            if (obj == null)
            {
                obj = new HotelCapacityInDestination(destination);
                dicDestination.Add(destination, obj);
            }

            return obj;

        }
    }
}