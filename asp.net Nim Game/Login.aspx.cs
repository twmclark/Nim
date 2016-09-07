using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void rgstrBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");

       

    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        


        string constring = ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username =@username");
        cmd.Connection = con;
        cmd.Parameters.Add("@Username", LoginBox.Text);
        int userCount = (int)cmd.ExecuteScalar();
        con.Close();

        if (userCount > 0)
        {
            Session["Username"] = LoginBox.Text;
             Response.Redirect("Game.aspx");
        }
        else
        {
            ErrorLbl.Visible = true; 
        }
    }
}