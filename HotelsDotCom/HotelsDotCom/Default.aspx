<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelsDotCom._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <label class="label">Where are you going?</label>
    <asp:DropDownList ID="ddlCities" runat="server"></asp:DropDownList>
  
    <label></label>
    <label class="label">Check in</label>
        <asp:TextBox ID="txtArrivalDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvArrivalDate" runat="server"
                ControlToValidate="txtArrivalDate" 
                Text="*" CssClass="validator" 
                Display="Dynamic"> </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvArrivalDate" runat="server" 
                Text="Must be a valid date"
                CssClass="validator" 
                Display="Dynamic" 
                ControlToValidate="txtArrivalDate"
                Type="Date"
                Operator="DataTypeCheck"> </asp:CompareValidator><br />

    <label class="label">Check out</label>
        <asp:TextBox ID="txtDepartureDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDepartureDate" runat="server"
                ControlToValidate="txtDepartureDate" 
                Text="*" CssClass="validator"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvDepartureDate" runat="server" 
                Display="Dynamic"
                Text="Must be after arrival date" 
                CssClass="validator"
                ControlToValidate="txtDepartureDate" 
                Type="Date" Operator="GreaterThan"
                ControlToCompare="txtArrivalDate"> </asp:CompareValidator><br />
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
</asp:Content>
