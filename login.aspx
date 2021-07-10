<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container" style="text-align:left">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <h3>Connectez-vous à votre compte</h3>
                    <hr />
                    <asp:TextBox ID="txtlogin" runat="server" CssClass="form-control" placeholder="Nom d'utilisateur"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtmdp" runat="server" CssClass="form-control" placeholder="Mot de passe" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnlogin" runat="server" Text="Se connecter" CssClass="btn btn-success" OnClick="btnlogin_Click" />
                </div>
            </div>
            <center><asp:Image ID="imginscription" runat="server" ImageUrl="~/images/tenor.gif" Visible="false"></asp:Image>
            </center>
                <div class="col-md-6" runat="server" id="pnlinscription">
                <div class="card">
            <div class="card-header">
                <h2>Créer un nouveau compte</h2>
            </div>
                    <hr />
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">Nom : <asp:TextBox ID="txtnom" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-md-6">Prénom : <asp:TextBox ID="txtprenom" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-md-6">Nom d'utilisateur : <asp:TextBox ID="txtnomutilisateur" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-md-6">Mot de passe : <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></div>
                    <div class="col-md-6">Email : <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col-md-6">N° Téléphone : <asp:TextBox ID="txttel" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>

                <hr />
        <asp:Button ID="btnvalider" runat="server" Text="+ Créer mon nouveau compte client" CssClass="btn btn-info" OnClick="btnvalider_Click" />
   
            </div>
        </div>
            </div>
        </div>
    </div>
</asp:Content>

