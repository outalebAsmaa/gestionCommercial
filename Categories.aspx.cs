using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Categories : System.Web.UI.Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    // Select * From Categories
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
        // Afficher les données de la table Catégories
        if (!IsPostBack) 
        {
            // Le premier chargement de la page
            txtdatecreation.Text = DateTime.Now.ToShortDateString();
        }
        loaddata();
    }
    public void loaddata() 
    {
        Cmd.CommandText = "Select * From Categories order by ID DESC";
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
            Cmd.CommandText = "Update Categories set Nom = '" + ((TextBox)e.Item.FindControl("txt1")).Text + "', Datecreation = '" + ((TextBox)e.Item.FindControl("txt2")).Text + "' where ID = "+((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
        if (e.CommandName == "delete") 
        {
            // Supprimer la catégorie séléctionner 
            Cmd.CommandText = "Delete From Categories where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
    }
    protected void btnvalider_Click(object sender, EventArgs e)
    {
        // verifié si le nom de la catégorie est existant
        Cmd.CommandText = "Select Count(ID) From Categories where Nom = '" + txtnom.Text + "'";
        Con.Open();
        string calcule = "" + Cmd.ExecuteScalar();
        Con.Close();
        if (calcule == "0")
        {
            // Ajouter une nouvelle catégorie
            Cmd.CommandText = "Insert into Categories (Nom,DateCreation) values ('" + txtnom.Text + "','" + txtdatecreation.Text + "')";
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
        }
        else 
        {
            Response.Write("<script>alert('Attention Nom catégorie déjà existant, Merci de choisir un autre ! ');</script>");
        }
        loaddata();
    }
}