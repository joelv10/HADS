Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("usuario") = Request.QueryString("user")
        If (Session("usuario") = "vadillo@ehu.es") Then
            System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo", False)
        End If

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Application("numProfesores")
        Label6.Text = Application("numAlumnos")
        Dim listaAlumnos As ListBox
        listaAlumnos = Application("alumnos")
        Dim listaProfesores As ListBox
        listaProfesores = Application("profesores")
        ListBox1.Items.Clear()
        For Each a In listaProfesores.Items
            ListBox1.Items.Add(a)
        Next
        ListBox1.DataBind()
        listaAlumnos = Application("alumnos")
        ListBox2.Items.Clear()
        For Each a In listaAlumnos.Items
            ListBox2.Items.Add(a)
        Next
        ListBox2.DataBind()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session.Abandon()
        Application("numProfesores") = Application("numProfesores") - 1
        Dim listaProfesores As ListBox
        listaProfesores = Application("profesores")
        listaProfesores.Items.Remove(Session("usuario"))
        Application("profesores") = listaProfesores
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/coordinador.aspx")
    End Sub
End Class