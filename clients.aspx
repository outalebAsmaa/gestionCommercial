<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="clients.aspx.cs" Inherits="clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td style="vertical-align:top">
                <div class="container">
        <div class="card">
            <div class="card-header">
                <h2>Ajouter un client</h2>
            </div>
            <div class="card-body">
                 Nom : <asp:TextBox ID="txtnom" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                 Prénom : <asp:TextBox ID="txtprenom" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                 Nom d'utilisateur : <asp:TextBox ID="txtnomutilisateur" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                 Mot de passe : <asp:TextBox ID="txtmdp" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        <br />
                Email : <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
                N° Téléphone : <asp:TextBox ID="txttel" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="btnvalider" runat="server" Text="Ajouter" style="border-color:green" CssClass="form-control" OnClick="btnvalider_Click" />
   
            </div>
        </div>
        </div>
            </td>
            <td style="width:5%"></td>
            <td  style="vertical-align:top">
                <div class="container" style="text-align:center">  
        <h2>Liste des Clients</h2>
        <table>
            <tr>
                <td>ID</td>
                <td>Nom</td>
                <td>Prénom</td>
                <td>Date Inscription</td>
                 <td>Etat</td>
                <td>Login</td>
                <td>MDP</td>
                <td>Email</td>
                <td>Tel</td>
                <td>Actions</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" EnableViewState="false">
                <ItemTemplate>
<tr>
    <td>
                            <asp:Label ID="lbl1" runat="server" CssClass="form-control" Text='<%#Eval("ID")%>'></asp:Label>
    </td>
                <td>
                    <asp:TextBox ID="txt1" runat="server" CssClass="form-control" Text='<%#Eval("Nom")%>'></asp:TextBox>
      
                </td>
     <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text='<%#Eval("Prenom")%>'></asp:TextBox>
      
                </td>
                <td>
                    <asp:TextBox ID="txt2" runat="server" CssClass="form-control" Text='<%#Eval("Dateinscription")%>'></asp:TextBox></td>
                     <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text='<%#Eval("Etat")%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Text='<%#Eval("Login")%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Text='<%#Eval("Motdepasse")%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Text='<%#Eval("Email")%>'></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Text='<%#Eval("Ntele")%>'></asp:TextBox></td>
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

