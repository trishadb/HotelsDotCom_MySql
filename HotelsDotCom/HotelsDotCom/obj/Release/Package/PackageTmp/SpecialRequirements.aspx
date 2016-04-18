<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialRequirements.aspx.cs"
    Inherits="HotelsDotCom.SpecialRequirements" MasterPageFile="~/Site.Master" %>

<%@ Import Namespace="HotelsDotCom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="titleContent frm-1 fadeIn animated">
        <h2>Add Special Requirements</h2>
    </div>
    <div class="formGroup frm-1 fadeIn animated">
        <%
    /*
            HotelRoomQuantity hotel_room = (HotelRoomQuantity)HttpContext.Current.Session["hotel_room"];
            Response.Write(hotel_room.H_name);
            Response.Write(" / ");
            Response.Write(hotel_room.R_type);
            Response.Write(" / ");
            Response.Write(hotel_room.Quantity);
             */
        %>
        <div class="reserve">
            <label class="label">Special Requirements</label>
            <asp:CheckBoxList CssClass="ddl" ID="cblSpecialRequirements" runat="server">
                <asp:ListItem>Shuttle</asp:ListItem>
                <asp:ListItem>Flower</asp:ListItem>
                <asp:ListItem>Room Service</asp:ListItem>
                <asp:ListItem>Massage</asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div class="btnGroup">
            <asp:Button CssClass="button btn-1 fadeInDown animated" ID="btnReserve" runat="server"
                Text="Add" OnClick="btnReserve_Click" />
        </div>
    </div>
</asp:Content>
