<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs"
    Inherits="HotelsDotCom.Reserve" MasterPageFile="~/Site.Master" %>

<%@ Import Namespace="HotelsDotCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="titleContent frm-1 fadeIn animated">
        <h2>Reserve Room</h2>
        <%
            HotelRoomQuantity hotel_room = (HotelRoomQuantity)HttpContext.Current.Session["hotel_room"];
            Response.Write(hotel_room.H_name);
            Response.Write(" / ");
            Response.Write(hotel_room.R_type);
        %>
    </div>

    <div class="formGroup frm-1 fadeIn animated">

        <div class="reserve">
            <label class="label">Number of Rooms</label>
            <asp:DropDownList CssClass="ddl" ID="ddlNoOfRooms" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="btnGroup">
            <asp:Button CssClass="button btn-1 fadeInDown animated" ID="btnReserve" runat="server" Text="Reserve" OnClick="btnReserve_Click" />
        </div>
    </div>
</asp:Content>
