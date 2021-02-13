Imports System.Data.SqlClient
Imports System.Security.Cryptography
Module MyMod
    Public mycommand As New System.Data.SqlClient.SqlCommand
    Public myadapter As New System.Data.SqlClient.SqlDataAdapter

    Public mydata As New DataTable

    Public DR As System.Data.SqlClient.SqlDataReader

    Public SQL As String

    Public conn As New SqlConnection

    Public cn As New Connection

    Public users_baru As Boolean
    Public oUsers As New User

    Public login_valid As Boolean
    Public Sub DBConnect()
        cn.DataSource = "DESKTOP-QJ51NG5\SQLEXPRESS"
        cn.DatabaseName = "uas2021"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub
    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
End Module
