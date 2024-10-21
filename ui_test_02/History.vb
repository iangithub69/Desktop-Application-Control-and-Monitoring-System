
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class History

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

            newLine = ListView1.Items.Add(dr("session_id"))
            newLine.SubItems.Add(dr("connection_name"))
            newLine.SubItems.Add(dr("device_name"))
            newLine.SubItems.Add(dr("os_info"))

            newLine.SubItems.Add(dr("rtc_time"))
            newLine.SubItems.Add(dr("rtc_date"))

            newLine.SubItems.Add(dr("water_level"))
            newLine.SubItems.Add(dr("temp_level"))

            newLine.SubItems.Add(dr("load1_status"))
            newLine.SubItems.Add(dr("load1_hourOn"))
            newLine.SubItems.Add(dr("load1_minuteOn"))
            newLine.SubItems.Add(dr("load1_hourOff"))
            newLine.SubItems.Add(dr("load1_minuteOff"))

            newLine.SubItems.Add(dr("load2_status"))
            newLine.SubItems.Add(dr("load2_hourOn"))
            newLine.SubItems.Add(dr("load2_minuteOn"))
            newLine.SubItems.Add(dr("load2_hourOff"))
            newLine.SubItems.Add(dr("load2_minuteOff"))

            newLine.SubItems.Add(dr("load3_status"))
            newLine.SubItems.Add(dr("load3_hourOn"))
            newLine.SubItems.Add(dr("load3_minuteOn"))
            newLine.SubItems.Add(dr("load3_hourOff"))
            newLine.SubItems.Add(dr("load3_minuteOff"))

            newLine.SubItems.Add(dr("load4_status"))
            newLine.SubItems.Add(dr("load4_hourOn"))
            newLine.SubItems.Add(dr("load4_minuteOn"))
            newLine.SubItems.Add(dr("load4_hourOff"))
            newLine.SubItems.Add(dr("load4_minuteOff"))

            newLine.SubItems.Add(dr("login_time"))

            newLine.SubItems.Add(dr("rain_sensor"))
            newLine.SubItems.Add(dr("day_counter"))

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
                item.BackColor = Drawing.Color.PowderBlue
                item.UseItemStyleForSubItems = True
            End If
            i += 1
        Next

    End Sub

    Private Sub History_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Define the gradient colors
        Dim startColor As Color = Color.FromArgb(RGB(116, 185, 255)) ' Same as the form's current background color
        Dim endColor As Color = Color.FromArgb(100, 160, 230) ' Change this to your desired end color

        ' Create a linear gradient brush
        Dim gradientBrush As New LinearGradientBrush(Me.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical)

        ' Fill the form's background with the gradient brush
        e.Graphics.FillRectangle(gradientBrush, Me.ClientRectangle)
    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAccount()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        LoadAccount()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ExportToExcel()
    End Sub


    Private Sub ExportToExcel()
        Dim excelApp As Excel.Application = Nothing
        Dim excelWorkBook As Excel.Workbook = Nothing
        Dim excelWorkSheet As Excel.Worksheet = Nothing

        Try
            ' Initialize Excel Application
            excelApp = New Excel.Application()
            excelWorkBook = excelApp.Workbooks.Add()
            excelWorkSheet = excelWorkBook.Sheets(1)

            ' Add headers to Excel
            For colIndex As Integer = 0 To ListView1.Columns.Count - 1
                excelWorkSheet.Cells(1, colIndex + 1) = ListView1.Columns(colIndex).Text
            Next

            ' Add data to Excel
            For rowIndex As Integer = 0 To ListView1.Items.Count - 1
                For colIndex As Integer = 0 To ListView1.Columns.Count - 1
                    excelWorkSheet.Cells(rowIndex + 2, colIndex + 1) = ListView1.Items(rowIndex).SubItems(colIndex).Text
                Next
            Next

            ' Prompt the user to choose a save location and file name
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files|*.xlsx"
            saveFileDialog.Title = "Save Excel File"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Save the Excel file to the chosen location
                excelWorkBook.SaveAs(saveFileDialog.FileName)
            End If

        Catch ex As Exception
            ' Handle any exceptions here...

        Finally
            ' Release COM objects in reverse order of creation
            If excelWorkSheet IsNot Nothing Then
                Marshal.ReleaseComObject(excelWorkSheet)
            End If

            If excelWorkBook IsNot Nothing Then
                excelWorkBook.Close(SaveChanges:=False)
                Marshal.ReleaseComObject(excelWorkBook)
            End If

            If excelApp IsNot Nothing Then
                excelApp.Quit()
                Marshal.ReleaseComObject(excelApp)
            End If

            ' Release resources
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub DeleteSelectedItems()
        If ListView1.SelectedItems.Count > 0 Then
            connecttodb() ' Connect to database

            For Each selectedItem As ListViewItem In ListView1.SelectedItems
                Dim sessionID As String = selectedItem.SubItems(0).Text ' Assuming session_id is in the first column

                ' SQL query to delete the selected row based on the session_id
                sql = "DELETE FROM fertigation_table WHERE session_id = @sessionID"
                cmd = New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@sessionID", sessionID)

                ' Execute the delete command
                cmd.ExecuteNonQuery()

                ' Remove the selected item from the ListView
                ListView1.Items.Remove(selectedItem)
            Next

            ' Close database connections
            cmd.Dispose()
            cn.Close()
        Else
            MessageBox.Show("Please select items to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DeleteSelectedItems()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class