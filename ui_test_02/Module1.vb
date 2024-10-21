Imports MySql.Data.MySqlClient
Module Module1
    'declarations
    Public cn As New MySqlConnection
    Public dr As MySqlDataReader
    Public cmd As MySqlCommand

    Public sql As String
    Public newLine As ListViewItem

    Public uid As Integer
    Public Sub connecttodb()
        Try
            'online connnection db
            'cn.ConnectionString = "server=ianbayarcal.cmu-online.tech; user id=cmuon_bayarcalis; password=Ol^0f8b1; database=cmuonine_bayarcaldb; port=3306"

            'local networkconnection db
            'cn.ConnectionString = "server=localhost; user id =ianbayarcal; password=2020301243; database=lmsdb; port=3306"

            'local standalone connnection db
            cn.ConnectionString = "server=localhost; user id =root; password=2020301243; database=fertigationdb; port=3306"


            cn.Open()


            'dialog shows when error occures
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
