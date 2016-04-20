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
        private DBMgr dbm = DBMgr.getInstance();
        private string starting, ending, destination;
        private Search search;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            //private reservation = (Reservation)Session["Reservation"];
            search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
            //Response.Write(search.StartingDate); //4/2/2016 
            starting = search.StartingDate;
            ending = search.EndingDate;
            destination = search.Destination;
            //DBMgr dbm = new DBMgr();
            //List<HotelRoomQuantity> hotels = dbm.getHotelCapacityByDes("Hawaii");
            if (!IsPostBack)
            {
                //get hotels by destination
                //hotels = dbm.getHotelCapacityByDes(destination);
                hotels = Clone.cloneHotels( HotelCapacityFactory.getFactory().getHotelsByDestination(destination).getHotelCapacityByDestination());
                lblDestination.Text = destination;
                lblStart.Text = starting;
                lblEnd.Text = ending;

                //gets available rooms on selected dates
                List<HotelRoomQuantity> hotelList = getAvailableRooms(starting, ending, destination);

                //binds the list of hotels by destination to the list view control
                lstView.DataSource = hotelList;
                lstView.DataBind();

                //if (!IsPostBack)
                //{

                ////Add items to DropDown
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

        protected void lstView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string lstView_val = (string)e.CommandArgument;
            HotelRoomQuantity hotelRoom = dbm.getSelectdHotelRoom(lstView_val);
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

        private List<HotelRoomQuantity> getAvailableRooms(string starting, string ending, string destination) 
        {
            List<HotelRoomQuantity> tempHotels = new List<HotelRoomQuantity>();
            List<HotelRoomQuantity> hotel_occupied = dbm.getHotelCapacityByDes(destination);
            //List<HotelRoomQuantity> hotel_occupied = Clone.cloneHotels(HotelCapacityFactory.getFactory().getHotelsByDestination(destination).getHotelCapacityByDestination());
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

            //List<HotelRoomQuantity> occupied = dbm.getReserved(starting, ending, destination);

            foreach (HotelRoomQuantity hotel in hotels)
            {  
                hotel.TotalRooms = hotel.Quantity;
                     
                foreach (HotelRoomQuantity reserved in hotel_occupied)
                {
                    if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                    {
                        hotel.Quantity -= reserved.Quantity;
                        if (hotel.Quantity > 0)
                        {
                            hotel.AvailableRooms = hotel.Quantity;
                            tempHotels.Add(hotel);
                        }
                    }

                }

            }


            //for (int i = 0; i < hotels.Count; i++)
            //{
            //    qty = hotels[i].Quantity;
            //}
                        
            return tempHotels;
        }

        //private List<HotelRoomQuantity> getMax(List<HotelRoomQuantity> one, List<HotelRoomQuantity> two)
        //{
        //    List<HotelRoomQuantity> lst = new List<HotelRoomQuantity>();
        //    return lst;
        //}

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    //HotelRoomQuantity hotelRoom = hotels[radList.SelectedIndex];
        //    //Session["hotel_room"] = hotelRoom;


        //    //if (Session["user_id"] != null)
        //    //{
        //    //    Response.Redirect("Reserve.aspx");
        //    //}
        //    //else
        //    //{
        //    //    Response.Redirect("Login.aspx");
        //    //}
        //}
    }
}