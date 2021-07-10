<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td style="vertical-align:top">
                <div class="container">
        <div class="card">
            <div class="card-header">
                <h2>Ajouter une catégorie</h2>
            </div>
            <div class="card-body">
                 Nom : <asp:TextBox ID="txtnom" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        Date de création : <asp:TextBox ID="txtdatecreation" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="btnvalider" runat="server" Text="Ajouter" style="border-color:green" CssClass="form-control" OnClick="btnvalider_Click" />
   
            </div>
        </div>
        </div>
            </td>
            <td style="width:20%"></td>
            <td  style="vertical-align:top">
                <div class="container" style="text-align:center">  
        <h2>Liste des catégories</h2>
        <table>
            <tr>
                <td>ID</td>
                <td>Nom Catégorie</td>
                <td>Date Création</td>
                <td>Actions</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                <ItemTemplate>
<tr>
    <td>
                            <asp:Label ID="lbl1" runat="server" CssClass="form-control" Text='<%#Eval("ID")%>'></asp:Label>
    </td>
                <td>
                    <asp:TextBox ID="txt1" runat="server" CssClass="form-control" Text='<%#Eval("Nom")%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txt2" runat="server" CssClass="form-control" Text='<%#Eval("Datecreation")%>'></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button1" runat="server"  CssClass="form-control" Text="Modifier" CommandName="edit" style="border-color:blue" />
                    <asp:Button ID="Button2" runat="server"  CssClass="form-control" Text="Supprimer" CommandName="delete" style="border-color:red" />
                </td>
            </tr>
                </ItemTemplate>
            </asp:Repeater>
            
        </table>
    </div>
            </td>
        </tr>
    </table>
    

    
</asp:Content>

