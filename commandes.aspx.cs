using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class commandes : System.Web.UI.Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    // Select * From Categories
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
        // Afficher les données de la table commandes
        
        loaddata();
    }
    public void loaddata() 
    {
        Cmd.CommandText = "Select *,(Select NomProduit from Articles where ID = IDarticle) as NomProduit From commandes order by ID DESC";
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
            // Modifier la Article séléctionner
            Cmd.CommandText = "Update commandes set PrixTotal = " + ((TextBox)e.Item.FindControl("TextBox1")).Text + ",Etat = '" + ((TextBox)e.Item.FindControl("TextBox2")).Text + "' where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
        if (e.CommandName == "delete") 
        {
            // Supprimer la Article séléctionner 
            Cmd.CommandText = "Delete From commandes where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
    }
   
}