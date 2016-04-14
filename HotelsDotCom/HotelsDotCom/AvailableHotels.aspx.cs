using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class AvailableHotels : System.Web.UI.Page
    {
        private List<HotelRoomQuantity> hotels;
        protected void Page_Load(object sender, EventArgs e)
        {
            //private reservation = (Reservation)Session["Reservation"];
            Search search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
            //Response.Write(search.StartingDate); //4/2/2016 
            String starting = search.StartingDate;
            String ending = search.EndingDate;
            String destination = search.Destination;
            DBMgr dbm = new DBMgr();
            //List<HotelRoomQuantity> hotels = dbm.getHotelCapacityByDes("Hawaii");
            hotels = dbm.getHotelCapacityByDes(destination);

            List<HotelRoomQuantity> hotel_occupied = dbm.getHotelCapacityByDes(destination);
            foreach (HotelRoomQuantity room in hotel_occupied)
            {
                room.Quantity = 0;
            }
            DateTime ArrivalDate = Convert.ToDateTime(starting);
            DateTime DepartureDate = Convert.ToDateTime(ending);
            List<Object> list = new List<Object>();
            for (DateTime i = ArrivalDate; i < DepartureDate; i = i.AddDays(1))
            {
                String date = i.ToShortDateString();
                list.Add(dbm.getReservedOnSingleNight(date, destination));
            }

            for (int i = 0; i < list.Count; i++)
            {
                foreach (HotelRoomQuantity hotel in hotel_occupied)
                {
                    foreach (HotelRoomQuantity reserved in (List<HotelRoomQuantity>)list[i])
                    {
                        if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                        {
                            if (hotel.Quantity < reserved.Quantity)
                            {
                                hotel.Quantity = reserved.Quantity;
                            }
                        }

                    }
                }
            }

            List<HotelRoomQuantity> occupied = dbm.getReserved(starting, ending, destination);

            foreach (HotelRoomQuantity hotel in hotels)
            {
                foreach (HotelRoomQuantity reserved in hotel_occupied)
                {
                    if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                    {
                        hotel.Quantity = hotel.Quantity - reserved.Quantity;
                    }

                }
            }
            if (!IsPostBack)
            {

                //Add items to DropDown
                for (int i = 0; i < hotels.Count; i++)
                {
                    ListItem newItem = new ListItem()
                    {
                        Value = i.ToString(),
                        Text = hotels[i].H_name + " / " + hotels[i].R_type + " / " + hotels[i].Quantity,
                    };
                    radList.Items.Add(newItem);

                }
            }
        }

        private List<HotelRoomQuantity> getMax(List<HotelRoomQuantity> one, List<HotelRoomQuantity> two)
        {
            List<HotelRoomQuantity> lst = new List<HotelRoomQuantity>();
            return lst;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            HotelRoomQuantity hotelRoom = hotels[radList.SelectedIndex];
            Session["hotel_room"] = hotelRoom;


            if (Session["user_id"] != null)
            {
                Response.Redirect("Reserve.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}