<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="coordinador.aspx.vb" Inherits="WebApplication2.coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Cerrar Sesion" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Seleccione una asignatura:"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True">
                <asp:ListItem>ADSI</asp:ListItem>
                <asp:ListItem>EDA1</asp:ListItem>
                <asp:ListItem>HAS</asp:ListItem>
                <asp:ListItem>ISO</asp:ListItem>
                <asp:ListItem>SEG</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="La media de horas dedicadas a dicha asignatura es:"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
