using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class articles : System.Web.UI.Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    // Select * From Categories
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
        // Afficher les données de la table Articles
        if (!IsPostBack) 
        {
            // Le premier chargement de la page
            txtdatecreation.Text = DateTime.Now.ToShortDateString();
            DropDownList1.Items.Clear();
            int i =0;
            Cmd.CommandText = "Select Nom From Categories order by ID DESC";
            Con.Open();
            Dr = Cmd.ExecuteReader();
            while (Dr.Read()) 
            {
                // Remplir la liste des catégorie
                DropDownList1.Items.Insert(i, "" + Dr["Nom"].ToString());
                i++;
            }
            Con.Close();

        }
        loaddata();
    }
    public void loaddata() 
    {
        Cmd.CommandText = "Select * From Articles order by ID DESC";
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
            Cmd.CommandText = "Update Articles set NomProduit = '" + ((TextBox)e.Item.FindControl("txt1")).Text + "', Datecreation = '" + ((TextBox)e.Item.FindControl("txt2")).Text + "', Prix = '" + ((TextBox)e.Item.FindControl("TextBox1")).Text + "', Categorie = '" + ((TextBox)e.Item.FindControl("TextBox2")).Text + "', QT = '" + ((TextBox)e.Item.FindControl("TextBox3")).Text + "' where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
        if (e.CommandName == "delete") 
        {
            // Supprimer la Article séléctionner 
            Cmd.CommandText = "Delete From Articles where ID = " + ((Label)e.Item.FindControl("lbl1")).Text;
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            loaddata();
        }
    }
    protected void btnvalider_Click(object sender, EventArgs e)
    {
        // Ajouter une nouvelle Article
        int cat = 0;
        Cmd.CommandText = "Select ID From Categories where Nom = '" + DropDownList1.SelectedValue + "'";
        Con.Open();
        cat = Convert.ToInt32(Cmd.ExecuteScalar());
        Con.Close();
        FileUpload1.SaveAs(HttpContext.Current.ApplicationInstance.Server.MapPath("~/images/" + FileUpload1.FileName));
        Cmd.CommandText = "Insert into Articles (NomProduit,Prix,Categorie,QT,Datecreation,Photo) values ('"+txtnomproduit.Text+"','"+txtprix.Text+"',"+cat+",'"+txtqt.Text+"','"+txtdatecreation.Text+"','~/images/" + FileUpload1.FileName+"')";
        Con.Open();
        Cmd.ExecuteNonQuery();
        Con.Close();
        txtnomproduit.Text = "";
        txtprix.Text = "";
        txtqt.Text = "";
  
        loaddata();
    }
}