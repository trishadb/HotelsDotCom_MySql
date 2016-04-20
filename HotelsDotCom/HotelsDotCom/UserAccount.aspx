<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="HotelsDotCom.UserAccount" MasterPageFile="~/Site.Master" %>

<%--this is view reservations from jeff's file--%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
    <!--CSS HERE-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="titleContent frm-1 fadeIn animated">
        <h2>Your Reservations</h2>
    </div>
    <div class="user">
        <asp:LinkButton ID="linkBtnUser" runat="server" OnClick="linkBtnUser_Click" CssClass="button btnUser fadeInDown animated"></asp:LinkButton>
        <asp:Button ID="btnLogOut" runat="server" Text="Log out" CssClass="button btn-1 fadeInDown animated" OnClick="btnLogOut_Click" />
    </div>

    <div class="formGroup userGroup frm-1 fadeIn animated">
        <asp:Repeater ID="rptView" runat="server" OnItemCommand="rptView_ItemCommand" OnItemDataBound="rptView_ItemDataBound">
            <HeaderTemplate>
                <table class="tbl">
                    <thead>
                        <tr>
                            <th>Reservation ID</th>
                            <th>User ID</th>
                            <th>Hotel Name</th>
                            <th>Room Type</th>
                            <th>Starting Date</th>
                            <th>Ending Date</th>
                            <th>Quantity</th>
                            <th>Special Request</th>
                            <th>Price</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("r_id") %>   
                    </td>
                    <td>
                        <%#Eval("c_id") %> 
                    </td>
                    <td>
                        <%#Eval("h_name") %> 
                    </td>
                    <td>
                        <%#Eval("r_type") %>        
                    </td>
                    <td>
                        <%#Eval("starting") %>
                    </td>
                    <td>
                        <%#Eval("ending") %> 
                    </td>
                    <td>
                        <%#Eval("quantity") %> 
                    </td>
                    <td>
                        <%#Eval("spDescription") %> 
                    </td>
                    <td>
                        <%#Eval("spCost") %> 
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button btnSelect" CommandName="D" />
                        <asp:Button ID="btnAddSP" runat="server" Text="Extra Requirements" CssClass="button btnSelect" CommandName="A" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

