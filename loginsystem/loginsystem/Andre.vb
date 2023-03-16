Public Class Andre

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btncancel.Click
        txtaccount.Clear()
        txtpassword.Clear()
        txtaccount.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If PB1.Value < 100 Then
            PB1.Value = PB1.Value + 1
        Else
            Me.Dispose()
            mainform.Show()
        End If
    End Sub

    Private Sub txtaccount_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtaccount.KeyUp
        If e.KeyCode = Keys.Escape Then
            Button1_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            btnlogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtaccount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtaccount.TextChanged

    End Sub

    Private Sub txtpassword_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyUp
        If e.KeyCode = Keys.Escape Then
            Button1_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            btnlogin_Click(sender, e)
        End If
    End Sub

    Private Sub Tres_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Connection()
    End Sub

    Private Sub btnlogin_Click(sender As System.Object, e As System.EventArgs) Handles btnlogin.Click
        If Trim(txtaccount.Text) = "" Then
            MsgBox("Type Username.", MsgBoxStyle.Information)
        ElseIf Trim(txtpassword.Text) = "" Then
            MsgBox("Type password.", MsgBoxStyle.Information)
        Else
            OpenRecord("Select * from system_user Where account = '" _
                       & txtaccount.Text & "' And password = '" _
                       & txtpassword.Text & "'")

            If rs.RecordCount = 1 Then
                Timer1.Enabled = True
            Else
                MsgBox("Invalid Account! Please try again.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub PB1_Click(sender As System.Object, e As System.EventArgs) Handles PB1.Click

    End Sub
End Class
