<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="commandes.aspx.cs" Inherits="commandes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container" style="text-align:center">  
        <h2>Liste des Commandes</h2>
        <br /><br />
        <table>
            <tr>
               
                <td>ID</td>
                <td>Nom Produit</td>
                <td>Prix Total</td>
                <td>Etat</td>
                <td>Date de commande</td>
                <td>Actions</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                <ItemTemplate>
<tr>
     
    <td>
                            <asp:Label ID="lbl1" runat="server" CssClass="form-control" Text='<%#Eval("ID")%>'></asp:Label>
    </td>
                <td>
                    <asp:TextBox ID="txt1" runat="server" CssClass="form-control" Text='<%#Eval("NomProduit")%>' Enabled="false"></asp:TextBox></td>
             
                    <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text='<%#Eval("Prixtotal")%>'></asp:TextBox></td>
           
                    <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text='<%#Eval("Etat")%>'></asp:TextBox></td>
           <td>
                    <asp:TextBox ID="txt2" runat="server" CssClass="form-control" Text='<%#Eval("datecommande")%>' Enabled="false"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button1" runat="server"  CssClass="form-control" Text="Modifier" CommandName="edit" style="border-color:blue" />
                    <asp:Button ID="Button2" runat="server"  CssClass="form-control" Text="Supprimer" CommandName="delete" style="border-color:red" />
                </td>
            </tr>
                </ItemTemplate>
            </asp:Repeater>
            
        </table>
    </div>
    

    
</asp:Content>

