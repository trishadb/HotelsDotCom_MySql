using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class _Default : Page
    {
        DBMgr db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = DBMgr.getInstance();
            ArrayList cities = db.getCities();
            if (!IsPostBack)
            {

                foreach (Hotel h in cities)
                {
                    ddlCities.Items.Add(h.cities);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.StartingDate = txtArrivalDate.Text;
            search.EndingDate = txtDepartureDate.Text;
            search.Destination = ddlCities.SelectedValue;  //in order to get the dropdown list value, the binding has to to put in cs file, not aspx file.
            Session["Search"] = search;
            Response.Redirect("AvailableHotels.aspx");
        }
    }
}