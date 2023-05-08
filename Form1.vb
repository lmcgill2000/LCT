Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Net.Http
Imports Microsoft.Graph
Imports Microsoft.Graph.Authentication
Imports System.Net.Http.Headers
Imports Azure.Core
Imports Azure.Identity

Public Class Form1
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set up authentication
        Dim clientID As String = "8445c2e1-60ac-4f5c-adcd-6a22fec99ff8"
        Dim clientSecret As String = "qwB8Q~XKQ~PuNawafoJdM8-l0nVXRCxi1giKsczQ"
        Dim tenantID As String = "27f82e58-66fc-4604-8426-c82d16f3bf11"
        Dim authProvider As New DelegateAuthenticationProvider(Async Function(requestMessage)
                                                                   Dim authContext = New AuthenticationContext("https://login.microsoftonline.com/" + tenantId)
                                                                   Dim credential = New ClientCredential(clientId, clientSecret)
                                                                   Dim authResult = Await authContext.AcquireTokenAsync("https://graph.microsoft.com", credential)
                                                                   requestMessage.Headers.Authorization = New AuthenticationHeaderValue("Bearer", authResult.AccessToken)
                                                               End Function)
        Dim graphClient As New GraphServiceClient(authProvider)

        ' Retrieve all users
        Dim users = Await graphClient.Users.Request.GetAsync()

        ' Add each user to the ListBox
        For Each user In users
            ListBox1.Items.Add(user.DisplayName)
        Next
    End Sub
End Class
