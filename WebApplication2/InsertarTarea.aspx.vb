Imports System.Data.SqlClient

Public Class InsertarTarea
    Inherits System.Web.UI.Page
    Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim email = Session("usuario")
        dapMbrs = New SqlDataAdapter("select * from TareasGenericas", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")
        Session("datos") = dstMbrs
        Session("adaptador") = dapMbrs
        Dim rowMbrs As DataRow = tblMbrs.NewRow()
        rowMbrs("Codigo") = TextBox1.Text
        rowMbrs("Descripcion") = TextBox2.Text
        rowMbrs("CodAsig") = DropDownList1.Text
        rowMbrs("HEstimadas") = TextBox3.Text
        rowMbrs("Explotacion") = True
        rowMbrs("TipoTarea") = DropDownList2.Text
        tblMbrs.Rows.Add(rowMbrs)
        dapMbrs = Session("adaptador")
        dapMbrs.Update(dstMbrs, "tareas")
        dstMbrs.AcceptChanges()
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Session.Abandon()
        Application("numProfesores") = Application("numProfesores") - 1
        Dim listaProfesores As ListBox
        listaProfesores = Application("profesores")
        listaProfesores.Items.Remove(Session("usuario"))
        Application("profesores") = listaProfesores
        System.Web.Security.FormsAuthentication.SignOut()        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/TareasProfesor.aspx")
    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub
End Class