<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="HotelsDotCom.UserAccount" MasterPageFile="~/Site.Master" %>

<%--this is view reservations from jeff's file--%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="titleContent frm-1 fadeIn animated">
        <h2>Your Reservations</h2>
    </div>

    <div class="formGroup userGroup frm-1 fadeIn animated">

        <div id="valid">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validator" Font-Size="0.8em" ValidationGroup="required" />
        </div>
        <asp:RadioButtonList CssClass="radio" ID="rblist1" runat="server"></asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfvReservList" runat="server"
            ErrorMessage="Select a reservation" Display="None"
            ControlToValidate="rblist1" ValidationGroup="required"></asp:RequiredFieldValidator>
        <div class="btnGroup btnUserGroup">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button btn-1 fadeInDown animated" OnClick="btnDelete_Click" ValidationGroup="required" />
            <asp:Button ID="btnLogOut" runat="server" Text="Log out" CssClass="button btn-1 fadeInDown animated" OnClick="btnLogOut_Click" />
            <asp:Button ID="btnAddSP" runat="server" Text="Extra Requirements" CssClass="button btn-1 fadeInDown animated" OnClick="btnAddSP_Click" ValidationGroup="required"/>
        </div>
    </div>
</asp:Content>

