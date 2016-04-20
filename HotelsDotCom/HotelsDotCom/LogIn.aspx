<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HotelsDotCom.LogIn" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server">
        <ItemTemplate>

        </ItemTemplate>
    </asp:FormView>

    <div class="checkAvailContent">
        <div class="formGroup">
            <label class="label lbl-1 fadeInLeft animated">User name</label>
            <asp:TextBox CssClass="txtGroup txtDdl-2 fadeInUp animated" ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                ErrorMessage="Please enter username" Display="Dynamic" Text="*"
                ForeColor="#CC0000" Font-Size="1em" Font-Bold="True" ControlToValidate="txtName">
            </asp:RequiredFieldValidator>
            <br />

            <label class="label lbl-2 fadeInLeft animated">Password</label>
            <asp:TextBox CssClass="txtGroup txtDdl-1 fadeInUp animated" ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                ErrorMessage="Please enter password" Font-Bold="True" Text="*" Display="Dynamic" ForeColor="#CC0000" Font-Size="1em" ControlToValidate="txtPassword">
            </asp:RequiredFieldValidator>
            <br />
            <div class="btnGroup">
                <asp:Button CssClass="button btn-1 fadeInDown animated" ID="btnLogIn" runat="server" Text="Login" OnClick="btnLogIn_Click" />
            </div>

            <div id="valid">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validator" Font-Size="0.8em" />
            </div>
        </div>
    </div>
</asp:Content>
