using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Game : System.Web.UI.Page
{
       
       public static class Globals
       {
           public static int bag1 =10;
           public static int bag2 = 10;
           public static int bag3 = 10;

       }
    protected void Page_Load(object sender, EventArgs e)
    {
        generate(Globals.bag1, Globals.bag2, Globals.bag3);
        if (!Page.IsPostBack)
        {
           Globals.bag1 = 10;
           Globals.bag2 = 10;
           Globals.bag3 = 10;
           TemplateField totalPlayed = new TemplateField();
           totalPlayed.HeaderText = "Total Played";
           

           

        }

        WinLbl.Visible = false;
        RestartBtn.Visible = false;
    }

    public void generate(int bg1,int bg2,int bg3){

        Globals.bag1 = bg1;
        Globals.bag2 = bg2;
        Globals.bag3 = bg3;

        Bag1Lbl.Text = "bag1: " + Globals.bag1.ToString() + " Tokens";
        Bag2Lbl.Text = "bag2: " + Globals.bag2.ToString() + " Tokens";
        Bag3Lbl.Text = "bag3: " + Globals.bag3.ToString() + " Tokens";


        for (int i = 1; i <= Globals.bag1; i++)
        {
            bag1List.Items.Add(i.ToString());
        }
        for (int i = 1; i <= Globals.bag2; i++)
        {
            bag2List.Items.Add(i.ToString());
        }
        for (int i = 1; i <= Globals.bag3; i++)
        {
            bag3List.Items.Add(i.ToString());
        }

    }
    
    public int randomBag()
    {
        Random random = new Random();
        int value = random.Next(1, 4);
        return value;
    }

    public void compTurn()
    {
        Random random = new Random();
        String win = "computer";

       int pileChoice;
        while(true){
           pileChoice = randomBag();
           if (pileChoice == 1 && Globals.bag1 ==0)
           {}else if (pileChoice == 2 && Globals.bag2 ==0)
           {}else if (pileChoice == 3 && Globals.bag3 ==0)
           { }
           else { break; }
        }



        if (pileChoice == 1)
        { 
        int number = random.Next(1, Globals.bag1);
        bag1List.Items.Clear();
        bag2List.Items.Clear();
        bag3List.Items.Clear();
        generate(Globals.bag1 - number, Globals.bag2, Globals.bag3);
        OutputLbl.Text = "Removed" + number + " from bag1";
        checkWinner(win);
    }
        if (pileChoice == 2)
        {
            int number = random.Next(1, Globals.bag2);
            bag1List.Items.Clear();
            bag2List.Items.Clear();
            bag3List.Items.Clear();
            generate(Globals.bag1, Globals.bag2 - number, Globals.bag3);
            OutputLbl.Text = "Removed" + number + " from bag2";
            checkWinner(win);

        }
        if (pileChoice == 3)
        {
            int number = random.Next(1, Globals.bag3);
            bag1List.Items.Clear();
            bag2List.Items.Clear();
            bag3List.Items.Clear();
            generate(Globals.bag1 , Globals.bag2, Globals.bag3- number);
            OutputLbl.Text = "Removed" + number + " from bag3";
            checkWinner(win);

        }
    }

    public bool checkWinner(String winner)
    {
        if (Globals.bag1 == 0 && Globals.bag2 == 0 && Globals.bag3 == 0)
        {
            bag1tkbtn.Visible = false;
            bag2tkbtn.Visible = false;
            bag3tkbtn.Visible = false;
            WinLbl.Visible = true;
            RestartBtn.Visible = true;
            if (winner.Equals("player"))
            {
                string constring = ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Won = Won +1 WHERE [Username] = @username");
                cmd.Connection = con;
                cmd.Parameters.Add("@Username", (string)Session["username"]);
                cmd.ExecuteScalar();


                SqlCommand cmd3 = new SqlCommand("UPDATE Users SET Total = Total +1 WHERE [Username] = @username");
                cmd3.Connection = con;
                cmd3.Parameters.Add("@Username", (string)Session["username"]);
                cmd3.ExecuteScalar();


                con.Close();

            }
            else if (winner.Equals("computer"))
            {
                string constring = ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                SqlCommand cmd2 = new SqlCommand("UPDATE Users SET Lost = Lost +1 WHERE [Username] = @username");
                cmd2.Connection = con;
                cmd2.Parameters.Add("@Username", (string)Session["username"]);
                cmd2.ExecuteScalar();
                SqlCommand cmd3 = new SqlCommand("UPDATE Users SET Total = Total +1 WHERE [Username] = @username");
                cmd3.Connection = con;
                cmd3.Parameters.Add("@Username", (string)Session["username"]);
                cmd3.ExecuteScalar();
                
                con.Close();

            }
            WinLbl.Text = winner + " is the winner";
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Bag2List_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String win = "player";

        int value = Convert.ToInt32(bag1List.SelectedItem.Value);
        value = Globals.bag1 - value;
        bag1List.Items.Clear();
        bag2List.Items.Clear();
        bag3List.Items.Clear();
        generate(value, Globals.bag2, Globals.bag3);
        if (checkWinner(win)==true)
        {
            return;
        }
        if (Globals.bag1 == 0) {
            bag1tkbtn.Visible = false;
        }
            compTurn();}
    
    protected void bag2tkbtn_Click(object sender, EventArgs e)
    {
        String win = "player";

        int value = Convert.ToInt32(bag2List.SelectedItem.Value);
        bag1List.Items.Clear();
        bag2List.Items.Clear();
        bag3List.Items.Clear();
        generate(Globals.bag1, Globals.bag2 - value, Globals.bag3);
        if (checkWinner(win) == true)
        {
            return;
        }
        if (Globals.bag2 == 0)
        {
            bag2tkbtn.Visible = false;
        }
        compTurn();
    }
    protected void bag3tkbtn_Click(object sender, EventArgs e)
    {
        String win = "player";

        int value = Convert.ToInt32(bag3List.SelectedItem.Value);
        bag1List.Items.Clear();
        bag2List.Items.Clear();
        bag3List.Items.Clear(); 
        generate(Globals.bag1, Globals.bag2, Globals.bag3 - value);
        if (checkWinner(win) == true)
        {
            return;
        }
        if (Globals.bag3 == 0)
        {
            bag3tkbtn.Visible = false;
        }
        compTurn();
    }
    protected void RestartBtn_Click(object sender, EventArgs e)
    {
        generate(10, 10, 10);
        Response.Redirect(Request.RawUrl);
    }
}