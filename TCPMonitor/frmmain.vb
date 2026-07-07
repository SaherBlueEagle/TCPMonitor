Option Explicit On

Public Class frmmain

    Private Structure TcpInfo
        Dim LocalAddr As String
        Dim LocalPort As Integer
        Dim RemoteAddr As String
        Dim RemotePort As Integer
        Dim State As String
        Dim PID As Integer
        Dim Data As String
    End Structure

    Private TCPConnections() As TcpInfo
    Private SelectedPID As Long = 0

    Private Sub RefreshAll()
        'Capture dos output of netstat
        Dim Buff As String = CaptureDos("netstat", "-no")

        If String.IsNullOrEmpty(Buff) Then
            SetError("Cannot receive data.")
        Else
            'Clear list view.
            LstItems.Items.Clear()
            'Process buffer string.
            ProcessData(Buff)
            'Show connectiuons.
            ShowTCPConnections()
        End If
    End Sub

    Private Sub ProcessData(ByVal Source As String)


        Dim Lines() As String = Source.Split(vbLf)
        Dim Parts() As String
        Dim Count As Integer = 0
        Dim ConnCount As Integer = 0
        Dim Splitter As Char() = {" "c}

        For Count = 0 To Lines.Count - 1
            'Trim down line.
            Dim sLine As String = Lines(Count).Trim()

            If Not String.IsNullOrEmpty(sLine) Then
                If (Count > 3) Then
                    'Get TCP Connections.
                    If sLine.StartsWith("TCP") Then
                        'INC Counter
                        ReDim Preserve TCPConnections(ConnCount)
                        'Split line into 4 parts.
                        Parts = sLine.Split(Splitter, StringSplitOptions.RemoveEmptyEntries)

                        'Store TCP information.
                        With TCPConnections(ConnCount)
                            On Error Resume Next
                            'Local address and port
                            .LocalAddr = Parts(1).Split(":")(0)
                            .LocalPort = CInt(Parts(1).Split(":")(1))
                            'Remote address and port
                            .RemoteAddr = Parts(2).Split(":")(0)
                            .RemotePort = CInt(Parts(2).Split(":")(1))
                            .State = Parts(3)
                            .PID = CInt(Parts(4))
                            .Data = CInt(Parts(5))
                        End With

                        'INC connection counter
                        ConnCount += 1
                    End If
                End If
            End If
        Next Count

        'Clear up
        Erase Lines
        Erase Parts
    End Sub

    Private Sub ShowTCPConnections()
        Dim lvItem As ListViewItem = Nothing
        Dim iFont As New Font("Verdana", LstItems.Font.Size, FontStyle.Regular)
        Dim Temp As String = vbNullString
        Dim bOn As Boolean = False

        For Each Info As TcpInfo In TCPConnections
            'Used for cell back color.
            bOn = Not (bOn)

            'Create new list view item.
            lvItem = New ListViewItem()

            'Change list item back color.
            If bOn Then
                lvItem.BackColor = Color.FromArgb(231, 245, 250)
            Else
                lvItem.BackColor = Color.White
            End If

            'Set item font.
            lvItem.Font = iFont
            'Set listview image.
            lvItem.ImageKey = "app.png"

            'Get process appliaction path
            ' Temp = GetProcessName(Info.PID)
            Temp = GetPName(Info.PID)
            If Not String.IsNullOrEmpty(Temp) Then
                lvItem.Tag = Temp 'Set tag with filename.
                lvItem.Text = gFilename(Temp)
                lvItem.SubItems.Add(Info.LocalAddr) 'Local IP
                lvItem.SubItems.Add(Info.LocalPort) 'Local Port
                lvItem.SubItems.Add(Info.RemoteAddr) 'Remote IP
                lvItem.SubItems.Add(Info.RemotePort) 'Remote port
                lvItem.SubItems.Add(Info.State) 'State
                lvItem.SubItems.Add(Info.PID) 'PID

                'Add to item listview.
                LstItems.Items.Add(lvItem)
            End If
        Next Info

    End Sub

    Private Sub LstItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstItems.SelectedIndexChanged
        For Each lvItem As ListViewItem In LstItems.SelectedItems
            'Get process PID
            SelectedPID = CLng(lvItem.SubItems(6).Text)
        Next lvItem
    End Sub

    Private Sub cmdKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKill.Click

        If SelectedPID.Equals(0) Then
            SetError("Please select a process to close.")
        Else
            If MessageBox.Show("Are you sure you want to close this process",
                               "Kill Process", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes Then
                'Check if process was closed.
                If Not CloseProess(SelectedPID) Then
                    'Opps something went wrong.
                    SetError("Error closing process.")
                Else
                    'Reset process ID and refresh connections.
                    SelectedPID = 0
                    RefreshAll()
                End If
            End If
        End If
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'Refresh all connections.
        RefreshAll()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        'Close program.
        Close()
    End Sub

    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RefreshAll()
       

    End Sub
End Class


Module Tools

    Public Function GetProcessName(ByVal PID As Long) As String
        Try
            Return Process.GetProcessById(PID).MainModule.FileName
        Catch ex As Exception
            Return "Error Fetch process name"
        End Try
    End Function
    Public Function GetPName(ByVal PID) As String
        Try
            Return Process.GetProcessById(PID).ProcessName

        Catch ex As Exception
            Return "hidden process"
        End Try
    End Function
    Public Function CloseProess(ByVal PID As Long) As Boolean
        Dim Ret As Boolean = False
        'Try and close the process.

        Try
            Process.GetProcessById(PID).Kill()
            Ret = True
        Catch ex As Exception
            Ret = False
        End Try

        Return Ret
    End Function

    Public Function GetFilename(ByVal Source As String) As String
        Dim sPos As Integer = -1

        'Return filename.
        Try
            sPos = Source.LastIndexOf("\")

            If sPos <> -1 Then
                Return Source.Substring(sPos + 1)
            End If

            Return Source
        Catch ex As Exception
            Return Source
        End Try
    End Function
    Public Function gFilename(ByVal pn) As String
        Try
            For Each prog As Process In Process.GetProcesses
                If prog.ProcessName.Contains(pn) Then
                    Return prog.ProcessName
                End If
            Next
        Catch ex As Exception
            Return "Filename error"
        End Try
    End Function
    Public Sub SetError(ByVal message As String, Optional ByVal Title As String = "Errror")
        MessageBox.Show(message, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Function CaptureDos(ByVal Filename As String, Optional ByVal Parms As String = vbNullString) As String
        Dim Exec As New System.Diagnostics.Process()
        Dim Buffer As String = vbNullString

        Try
            With Exec
                .StartInfo.RedirectStandardOutput = True
                .StartInfo.UseShellExecute = False
                .StartInfo.CreateNoWindow = True
                .StartInfo.FileName = Filename
                .StartInfo.Arguments = Parms
                .Start()
                'Read in output.
                Buffer = .StandardOutput.ReadToEnd()
                'Wait for exit.
                Exec.WaitForExit()
                'Return string.
                Return Buffer
            End With

        Catch ex As Exception
            Return vbNullString
        End Try
    End Function

End Module

