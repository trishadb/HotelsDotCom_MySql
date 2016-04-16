<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="HotelsDotCom.UserAccount" MasterPageFile="~/Site.Master" %>

<%--this is view reservations from jeff's file--%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="formGroup userGroup frm-1 fadeIn animated">
        <h2>Your Reservations</h2>

        <asp:RadioButtonList CssClass="radio" ID="rblist1" runat="server"></asp:RadioButtonList>

        <div class="btnGroup btnUserGroup">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button btn-1 fadeInDown animated" OnClick="btnDelete_Click" />
            <asp:Button ID="btnLogOut" runat="server" Text="Log out" CssClass="button btn-1 fadeInDown animated" OnClick="btnLogOut_Click" />
        </div>
    </div>
</asp:Content>

