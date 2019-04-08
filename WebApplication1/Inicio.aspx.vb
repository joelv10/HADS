Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Function encriptarcontra(ByVal contra As String) As String
        Dim pass As New System.Security.Cryptography.SHA256CryptoServiceProvider
        Dim pass2 As Byte() = pass.ComputeHash(Encoding.UTF8.GetBytes(contra))
        Dim sBuilder As New StringBuilder()
        Dim cont As Integer
        For cont = 0 To pass2.Length - 1
            sBuilder.Append(pass2(cont).ToString("x2"))
        Next cont
        Return sBuilder.ToString
    End Function
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim accesoBD As New ClassLibrary1.AccesodatosSQL
        accesoBD.Conectar()

        If (accesoBD.contar(TextBox1.Text, encriptarcontra(TextBox2.Text)) = 1) Then
            If (accesoBD.estaConfirmado(TextBox1.Text, encriptarcontra(TextBox2.Text))) Then
                If (accesoBD.esAlumno(TextBox1.Text)) Then
                    System.Web.Security.FormsAuthentication.SetAuthCookie("alumno", False)
                    Application("numAlumnos") = Application("numAlumnos") + 1
                    Dim listaAlumnos = Application("alumnos")
                    listaAlumnos.Items.Add(TextBox1.Text)
                    Application("alumnos") = listaAlumnos
                    Response.Redirect("http://hads18-villalobos.azurewebsites.net/Alumno.aspx?user=" & TextBox1.Text)
                Else
                    System.Web.Security.FormsAuthentication.SetAuthCookie("profesor", False)
                    Application("numProfesores") = Application("numProfesores") + 1
                    Dim listaProfesores = Application("profesores")
                    listaProfesores.Items.Add(TextBox1.Text)
                    Application("profesores") = listaProfesores
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