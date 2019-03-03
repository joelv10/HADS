<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CambiarContraseña.aspx.vb" Inherits="WebApplication1.CambiarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server" Text="E-mail*:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Width="192px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="E-mail incorrecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Solicitar código" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Código recibido*:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="192px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo Requerido" Visible="False"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nueva Contraseña*:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Visible="False" Width="192px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Campo Requerido" Visible="False"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Repetir Contraseña*:" Visible="False"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="192px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Campo Requerido" Visible="False"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="La contraseña no coincide"></asp:CompareValidator>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Cambiar Constraseña" Visible="False" />
&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx" Visible="False">Contraseña modificada correctamente, haga click aquí para acceder al Login</asp:HyperLink>
        </div>
    </form>
</body>
</html>
