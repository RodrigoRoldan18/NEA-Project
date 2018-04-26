Public Class StartMenu
    Property CreateLoad As String
    Property FileName As String
    Private FileNameForm As Form2_FileName

    Private Sub BtCreateZoo_Click(sender As Object, e As EventArgs) Handles BtCreateZoo.Click
        'When the button "Create" is clicked, this subroutine will store a value into the property CreateLoad
        'to remind the system that the player selected the option Create. It will then change the layout to acquire a new input
        CreateLoad = "Create"
        LayoutToFileName()
    End Sub

    Private Sub BtLoadZoo_Click(sender As Object, e As EventArgs) Handles BtLoadZoo.Click
        'When the button "Load" is clicked, this subroutine will store a value in the property "CreateLoad"
        'to remind the program that the player selected this option. Then the layout will change to obtain a new input by the player
        CreateLoad = "Load"
        LayoutToFileName()
    End Sub

    Private Sub BtTutorial_Click(sender As Object, e As EventArgs) Handles BtTutorial.Click
        'When the button "Tutorial" is clicked, this subroutine will open another form to show the tutorial.
        If BtTutorial.Text = "Tutorial" Then
            Dim DisplayTutorial = New Simulation()
            DisplayTutorial.Show()
        ElseIf BtTutorial.Text = "Confirm" Then
            'Otherwise, when the button Is clicked, If the text in it does Not say "Tutorial" then depending on the property "CreateLoad"
            'The subroutine will call a function to find the file in a textfile
            Dim Validate As Boolean
            FileName = Me.Controls("TbxFileName").Text
            If CreateLoad = "Load" Then
                If FileName <> "" Then
                    ModuleLoad.FindFile(FileName, Validate)
                End If
            End If
            If CreateLoad = "Create" Then
                If FileName <> "" Then
                    ModuleLoad.FindFile(FileName, Validate)
                End If
            End If
            If Validate = True Then
                'Once the file is found or not (depending if the player is loading or creating a game), a subroutine is called to open a form
                OpenSimulation(CreateLoad, FileName)
            End If
        End If
    End Sub

    Private Sub OpenSimulation(ByVal CreateLoad As String, ByRef FileName As String)
        'This is where the subroutine opens the form "Simulation" to start the game
        'and hides this current form as it will not be used anymore
        Dim GoSimulation As New Simulation(FileName, CreateLoad)
        GoSimulation.Show()
        Me.Hide()
    End Sub

    Private Sub LayoutToFileName()
        'The layout of the form is changed to obtain the name of the file
        'A back button is created in case the player made a mistake and wants to go back
        Dim BtBack As Button = New Button
        BtBack.Name = "BtBack"
        BtBack.Text = "Back"
        BtBack.Size = New Size(75, 35)
        BtBack.Location = New Point(12, 12)
        BtBack.Font = New Drawing.Font("Tahoma", 16)
        BtBack.FlatStyle = FlatStyle.Flat
        Me.Controls.Add(BtBack)
        AddHandler BtBack.Click, AddressOf BtBack_Click
        'Textbox used to get the name of the file.
        Dim TbxFileName As TextBox = New TextBox
        TbxFileName.Name = "TbxFileName"
        TbxFileName.Size = New Size(325, 33)
        TbxFileName.Location = New Point(87, 117)
        TbxFileName.Font = New Drawing.Font("Tahoma", 16)
        Me.Controls.Add(TbxFileName)
        AddHandler TbxFileName.TextChanged, AddressOf TbxFileName_TextChanged
        'The previous labels and buttons are edited to fit the new layout
        WelcomeMsg.Text = "Please enter the name of the zoo"
        WelcomeMsg.Font = New Drawing.Font("Broadway", 16)
        WelcomeMsg.Size = New Size(390, 24)
        WelcomeMsg.Location = New Point(52, 58)

        BtTutorial.Text = "Confirm"
        BtTutorial.Size = New Size(112, 37)
        BtTutorial.Location = New Point(195, 235)
        BtTutorial.Font = New Drawing.Font("Tahoma", 16)
        'Some buttons are hidden as they are not needed in this new layout
        BtCreateZoo.Hide()
        BtLoadZoo.Hide()
    End Sub

    Private Sub LayoutToStartMenu()
        'The original layout of the form is restored by this subroutine.
        WelcomeMsg.Text = "Welcome to the Zoo!"
        WelcomeMsg.Font = New Drawing.Font("Broadway", 28)
        WelcomeMsg.Size = New Size(412, 42)
        WelcomeMsg.Location = New Point(35, 9)

        BtTutorial.Text = "Tutorial"
        BtTutorial.Size = New Size(148, 38)
        BtTutorial.Location = New Point(161, 251)
        BtTutorial.Font = New Drawing.Font("Broadway", 16)

        BtCreateZoo.Show()
        BtLoadZoo.Show()

    End Sub

    Private Sub BtBack_Click(sender As Object, e As EventArgs)
        'When the player clicks the back button, the new controls added are removed
        'A subroutine is also called to restore the previous layout of the form
        Dim ButtonClicked As Button = CType(sender, Button)
        ButtonClicked.Hide()
        Me.Controls("TbxFileName").Dispose()
        LayoutToStartMenu()
    End Sub

    Private Sub TbxFileName_TextChanged(sender As Object, e As EventArgs)
        'Recognises when the player entered data into the textbox
    End Sub
End Class

'bibliography: 
''background lion: https://favim.com/image/445038/
''background grass: https://opengameart.org/content/grass-pixel-art
''floor stone: https://www.spoonflower.com/fabric/4646980-8-bit-stone-block-by-wilsongraphics
