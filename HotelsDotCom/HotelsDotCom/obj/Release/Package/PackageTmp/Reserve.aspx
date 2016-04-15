<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserve.aspx.cs" Inherits="HotelsDotCom.Reserve" MasterPageFile="~/Site.Master"%>

<%@ Import Namespace="HotelsDotCom"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <h2>Reserve Room</h2>
       <%
        HotelRoomQuantity hotel_room = (HotelRoomQuantity)HttpContext.Current.Session["hotel_room"];
        Response.Write(hotel_room.H_name);
        Response.Write(" / ");
        Response.Write(hotel_room.R_type);
        Response.Write(" / ");
        Response.Write(hotel_room.Quantity);
         %>
    <br/>
    <label class="label">Number of Rooms</label>
    <asp:DropDownList ID="ddlNoOfRooms" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnReserve" runat="server" Text="Reserve" OnClick="btnReserve_Click" />
</asp:Content>
