using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class AvailableHotels : System.Web.UI.Page
    {

        private List<HotelRoomQuantity> hotels;
        private DBMgr mgr = DBMgr.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //DBMgr mgr = new DBMgr();
                //HttpContext cont = HttpContext.Current;
                //HttpResponse resp = cont.Response;
                Search search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
                String starting = search.StartingDate;
                String ending = search.EndingDate;
                String destination = search.Destination;

                lblDestination.Text = destination;
                lblStart.Text = starting;
                lblEnd.Text = ending;


                //binding the list of hotels by destination to the list view control
                hotels = mgr.getHotelCapacityByDes(destination);
                lstView.DataSource = hotels;
                lstView.DataBind();

                int q = occupiedRooms(starting, ending, destination);
                //lblQuantity.Text = q.ToString();

                ////private reservation = (Reservation)Session["Reservation"];
                //Search search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
                //Response.Write(search.StartingDate); //4/2/2016 
                //starting = search.StartingDate;
                //ending = search.EndingDate;
                //String destination = search.Destination;
                ////DBMgr dbm = new DBMgr();
                ////List<HotelRoomQuantity> hotels = dbm.getHotelCapacityByDes("Hawaii");
                //hotels = mgr.getHotelCapacityByDes(destination);

                //List<HotelRoomQuantity> hotel_occupied = mgr.getHotelCapacityByDes(destination);

                //foreach (HotelRoomQuantity room in hotel_occupied)
                //{
                //    room.Quantity = 0;
                //}
                //DateTime ArrivalDate = Convert.ToDateTime(starting);
                //DateTime DepartureDate = Convert.ToDateTime(ending);
                //List<Object> list = new List<Object>();
                //for (DateTime i = ArrivalDate; i < DepartureDate; i = i.AddDays(1))
                //{
                //    String date = i.ToShortDateString();
                //    Debug.WriteLine("date: " + date);
                //    list.Add(mgr.getReservedOnSingleNight(date, destination));
                //}

                //for (int i = 0; i < list.Count; i++)
                //{
                //    foreach (HotelRoomQuantity hotel in hotel_occupied)
                //    {
                //        Debug.WriteLine("Hotel occupied: " + hotel.H_name + "\nqty: " + hotel.Quantity);
                //        foreach (HotelRoomQuantity reserved in (List<HotelRoomQuantity>)list[i])
                //        {
                //            Debug.WriteLine("Hotel reserved: " + reserved.H_name + "\nqty: " + reserved.Quantity);
                //            if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                //            {
                //                Debug.WriteLine("If hotel name equals to reserved: " + reserved.H_name + " and hotel r_type equals to reserved: " + reserved.R_type);
                //                if (hotel.Quantity < reserved.Quantity)
                //                {
                //                    Debug.WriteLine("If hotel quantity " + hotel.Quantity + " is less than reserved: " + reserved.Quantity);
                //                    hotel.Quantity = reserved.Quantity;
                //                }
                //            }

                //        }
                //    }
                //}

                //List<HotelRoomQuantity> occupied = mgr.getReserved(starting, ending, destination);

                //foreach (HotelRoomQuantity hotel in hotels)
                //{
                //    Debug.WriteLine("\nhotel: " + hotel.H_name + "\nqty:" + hotel.Quantity);
                //    foreach (HotelRoomQuantity reserved in hotel_occupied)
                //    {
                //        Debug.WriteLine("reserved: " + reserved.H_name + "\nqty:" + reserved.Quantity);
                //        if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                //        {
                //            hotel.Quantity = hotel.Quantity - reserved.Quantity;
                //            Debug.WriteLine("reserved quantity: " + reserved.Quantity);
                //            Debug.WriteLine("hotel quantity: " + hotel.Quantity);
                //            //hotel.AvailableRooms = hotel.Quantity - reserved.Quantity;
                //        }

                //    }
                //}

                //////Add items to radio list
                //for (int i = 0; i < hotels.Count; i++)
                //{
                //    ListItem newItem = new ListItem()
                //    {
                //        Value = i.ToString(),
                //        Text = hotels[i].H_name + " / " + hotels[i].R_type + " / " + hotels[i].Quantity,
                //    };
                //    radList.Items.Add(newItem);

                //}
            }
        }

        //private List<HotelRoomQuantity> getMax(List<HotelRoomQuantity> one, List<HotelRoomQuantity> two)
        //{
        //    List<HotelRoomQuantity> lst = new List<HotelRoomQuantity>();
        //    return lst;
        //}

        private int occupiedRooms(string starting, string ending, string destination)
        {
            int q = 0;
            List<HotelRoomQuantity> hotel_occupied = mgr.getHotelCapacityByDes(destination);

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
                list.Add(mgr.getReservedOnSingleNight(date, destination));
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

            List<HotelRoomQuantity> occupied = mgr.getReserved(starting, ending, destination);

            foreach (HotelRoomQuantity hotel in hotels)
            {
                foreach (HotelRoomQuantity reserved in hotel_occupied)
                {
                    if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                    {
                        hotel.Quantity = hotel.Quantity - reserved.Quantity;
                        //hotel.AvailableRooms = hotel.Quantity - reserved.Quantity;
                        q = hotel.Quantity;
                    }

                }
            }
            return q;
        }

        protected void lstView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string lstView_val = (string)e.CommandArgument;
            HotelRoomQuantity hotelRoom = mgr.getSelectdHotelRoom(lstView_val);
            Session["hotel_room"] = hotelRoom;
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Reserve.aspx");
            }
        }

        protected void lstView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HotelRoomQuantity hh = (HotelRoomQuantity)e.Item.DataItem;
            Button btnSelect = (Button)e.Item.FindControl("btnSelect");
            btnSelect.CommandArgument = hh.H_name + "-" + hh.R_type;

        }

    }
}