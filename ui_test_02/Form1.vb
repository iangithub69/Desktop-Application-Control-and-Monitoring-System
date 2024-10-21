''DACMSversion1

Imports System.IO
Imports System.IO.Ports
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D

Public Class Form1
    Dim recievedData As String = ""
    Dim value1 As Integer

    Private splashScreen As Splash
    Private isButtonPressed As Boolean = False
    Private debounceTimer As System.Threading.Timer

    Dim isAuthenticated As Boolean = False

    'Private Sub RestrictInvalidCharacters(textBox As TextBox, invalidChars As String)
    '    AddHandler textBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
    '                                     If invalidChars.Contains(e.KeyChar) Then
    '                                         e.Handled = True
    '                                     End If
    '                                 End Sub
    'End Sub

    Private Sub LoadAccount() 'this is where the refresh button is declared
        connecttodb() 'Connect to database

        sql = "SELECT * FROM fertigation_table" 'Selecting all information on the table
        'sql = "SELECT * FROM userccounts" 'online database
        cmd = New MySqlCommand(sql, cn)
        dr = cmd.ExecuteReader

        ListView1.Items.Clear()


        While dr.Read


            'This will show to listview
            'values must be identical to database table
            ' Convert "load1_status" to "On" or "Off"

            ' Add converted "load1_status", "load2_status", "load3_status", "load4_status" to ListView
            newLine = ListView1.Items.Add(dr("session_id"))
            newLine.SubItems.Add(dr("connection_name"))
            newLine.SubItems.Add(dr("device_name"))
            newLine.SubItems.Add(dr("os_info"))
            newLine.SubItems.Add(dr("rtc_time"))
            newLine.SubItems.Add(dr("login_time"))
            newLine.SubItems.Add(dr("fdevice_name"))
            newLine.SubItems.Add(dr("version"))

        End While
        'i dont know what this is
        cmd = Nothing
        dr.Close()
        cn.Close()
        ' Assuming ListView1 is your ListView control
        Dim i As Integer = 0

        For Each item As ListViewItem In ListView1.Items
            If i Mod 2 = 0 Then
                item.BackColor = Drawing.Color.LightBlue
                item.UseItemStyleForSubItems = True
            End If
            i += 1
        Next

    End Sub

    Private Sub SplashClosed(sender As Object, e As EventArgs)
        ' Splash screen closed, show Form1
        Dim form1 As New Form1()
        form1.Show()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Define the gradient colors
        Dim startColor As Color = Color.FromArgb(RGB(116, 185, 255)) ' Same as the form's current background color
        Dim endColor As Color = Color.FromArgb(100, 160, 230) ' Change this to your desired end color

        ' Create a linear gradient brush
        Dim gradientBrush As New LinearGradientBrush(Me.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical)

        ' Fill the form's background with the gradient brush
        e.Graphics.FillRectangle(gradientBrush, Me.ClientRectangle)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MonthCalendar1.Visible = False

        splashScreen = New Splash()
        splashScreen.ShowDialog()

        ' Handle the FormClosed event of the splash screen
        AddHandler splashScreen.FormClosed, AddressOf SplashClosed

        'to fetch computer info on current device
        Timer1.Enabled = True
        DeviceNameInfo.Text = My.Computer.Name ' Set the computer name when the form loads
        OSinfo.Text = My.Computer.Info.OSFullName
        '

        ' Populate the ComboBox with timer options
        ComboBox3.Items.Add("On")
        ComboBox3.Items.Add("Off")

        ComboBox2.Items.Add("Sun")
        ComboBox2.Items.Add("Mon")
        ComboBox2.Items.Add("Tue")
        ComboBox2.Items.Add("Wed")
        ComboBox2.Items.Add("Thu")
        ComboBox2.Items.Add("Fri")
        ComboBox2.Items.Add("Sat")

        ''loading available com ports
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
        Next

        LoadAccount()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'to fetch date and time on current device
        ' Use "MMMM" in the format string to display the full month name
        DateInfo.Text = Date.Now.ToString("dd MMMM yyyy")
        TimeInfo.Text = Date.Now.ToString("hh:mm:ss")

    End Sub



    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If SerialPort1.IsOpen Then
    '        MessageBox.Show("Serial port is already open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If

    '    If ComboBox1.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ComboBox1.SelectedItem.ToString()) Then
    '        SerialPort1.PortName = ComboBox1.Text
    '        SerialPort1.Open()


    '        Timer1.Enabled = True
    '        Timer2.Enabled = True

    '    Else
    '        MessageBox.Show("Please select a valid port from the combobox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SerialPort1.IsOpen Then
            MessageBox.Show("Serial port is already open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If ComboBox1.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ComboBox1.SelectedItem.ToString()) Then
            SerialPort1.PortName = ComboBox1.Text

            ' Request PIN code from the user
            Dim pinCode As String = InputBox("Enter PIN Code:")

            ' Hardcoded PIN code (for demonstration)
            Dim hardcodedPIN As String = "12345"

            If pinCode = hardcodedPIN Then
                ' If the entered PIN code matches the hardcoded PIN code
                SerialPort1.Open()
                Timer1.Enabled = True
                Timer2.Enabled = True

                Button1.BackColor = Color.GreenYellow
                DCButton.BackColor = Color.Silver
                Button9.BackColor = Color.Silver
                Button10.BackColor = Color.Silver
                Button7.BackColor = Color.Silver
                Button11.BackColor = Color.Silver
                LoadAccount()

            Else
                MessageBox.Show("Invalid PIN code. Connection denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please select a valid port from the combobox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub




    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        GaugeControl1.SetPointerValue("Scale1", "Pointer1", Val(TextBox20.Text))
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If SerialPort1.IsOpen Then
            Dim receivedData As String = SerialPort1.ReadExisting()

            ' Split the received data into water level and RTC data
            Dim dataParts As String() = receivedData.Split(","c)
            If dataParts.Length >= 29 Then
                TextBox20.Text = dataParts(0) ' Water level data
                TempTextBox.Text = dataParts(1) 'temp
                TextBoxDay.Text = dataParts(2)  'day
                TextBoxDate.Text = dataParts(3) 'date
                TextBoxRTC.Text = dataParts(4) ' RTC data
                TextBox7.Text = dataParts(5)    'Timer1 hour
                TextBox6.Text = dataParts(6)    'Timer1 minute
                TextBox5.Text = dataParts(7)    'Timer1 hour off
                TextBox4.Text = dataParts(8)    'timer1 minute off
                TextBox14.Text = dataParts(9)   'timer2 hour
                TextBox13.Text = dataParts(10)  'timer2 minute
                TextBox12.Text = dataParts(11)  'timer2 hour off
                TextBox11.Text = dataParts(12)   'timer2 minute off
                TextBox38.Text = dataParts(13)  'timer3 hour
                TextBox37.Text = dataParts(14)  'timer3 minute
                TextBox36.Text = dataParts(15)  'timer3 hour off
                TextBox35.Text = dataParts(16)  'timer3 minute off
                TextBox33.Text = dataParts(17)  'timer4 hour
                TextBox32.Text = dataParts(18)  'timer4 minute
                TextBox31.Text = dataParts(19)  'timer4 hour off
                TextBox30.Text = dataParts(20)  'timer4 minute off



                If dataParts(21) = "1" Then
                    txtLoad1StatusShow.Text = "On"
                ElseIf dataParts(21) = "0" Then     'load1 status
                    txtLoad1StatusShow.Text = "Off"
                End If
                If dataParts(22) = "1" Then
                    TextBox15.Text = "On"
                ElseIf dataParts(22) = "0" Then     'load2 status
                    TextBox15.Text = "Off"
                End If

                If dataParts(23) = "1" Then
                    TextBox39.Text = "On"
                ElseIf dataParts(23) = "0" Then     'load3 status
                    TextBox39.Text = "Off"
                End If

                If dataParts(24) = "1" Then
                    TextBox34.Text = "On"
                ElseIf dataParts(24) = "0" Then     'load4 status
                    TextBox34.Text = "Off"
                End If

                TextBox21.Text = dataParts(25)      'rain sensor
                TextBox40.Text = dataParts(26)      'day counter
                Label75.Text = dataParts(27)        'device name
                Label77.Text = dataParts(28)        'version
            End If

        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If

        If SerialPort2.IsOpen Then
            SerialPort2.Close()
        End If
    End Sub

    Private Sub TempTextBox_TextChanged(sender As Object, e As EventArgs) Handles TempTextBox.TextChanged
        GaugeControl3.SetPointerValue("Scale1", "Pointer1", Val(TempTextBox.Text))
    End Sub

    Private Sub DCButton_Click(sender As Object, e As EventArgs) Handles DCButton.Click

        connecttodb()
        'Insert data into the database
        sql = "Insert into fertigation_table (connection_name, device_name, os_info, rtc_time, rtc_date, water_level, temp_level, load1_status, load1_hourOn, load1_minuteOn, load1_hourOff, load1_minuteOff, load2_status, load2_hourOn, load2_minuteOn, load2_hourOff, load2_minuteOff, load3_status, load3_hourOn, load3_minuteOn, load3_hourOff, load3_minuteOff, load4_status, load4_hourOn, load4_minuteOn, load4_hourOff, load4_minuteOff, rain_sensor, day_counter, fdevice_name, version) values (@connection_name, @device_name, @os_info, @rtc_time, @rtc_date, @water_level, @temp_level, @load1_status, @load1_hourOn, @load1_minuteOn, @load1_hourOff, @load1_minuteOff, @load2_status, @load2_hourOn, @load2_minuteOn, @load2_hourOff, @load2_minuteOff, @load3_status, @load3_hourOn, @load3_minuteOn, @load3_hourOff, @load3_minuteOff, @load4_status, @load4_hourOn, @load4_minuteOn, @load4_hourOff, @load4_minuteOff, @rain_sensor, @day_counter, @fdevice_name, @version)"
        cmd = New MySqlCommand(sql, cn)

        With cmd
            ' Set parameters for the database insertion
            '.Parameters.AddWithValue("@session_id", CStr(Int(Rnd() * 100)))
            .Parameters.AddWithValue("@connection_name", ComboBox1.Text)
            .Parameters.AddWithValue("@device_name", DeviceNameInfo.Text)
            .Parameters.AddWithValue("@os_info", OSinfo.Text)

            .Parameters.AddWithValue("@rtc_time", TextBoxRTC.Text)
            .Parameters.AddWithValue("@rtc_date", TextBoxDate.Text)

            .Parameters.AddWithValue("@water_level", TextBox20.Text)
            .Parameters.AddWithValue("@temp_level", TempTextBox.Text)

            .Parameters.AddWithValue("@load1_status", txtLoad1StatusShow.Text)
            .Parameters.AddWithValue("@load1_hourOn", TextBox7.Text)
            .Parameters.AddWithValue("@load1_minuteOn", TextBox6.Text)
            .Parameters.AddWithValue("@load1_hourOff", TextBox5.Text)
            .Parameters.AddWithValue("@load1_minuteOff", TextBox4.Text)

            .Parameters.AddWithValue("@load2_status", TextBox15.Text)
            .Parameters.AddWithValue("@load2_hourOn", TextBox14.Text)
            .Parameters.AddWithValue("@load2_minuteOn", TextBox13.Text)
            .Parameters.AddWithValue("@load2_hourOff", TextBox12.Text)
            .Parameters.AddWithValue("@load2_minuteOff", TextBox11.Text)

            .Parameters.AddWithValue("@load3_status", TextBox39.Text)
            .Parameters.AddWithValue("@load3_hourOn", TextBox38.Text)
            .Parameters.AddWithValue("@load3_minuteOn", TextBox37.Text)
            .Parameters.AddWithValue("@load3_hourOff", TextBox36.Text)
            .Parameters.AddWithValue("@load3_minuteOff", TextBox35.Text)

            .Parameters.AddWithValue("@load4_status", TextBox34.Text)
            .Parameters.AddWithValue("@load4_hourOn", TextBox33.Text)
            .Parameters.AddWithValue("@load4_minuteOn", TextBox32.Text)
            .Parameters.AddWithValue("@load4_hourOff", TextBox31.Text)
            .Parameters.AddWithValue("@load4_minuteOff", TextBox30.Text)

            .Parameters.AddWithValue("@rain_sensor", TextBox21.Text)

            .Parameters.AddWithValue("@day_counter", TextBox40.Text)

            .Parameters.AddWithValue("@fdevice_name", Label75.Text)
            .Parameters.AddWithValue("@version", Label77.Text)

            ' Execute the database insertion
            .ExecuteReader()
        End With

        ' Close database connections
        dr = Nothing
        cmd.Dispose()
        cn.Close()

            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If

            ' Disable the timers
        'Timer1.Enabled = False
        Timer2.Enabled = False

        DCButton.BackColor = Color.IndianRed
        Button1.BackColor = Color.FromArgb(52, 73, 94)
        PictureBox3.BackColor = Color.FromArgb(52, 73, 94)

            TextBox20.Clear()
            TextBoxRTC.Clear()
            TextBoxDate.Clear()
            TempTextBox.Clear()
            TextBoxDay.Clear()
            TextBox7.Clear()
            TextBox6.Clear()
            TextBox5.Clear()
            TextBox4.Clear()
            txtLoad1StatusShow.Clear()
            TextBox15.Clear()
            TextBox14.Clear()
            TextBox13.Clear()
            TextBox12.Clear()
            TextBox11.Clear()
            TextBox39.Clear()
            TextBox38.Clear()
            TextBox37.Clear()
            TextBox36.Clear()
            TextBox35.Clear()
            TextBox34.Clear()
            TextBox33.Clear()
            TextBox32.Clear()
            TextBox31.Clear()
            TextBox30.Clear()
            ComboBox2.Items.Clear()
            TextBox29.Clear()
            TextBox28.Clear()
            TextBox27.Clear()
        TextBox26.Clear()
        TextBox21.Clear()
        TextBox40.Clear()
        Label75.Text = ""
        Label77.Text = ""




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            Dim selectedDay As String = ComboBox2.SelectedItem.ToString()

            ' Check if a day is selected
            If String.IsNullOrEmpty(selectedDay) Then
                ' Handle invalid selection
                MessageBox.Show("Invalid day selection")
                Return
            End If

            ' Construct the date and time string in the format expected by the Arduino
            Dim dateTimeString As String = TextBox18.Text & "-" & TextBox17.Text & "-" & TextBox3.Text & " " &
                                           TextBox2.Text & ":" & TextBox16.Text & ":" & TextBox19.Text & " " &
                                           selectedDay

            ' Send the date and time string to the Arduino
            SerialPort1.WriteLine("SET_TIME:" & dateTimeString)

            TextBox3.Clear()
            TextBox17.Clear()
            TextBox18.Clear()
            TextBox2.Clear()
            TextBox16.Clear()
            TextBox19.Clear()


            MsgBox("Time/Date sent to Arduino: " & dateTimeString)
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Construct the timer1 settings string in the format expected by the Arduino
        Try

            Dim timer1SettingsString As String = ComboBox7.Text & "," & ComboBox8.Text & "," & ComboBox9.Text & "," & ComboBox10.Text
            ' Send the timer1 settings string to the Arduino
            SerialPort1.WriteLine("SET_TIMER1:" & timer1SettingsString)

            MsgBox("Timer1 settings sent to Arduino: " & timer1SettingsString)

            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            ComboBox9.Items.Clear()
            ComboBox10.Items.Clear()

        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

   
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        History.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Construct the timer2 settings string in the format expected by the Arduino
        Try

            Dim timer2SettingsString As String = ComboBox11.Text & "," & ComboBox12.Text & "," & ComboBox13.Text & "," & ComboBox14.Text
            ' Send the timer2 settings string to the Arduino
            SerialPort1.WriteLine("SET_TIMER2:" & timer2SettingsString)

            ' Clear the COmboboxes after sending
            ComboBox11.Items.Clear()
            ComboBox12.Items.Clear()
            ComboBox13.Items.Clear()
            ComboBox14.Items.Clear()

            MsgBox("Timer2 settings sent to Arduino: " & timer2SettingsString)
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Construct the timer3 settings string in the format expected by the Arduino
        Try

            Dim timer3SettingsString As String = ComboBox15.Text & "," & ComboBox16.Text & "," & ComboBox17.Text & "," & ComboBox18.Text
            ' Send the timer3 settings string to the Arduino
            SerialPort1.WriteLine("SET_TIMER3:" & timer3SettingsString)

            ' Clear the TextBoxes after sending
            ComboBox15.Items.Clear()
            ComboBox16.Items.Clear()
            ComboBox17.Items.Clear()
            ComboBox18.Items.Clear()

            MsgBox("Timer3 settings sent to Arduino: " & timer3SettingsString)
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Construct the timer4 settings string in the format expected by the Arduino
        Try

            Dim timer4SettingsString As String = ComboBox19.Text & "," & ComboBox20.Text & "," & ComboBox21.Text & "," & ComboBox22.Text
            ' Send the timer4 settings string to the Arduino
            SerialPort1.WriteLine("SET_TIMER4:" & timer4SettingsString)

            ' Clear the TextBoxes after sending
            ComboBox19.Items.Clear()
            ComboBox20.Items.Clear()
            ComboBox21.Items.Clear()
            ComboBox22.Items.Clear()

            MsgBox("Timer4 settings sent to Arduino: " & timer4SettingsString)
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Get the selected value from the ComboBox (assuming it's either "1" or "0")
        Try

            Dim selectedValue As String = ComboBox3.SelectedItem.ToString()

            ' Check if a valid value is selected
            If selectedValue <> "On" AndAlso selectedValue <> "Off" Then
                ' Handle invalid selection
                MessageBox.Show("Invalid selection. Please select either 'On' or 'Off'.")
                Return
            End If

            ' Construct the command based on the selected value
            Dim command As String = "TIMER1:"
            If selectedValue = "On" Then
                command &= "On"
            Else
                command &= "Off"
            End If

            ' Send the command to the Arduino
            SerialPort1.WriteLine(command)

            ' Display a message indicating the action
            If selectedValue = "On" Then
                MsgBox("Timer 1 is set to ON")
            Else
                MsgBox("Timer 1 is set to OFF")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' Get the selected value from the ComboBox (assuming it's either "1" or "0")
        Try

            Dim selectedValue As String = ComboBox4.SelectedItem.ToString()

            ' Check if a valid value is selected
            If selectedValue <> "On" AndAlso selectedValue <> "Off" Then
                ' Handle invalid selection
                MessageBox.Show("Invalid selection. Please select either 'On' or 'Off'.")
                Return
            End If

            ' Construct the command based on the selected value
            Dim command As String = "TIMER2:"
            If selectedValue = "On" Then
                command &= "On"
            Else
                command &= "Off"
            End If

            ' Send the command to the Arduino
            SerialPort1.WriteLine(command)

            ' Display a message indicating the action
            If selectedValue = "On" Then
                MsgBox("Timer 2 is set to ON")
            Else
                MsgBox("Timer 2 is set to OFF")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ' Get the selected value from the ComboBox (assuming it's either "1" or "0")
        Try

            Dim selectedValue As String = ComboBox5.SelectedItem.ToString()

            ' Check if a valid value is selected
            If selectedValue <> "On" AndAlso selectedValue <> "Off" Then
                ' Handle invalid selection
                MessageBox.Show("Invalid selection. Please select either 'On' or 'Off'.")
                Return
            End If

            ' Construct the command based on the selected value
            Dim command As String = "TIMER3:"
            If selectedValue = "On" Then
                command &= "On"
            Else
                command &= "Off"
            End If

            ' Send the command to the Arduino
            SerialPort1.WriteLine(command)

            ' Display a message indicating the action
            If selectedValue = "On" Then
                MsgBox("Timer 3 is set to ON")
            Else
                MsgBox("Timer 3 is set to OFF")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ' Get the selected value from the ComboBox (assuming it's either "1" or "0")
        Try

            Dim selectedValue As String = ComboBox6.SelectedItem.ToString()

            ' Check if a valid value is selected
            If selectedValue <> "On" AndAlso selectedValue <> "Off" Then
                ' Handle invalid selection
                MessageBox.Show("Invalid selection. Please select either 'On' or 'Off'.")
                Return
            End If

            ' Construct the command based on the selected value
            Dim command As String = "TIMER4:"
            If selectedValue = "On" Then
                command &= "On"
            Else
                command &= "Off"
            End If

            ' Send the command to the Arduino
            SerialPort1.WriteLine(command)

            ' Display a message indicating the action
            If selectedValue = "On" Then
                MsgBox("Timer 4 is set to ON")
            Else
                MsgBox("Timer 4 is set to OFF")
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    'Private Sub Button7_MouseDown(sender As Object, e As MouseEventArgs) Handles Button7.MouseDown

    '    isButtonPressed = True

    '    ' Start a timer to send "M1" at a controlled interval
    '    Dim sendInterval As Integer = 290  ' Adjust the interval in milliseconds as needed
    '    debounceTimer = New System.Threading.Timer(AddressOf SendM1Command, Nothing, 0, sendInterval)

    'End Sub

    'Private Sub Button7_MouseUp(sender As Object, e As MouseEventArgs) Handles Button7.MouseUp
    '    Try
    '        ' Stop the timer and send "M0" to turn off the mixer
    '        isButtonPressed = False
    '        debounceTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite)
    '        SerialPort1.WriteLine("M0")
    '    Catch ex As Exception
    '        ' Handle any exceptions that occur during the process
    '        MessageBox.Show("An error occurred: No values are selected/incorrect input")
    '    End Try
    'End Sub

    'Private Sub SendM1Command(state As Object)
    '    Try
    '        ' This method will be called by the timer to send "M1" command
    '        SerialPort1.WriteLine("M1")
    '    Catch ex As Exception
    '        ' Handle any exceptions that occur during the process
    '        MessageBox.Show("An error occurred: No values are selected/incorrect input")
    '    End Try
    'End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            ' Prompt the user for confirmation
            Dim confirmationResult As DialogResult = MessageBox.Show("Are you sure you want to SHUTDOWN the system? Please NOTE that if you initiate system shutdown to the arduino you'll have to manually reset the system device", "Confirmation", MessageBoxButtons.YesNo)

            ' Check the user's response
            If confirmationResult = DialogResult.Yes Then
                ' User confirmed, send the command to the Arduino
                SerialPort1.WriteLine("Sd")
            Else
                ' User declined
                MessageBox.Show("System Shutdown Cancelled")
            End If

            PictureBox3.BackColor = Color.IndianRed
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Try
            ' Prompt the user for confirmation
            Dim confirmationResult As DialogResult = MessageBox.Show("Are you sure you want to reset day counter?", "Confirmation", MessageBoxButtons.YesNo)

            ' Check the user's response
            If confirmationResult = DialogResult.Yes Then
                ' User confirmed, send the command to the Arduino
                SerialPort1.WriteLine("Rdc")
            Else
                ' User declined
                MessageBox.Show("Day counter reset cancelled.")
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred: No values are selected/incorrect input")
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim command As String = "MPOn"
            SerialPort1.WriteLine(command) ' Send the command over the serial port

            Button9.BackColor = Color.Chartreuse
            Button10.BackColor = Color.Silver
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            Dim command As String = "MPOff"
            SerialPort1.WriteLine(command) ' Send the command over the serial port

            Button9.BackColor = Color.Silver
            Button10.BackColor = Color.IndianRed
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            ' This method will be called by the timer to send "M1" command
            Dim command As String = "MOn"
            SerialPort1.WriteLine(command)

            ' Change the BackColor of the button after it is pressed
            Button7.BackColor = Color.Chartreuse ' You can choose any color you want
            Button11.BackColor = Color.Silver
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            ' This method will be called by the timer to send "MOff" command
            Dim command As String = "MOff"
            SerialPort1.WriteLine(command)

            ' Reset the BackColor of Button7 to silver
            Button7.BackColor = Color.Silver
            Button11.BackColor = Color.IndianRed
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox3.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox17.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox17.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox18.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox18.Text.Length >= 4 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox2.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox16.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox19.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If TextBox19.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton1.ValueChanged
        Try
            If SwitchButton1.Value Then
                ' Switch is ON, send the command
                Dim command As String = "MPOn"
                SerialPort1.WriteLine(command)
            Else
                ' Switch is OFF, send the command
                Dim command As String = "MPOff"
                SerialPort1.WriteLine(command)
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub SwitchButton2_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton2.ValueChanged
        Try
            If SwitchButton2.Value Then
                ' Switch is ON, send the command
                Dim command As String = "MOn"
                SerialPort1.WriteLine(command)
            Else
                ' Switch is OFF, send the command
                Dim command As String = "MOff"
                SerialPort1.WriteLine(command)
            End If
        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox7.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox7.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox8.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox8.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox9.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox9.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox10.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox10.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox11.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox11.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox12.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox12.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox13.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox13.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox14.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox14.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox15.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox15.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox16.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox16.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox17.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox17.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox18.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox18.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox19.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox19.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox20.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox20.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox21.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox21.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox22.KeyPress
        ' Check if the pressed key is a number or a control key (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number and not a control key, suppress it
            e.Handled = True
        End If

        ' Check if the length of the text in the TextBox is already 2
        If ComboBox22.Text.Length >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length is 2 and the pressed key is not a control key, suppress it
            e.Handled = True
        End If
    End Sub


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        MonthCalendar1.Visible = Not MonthCalendar1.Visible
    End Sub


    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        ' Extract day, month, and year from the selected date
        Dim selectedDate As Date = e.Start
        Dim selectedDay As Integer = selectedDate.Day
        Dim selectedMonth As Integer = selectedDate.Month
        Dim selectedYear As Integer = selectedDate.Year

        ' Update textboxes with the selected values
        TextBox3.Text = selectedDay.ToString()
        TextBox17.Text = selectedMonth.ToString()
        TextBox18.Text = selectedYear.ToString()
    End Sub
End Class
