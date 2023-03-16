Public Class formUsers
    Dim isEdit As Boolean = False
    Public Sub getAllUsers(ByVal str As String)
        lvAccounts.Items.Clear()

        OpenRecord("Select * from system_user Where fullname like '" & str & "%'")
        With rs
            While Not .EOF
                lvi = lvAccounts.Items.Add(.Fields("id").Value)
                lvi.SubItems.Add(.Fields("fullname").Value)
                lvi.SubItems.Add(.Fields("account").Value)
                lvi.SubItems.Add(.Fields("password").Value)
                .MoveNext()
            End While
        End With
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub formUsers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Connection()
        getAllUsers("")
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        txtFullname.Clear()
        txtAccount.Clear()
        txtPassword.Clear()
        txtFullname.Focus()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtFullname.Text = "" Then
            MsgBox("Fullname required.", MsgBoxStyle.Information)
            txtFullname.Focus()
        ElseIf txtAccount.Text = "" Then
            MsgBox("Account required.", MsgBoxStyle.Information)
            txtAccount.Focus()
        ElseIf txtPassword.Text = "" Then
            MsgBox("Password required.", MsgBoxStyle.Information)
            txtPassword.Focus()
        Else
            If isEdit = False Then
                OpenRecord("Insert into system_user values(null, '" & txtFullname.Text & " '," _
                           & "'" & txtAccount.Text & "','" & txtPassword.Text & "')")
                MsgBox("New Account Added!", MsgBoxStyle.Information)
            Else
                OpenRecord("Update system_user set fullname =" _
                           & "'" & txtFullname.Text & "', account='" & txtAccount.Text & "'" _
                           & ", password='" & txtAccount.Text & "' Where id = '" & lvAccounts.SelectedItems.Item(0).SubItems(0).Text & "'")
                MsgBox("Account update successfully!", MsgBoxStyle.Information)
                isEdit = False
            End If
            getAllUsers("")
            btnCancel_Click(sender, e)
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged
        lvAccounts.Items.Clear()

        OpenRecord("Select * from system_user Where Fullname like '%" & txtSearch.Text & "%'")
        With rs
            While Not .EOF
                lvi = lvAccounts.Items.Add(.Fields("Id").Value)
                lvi.SubItems.Add(.Fields("Fullname").Value)
                lvi.SubItems.Add(.Fields("Account").Value)
                lvi.SubItems.Add(.Fields("Password").Value)
                .MoveNext()
            End While
        End With
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click

        txtFullname.Text = lvAccounts.SelectedItems.Item(0).SubItems(1).Text
        txtAccount.Text = lvAccounts.SelectedItems.Item(0).SubItems(2).Text
        txtPassword.Text = lvAccounts.SelectedItems.Item(0).SubItems(3).Text
        isEdit = True
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If lvAccounts.Items.Count = 0 Then Exit Sub
        If lvAccounts.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("This action will delete the selected account. " _
                  & "Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            OpenRecord("Delete from system_user where id ='" _
                       & lvAccounts.SelectedItems.Item(0).SubItems(0).Text & "'")
            MsgBox("Account has been deleted.", MsgBoxStyle.Information)
        End If
        getAllUsers("")
        btnCancel_Click(sender, e)
    End Sub

    Private Sub lvAccounts_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvAccounts.SelectedIndexChanged

    End Sub
End Class