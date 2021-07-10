using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class clients : System.Web.UI.Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    // Select * From Clients
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
        // Afficher les données de la table Catégories
       
        loaddata();
    }
    public void loaddata() 
    {
        Cmd.CommandText = "Select * From Clients order by ID DESC";
        Con.Open();
        Dr = Cmd.ExecuteReader();
        Repeater1.DataSource = Dr;
        Repeater1.DataBind();
        Con.Close();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit") 
        {
            // Modifier la catégorie séléctionner
            Cmd.CommandText = "Update Clients set Nom = '" + ((TextBox)e.Item.FindControl("txt1")).Text + "',Prenom = '" + ((TextBox)e.Item.FindControl("TextBox1")).Text + "',Dateinscription = '" + ((TextBox)e.Item.FindControl("txt2")).Text + "',Etat = '" + ((TextBox)e.Item.FindControl("TextBox2")).Text + "',Login = '" + ((TextBox)e.Item.FindControl("TextBox3")).Text + "',Motdepasse = '" + ((TextBox)e.Item.FindControl("TextBox4")).Text + "',Email = '" + ((TextBox)e.Item.FindControl("TextBox5")).Text + "',Ntele = '" + ((TextBox)e.Item.FindControl("TextBox6")).Text + "' where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
        if (e.CommandName == "delete") 
        {
            // Supprimer la catégorie séléctionner 
            Cmd.CommandText = "Delete From Clients where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
    }
    protected void btnvalider_Click(object sender, EventArgs e)
    {
        // verifié si le nom de la catégorie est existant
        Cmd.CommandText = "Select Count(ID) From Clients where Login = '" + txtnomutilisateur.Text + "'";
        Con.Open();
        string calcule = "" + Cmd.ExecuteScalar();
        Con.Close();
        if (calcule == "0")
        {
            // Ajouter une nouvelle catégorie
            Cmd.CommandText = "Insert into Clients (Nom,Prenom,Etat,Login,Motdepasse,Email,Ntele,dateinscription) values ('"+txtnom.Text+"','"+txtprenom.Text+"','Inactif','"+txtnomutilisateur.Text+"','"+txtmdp.Text+"','"+txtemail.Text+"','"+txttel.Text+"','"+DateTime.Now.ToShortDateString()+"')";
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
        }
        else 
        {
            Response.Write("<script>alert('Attention Nom utilisateur déjà existant, Merci de choisir un autre ! ');</script>");
        }
        loaddata();
    }
}