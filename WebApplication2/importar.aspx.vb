Imports System.Data.SqlClient
Imports System.Xml

Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Xml1.DocumentSource = Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml")
        Xml1.TransformSource = Server.MapPath("App_Data/XSLTFile.xsl")

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim xd As New XmlDocument
        xd.Load(Server.MapPath("App_Data/" & DropDownList1.SelectedValue & ".xml"))
        Dim LasTareas As XmlNodeList
        LasTareas = xd.GetElementsByTagName("tarea")
        Dim i As Integer
        For i = 0 To LasTareas.Count - 1
            Dim desc As XmlNodeList = xd.GetElementsByTagName("descripcion")
            Dim HE As XmlNodeList = xd.GetElementsByTagName("hestimadas")
            Dim expo As XmlNodeList = xd.GetElementsByTagName("explotacion")
            Dim tipo As XmlNodeList = xd.GetElementsByTagName("tipotarea")
            dapMbrs = New SqlDataAdapter("select * from TareasGenericas", conClsf)
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "tareas")
            tblMbrs = dstMbrs.Tables("tareas")
            Session("datos") = dstMbrs
            Session("adaptador") = dapMbrs
            Dim rowMbrs As DataRow = tblMbrs.NewRow()
            rowMbrs("Codigo") = LasTareas(i).Attributes(0).InnerText
            rowMbrs("Descripcion") = desc(0).InnerText
            rowMbrs("CodAsig") = DropDownList1.SelectedValue
            rowMbrs("HEstimadas") = HE(0).InnerText
            rowMbrs("Explotacion") = expo(0).InnerText
            rowMbrs("TipoTarea") = tipo(0).InnerText
            tblMbrs.Rows.Add(rowMbrs)
            dapMbrs = Session("adaptador")
            dapMbrs.Update(dstMbrs, "tareas")
            dstMbrs.AcceptChanges()
        Next
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
End Class