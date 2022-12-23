Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class SQLHelper


    'ByVal args As String()
    Public Function GetDataSet(ByVal cmdText As String, ByVal cmdType As CommandType) As DataSet

        'Return GetDataSet(cmdText, cmdType, null)
        Dim connectionString As String
        Dim connection As New SqlConnection()
        'Dim sqlCommand As New SqlCommand()
        Dim dataAdapter = New SqlDataAdapter()
        Dim ds As New DataSet()


        Try

            'connectionString = "Data Source=LAPTOP-PIC2FSAE;Initial Catalog=Ventas;User ID=UserName;Password=Password"
            connectionString = ConfigurationManager.ConnectionStrings("VentasConnection").ConnectionString

            connection = New SqlConnection(connectionString)


            connection.Open()

            Dim cmd As New SqlCommand(cmdText, connection)
            cmd.CommandType = cmdType

            'Dim dataAdapter As SqlDataAdapter

            'dataAdapter = New SqlDataAdapter("select * from Productos", connection)

            dataAdapter.SelectCommand = cmd

            dataAdapter.Fill(ds)

            connection.Close()
            connection.Dispose()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
                connection.Dispose()
            End If
        End Try

        Return ds

    End Function

    Public Function GetDataSet(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal Parameters() As SqlParameter) As DataSet
        Dim connectionString As String
        Dim connection As New SqlConnection()
        'Dim sqlCommand As New SqlCommand()
        Dim dataAdapter = New SqlDataAdapter()
        Dim ds As New DataSet()


        Try

            'connectionString = "Data Source=LAPTOP-PIC2FSAE;Initial Catalog=Ventas;User ID=UserName;Password=Password"
            connectionString = ConfigurationManager.ConnectionStrings("VentasConnection").ConnectionString

            connection = New SqlConnection(connectionString)


            connection.Open()

            Dim cmd As New SqlCommand(cmdText, connection)
            cmd.CommandType = cmdType

            cmd.Parameters.AddRange(Parameters)
            'Dim dataAdapter As SqlDataAdapter

            'dataAdapter = New SqlDataAdapter("select * from Productos", connection)

            dataAdapter.SelectCommand = cmd

            dataAdapter.Fill(ds)

            connection.Close()
            connection.Dispose()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
                connection.Dispose()
            End If
        End Try

        Return ds

    End Function

    Public Function ExecuteNonQuery(ByVal cmdText As String, ByVal cmdType As CommandType, ByVal Parameters() As SqlParameter) As Integer
        Dim connectionString As String
        Dim connection As New SqlConnection()
        'Dim sqlCommand As New SqlCommand()
        Dim result As Integer

        Try

            'connectionString = "Data Source=LAPTOP-PIC2FSAE;Initial Catalog=Ventas;User ID=UserName;Password=Password"
            connectionString = ConfigurationManager.ConnectionStrings("VentasConnection").ConnectionString

            connection = New SqlConnection(connectionString)


            connection.Open()

            Dim cmd As New SqlCommand(cmdText, connection)
            cmd.CommandType = cmdType

            cmd.Parameters.AddRange(Parameters)

            result = cmd.ExecuteNonQuery()

            connection.Close()
            connection.Dispose()
        Catch ex As Exception
            If connection.State = ConnectionState.Open Then
                connection.Close()
                connection.Dispose()
            End If
        End Try

        Return result

    End Function

    Public Function CreateParameter(ByVal ParamName As String, ByVal SqlDbType As SqlDbType, ByVal Value As Object) _
    As SqlParameter

        Dim param As New SqlParameter
        With param
            .ParameterName = ParamName
            .SqlDbType = SqlDbType
            .Value = Value
        End With

        Return param

    End Function
End Class
