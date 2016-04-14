<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="HotelsDotCom.UserAccount" MasterPageFile="~/Site.Master"%>

<%--this is view reservations from jeff's file--%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <h2>Your Reservations</h2>

    <asp:RadioButtonList ID="rblist1" runat="server">
    </asp:RadioButtonList>
    <asp:Button ID="btnDelete" runat="server" Text="Delete"
        CssClass="button" OnClick="btnDelete_Click" />&nbsp;

     <asp:Button ID="btnLogOut" runat="server" Text="Log out"
         CssClass="button" OnClick="btnLogOut_Click"/>&nbsp;
</asp:Content>

