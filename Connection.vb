Public Class Connection
    Private _datasource As String
    Private _database As String
    Private _datareader As System.Data.SqlClient.SqlDataReader


    Public Property DataReader() As Object
        Get
            Return _datareader
        End Get
        Set(ByVal value As Object)
            _datareader = value
        End Set
    End Property


    Public Property DataSource() As String
        Get
            Return _datasource
        End Get
        Set(ByVal value As String)
            _datasource = value
        End Set
    End Property



    Public Property DatabaseName() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property


    Public Sub Connect()
        Try
            conn.Close()
            conn.ConnectionString = "Data Source=" & _datasource & ";Initial Catalog=" & _database & ";Integrated Security=True"

            conn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub


    Public Sub Disconnect()
        If (conn.State = True) Then
            conn.Close()
            conn.Dispose()
        End If
    End Sub
End Class
