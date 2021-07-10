<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
       <asp:Image ID="img1" runat="server" ImageUrl="~/images/1.PNG" style="width:100%" />
    </div>

    <div class="row">
        <div class="col-md-12">
            <h2>SHOP</h2>
            <div class="row">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                <ItemTemplate>
<div class="col-md-3" style="text-align:center">
            <div class="card" style="box-shadow:gray 2px 2px;border-color:lightgray">
                <div class="card-header">
                    <asp:Label ID="lbl1" runat="server"  Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
                    <h5><asp:Label ID="txt1" runat="server" Text='<%#Eval("NomProduit")%>'></asp:Label></h5>
                </div>
                <hr />
                <div class="card-body">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Photo")%>' Height="100px" />
                    <br />
                    <asp:Label ID="TextBox1" runat="server" Text='<%#Eval("Prix")%>'></asp:Label>,00 MAD - <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("CAT")%>'></asp:Label>
                </div>
                <hr />
                <div class="card-footer">
                    <asp:Panel ID="pnlbuy" runat="server">
                    <table style="width:100%" runat="server" id="tablebuy">
                        <tr>
                            <td>Quantité : </td>
                            <td><asp:TextBox ID="txtqt" runat="server" CssClass="form-control" Width="70px" TextMode="Number" Text='<%#Eval("QT")%>' style="zoom:0.8"></asp:TextBox></td>
                            <td><asp:ImageButton ID="img1" runat="server" ImageUrl="~/images/AddCart.jpg" style="height:35px" CommandName="cart" /></td>
                        </tr>
                    </table>
                    </asp:Panel>
                    
                </div>
            </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
             
        
        </div>
       
    </div>
</asp:Content>
