<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Confirmar.aspx.vb" Inherits="WebApplication1.Confirmar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enhorabuena. Ya se ha registrado correctamente."></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Su registro no será verificado, entre mediante el email que le hemos mandado"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Click aquí para ir al Login</asp:HyperLink>
        </div>
    </form>
</body>
</html>
