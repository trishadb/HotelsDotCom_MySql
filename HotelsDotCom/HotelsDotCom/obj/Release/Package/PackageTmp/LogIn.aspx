<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HotelsDotCom.LogIn" MasterPageFile="~/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">

    <div id="body">

        <hgroup class="title">
            <h2>Log in</h2>
        </hgroup>
        <section id="loginForm">
            <h2>Use a local account to log in.</h2>

            <p class="validation-summary-errors">
            </p>
            <fieldset>
                <legend>Log in Form</legend>
                <ol>
                    <li>
                        <label for="txtName">User name</label>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                    </li>
                    <li>
                        <label for="txtPassword">Password</label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </li>

                </ol>
                <asp:Button ID="btnLogIn" runat="server" Text="Login"
                    CssClass="button" OnClick="btnLogIn_Click"/>&nbsp;
            </fieldset>
        </section>
    </div>
</asp:Content>
