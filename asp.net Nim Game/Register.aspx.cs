using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DetailsView1_ModeChanged(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void DetailsView1_ModeChanged1(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}