Public Class mainform

    Private Sub ManageUsersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ManageUsersToolStripMenuItem.Click

    End Sub

    Private Sub ManageUsersToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ManageUsersToolStripMenuItem1.Click
        formUsers.MdiParent = Me
        formUsers.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Are you sure you want to Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Application.ExitThread()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub
End Class