Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("usuario") = Request.QueryString("user")

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session.Abandon()
        Application("numAlumnos") = Application("numAlumnos") - 1
        Dim listaAlumnos As ListBox
        listaAlumnos = Application("alumnos")
        listaAlumnos.Items.Remove(Session("usuario"))
        Application("alumnos") = listaAlumnos
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
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
End Class