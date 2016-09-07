<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 760px">
    
        <asp:Label ID="Label1" runat="server" Text="Register"></asp:Label>
        <br />
        <asp:Button ID="rgstrBtn" runat="server" OnClick="rgstrBtn_Click" Text="Register" />
        <br />
        <asp:Label ID="LoginLabel" runat="server" Text="Login"></asp:Label>
        <br />
        <asp:TextBox ID="LoginBox" Maxlength="10" runat="server"></asp:TextBox>
        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
    
        <asp:Label ID="ErrorLbl" runat="server" Text="Username does not exist" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
