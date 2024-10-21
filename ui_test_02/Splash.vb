Public Class Splash
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the maximum value for the progress bar
        ProgressBar1.Maximum = 100

        Dim splashTimer As New Timer()
        splashTimer.Interval = 10 ' Set a small interval for smooth progress simulation
        AddHandler splashTimer.Tick, AddressOf Timer1_Tick
        splashTimer.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        ' Increment the progress bar value by a small amount
        ProgressBar1.Value += 1

        ' Check if progress bar reached maximum value (100)
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            ' Close the splash screen
            Dim timer As Timer = DirectCast(sender, Timer)
            timer.Stop()
            Me.Close()
        End If

        ' Update the label text based on the progress bar value
        UpdateLabelText()
    End Sub

    Private Sub UpdateLabelText()
        ' Update the label text based on the progress bar value
        Select Case ProgressBar1.Value
            Case 0 To 5
                Label1.Text = "Initializing.."
            Case 0 To 10
                Label1.Text = "Initializing..."
            Case 0 To 15
                Label1.Text = "Initializing...."
            Case 0 To 20
                Label1.Text = "Initializing."
            Case 0 To 25
                Label1.Text = "Initializing.."
            Case 0 To 30
                Label1.Text = "Initializing..."
            Case 0 To 35
                Label1.Text = "Initializing...."
            Case 0 To 40
                Label1.Text = "Initializing."
            Case 0 To 45
                Label1.Text = "Initializing.."
            Case 0 To 50
                Label1.Text = "Initializing..."
            Case 0 To 60
                Label1.Text = "Initializing...."
            Case 0 To 70
                Label1.Text = "Initializing."
            Case 0 To 80
                Label1.Text = "Initializing.."
            Case 0 To 90
                Label1.Text = "Initializing..."
            Case Else
                Label1.Text = "Finishing.."
        End Select
    End Sub

End Class