using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class login : System.Web.UI.Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (txtlogin.Text.ToUpper() == "A.OUTALEB" && txtmdp.Text == "admin1")
        {
            Session["LOG"] = "O";
            Session["IDconnected"] = "0";
            Response.Redirect("default.aspx");
        }
        else if(txtlogin.Text.ToUpper() == "A.TERBACHI" && txtmdp.Text == "admin2")
        {
            Session["LOG"] = "O";
            Session["IDconnected"] = "0";
            Response.Redirect("default.aspx");
        }
        else
        {
            Cmd.CommandText = "Select Motdepasse from Clients where login = '" + txtlogin.Text + "'";
            Con.Open();
            string mdp = "" + Cmd.ExecuteScalar();
            Con.Close();
            if (mdp == txtmdp.Text)
            {
                Session["LOG"] = "O";
                Cmd.CommandText = "Select ID from clients where login = '" + txtlogin.Text + "'";
                Con.Open();
                string idclient = "" + Cmd.ExecuteScalar();
                Con.Close();
                Session["IDconnected"] = "" + idclient;
                Response.Redirect("default.aspx");
            }

            else
            {
                txtlogin.BorderColor = System.Drawing.Color.Red;
                txtmdp.BorderColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void btnvalider_Click(object sender, EventArgs e)
    {
        // verifié si le nom d'utilisateur est existant
        Cmd.CommandText = "Select Count(ID) From Clients where Login = '" + txtnomutilisateur.Text + "'";
        Con.Open();
        string calcule = "" + Cmd.ExecuteScalar();
        Con.Close();
        if (calcule == "0")
        {
            // Ajouter un nouveau client
            Cmd.CommandText = "Insert into Clients (Nom,Prenom,Etat,Login,Motdepasse,Email,Ntele,dateinscription) values ('" + txtnom.Text + "','" + txtprenom.Text + "','Inactif','" + txtnomutilisateur.Text + "','" + txtmdp.Text + "','" + txtemail.Text + "','" + txttel.Text + "','" + DateTime.Now.ToShortDateString() + "')";
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            pnlinscription.Visible = false;
            imginscription.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('Attention Nom utilisateur déjà existant, Merci de choisir un autre ! ');</script>");
        }
       
    }

}