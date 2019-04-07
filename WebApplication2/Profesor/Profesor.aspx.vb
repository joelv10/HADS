Public Class Profesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("usuario") = Request.QueryString("user")
        If (Session("usuario") = "vadillo@ehu.es") Then
            System.Web.Security.FormsAuthentication.SetAuthCookie("vadillo", False)
        End If

    End Sub

End Class