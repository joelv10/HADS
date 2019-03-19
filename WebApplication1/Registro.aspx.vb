Imports AccesoDatos.accesodatosSQL
Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
            If (accesoBD.buscarUsuario(email) = False) Then
                Label7.Text = "Por favor, verifique su registro mediante el email que le acabamos de mandar, gracias "
                Label7.Visible = True
                accesoBD.insertar(email, nombre, apellido, numRandom, False, tipo, pass)
                enviar.enviarEmail(email, "Registro", "Para continuar su registro haga click aquí http://hads18-villalobos.azurewebsites.net/Confirmar.aspx?numero=" & numRandom & "&usuario=" & email, numRandom)
                accesoBD.cerrarconexion()
            Else
                Label7.Text = "Este email ya ha sido registrado previamente"
                Label7.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class