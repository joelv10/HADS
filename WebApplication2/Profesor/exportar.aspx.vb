Imports System.Data.SqlClient
Imports System.Xml

Public Class exportar
    Inherits System.Web.UI.Page
    Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim email = Session("usuario")
        dapMbrs = New SqlDataAdapter("select * from TareasGenericas where CodAsig = '" & DropDownList1.Text & "' and Codigo not in (select CodTarea from EstudiantesTareas  where Email='" & email & "')", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")
        GridView1.DataSource = tblMbrs
        GridView1.DataBind()
        Session("datos") = dstMbrs
        Session("adaptador") = dapMbrs
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim email = Session("usuario")
        dapMbrs = New SqlDataAdapter("select * from TareasGenericas where CodAsig = '" & DropDownList1.Text & "' and Codigo not in (select CodTarea from EstudiantesTareas  where Email='" & email & "')", conClsf)
        Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")
        Dim xd As New XmlDocument
        Dim xt As XmlText
        Dim cabecera As String = "<?xml version='1.0' standalone='yes'?> <tareas xmlns:has='http://ji.ehu.es/has'></tareas>"
        xd.LoadXml(cabecera)
        For Each row As DataRow In tblMbrs.Rows
            Dim cod As String = CStr(row("Codigo"))
            Dim desc As String = CStr(row("Descripcion"))
            Dim codAsig As String = CStr(row("CodAsig"))
            Dim HE As String = CStr(row("HEstimadas"))
            Dim expo As String = CStr(row("Explotacion"))
            Dim tipo As String = CStr(row("TipoTarea"))
            Dim tareas As XmlElement
            tareas = xd.CreateElement("tarea")
            Dim atributo As XmlAttribute = xd.CreateAttribute("codigo")
            xt = xd.CreateTextNode(cod)
            atributo.AppendChild(xt)
            tareas.Attributes.Append(atributo)            xd.DocumentElement.AppendChild(tareas)            Dim descripcion As XmlElement            descripcion = xd.CreateElement("descripcion")
            xt = xd.CreateTextNode(desc)
            descripcion.AppendChild(xt)
            tareas.AppendChild(descripcion)            Dim hestimadas As XmlElement            hestimadas = xd.CreateElement("hestimadas")
            xt = xd.CreateTextNode(HE)
            hestimadas.AppendChild(xt)
            tareas.AppendChild(hestimadas)            Dim explotacion As XmlElement            explotacion = xd.CreateElement("explotacion")
            xt = xd.CreateTextNode(expo)
            explotacion.AppendChild(xt)
            tareas.AppendChild(explotacion)
            Dim tipotarea As XmlElement            tipotarea = xd.CreateElement("tipotarea")
            xt = xd.CreateTextNode(tipo)
            tipotarea.AppendChild(xt)
            tareas.AppendChild(tipotarea)
            xd.Save(Server.MapPath("App_Data/" & codAsig & ".xml"))
        Next

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("http://hads18-villalobos.azurewebsites.net/Inicio.aspx")
        Session.Abandon()
        System.Web.Security.FormsAuthentication.SignOut()
    End Sub
End Class