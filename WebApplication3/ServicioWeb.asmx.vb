Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ServicioWeb
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function getMaterias() As DataSet
        Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim dapMbrs As New SqlDataAdapter()
        dapMbrs = New SqlDataAdapter("select codigo from Asignaturas", conClsf)
        Dim ds As New DataSet
        dapMbrs.Fill(ds, "asignaturas")
        Return ds
    End Function
    <WebMethod()>
    Public Function getDedicaciones(ByVal asignatura As String) As DataSet
        Dim conClsf As New SqlConnection(“Server=tcp:hads18-villalobos.database.windows.net,1433;Initial Catalog=HADS18-villalobos;Persist Security Info=False;User ID=villalobos;Password=G4py5BAi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim dapMbrs As New SqlDataAdapter()
        dapMbrs = New SqlDataAdapter("select avg(HReales) from TareasGenericas inner join EstudiantesTareas on TareasGenericas.Codigo = EstudiantesTareas.CodTarea where TareasGenericas.CodAsig = '" & asignatura & "'", conClsf)
        Dim ds As New DataSet
        dapMbrs.Fill(ds, "hreales")
        Return ds

    End Function

End Class