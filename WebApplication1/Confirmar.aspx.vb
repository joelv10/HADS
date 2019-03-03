Public Class Confirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim accesoBD As New ClassLibrary1.AccesodatosSQL
        Dim numero = Request.QueryString("numero")
        Dim usuario = Request.QueryString("usuario")
        If (accesoBD.buscarUsuario(usuario, numero) <> "") Then
            Label2.Visible = False
            Label1.Visible = True
            HyperLink1.Visible = True
            accesoBD.Conectar()
            accesoBD.confirmar(usuario, numero)
            accesoBD.cerrarconexion()
        Else
            Label1.Visible = False
            HyperLink1.Visible = False
        End If

    End Sub

End Class