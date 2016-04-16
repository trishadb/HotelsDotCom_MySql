<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HotelsDotCom.LogIn" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">

    <div class="formGroup">
        <label class="label lbl-1 fadeInLeft animated">User name</label>
        <asp:TextBox CssClass="txtGroup txtDdl-2 fadeInUp animated" ID="txtName" runat="server"></asp:TextBox>
        <br />

        <label class="label lbl-2 fadeInLeft animated">Password</label>
        <asp:TextBox CssClass="txtGroup txtDdl-1 fadeInUp animated" ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        <br />

        <div class="btnGroup">
            <asp:Button CssClass="button btn-1 fadeInDown animated" ID="btnLogIn" runat="server" Text="Login"  OnClick="btnLogIn_Click" />
        </div>
    </div>
</asp:Content>
