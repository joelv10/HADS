Imports System.Data.SqlClient

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dstMbrs = Session("datos")
            tblMbrs.Clear()
        Else
            Dim email = Session("usuario")
            dapMbrs = New SqlDataAdapter("select codigoasig from GruposClase inner join EstudiantesGrupo on codigo = Grupo where Email = '" & email & "'", conClsf)
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "asignaturas")
            tblMbrs = dstMbrs.Tables("asignaturas")
            DropDownList1.DataSource = tblMbrs
            DropDownList1.DataTextField = "codigoasig"
            DropDownList1.DataBind()
            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim email = Session("usuario")
        dapMbrs = New SqlDataAdapter("select Codigo, Descripcion, HEstimadas, TipoTarea from TareasGenericas where Explotacion = '1' and CodAsig = '" & DropDownList1.Text & "' and Codigo not in (select CodTarea from EstudiantesTareas  where Email='" & email & "')", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")
        GridView1.DataSource = tblMbrs
        GridView1.DataBind()
        Session("datos") = dstMbrs
        Session("adaptador") = dapMbrs
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

        Response.Redirect("InstanciarTareas.aspx?Tarea= " & GridView1.SelectedValue & "&HEstimadas=" & GridView1.SelectedRow.Cells(3).Text)
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session.Abandon()
        Application("numAlumnos") = Application("numAlumnos") - 1
        Dim listaAlumnos As ListBox
        listaAlumnos = Application("alumnos")
        listaAlumnos.Items.Remove(Session("usuario"))
        Application("alumnos") = listaAlumnos
        System.Web.Security.FormsAuthentication.SignOut()        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
    End Sub
End Class