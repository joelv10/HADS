Imports AccesoDatos.accesodatosSQL
Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label7.Visible = True
        Try
            Dim enviar As New ClassLibrary2.EnviarEmails
            Dim numRandom = enviar.crearRandom
            Dim email = TextBox1.Text
            Dim nombre = TextBox2.Text
            Dim apellido = TextBox5.Text
            Dim pass = TextBox3.Text
            Dim tipo = DropDownList1.Text
            Dim accesoBD As New ClassLibrary1.AccesodatosSQL
            accesoBD.Conectar()
            accesoBD.insertar(email, nombre, apellido, numRandom, False, tipo, pass)
            enviar.enviarEmail(email, "Registro", "Para continuar su registro haga click aquí http://localhost:50984/Confirmar.aspx?numero=" & numRandom & "&usuario=" & email, numRandom)
            accesoBD.cerrarconexion()
        Catch ex As Exception

        End Try
    End Sub
End Class