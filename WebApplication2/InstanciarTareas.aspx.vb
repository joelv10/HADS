Imports System.Data.SqlClient
Public Class InstanciarTareas
    Inherits System.Web.UI.Page
    Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim email = Session("usuario")
        TextBox1.Text = email
        TextBox2.Text = Request.QueryString("Tarea")
        TextBox3.Text = Request.QueryString("HEstimadas")
        dapMbrs = New SqlDataAdapter("select Email, CodTarea, HEstimadas, HReales from EstudiantesTareas where Email='" & email & "'", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")
        GridView1.DataSource = tblMbrs
        GridView1.DataBind()
        Session("datos") = dstMbrs
        Session("adaptador") = dapMbrs
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tblMbrs = dstMbrs.Tables("tareas")
        Dim rowMbrs As DataRow = tblMbrs.NewRow()
        rowMbrs("Email") = TextBox1.Text
        rowMbrs("CodTarea") = TextBox2.Text
        rowMbrs("HEstimadas") = TextBox3.Text
        rowMbrs("HReales") = TextBox4.Text
        tblMbrs.Rows.Add(rowMbrs)
        Label7.Text = "Añadida cuenta en la tabla: " + TextBox1.Text
        Label7.Visible = True
        GridView1.DataSource = tblMbrs
        GridView1.DataBind()
        dapMbrs = Session("adaptador")
        dapMbrs.Update(dstMbrs, "tareas")
        dstMbrs.AcceptChanges()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
        Session.Abandon()
    End Sub
End Class