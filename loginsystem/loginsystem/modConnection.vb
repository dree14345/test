Imports ADODB
Module modConnection
    Public conn As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public lvi As ListViewItem

    Public Sub Connection()
        On Error GoTo Err
        If conn.State = ObjectStateEnum.adStateOpen Then conn.Close()
        conn.ConnectionString = "Driver=MYSQL ODBC 5.1 Driver;Server=Localhost;" & " Port = 3306;Database=login_db;UID=root; PWD=;Option=3;"
        conn.ConnectionTimeout = 5
        conn.CursorLocation = CursorLocationEnum.adUseClient
        conn.Open()
        Exit Sub
Err:
        MsgBox(Err.Description, MsgBoxStyle.Information + MsgBoxStyle.Critical)
    End Sub
    Public Sub OpenRecord(ByVal sql As String)
        On Error GoTo Err
        If rs.State = ObjectStateEnum.adStateOpen Then rs.Close()
        rs.Open(sql, conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockBatchOptimistic)
        Exit Sub
Err:
        MsgBox(Err.Description, MsgBoxStyle.Information)
    End Sub
End Module
