<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableHotels.aspx.cs" Inherits="HotelsDotCom.AvailableHotels" %>

<%@ Import Namespace="HotelsDotCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="formGroup frm-1 fadeIn animated">
        <asp:ListView runat="server" ID="lstTemp">
            <LayoutTemplate>
                <ul>
                    <li runat="server" id="itemplaceholder"></li>

                </ul>

            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <%#Eval("cities") %>
                </li>
            </ItemTemplate>


        </asp:ListView>
        <h2>Room Availability</h2>
        <%
            HttpContext cont = HttpContext.Current;
            HttpResponse resp = cont.Response;
            Search search = (Search)HttpContext.Current.Session["search"]; //I can not use private to define search
            String starting = search.StartingDate;
            String ending = search.EndingDate;
            String destination = search.Destination;


            DBMgr dbm = new DBMgr();
            List<HotelRoomQuantity> hotels = dbm.getHotelCapacityByDes(destination);

            List<HotelRoomQuantity> occupied = dbm.getReserved(starting, ending, destination);
            resp.Write("Hotel Capacity in " + destination);
            resp.Write("<br>");
            resp.Write("<br>");
            foreach (HotelRoomQuantity hotel in hotels)
            {
                resp.Write(hotel.H_name);
                resp.Write("  /  ");
                resp.Write(hotel.R_type);
                resp.Write("  /  ");
                resp.Write(hotel.Quantity);
                resp.Write("<br>");
            }
            resp.Write("<br>");
            resp.Write("<br>");

            foreach (HotelRoomQuantity hotel in hotels)
            {
                foreach (HotelRoomQuantity reserved in occupied)
                {
                    if (hotel.H_name.Equals(reserved.H_name) && hotel.R_type.Equals(reserved.R_type))
                    {
                        hotel.Quantity = hotel.Quantity - reserved.Quantity;
                    }

                }
            }


            resp.Write("<br>");

            resp.Write("Hotel Availability in " + destination + " during " + starting + " - " + ending);
            resp.Write("<br>");
            resp.Write("<br>");    
        %>
        <asp:RadioButtonList CssClass="radio" ID="radList" runat="server"></asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfvRadList" runat="server"
            ErrorMessage="Select a hotel" ControlToValidate="radList" Display="None"></asp:RequiredFieldValidator>

        <div class="btnGroup">
            <asp:Button CssClass="button btn-1 fadeInDown animated" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        </div>
        <div id="valid">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validator" Font-Size="0.8em" />
        </div>
    </div>
</asp:Content>
