Imports System.Net.Mail
Public Class CambiarContraseña
    Inherits System.Web.UI.Page
    Dim enviar As New ClassLibrary2.EnviarEmails
    Dim numRandom = enviar.crearRandom
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim accesoBD As New ClassLibrary1.AccesodatosSQL
        Dim email = TextBox4.Text
        accesoBD.Conectar()
        enviar.enviarEmail(email, "Cambio contraseña", "Su código de verificación es el siguiente: " & numRandom, numRandom)
        accesoBD.insertarCodigo(email, numRandom)
        Label1.Visible = True
        TextBox1.Visible = True
        Label2.Visible = True
        TextBox2.Visible = True
        Label3.Visible = True
        TextBox3.Visible = True
        Button2.Visible = True
        accesoBD.cerrarconexion()
        RequiredFieldValidator1.Enabled = False
        RegularExpressionValidator1.Enabled = False
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim accesoBD As New ClassLibrary1.AccesodatosSQL
        Dim email = TextBox4.Text
        Dim contra = TextBox2.Text
        If (TextBox1.Text = numRandom) Then
            accesoBD.cambiarContrasena(email, contra)
            HyperLink1.Visible = True
        End If
    End Sub
End Class