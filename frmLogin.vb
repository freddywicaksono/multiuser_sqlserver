Public Class FRMlOGIN

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        oUsers.Login(txtUsername.Text, txtPassword.Text)
        If (login_valid = True) Then
            If (oUsers.rolename = "admin") Then
                Form1.Show()
                Me.Hide()
            ElseIf (oUsers.rolename = "dosen") Then
                Form2.Show()
                Me.Hide()
            ElseIf (oUsers.rolename = "mahasiswa") Then
                Form3.Show()
                Me.Hide()
            Else
                MessageBox.Show("User tidak dikenal")
            End If
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub
End Class