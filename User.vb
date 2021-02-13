Public Class User
    Dim strsql As String
    Dim info As String
    Private _iduser As System.Int32
    Private _username As System.String
    Private _passwd As System.String
    Private _rolename As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property username()
        Get
            Return _username
        End Get
        Set(ByVal value)
            _username = value
        End Set
    End Property
    Public Property passwd()
        Get
            Return _passwd
        End Get
        Set(ByVal value)
            _passwd = value
        End Set
    End Property
    Public Property rolename()
        Get
            Return _rolename
        End Get
        Set(ByVal value)
            _rolename = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (users_baru = True) Then
            strsql = "Insert into users(username,passwd,rolename) values ('" & _username & "','" & _passwd & "','" & _rolename & "')"
            info = "INSERT"
        Else
            strsql = "update users set username='" & _username & "', passwd='" & _passwd & "', rolename='" & _rolename & "' where username='" & _username & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Cariusers(ByVal susername As String)
        DBConnect()
        strsql = "SELECT * FROM users WHERE username='" & susername & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            users_baru = False
            DR.Read()
            username = Convert.ToString((DR("username")))
            passwd = Convert.ToString((DR("passwd")))
            rolename = Convert.ToString((DR("rolename")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            users_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal susername As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM users WHERE username='" & susername & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM users"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub

    Public Function Login(ByVal uname As String, ByVal pwd As String) As Boolean
        Dim pwd_en As String
        pwd_en = getMD5Hash(pwd)
        DBConnect()
        strsql = "SELECT * FROM users WHERE username='" & uname & "' and passwd ='" & pwd_en & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            login_valid = True
            DR.Read()
            username = Convert.ToString((DR("username")))
            passwd = Convert.ToString((DR("passwd")))
            rolename = Convert.ToString((DR("rolename")))

        Else
            login_valid = False
        End If
        DBDisconnect()
        Return login_valid
    End Function
End Class
