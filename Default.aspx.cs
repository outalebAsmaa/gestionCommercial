using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class _Default : Page
{
    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/dbex11.accdb"));
    OleDbCommand Cmd = new OleDbCommand();
    OleDbDataReader Dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        Cmd.Connection = Con;
        Cmd.CommandText = "Select *,(Select Nom From Categories where ID = Categorie) as CAT From Articles order by categorie ASC";
        Con.Open();
        Dr = Cmd.ExecuteReader();
        Repeater1.DataSource = Dr;
        Repeater1.DataBind();
        foreach (RepeaterItem item in Repeater1.Items) 
        {
            if ("" + Session["LOG"] != "O")
            {
                ((Panel)item.FindControl("pnlbuy")).Visible = false;
            }
        }
        Con.Close();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e) 
    {
        Cmd.CommandText = "Insert into Commandes (IDarticle,Datecommande,PrixTotal,Etat,idclient) values (" + ((Label)e.Item.FindControl("lbl1")).Text + ",'" + DateTime.Now.ToShortDateString() + "','" + Convert.ToInt32(((Label)e.Item.FindControl("TextBox1")).Text)*Convert.ToInt32(((TextBox)e.Item.FindControl("txtqt")).Text) + "','En Attente',"+Session["IDconnected"]+")";
        Con.Open();
        Cmd.ExecuteNonQuery();
        Con.Close();
    }
}