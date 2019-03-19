Imports System.Data.SqlClient

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim accesoBD As New ClassLibrary1.AccesodatosSQL
        accesoBD.Conectar()
        If (accesoBD.contar(TextBox1.Text, TextBox2.Text) = 1) Then
            If (accesoBD.estaConfirmado(TextBox1.Text, TextBox2.Text)) Then
                If (accesoBD.esAlumno(TextBox1.Text)) Then
                    Response.Redirect("http://hads18-villalobos.azurewebsites.net/Alumno.aspx?user=" & TextBox1.Text)
                Else
                    Response.Redirect("http://hads18-villalobos.azurewebsites.net/Profesor.aspx?user=" & TextBox1.Text)
                End If

            Else
                Label1.Text = "El usuario no ha sido verificado aún, por favor, consulte el mensaje de su email"
                    Label1.Visible = True
            End If
        Else
            Label1.Text = "Usuario/Password incorrecto/s"
            Label1.Visible = True
        End If
        accesoBD.cerrarconexion()
    End Sub
End Class