Imports System.Data.SqlClient

Public Class InsertarTarea
    Inherits System.Web.UI.Page
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tblMbrs = dstMbrs.Tables("tareas")
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
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
        Session.Abandon()
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/TareasProfesor.aspx")
    End Sub
End Class