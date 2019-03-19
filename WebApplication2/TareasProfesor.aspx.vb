Public Class TareasProfesor
    Inherits System.Web.UI.Page
    Dim email = "vadillo@ehu.es"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
        Session.Abandon()
    End Sub
End Class