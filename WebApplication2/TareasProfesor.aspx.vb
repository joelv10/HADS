Public Class TareasProfesor
    Inherits System.Web.UI.Page
    Dim email = "vadillo@ehu.es"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Session.Abandon()
        Application("numProfesores") = Application("numProfesores") - 1
        Dim listaProfesores As ListBox
        listaProfesores = Application("profesores")
        listaProfesores.Items.Remove(Session("usuario"))
        Application("profesores") = listaProfesores
        System.Web.Security.FormsAuthentication.SignOut()        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/InsertarTarea.aspx")
    End Sub
End Class