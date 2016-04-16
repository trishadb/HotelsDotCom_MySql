<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelsDotCom._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">

    <div class="formGroup">
        <label class="label lbl-1 fadeInLeft animated">Where are you going?</label>
        <asp:DropDownList CssClass="ddl txtDdl-1 fadeInUp animated" ID="ddlCities" runat="server"></asp:DropDownList>
        <br />

        <label class="label lbl-2 fadeInLeft animated">Check in</label>
        <asp:TextBox CssClass="txtGroup txtDdl-2 fadeInUp animated" ID="txtArrivalDate" runat="server" TextMode="Date" EnableViewState="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvArrivalDate" runat="server"
            ControlToValidate="txtArrivalDate"
            Text="*" CssClass="validator"
            Display="Dynamic" ErrorMessage="Enter check in date" Font-Bold="False"> </asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvArrivalDate" runat="server"
            Text="*"
            CssClass="validator"
            Display="Dynamic"
            ControlToValidate="txtArrivalDate"
            Type="Date"
            Operator="DataTypeCheck" ErrorMessage="Must be a valid date"> </asp:CompareValidator>

        <br />

        <label class="label lbl-3 fadeInLeft animated">Check out</label>
        <asp:TextBox CssClass="txtGroup txtDdl-3 fadeInUp animated" ID="txtDepartureDate" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDepartureDate" runat="server"
            ControlToValidate="txtDepartureDate"
            Text="*" CssClass="validator"
            Display="Dynamic" ErrorMessage="Enter check out date"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvDepartureDate" runat="server"
            Display="Dynamic"
            Text="*"
            CssClass="validator"
            ControlToValidate="txtDepartureDate"
            Type="Date" Operator="GreaterThan"
            ControlToCompare="txtArrivalDate" ErrorMessage="Must be after arrival date"> </asp:CompareValidator>

        <div class="btnGroup btn-1 fadeInDown animated">
            <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
    </div>
</asp:Content>
