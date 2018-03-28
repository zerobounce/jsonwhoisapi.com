
Imports System.Web.Script.Serialization
Public Class jsonwhoisapi

Public Function GetWhoISParsed(ByVal vDomain As String) As WhoISParsed
      
      Try
           Dim strAccountNumber As String = "" 'Set your Account Number
           Dim strAPIKey As String = ""  'Set Your API Key
           
           Dim request = TryCast(System.Net.WebRequest.Create("https://jsonwhoisapi.com/api/v1/whois?identifier=" & HttpUtility.UrlEncode(vDomain)), System.Net.HttpWebRequest)

            request.Method = "GET"
            request.ContentType = "application/json"
            
            Dim svcCredentials As String = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strAccountNumber & ":" & strAPIKey))

           request.Headers.Add("authorization", "Basic " & svcCredentials)

            Dim strResponseContent As String
            Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
                Using reader = New System.IO.StreamReader(response.GetResponseStream())
                    strResponseContent = reader.ReadToEnd()
                End Using
            End Using

            Dim serializer As New JavaScriptSerializer
            Dim oWhoIsParsed As WhoISParsed
            oWhoIsParsed = serializer.Deserialize(Of WhoISParsed)(strResponseContent)
            Return oWhoIsParsed.created

        Catch ex As Exception
            'Handle any errors
        End Try

    End Function
End Class


Public Class Owner
        Public Property handle As Object
        Public Property type As Object
        Public Property name As String
        Public Property organization As String
        Public Property email As String
        Public Property address As String
        Public Property zipcode As String
        Public Property city As String
        Public Property state As String
        Public Property country As String
        Public Property phone As String
        Public Property fax As String
        Public Property created As Object
        Public Property changed As Object
    End Class

    Public Class Admin
        Public Property handle As Object
        Public Property type As Object
        Public Property name As String
        Public Property organization As String
        Public Property email As String
        Public Property address As String
        Public Property zipcode As String
        Public Property city As String
        Public Property state As String
        Public Property country As String
        Public Property phone As String
        Public Property fax As String
        Public Property created As Object
        Public Property changed As Object
    End Class

    Public Class Tech
        Public Property handle As Object
        Public Property type As Object
        Public Property name As String
        Public Property organization As String
        Public Property email As String
        Public Property address As String
        Public Property zipcode As String
        Public Property city As String
        Public Property state As String
        Public Property country As String
        Public Property phone As String
        Public Property fax As String
        Public Property created As Object
        Public Property changed As Object
    End Class

    Public Class Contacts
        Public Property owner As Owner()
        Public Property admin As Admin()
        Public Property tech As Tech()
    End Class

    Public Class Registrar
        Public Property id As String
        Public Property name As Object
        Public Property email As Object
        Public Property url As Object
        Public Property phone As Object
        Public Property table As Table
    End Class
    
    Public Class Table
    End Class
    
    Public Class WhoISParsed
        Public Property name As String
        Public Property created As Object
        Public Property changed As Object
        Public Property expires As Object
        Public Property dnssec As Object
        Public Property registered As Object
        Public Property status As Object
        Public Property nameservers As Object()
        Public Property contacts As Contacts
        Public Property registrar As Registrar
        Public Property throttled As Object
    End Class
