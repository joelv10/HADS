Imports AccesoDatos.accesodatosSQL, System.Security.Cryptography
Public Class Registro
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

        Try
            Dim encriptar As SHA256
            Dim enviar As New ClassLibrary2.EnviarEmails
            Dim numRandom = enviar.crearRandom
            Dim email = TextBox1.Text
            Dim nombre = TextBox2.Text
            Dim apellido = TextBox5.Text
            Dim pass = TextBox3.Text
            Dim tipo = DropDownList1.Text
            Dim accesoBD As New ClassLibrary1.AccesodatosSQL
            Dim vip As New esVip.Matriculas
            accesoBD.Conectar()
            If (vip.comprobar(email) = "SI") Then
                If (accesoBD.buscarUsuario(email) = False) Then
                    Label7.Text = "Por favor, verifique su registro mediante el email que le acabamos de mandar, gracias "
                    Label7.Visible = True
                    accesoBD.insertar(email, nombre, apellido, numRandom, False, tipo, encriptarcontra(pass))
                    enviar.enviarEmail(email, "Registro", "Para continuar su registro haga click aquí http://hads18-villalobos.azurewebsites.net/Confirmar.aspx?numero=" & numRandom & "&usuario=" & email, numRandom)
                    accesoBD.cerrarconexion()
                Else
                    Label7.Text = "Este email ya ha sido registrado previamente"
                    Label7.Visible = True
                End If
            Else
                Label7.Text = "Usted no es vip, no se puede registrar"
                Label7.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class