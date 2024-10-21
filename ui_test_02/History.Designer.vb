<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(History))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.session_id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.connection_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.device_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.os_info = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rtc_time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rtc_date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.water_level = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.temp_level = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load1_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load1_hourOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load1_minuteOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load1_hourOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load1_minuteOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load2_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load2_hourOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load2_minuteOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load2_hourOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load2_minuteOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load3_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load3_hourOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load3_minuteOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load3_hourOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load3_minuteOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load4_status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load4_hourOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load4_minuteOn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load4_hourOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.load4_minuteOff = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.login_time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rain_sensor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.day_counter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fdevice_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.version = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.session_id, Me.connection_name, Me.device_name, Me.os_info, Me.rtc_time, Me.rtc_date, Me.water_level, Me.temp_level, Me.load1_status, Me.load1_hourOn, Me.load1_minuteOn, Me.load1_hourOff, Me.load1_minuteOff, Me.load2_status, Me.load2_hourOn, Me.load2_minuteOn, Me.load2_hourOff, Me.load2_minuteOff, Me.load3_status, Me.load3_hourOn, Me.load3_minuteOn, Me.load3_hourOff, Me.load3_minuteOff, Me.load4_status, Me.load4_hourOn, Me.load4_minuteOn, Me.load4_hourOff, Me.load4_minuteOff, Me.login_time, Me.rain_sensor, Me.day_counter, Me.fdevice_name, Me.version})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(54, 110)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1331, 758)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'session_id
        '
        Me.session_id.Text = "ID"
        Me.session_id.Width = 35
        '
        'connection_name
        '
        Me.connection_name.Text = "Connection"
        Me.connection_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.connection_name.Width = 80
        '
        'device_name
        '
        Me.device_name.Text = "Device"
        Me.device_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'os_info
        '
        Me.os_info.Text = "OS"
        Me.os_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rtc_time
        '
        Me.rtc_time.Text = "RTC Time"
        Me.rtc_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rtc_time.Width = 80
        '
        'rtc_date
        '
        Me.rtc_date.Text = "RTC Date"
        Me.rtc_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rtc_date.Width = 90
        '
        'water_level
        '
        Me.water_level.Text = "Water %"
        Me.water_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.water_level.Width = 63
        '
        'temp_level
        '
        Me.temp_level.Text = "Temp %"
        Me.temp_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.temp_level.Width = 63
        '
        'load1_status
        '
        Me.load1_status.Text = "L1 Stat"
        Me.load1_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load1_status.Width = 55
        '
        'load1_hourOn
        '
        Me.load1_hourOn.Text = "L1hourON"
        Me.load1_hourOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load1_hourOn.Width = 75
        '
        'load1_minuteOn
        '
        Me.load1_minuteOn.Text = "L1minuteON"
        Me.load1_minuteOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load1_minuteOn.Width = 85
        '
        'load1_hourOff
        '
        Me.load1_hourOff.Text = "L1hourOff"
        Me.load1_hourOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load1_hourOff.Width = 75
        '
        'load1_minuteOff
        '
        Me.load1_minuteOff.Text = "L1minuteOff"
        Me.load1_minuteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load1_minuteOff.Width = 85
        '
        'load2_status
        '
        Me.load2_status.Text = "L2 Stat"
        Me.load2_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load2_status.Width = 55
        '
        'load2_hourOn
        '
        Me.load2_hourOn.Text = "L2hourOn"
        Me.load2_hourOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load2_hourOn.Width = 75
        '
        'load2_minuteOn
        '
        Me.load2_minuteOn.Text = "L2minuteOn"
        Me.load2_minuteOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load2_minuteOn.Width = 85
        '
        'load2_hourOff
        '
        Me.load2_hourOff.Text = "L2hourOff"
        Me.load2_hourOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load2_hourOff.Width = 75
        '
        'load2_minuteOff
        '
        Me.load2_minuteOff.Text = "L2minuteOff"
        Me.load2_minuteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load2_minuteOff.Width = 85
        '
        'load3_status
        '
        Me.load3_status.Text = "L3 Stat"
        Me.load3_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load3_status.Width = 55
        '
        'load3_hourOn
        '
        Me.load3_hourOn.Text = "L3hourOn"
        Me.load3_hourOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load3_hourOn.Width = 75
        '
        'load3_minuteOn
        '
        Me.load3_minuteOn.Text = "L3minuteOn"
        Me.load3_minuteOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load3_minuteOn.Width = 85
        '
        'load3_hourOff
        '
        Me.load3_hourOff.Text = "L3hourOff"
        Me.load3_hourOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load3_hourOff.Width = 75
        '
        'load3_minuteOff
        '
        Me.load3_minuteOff.Text = "L3minuteOff"
        Me.load3_minuteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load3_minuteOff.Width = 85
        '
        'load4_status
        '
        Me.load4_status.Text = "L4 Stat"
        Me.load4_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load4_status.Width = 55
        '
        'load4_hourOn
        '
        Me.load4_hourOn.Text = "L4hourOn"
        Me.load4_hourOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load4_hourOn.Width = 75
        '
        'load4_minuteOn
        '
        Me.load4_minuteOn.Text = "L4minuteOn"
        Me.load4_minuteOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load4_minuteOn.Width = 85
        '
        'load4_hourOff
        '
        Me.load4_hourOff.Text = "L4hourOn"
        Me.load4_hourOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load4_hourOff.Width = 75
        '
        'load4_minuteOff
        '
        Me.load4_minuteOff.Text = "L4minuteOff"
        Me.load4_minuteOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.load4_minuteOff.Width = 85
        '
        'login_time
        '
        Me.login_time.DisplayIndex = 30
        Me.login_time.Text = "Login Time"
        Me.login_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.login_time.Width = 85
        '
        'rain_sensor
        '
        Me.rain_sensor.DisplayIndex = 28
        Me.rain_sensor.Text = "Rain Sensor"
        Me.rain_sensor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rain_sensor.Width = 85
        '
        'day_counter
        '
        Me.day_counter.DisplayIndex = 29
        Me.day_counter.Text = "Day Counter"
        Me.day_counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.day_counter.Width = 85
        '
        'fdevice_name
        '
        Me.fdevice_name.Text = "F-Device Name"
        '
        'version
        '
        Me.version.Text = "F Version"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton2, Me.ToolStripButton7, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1447, 70)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Enabled = False
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 67)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(36, 67)
        Me.ToolStripButton4.Text = "Refresh"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Enabled = False
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 67)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 67)
        Me.ToolStripButton2.Text = "Export to Excel"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Enabled = False
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 67)
        Me.ToolStripButton7.Text = "ToolStripButton7"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 67)
        Me.ToolStripButton1.Text = "Delete Item"
        '
        'History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1447, 918)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListView1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents session_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents connection_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents device_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents os_info As System.Windows.Forms.ColumnHeader
    Friend WithEvents rtc_time As System.Windows.Forms.ColumnHeader
    Friend WithEvents rtc_date As System.Windows.Forms.ColumnHeader
    Friend WithEvents water_level As System.Windows.Forms.ColumnHeader
    Friend WithEvents temp_level As System.Windows.Forms.ColumnHeader
    Friend WithEvents load1_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents load1_hourOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load1_minuteOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load1_hourOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load1_minuteOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load2_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents load2_hourOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load2_minuteOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load2_hourOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load2_minuteOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load3_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents load3_hourOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load3_minuteOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load3_hourOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load3_minuteOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load4_status As System.Windows.Forms.ColumnHeader
    Friend WithEvents load4_hourOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load4_minuteOn As System.Windows.Forms.ColumnHeader
    Friend WithEvents load4_hourOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents load4_minuteOff As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents login_time As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rain_sensor As System.Windows.Forms.ColumnHeader
    Friend WithEvents day_counter As System.Windows.Forms.ColumnHeader
    Friend WithEvents fdevice_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents version As System.Windows.Forms.ColumnHeader
End Class
