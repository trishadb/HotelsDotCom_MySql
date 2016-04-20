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
        private int user_id;
        private DBMgr_Jeff dbmJ;
        protected void Page_Load(object sender, EventArgs e)
        {
            HotelRoomQuantity hotel_room = (HotelRoomQuantity)HttpContext.Current.Session["hotel_room"];
            lblSelectedRoom.Text = hotel_room.H_name + " / " + hotel_room.R_type;

            dbmJ = DBMgr_Jeff.getInstance();
            user_id = (int)Session["user_id"];
            
        }

        private void AddCookie()
        {
            HttpCookie usernameCookie = new HttpCookie("username");
            string name = dbmJ.getUser(user_id);
            usernameCookie.Value = name;
            usernameCookie.Expires = DateTime.Now.AddMonths(1);

            Response.Cookies.Add(usernameCookie);
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

            dbm.insertReservation(user_id, hotel, r_type, starting, ending, quantity);
            AddCookie();
            Response.Redirect("UserAccount.aspx");

        }


    }
}