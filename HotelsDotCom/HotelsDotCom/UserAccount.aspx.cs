using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class UserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int user_id = (int)Session["user_id"];
                DBMgr dbm = new DBMgr();

                List<Reservation> hotels = dbm.getReservations(user_id);
                //Add items to DropDown
                for (int i = 0; i < hotels.Count; i++)
                {
                    ListItem newItem = new ListItem()
                    {
                        Value = hotels[i].r_id.ToString(),
                        Text = hotels[i].r_id + " / " + hotels[i].c_id
                        + " / " + hotels[i].h_name + " / " + hotels[i].r_type
                        + " / " + hotels[i].starting + " / " + hotels[i].ending
                        + " / " + hotels[i].quantity,
                    };
                    rblist1.Items.Add(newItem);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DBMgr dbm = new DBMgr();
            int r_id = Convert.ToInt32(rblist1.SelectedValue);
            dbm.deleteReservation(r_id);
            Response.Redirect("UserAccount.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

    }
}