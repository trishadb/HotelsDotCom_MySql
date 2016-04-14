using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class Reserve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            DBMgr dbm = new DBMgr();
            HotelRoomQuantity hotel_room = (HotelRoomQuantity)Session["hotel_room"];
            String hotel = hotel_room.H_name;
            String r_type = hotel_room.R_type;
            int quantity = Convert.ToInt32(ddlNoOfRooms.SelectedValue);
            Search search = (Search)Session["search"];
            String starting = search.StartingDate;
            String ending = search.EndingDate;

            int user_id = (int)Session["user_id"];
            dbm.insertReservation(user_id, hotel, r_type, starting, ending, quantity);

            Response.Redirect("UserAccount.aspx");
        }
    }
}