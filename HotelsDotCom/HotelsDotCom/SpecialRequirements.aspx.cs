using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class SpecialRequirements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            
            Reservation r = new Reservation();
            //Decorator rsv = new Reservation();
            Decorator rsv = (Decorator)r;
            if (cblSpecialRequirements.Items[0].Selected) rsv = new Shuttle(rsv);
            if (cblSpecialRequirements.Items[1].Selected) rsv = new Flower(rsv);
            if (cblSpecialRequirements.Items[2].Selected) rsv = new RoomService(rsv);
            if (cblSpecialRequirements.Items[3].Selected) rsv = new Massage(rsv);

            int res_id = Convert.ToInt32(Request.QueryString["r_id"]);

            String sp = rsv.specialRequirement();
            decimal price = rsv.cost();
            HotelsDotCom.DBMgr_Jeff dbm = HotelsDotCom.DBMgr_Jeff.getInstance();
            int i = dbm.insertSpecialRequirements(res_id, sp, price);
            Response.Redirect("UserAccount.aspx");
            /*
            bool s = cblSpecialRequirements.Items[0].Selected;
            bool t = cblSpecialRequirements.Items[1].Selected;
            bool p = cblSpecialRequirements.Items[2].Selected;
            bool q = cblSpecialRequirements.Items[3].Selected;
             */
 

        }
    }
}