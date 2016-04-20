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
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null)
                {
                    txtName.Text = Request.Cookies["username"].Value;
                }
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            String user_name = txtName.Text;
            String psw = txtPassword.Text;
            bool isValid;
            try
            {
                DBMgr dbm = new DBMgr();
                isValid = dbm.isValidUser(user_name, psw);
   
                if (isValid)
                {
                    //if (user_id != -1)
                    //{
                    int user_id = dbm.isUser(user_name, psw);
                    Session["user_id"] = user_id;
                    Response.Redirect("Reserve.aspx");
                    //}
                }
                else
                {
                    lblError.Text = "Invalid username or password";
                   // Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}