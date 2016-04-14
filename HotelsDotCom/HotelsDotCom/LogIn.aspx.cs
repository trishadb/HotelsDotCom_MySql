using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelsDotCom
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            String user_name = txtName.Text;
            String psw = txtPassword.Text;
            DBMgr dbm = new DBMgr();
            int user_id = dbm.isUser(user_name, psw);
            if (user_id != -1)
            {
                Session["user_id"] = user_id;
                Response.Redirect("Reserve.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}