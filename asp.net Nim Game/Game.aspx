<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 640px">
    
        <asp:Label ID="Bag1Lbl" runat="server" Text="Bag1"></asp:Label>
    
        <asp:DropDownList ID="bag1List" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="bag1tkbtn" runat="server" OnClick="Button1_Click" Text="Take Tokens" />
    
        <br />
        <asp:Label ID="Bag2Lbl" runat="server" Text="Bag2"></asp:Label>
        <asp:DropDownList ID="bag2List" runat="server">
        </asp:DropDownList>
        <asp:Button ID="bag2tkbtn" runat="server" Text="Take Tokens" OnClick="bag2tkbtn_Click" />
        <br />
        <asp:Label ID="Bag3Lbl" runat="server" Text="Bag3"></asp:Label>
    
        <asp:DropDownList ID="bag3List" runat="server">
        </asp:DropDownList>
        <asp:Button ID="bag3tkbtn" runat="server" Text="Take Tokens" OnClick="bag3tkbtn_Click" />
    
        <br />
        <asp:Label ID="OutputLbl" runat="server" Text="Output"></asp:Label>
        <br />
        <br />
        <asp:Label ID="WinLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="RestartBtn" runat="server" OnClick="RestartBtn_Click" Text="Restart" />
        <br />
        <br />
        <asp:Label ID="UserLbl" runat="server" Text="user"></asp:Label>
        <br />
        <asp:Label ID="WonLbl" runat="server" Text="won"></asp:Label>
        <br />
        <asp:Label ID="LostLbl" runat="server" Text="lost"></asp:Label>
        <br />
        <asp:Label ID="DrawnLbl" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="UserGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="Won" HeaderText="Won" SortExpression="Won" />
                <asp:BoundField DataField="Lost" HeaderText="Lost" SortExpression="Lost" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UsersConnectionString %>" SelectCommand="SELECT * FROM [Users] WHERE ([Username] = @Username)">
            <SelectParameters>
                <asp:SessionParameter Name="Username" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
