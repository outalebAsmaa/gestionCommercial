<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="articles.aspx.cs" Inherits="articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td style="vertical-align:top">
                <div class="container">
        <div class="card">
            <div class="card-header">
                <h2>Ajouter un article</h2>
            </div>
            <div class="card-body">
                 Nom : <asp:TextBox ID="txtnomproduit" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                Prix : <asp:TextBox ID="txtprix" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                Catégorie : <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
        <br />
                Photo : <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
                Quantité : <asp:TextBox ID="txtqt" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        Date de création : <asp:TextBox ID="txtdatecreation" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="btnvalider" runat="server" Text="Ajouter" style="border-color:green" CssClass="form-control" OnClick="btnvalider_Click" />
   
            </div>
        </div>
        </div>
            </td>
            <td style="width:10%"></td>
            <td  style="vertical-align:top">
                <div class="container" style="text-align:center">  
        <h2>Liste des Articles</h2>
        <table>
            <tr>
                <td>Photo</td>
                <td>ID</td>
                <td>Nom Produit</td>
                <td>Prix</td>
                <td>Catégorie</td>
                <td>Quantité</td>
                <td>Date de création</td>
                <td>Actions</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                <ItemTemplate>
<tr>
     <td>
         <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Photo")%>' Width="50px" />
    </td>
    <td>
                            <asp:Label ID="lbl1" runat="server" CssClass="form-control" Text='<%#Eval("ID")%>'></asp:Label>
    </td>
                <td>
                    <asp:TextBox ID="txt1" runat="server" CssClass="form-control" Text='<%#Eval("NomProduit")%>'></asp:TextBox></td>
             
                    <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text='<%#Eval("Prix")%>'></asp:TextBox></td>
           
                    <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text='<%#Eval("Categorie")%>'></asp:TextBox></td>
           
                     <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Text='<%#Eval("QT")%>'></asp:TextBox></td>
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

