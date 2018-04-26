Public Class Form2_FileName
    Property FileName As String
    Property CreateLoad2 As String
    Public Sub New(ByVal CreateLoad As String)

        ' This call is required by the designer.
        InitializeComponent()
        CreateLoad2 = StartMenu.CreateLoad
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Form2_FileName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "FileName"
    End Sub
    Private Sub BtBack_Click(sender As Object, e As EventArgs) Handles BtBack.Click
        Dim StartMenuForm As StartMenu = New StartMenu
        StartMenuForm.Show()
        Me.Dispose()
    End Sub

    Private Sub BtConfirm_Click(sender As Object, e As EventArgs) Handles BtConfirm.Click
        Dim FileNameInput As String
        Dim validate As Boolean
        'CREATE is false LOAD is true
        FileNameInput = TbxFileName.Text
        FileName = FileNameInput
        If CreateLoad2 = "Load" Then
            If TbxFileName.Text <> "" Then
                ModuleLoad.FindFile(FileName, validate)
            End If
        End If
        If CreateLoad2 = "Create" Then
            If TbxFileName.Text <> "" Then
                ModuleLoad.FindFile(FileName, validate)
            End If
        End If
        If validate = True Then
            Dim GoSimulation As New Simulation(FileName, CreateLoad2)
            GoSimulation.Show()
            Me.Hide()

        End If

    End Sub

    Private Sub TbxFileName_TextChanged(sender As Object, e As EventArgs) Handles TbxFileName.TextChanged

    End Sub
End Class

'CREATE is false LOAD is true