Module ModuleSave
    Function SaveZoo(ByRef FileName As String, ByVal ObjectsInField As List(Of String))
        Dim FileHandle As IO.StreamWriter
        Dim prompt As String = String.Empty
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        'This function checks if the player wants to change the name of the game or stick with it. 
        Dim answer As Object
        ' Set prompt.
        prompt = "Your zoo will be saved with the name: " & FileName & "If you want to change the name, please type a new one. Otherwise, don't type anything"
        ' Set title.
        title = "Save Zoo"
        ' Set default value.
        defaultResponse = FileName

        ' Display prompt, title, and default value.
        answer = InputBox(prompt, title, defaultResponse)
        If answer = "" Then
            answer = defaultResponse
        End If
        ' Say something to the user
        MessageBox.Show("Your zoo will be saved with the name: " & answer)
        'add something to check if there is already an existing file with that name
        FileName = answer
        Try
            FileHandle = New IO.StreamWriter(FileName & ".txt")
            For Each item In ObjectsInField 'this should include only the buildings and animals on the field
                FileHandle.Write(item & "|")
            Next
            FileHandle.WriteLine()
            FileHandle.Close()
        Catch
            MsgBox("Error saving the zoo")
        End Try
        Return FileName
    End Function

    Sub SaveInventory(ByVal inventory As List(Of String), ByVal FileName As String)
        'the inventory is saved in the file adding dividers between objects to keep a secure file structure
        Dim FileHandle As IO.StreamWriter
        Try
            FileHandle = New IO.StreamWriter(FileName & ".txt", True)
            For i = 0 To (inventory.Count - 1)
                FileHandle.Write(inventory(i) & ",")
            Next
            FileHandle.WriteLine()
            FileHandle.Close()
        Catch
            MsgBox("Error saving the inventory")
        End Try
    End Sub

    Sub SaveCurrencyAndPopularity(ByVal MainCurrency As Integer, ByVal Popularity As Decimal, ByVal FileName As String, ByVal Week As Integer, ByVal SeasonSelected As String, ByVal SeasonNumber As Integer, ByVal eventtype As Integer, ByVal eventtime As Integer)
        Dim FileHandle As IO.StreamWriter
        'the other important properties are saved here appending data to the file. 
        Try
            FileHandle = New IO.StreamWriter(FileName & ".txt", True)
            FileHandle.WriteLine(MainCurrency)
            FileHandle.WriteLine(Popularity)
            FileHandle.WriteLine(Week)
            FileHandle.WriteLine(SeasonSelected)
            FileHandle.WriteLine(SeasonNumber)
            FileHandle.WriteLine(eventtype)
            FileHandle.WriteLine(eventtime)
            FileHandle.Close()
        Catch
            MsgBox("Error saving the Currency, Popularity, week and season")
        End Try
    End Sub

    Sub SaveAnimalsInUse(ByVal AnimalsInUse As List(Of Animal), ByVal FileName As String, ByVal BuildingsInUse As List(Of Building), ByRef EmployersInUse As List(Of String))
        Dim FileHandle As IO.StreamWriter
        Dim SaveAnimal As Animal
        Dim SaveBuilding As Building
        Dim SaveEmployer As String
        'the three lists are saved into the file adding the dividers where needed to keep a secure file structure
        Try
            FileHandle = New IO.StreamWriter(FileName & ".txt", True)
            For i = 0 To AnimalsInUse.Count - 1
                SaveAnimal = AnimalsInUse(i)
                FileHandle.Write(SaveAnimal.GetName & "/" & SaveAnimal.GetNickname & "/" & SaveAnimal.GetHealth & "/" & SaveAnimal.GetFood & "/" & SaveAnimal.GetHygiene & "/" & SaveAnimal.GetWater & "/" & SaveAnimal.GetLove & "/")
                FileHandle.Write(",")
            Next
            FileHandle.WriteLine("")
            For i = 0 To BuildingsInUse.Count - 1
                SaveBuilding = BuildingsInUse(i)
                FileHandle.Write(SaveBuilding.GetName & "/" & SaveBuilding.GetHealth & "/" & SaveBuilding.GetHygiene & "/")
                FileHandle.Write(",")
            Next
            FileHandle.WriteLine("")
            For i = 0 To EmployersInUse.Count - 1
                SaveEmployer = EmployersInUse(i)
                FileHandle.Write(SaveEmployer)
                FileHandle.Write(",")
            Next
            FileHandle.WriteLine()
            FileHandle.Close()
        Catch
            MsgBox("Error saving the inventory")
        End Try
    End Sub
End Module

