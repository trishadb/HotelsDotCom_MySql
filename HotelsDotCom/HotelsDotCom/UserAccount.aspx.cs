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
        int user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user_id = (int)Session["user_id"];


                DBMgr_Jeff dbmJ = DBMgr_Jeff.getInstance();
                linkBtnUser.Text = dbmJ.getUser(user_id);
                List<Reservation> reservations = dbmJ.getReservations(user_id);
                rptView.DataSource = reservations;
                rptView.DataBind();
                //Add items to DropDown
                //for (int i = 0; i < hotels.Count; i++)
                //{
                //    ListItem newItem = new ListItem()
                //    {
                //        Value = hotels[i].r_id.ToString(),
                //        Text = hotels[i].r_id + " / " + hotels[i].c_id
                //        + " / " + hotels[i].h_name + " / " + hotels[i].r_type
                //        + " / " + hotels[i].starting + " / " + hotels[i].ending
                //        + " / " + hotels[i].quantity
                //        + " / " + hotels[i].spDescription + " / " + hotels[i].spCost,
                //    };
                //    rblist1.Items.Add(newItem);
                //}
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void rptView_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DBMgr dbm = new DBMgr();
            string rptView_val = (string)e.CommandArgument;
            int r_id = Convert.ToInt32(rptView_val);
            if (e.CommandName.Equals("D"))
            {
                dbm.deleteReservation(r_id);
                Response.Redirect("UserAccount.aspx");
            }
            else
            {
                Response.Redirect("SpecialRequirements.aspx?r_id=" + r_id);
            }
        }

        protected void rptView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Reservation res = (Reservation)e.Item.DataItem;
            Button btnDelete = (Button)e.Item.FindControl("btnDelete");
            Button btnAddSP = (Button)e.Item.FindControl("btnAddSP");
            if (res != null)
            {
                btnDelete.CommandArgument = res.r_id.ToString();
                btnAddSP.CommandArgument = res.r_id.ToString();
            }
        }

        protected void linkBtnUser_Click(object sender, EventArgs e)
        {
            if (user_id != null)
            {
                Response.Redirect("UserAccount.aspx");
            }

        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DBMgr dbm = new DBMgr();
        //    int r_id = Convert.ToInt32(rblist1.SelectedValue);
        //    dbm.deleteReservation(r_id);
        //    Response.Redirect("UserAccount.aspx");
        //}

        //protected void btnAddSP_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SpecialRequirements.aspx?r_id=" + rblist1.SelectedValue);
        //}
    }
}