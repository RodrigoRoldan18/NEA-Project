Module PrepareNextWeek
    Public Function CheckItemsInZoo(ByRef ItemsInZoo As Integer, ByVal TbLPField As TableLayoutPanel) As Integer
        'the items on the field are checked for the system to judge if the popularity of the zoo has to decrease.
        Dim objects As Integer = 0
        Dim RowCount As Integer = TbLPField.RowCount
        Dim ColumnCount As Integer = TbLPField.ColumnCount
        For Column = 0 To ColumnCount - 1
            For Row = 0 To RowCount - 1
                Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                If CellObject.Tag <> "Path" Then
                    objects += 1
                End If
            Next
        Next
        Return objects
    End Function

    Public Function AddAnimal(ByVal ObjectSelected As String, ByRef AnimalsInUse As List(Of Animal)) As List(Of Animal)
        Dim prompt As String = String.Empty
        Dim title As String = String.Empty
        Dim defaultResponse As String = String.Empty
        'when the player added a new animal to the field or if a new animal has been born the player will be asked to set a nickname to the animal
        Dim answer As Object
        ' Set prompt.
        prompt = "Hello there. Please type a nickname for this animal"
        ' Set title.
        title = "Get Animal Nickname"
        ' Set default value.
        defaultResponse = ObjectSelected

        ' Display prompt, title, and default value.
        answer = InputBox(prompt, title, defaultResponse)
        Dim NewAnimal As New Animal(ObjectSelected, answer)
        MsgBox("A new animal has been added, it is a: " & NewAnimal.GetName & vbNewLine & "Its Nickname is: " & NewAnimal.GetNickname & vbNewLine & "It has " & NewAnimal.GetHealth & " health" & vbNewLine & "It has " & NewAnimal.GetFood & " food" & vbNewLine & "It has " & NewAnimal.GetHygiene & " hygiene" & vbNewLine & "It has " & NewAnimal.GetWater & " water" & vbNewLine & "It has " & NewAnimal.GetLove & " love")
        AnimalsInUse.Add(NewAnimal)
        Return AnimalsInUse
    End Function

    Public Function AddBuilding(ByRef ObjectSelected As String, ByVal BuildingsInUse As List(Of Building)) As List(Of Building)
        Dim NewBuilding As New Building(ObjectSelected)
        'when a building is placed on the field the player will be informed
        MsgBox("A new building has been added, it is a: " & NewBuilding.GetName & vbNewLine & "It has " & NewBuilding.GetHealth & " health" & vbNewLine & "It has " & NewBuilding.GetHygiene & " hygiene")
        BuildingsInUse.Add(NewBuilding)
        Return BuildingsInUse
    End Function

    Public Function TimeEffect(ByRef AnimalsInUse As List(Of Animal), ByRef BuildingsInUse As List(Of Building))
        Dim Animal As Animal
        Dim Building As Building
        'every week the objects on the field will suffer from time. Getting older in terms of lowering their stats. 
        For x = 0 To AnimalsInUse.Count - 1
            Animal = AnimalsInUse(x)
            Animal.ChangeHealth()
            Animal.ChangeFood()
            Animal.ChangeHygiene()
            Animal.ChangeWater()
            Animal.ChangeLove()
        Next
        For x = 0 To BuildingsInUse.Count - 1
            Building = BuildingsInUse(x)
            Building.ChangeHealth()
            Building.ChangeHygiene()
        Next
        Return AnimalsInUse
        Return BuildingsInUse
    End Function

    Public Function BuildingOutcome(ByRef MainCurrency As Integer, ByVal BuildingsInUse As List(Of Building), ByVal Popularity As Decimal, ByVal eventplus As Decimal) As Integer
        Dim BuildingName As String
        'the buildings give a certain amount of outcome as a reward of placing them on the field.
        'the outcome depends on the popularity of the zoo and if there is an event active
        For Each building In BuildingsInUse
            BuildingName = building.GetName
            If BuildingName = "Toilet" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 0.5) * 100)
            End If
            If BuildingName = "Popcorn_Shop" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 1.1) * 100)
            End If
            If BuildingName = "Balloon_Shop" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 0.8) * 100)
            End If
            If BuildingName = "GiftShop" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 1.2) * 100)
            End If
            If BuildingName = "Burger_Shop" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 1.1) * 100)
            End If
            If BuildingName = "Drink_Shop" Then
                MainCurrency = MainCurrency + ((Popularity * eventplus * 1.0) * 100)
            End If
        Next
        Return MainCurrency
    End Function

    Public Function RestoreAnimal(ByRef AnimalsInUse As List(Of Animal), ByRef MainCurrency As Integer, ByVal TbLPField As TableLayoutPanel, ByRef EmployersInUse As List(Of String))
        Dim Animal As Animal
        Dim MoneySpent As Boolean
        Dim validation As Boolean
        Dim answerdofunc As Object
        Dim maxanimals As Integer
        Dim NoOfEmployers As Integer
        Dim foodvalidate As Boolean = False
        Dim watervalidate As Boolean = False
        Dim cleanvalidate As Boolean = False
        'every week the player will be asked to restore the stats of the animals.
        'this subroutine is supposed to be annoying as the player is asked to pay money to restore a single property of a single animal. 
        'if the player has a lot of animals, then this section will take long to complete.
        'However, if the player has employers, it will be done automatically.
        If EmployersInUse.Contains("FoodEmployer") Or EmployersInUse.Contains("WaterEmployer") Or EmployersInUse.Contains("Cleaner") Then
            If EmployersInUse.Contains("FoodEmployer") Then
                For i = 0 To EmployersInUse.Count - 1
                    If EmployersInUse(i) = "FoodEmployer" Then
                        NoOfEmployers += 1
                    End If
                Next
                maxanimals = 10 * NoOfEmployers
                'if the animals covered by the employer(s) is higher than the current number of animals on the field then it is done automatically and the player does not have to pay
                If maxanimals > AnimalsInUse.Count - 1 Then
                    For x = 0 To AnimalsInUse.Count - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetFood < 50 Then
                            Animal.RestoreFood()
                        End If
                    Next
                ElseIf maxanimals <= AnimalsInUse.Count - 1 Then
                    ' if the animals covered by the employer(s) is lower then the player only has to pay for the animals that are not covered by the employer
                    For x = 0 To maxanimals - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetFood < 50 Then
                            Animal.RestoreFood()
                        End If
                    Next
                    For y = (maxanimals - 1) To (AnimalsInUse.Count - 1)
                        Animal = AnimalsInUse(y)
                        If MainCurrency >= 50 Then
                            If Animal.GetFood < 50 Then
                                Do
                                    'this is where the player is asked to pay to restore the food of the animals that were not covered by the employer
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on food. Do you want to buy more food? (£50) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                        'there are some error checks to make sure that the player has enough money and has typed the correct thing
                                        MainCurrency = MainCurrency - 50
                                        Animal.RestoreFood()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 50 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                        End If
                    Next
                End If
            End If
            'the same thing is done for the water employer
            If EmployersInUse.Contains("WaterEmployer") Then
                For i = 0 To EmployersInUse.Count - 1
                    If EmployersInUse(i) = "WaterEmployer" Then
                        NoOfEmployers += 1
                    End If
                Next
                maxanimals = 10 * NoOfEmployers
                If maxanimals > AnimalsInUse.Count - 1 Then
                    For x = 0 To AnimalsInUse.Count - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetWater < 50 Then
                            Animal.RestoreWater()
                        End If
                    Next
                ElseIf maxanimals <= AnimalsInUse.Count - 1 Then
                    For x = 0 To maxanimals - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetWater < 50 Then
                            Animal.RestoreWater()
                        End If
                    Next
                    For y = (maxanimals - 1) To (AnimalsInUse.Count - 1)
                        Animal = AnimalsInUse(y)
                        If MainCurrency >= 50 Then
                            If Animal.GetWater < 50 Then
                                Do
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on water. Do you want to buy more water? (£50) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                        MainCurrency = MainCurrency - 50
                                        Animal.RestoreWater()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 50 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                        End If
                    Next
                End If
            End If
            'the same thing is done for the cleaner
            If EmployersInUse.Contains("Cleaner") Then
                For i = 0 To EmployersInUse.Count - 1
                    If EmployersInUse(i) = "Cleaner" Then
                        NoOfEmployers += 1
                    End If
                Next
                maxanimals = 10 * NoOfEmployers
                If maxanimals > AnimalsInUse.Count - 1 Then
                    For x = 0 To AnimalsInUse.Count - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetHygiene < 50 Then
                            Animal.RestoreHygiene()
                        End If
                    Next
                ElseIf maxanimals <= AnimalsInUse.Count - 1 Then
                    For x = 0 To maxanimals - 1
                        Animal = AnimalsInUse(x)
                        If Animal.GetHygiene < 50 Then
                            Animal.RestoreHygiene()
                        End If
                    Next
                    For y = (maxanimals - 1) To (AnimalsInUse.Count - 1)
                        Animal = AnimalsInUse(y)
                        If MainCurrency >= 150 Then
                            If Animal.GetHygiene < 50 Then
                                Do
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on hygiene. Do you want to clean it? (£150) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 150 <= MainCurrency Then
                                        MainCurrency = MainCurrency - 150
                                        Animal.RestoreHygiene()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 150 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                        End If
                    Next
                End If
            End If
            For p = 0 To EmployersInUse.Count - 1
                If EmployersInUse(p) = "FoodEmployer" Then
                    foodvalidate = True
                End If
                If EmployersInUse(p) = "WaterEmployer" Then
                    watervalidate = True
                End If
                If EmployersInUse(p) = "Cleaner" Then
                    cleanvalidate = True
                End If
            Next
            'this is done in case the player does not have any employers of a specific kind
            If foodvalidate = False Then
                For x = 0 To AnimalsInUse.Count - 1
                    Animal = AnimalsInUse(x)
                    If MainCurrency >= 50 Then
                        If Animal.GetFood < 50 Then
                            Do
                                Dim prompt As String = String.Empty
                                Dim title As String = String.Empty
                                Dim defaultResponse As String = String.Empty

                                Dim answer As Object
                                ' Set prompt.
                                prompt = Animal.GetName & " is low on food. Do you want to buy more food? (£50) Yes/No"
                                ' Set title.
                                title = "Restore Animals"

                                ' Display prompt, title, and default value.
                                answer = InputBox(prompt, title, defaultResponse)
                                If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                    MainCurrency = MainCurrency - 50
                                    Animal.RestoreFood()
                                    MoneySpent = True
                                    validation = True
                                ElseIf 50 > MainCurrency Then
                                    MsgBox("You cannot afford that.")
                                    validation = True
                                ElseIf LCase(answer) = "no" Then
                                    validation = True
                                Else
                                    MsgBox("Please enter a valid option")
                                    validation = False
                                End If
                            Loop Until validation = True
                        End If
                    End If
                Next
            End If
            If watervalidate = False Then
                For x = 0 To AnimalsInUse.Count - 1
                    Animal = AnimalsInUse(x)
                    If MainCurrency >= 50 Then
                        If Animal.GetWater < 50 Then
                            Do
                                Dim prompt As String = String.Empty
                                Dim title As String = String.Empty
                                Dim defaultResponse As String = String.Empty

                                Dim answer As Object
                                ' Set prompt.
                                prompt = Animal.GetName & " is low on water. Do you want to buy more water? (£50) Yes/No"
                                ' Set title.
                                title = "Restore Animals"

                                ' Display prompt, title, and default value.
                                answer = InputBox(prompt, title, defaultResponse)
                                If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                    MainCurrency = MainCurrency - 50
                                    Animal.RestoreWater()
                                    MoneySpent = True
                                    validation = True
                                ElseIf 50 > MainCurrency Then
                                    MsgBox("You cannot afford that.")
                                    validation = True
                                ElseIf LCase(answer) = "no" Then
                                    validation = True
                                Else
                                    MsgBox("Please enter a valid option")
                                    validation = False
                                End If
                            Loop Until validation = True
                        End If
                    End If
                Next
            End If
            If cleanvalidate = False Then
                For x = 0 To AnimalsInUse.Count - 1
                    Animal = AnimalsInUse(x)
                    If MainCurrency >= 150 Then
                        If Animal.GetHygiene < 50 Then
                            Do

                                Dim prompt As String = String.Empty
                                Dim title As String = String.Empty
                                Dim defaultResponse As String = String.Empty

                                Dim answer As Object
                                ' Set prompt.
                                prompt = Animal.GetName & " is low on hygiene. Do you want to clean it? (£150) Yes/No"
                                ' Set title.
                                title = "Restore Animals"

                                ' Display prompt, title, and default value.
                                answer = InputBox(prompt, title, defaultResponse)
                                If LCase(answer) = "yes" And 150 <= MainCurrency Then
                                    MainCurrency = MainCurrency - 150
                                    Animal.RestoreHygiene()
                                    MoneySpent = True
                                    validation = True
                                ElseIf 150 > MainCurrency Then
                                    MsgBox("You cannot afford that.")
                                    validation = True
                                ElseIf LCase(answer) = "no" Then
                                    validation = True
                                Else
                                    MsgBox("Please enter a valid option")
                                    validation = False
                                End If
                            Loop Until validation = True
                        End If
                    End If
                Next
            End If
        Else
            'this is done if the player does not have any employers of any type
            Do
                Dim promptdofunc As String = String.Empty
                Dim titledofunc As String = String.Empty
                Dim defaultResponsedofunc As String = String.Empty
                ' Set prompt.
                promptdofunc = "Do you want to restore some animal stats? (yes/no)"
                ' Set title.
                titledofunc = "Restore Animals"

                ' Display prompt, title, and default value.
                answerdofunc = InputBox(promptdofunc, titledofunc, defaultResponsedofunc)
                If LCase(answerdofunc) = "yes" Then
                    For x = 0 To AnimalsInUse.Count - 1
                        Animal = AnimalsInUse(x)
                        If MainCurrency >= 50 Then
                            If Animal.GetFood < 50 Then
                                Do
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on food. Do you want to buy more food? (£50) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                        MainCurrency = MainCurrency - 50
                                        Animal.RestoreFood()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 50 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                            If Animal.GetHygiene < 50 Then
                                Do
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on hygiene. Do you want to clean it? (£150) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 150 <= MainCurrency Then
                                        MainCurrency = MainCurrency - 150
                                        Animal.RestoreHygiene()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 150 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                            If Animal.GetWater < 50 Then
                                Do
                                    Dim prompt As String = String.Empty
                                    Dim title As String = String.Empty
                                    Dim defaultResponse As String = String.Empty

                                    Dim answer As Object
                                    ' Set prompt.
                                    prompt = Animal.GetName & " is low on water. Do you want to buy more water? (£50) Yes/No"
                                    ' Set title.
                                    title = "Restore Animals"

                                    ' Display prompt, title, and default value.
                                    answer = InputBox(prompt, title, defaultResponse)
                                    If LCase(answer) = "yes" And 50 <= MainCurrency Then
                                        MainCurrency = MainCurrency - 50
                                        Animal.RestoreWater()
                                        MoneySpent = True
                                        validation = True
                                    ElseIf 50 > MainCurrency Then
                                        MsgBox("You cannot afford that.")
                                        validation = True
                                    ElseIf LCase(answer) = "no" Then
                                        validation = True
                                    Else
                                        MsgBox("Please enter a valid option")
                                        validation = False
                                    End If
                                Loop Until validation = True
                            End If
                            If Animal.GetLove < 20 Then
                                'love cannot be restored by the player but the system informs the player what to do to increase the love of animals
                                MsgBox(Animal.GetName & " is low on love. A parter next to the animal will increase its love")
                            End If
                            If Animal.GetFood = 100 And Animal.GetWater = 100 And Animal.GetHygiene = 100 Then
                                Animal.RestoreHealth()
                            End If
                        End If
                    Next
                ElseIf LCase(answerdofunc) = "no" Then

                Else
                    MsgBox("Please enter a valid option")
                End If
            Loop Until LCase(answerdofunc) = "yes" Or LCase(answerdofunc) = "no"
        End If
        If MoneySpent = True Then
            MsgBox("Your currency is now: £" & MainCurrency)
        End If
        Return AnimalsInUse
        Return MainCurrency
    End Function

    Public Function Diseases(ByRef AnimalsInUse As List(Of Animal)) As List(Of Animal)
        'random unlucky events are triggered so that the stats of the animals are affected when triggered
        Randomize()
        Dim RandomDisease As Integer
        Dim Animal As Animal

        RandomDisease = Math.Round(Rnd() * 10)
        If RandomDisease = 2 Then
            MsgBox("The pipeline used to provide water to the animals broke. All the animals lost 40 water.")
            For x = 0 To AnimalsInUse.Count - 1
                Animal = AnimalsInUse(x)
                Animal.BrokenPipe()
            Next
        ElseIf RandomDisease = 4 Then
            MsgBox("Some animals have caught a disease. These animals lost 30 health.")
            For x = 0 To AnimalsInUse.Count - 1
                RandomDisease = Math.Round(Rnd() * 10)
                If RandomDisease Mod 2 = 0 Then 'MOD gives the remainder
                    Animal = AnimalsInUse(x)
                    Animal.Diseasehealth()
                End If
            Next
        ElseIf RandomDisease = 6 Then
            MsgBox("There has been a sandstorm, some habitats are in bad hygienic conditions. Some animals lost 40 hygiene. ")
            For x = 0 To AnimalsInUse.Count - 1
                RandomDisease = Math.Round(Rnd() * 10)
                If RandomDisease Mod 2 = 0 Then
                    Animal = AnimalsInUse(x)
                    Animal.SandStorm()
                End If
            Next
        ElseIf RandomDisease = 8 Then
            MsgBox("The food supply has not arrived and the animals are hungry. All animals lost 30 food.")
            For x = 0 To AnimalsInUse.Count - 1
                Animal = AnimalsInUse(x)
                Animal.FoodMissing()
            Next
        End If
        Return AnimalsInUse
    End Function

    Public Function KillAnimal(ByRef AnimalsInUse As List(Of Animal), ByRef TbLPField As TableLayoutPanel) As List(Of Animal)
        Dim SelectedAnimal As Animal
        Dim SelectedAnimalTag As String
        Dim PosOfSelectedAnimal As TableLayoutPanelCellPosition
        Dim RandomPosition As Integer
        Dim AnimalKilled As Boolean = False
        'if an animal reaches 0 on any stat then the animal dies at the end of the week. 
        For i = 0 To (AnimalsInUse.Count - 1)
            Try
                SelectedAnimal = AnimalsInUse(i)
                If SelectedAnimal.GetFood <= 0 Or SelectedAnimal.GetHygiene <= 0 Or SelectedAnimal.GetWater <= 0 Or SelectedAnimal.GetLove <= 0 Or SelectedAnimal.GetHealth <= 0 Then
                    'the system informs what animal has died
                    MsgBox(SelectedAnimal.GetName & " " & SelectedAnimal.GetNickname & " has died")
                    'the said animal is removed from the list
                    AnimalsInUse.Remove(SelectedAnimal)
                    'depending on the selected animal, select the type of image 
                    Select Case SelectedAnimal.GetName
                        Case "Rhino"
                            SelectedAnimalTag = "Rhino"
                        Case "Snake"
                            SelectedAnimalTag = "Snake"
                        Case "Hippo"
                            SelectedAnimalTag = "Hippo"
                        Case "Lion"
                            SelectedAnimalTag = "Lion"
                        Case "Zebra"
                            SelectedAnimalTag = "Zebra"
                        Case "Dolphin"
                            SelectedAnimalTag = "Dolphin"
                    End Select
                    'get all the animals on the field with that name
                    Dim AnimalCategorySearch = From Control In TbLPField.Controls Where Control.Tag = SelectedAnimalTag
                    'get a random number from AnimalCategorySearch and set the item to that number and delete it from the field
                    Randomize()
                    RandomPosition = Math.Round(Rnd() * (AnimalCategorySearch.Count))
                    If AnimalKilled = False Then
                        'position of the selected cell in the table, change the image background to the default one. 
                        PosOfSelectedAnimal = TbLPField.GetPositionFromControl(AnimalCategorySearch(RandomPosition)) 'This is not needed but it might be useful later on
                        'the cell from the table is selected and then the background image is removed
                        ''maybe add a grave so that the dead animals are substituted by it and the player has to pay to remove them
                        TbLPField.GetControlFromPosition(PosOfSelectedAnimal.Column, PosOfSelectedAnimal.Row).BackgroundImage = My.Resources.stonefloor
                        TbLPField.GetControlFromPosition(PosOfSelectedAnimal.Column, PosOfSelectedAnimal.Row).Tag = "Path"
                        AnimalKilled = True
                    End If
                End If
            Catch

            End Try
            AnimalKilled = False
        Next
        Return AnimalsInUse
        'Things to improve here: the system should delete actual cell where the player decided to place that animal, not just a random one of the species.
    End Function

    Public Function CheckSurrounding(ByVal TbLPField As TableLayoutPanel, ByVal AnimalsInUse As List(Of Animal)) As List(Of Animal)
        Dim Row As Integer
        Dim Column As Integer
        Dim RowCount As Integer = TbLPField.RowCount
        Dim ColumnCount As Integer = TbLPField.ColumnCount
        Dim SelectedAnimal As Animal
        Dim ObjectOrAnimalName As String
        Dim Partner As Boolean = False
        Dim Animal2 As Animal
        Dim speciecount As Integer = 1
        Dim count As Integer = 0
        Dim secondanimalcount As Integer
        Dim SpecieList As New List(Of Animal)
        Dim totaltimesnumber As New Queue(Of Integer)
        'this feature is used for the system to check if love has to be incremented for the animals on the field
        Do
            For Column = 0 To ColumnCount - 1
                For Row = 0 To RowCount - 1
                    Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                    'the system goes cell by cell on the table
                    If count < AnimalsInUse.Count Then
                        Partner = False
                        SelectedAnimal = AnimalsInUse(count)   'the first item on the queue is obtained.
                        ObjectOrAnimalName = SelectedAnimal.GetName     'the name of the first item on the queue is obtained.
                        ''ObjectOnField = GetNameForField(ObjectOrAnimalName)     'the actual name of the animal used on the field is returned, (this might not be needed because the name is the same as the tag which is what it's used to identify the cell)
                        NextSpaceChecking(ObjectOrAnimalName, Row, Column, TbLPField, SelectedAnimal, Partner)       'in the field if the animal is next to someone from the same species then it is considered to have a partner and love will increase
                        If Partner = True Then
                            'if the animal selected has another animal of the same species next to it, then the system will move to the next object on the list
                            count += 1
                            'if the selected animal has 100 love or more then the animal is ready to reproduce. 
                            If SelectedAnimal.GetLove >= 100 Then
                                Dim AnimalCategorySearch = From AnimalSelected In AnimalsInUse Where AnimalSelected.Name = ObjectOrAnimalName 'LINQ to get the animals with the same name from the list AnimalsInUse
                                Dim SameSpecies As Integer
                                SameSpecies = AnimalCategorySearch.Count
                                For individual = 0 To SameSpecies - 1
                                    SpecieList.Add(AnimalCategorySearch(individual))    'a new list is created with only the animals from the same species. 
                                Next

                                Dim timesNumber As Integer = 1
                                Dim typeofanimal As Integer = 1
                                Dim previtem As Animal

                                For x = 1 To AnimalsInUse.Count - 1
                                    previtem = AnimalsInUse(x - 1)
                                    If previtem.GetName = AnimalsInUse(x).GetName Then       'this is from the inventorymenu section trying to get the order of the animals in use just to know the number of animals inside a specie
                                        timesNumber += 1
                                    Else
                                        totaltimesnumber.Enqueue(timesNumber)
                                        typeofanimal += 1
                                        timesNumber = 1
                                    End If
                                    If x = AnimalsInUse.Count - 1 Then
                                        totaltimesnumber.Enqueue(timesNumber)
                                    End If

                                Next
                                'the second animal which is going to reproduce with the selected one is set to be the one that follows it on the list
                                secondanimalcount = count
                                'if there are 4 Rhinos, the loop will only consider 3 of them because otherwise the system will make the rhino selected reproduce with itself
                                For PartnerCount = 1 To SameSpecies - 1
                                    Try
                                        'the second animal will be selected as the following item in the list
                                        Animal2 = SpecieList(secondanimalcount)    'this will only work for the first species
                                    Catch
                                        'however the system will have an error going outside the boundaries.
                                        'therefore the position of the second animal is reconsidered by substracting the quantity of the quantity of the species before the selected one on the list
                                        'For example, the list contains 4 Rhinos and 3 Zebras. The Zebras can reproduce so the position of the first zebra is (4) and the next one is (5)
                                        'but the position of the second animal on the specie list is (1) not (5)
                                        'then the system will do 5(of the original inventory list) - 4(of the quantity of the previous species) 
                                        secondanimalcount = secondanimalcount - totaltimesnumber.Dequeue()
                                        If secondanimalcount > SpecieList.Count Then
                                            'if the position determined is still higher than the actual quantity then the previous step will be repeated with the next specie
                                            'this is because the position of the selected specie on the list is after 2 other species, not 1
                                            secondanimalcount = secondanimalcount - totaltimesnumber.Dequeue()
                                        End If
                                        If secondanimalcount = SpecieList.Count Then
                                            'if the default position of the second animal is outside the bounds. then it is set to 0
                                            'this is because the selected animal is at the end of the list and the system has to look for the next animal from the beginning of the list.
                                            secondanimalcount = 0
                                        End If
                                        Animal2 = SpecieList(secondanimalcount)
                                    End Try
                                    If Animal2.GetLove >= 100 Then
                                        'Once the 2nd animal is obtained, it is checked if the animal can reproduce.
                                        Reproduce(ObjectOrAnimalName, Row, Column, TbLPField, SelectedAnimal, Animal2, AnimalsInUse, count, secondanimalcount)
                                    End If
                                    'then the default position of the second animal is updated and the steps are repeated
                                    secondanimalcount += 1
                                    If secondanimalcount = SameSpecies Then
                                        'if the system reached the end of the list it starts over
                                        secondanimalcount = 0
                                    End If
                                Next
                                SpecieList.Clear()
                                totaltimesnumber.Clear()
                            End If
                            'Animal2 should have the values of the next animal inside AnimalsInUse that has the same name as the SelectedAnimal
                        End If
                    End If
                Next
            Next
            If Partner = False Then
                'if the system found no partner for the animal then it moves on
                count += 1
            End If
            If Row = RowCount - 1 Then
                Row = 0
            End If
            If Column = ColumnCount - 1 Then
                Column = 0
            End If
            'if the system went through all the cells it will do it again until it checked for every animal on the list. 
        Loop Until count = AnimalsInUse.Count
        'check the surroundings and if there is an animal from the same species add 5 to love
        'if the animal and the one next to it reach 100 love then concieve a child and their love goes back to 50
        'if the animals does not have a parter, love will decrease

        'this is supposed to look through the field and see if the animal selected has someone from the same species next to it, if it does not then love will decrease and viceversa
        Return AnimalsInUse
    End Function

    Private Function PlaceBackground(ByVal ObjectOrAnimalName As String, ByRef CurrentCell As Control)
        'this function places the background of the button on the table depending on the tag
        Select Case ObjectOrAnimalName
            Case "Rhino"
                CurrentCell.BackgroundImage = My.Resources.rhinoceros
            Case "Snake"
                CurrentCell.BackgroundImage = My.Resources.snake
            Case "Hippo"
                CurrentCell.BackgroundImage = My.Resources.hippopotamus
            Case "Lion"
                CurrentCell.BackgroundImage = My.Resources.lion
            Case "Zebra"
                CurrentCell.BackgroundImage = My.Resources.zebra
            Case "Dolphin"
                CurrentCell.BackgroundImage = My.Resources.dolphin

            Case "Toilet"
                CurrentCell.BackgroundImage = My.Resources.toilet
            Case "Popcorn_Shop"
                CurrentCell.BackgroundImage = My.Resources.popcorn
            Case "Balloon_Shop"
                CurrentCell.BackgroundImage = My.Resources.balloons
            Case "Giftshop"
                CurrentCell.BackgroundImage = My.Resources.gift
            Case "Burger_Shop"
                CurrentCell.BackgroundImage = My.Resources.burger
            Case "Drink_Shop"
                CurrentCell.BackgroundImage = My.Resources.drink
        End Select
        Return CurrentCell
    End Function

    Private Function NextSpaceChecking(ByVal ObjectOrAnimalName As String, ByVal Row As Integer, ByVal Column As Integer, ByVal TbLPField As TableLayoutPanel, ByRef SelectedAnimal As Animal, ByRef Partner As Boolean)
        Dim validate As Boolean = False
        'this is where the system checks for the cells around the one selected to check if the animal has a partner from the same species next to it
        If TbLPField.GetControlFromPosition(Column, Row).Tag = ObjectOrAnimalName Then
            Do
                Try
                    If TbLPField.GetControlFromPosition(Column + 1, Row).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column - 1, Row).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column, Row + 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column, Row - 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column - 1, Row - 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column - 1, Row + 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column + 1, Row - 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                Try
                    If TbLPField.GetControlFromPosition(Column + 1, Row + 1).Tag = ObjectOrAnimalName Then
                        SelectedAnimal.PartnerLove()
                        Partner = True
                    End If
                Catch
                    validate = False
                End Try
                validate = True

            Loop Until validate = True
        End If
        'However, a lot of try and catches are used here for the cells that are at the boundary of the table. 
        Return SelectedAnimal
        Return Partner
    End Function

    Private Function Reproduce(ByVal ObjectOrAnimalName As String, ByVal Row As Integer, ByVal Column As Integer, ByVal TbLPField As TableLayoutPanel, ByRef SelectedAnimal As Animal, ByRef animal2 As Animal, ByRef AnimalsInUse As List(Of Animal), ByVal count As Integer, ByVal secondanimalcount As Integer)
        Dim ObjectSelected As String
        Dim replaceanimal2 As Integer
        Dim CurrentCell As Control
        ObjectSelected = ObjectOrAnimalName
        'when two animals can reproduce, the system checks the positions next to the first selected animal and places the newborn animal in one of these positions
        If TbLPField.GetControlFromPosition(Column, Row).Tag = ObjectOrAnimalName Then
            If TbLPField.GetControlFromPosition(Column + 1, Row).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column + 1, Row)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)
                'then the love for both parents is decreased
                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                replaceanimal2 = (secondanimalcount - 1) + (count - 1)
                AnimalsInUse(replaceanimal2) = animal2
                'the stats of both of the parents are updated and substituted in the AnimalsInUse list.
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)
                'the player is informed that an animal has been born and the player is then asked to set a name to the newborn animal
                TbLPField.GetControlFromPosition(Column + 1, Row).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column + 1, Row).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column - 1, Row).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column - 1, Row)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column - 1, Row).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column - 1, Row).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column, Row + 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column, Row + 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column, Row + 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column, Row + 1).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column, Row - 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column, Row - 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column, Row - 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column, Row - 1).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column - 1, Row - 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column - 1, Row - 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column - 1, Row - 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column - 1, Row - 1).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column - 1, Row + 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column - 1, Row + 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column - 1, Row + 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column - 1, Row + 1).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column + 1, Row - 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column + 1, Row - 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column + 1, Row - 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column + 1, Row - 1).Tag = CurrentCell.Tag

            ElseIf TbLPField.GetControlFromPosition(Column + 1, Row + 1).Tag <> ObjectOrAnimalName Then
                CurrentCell = TbLPField.GetControlFromPosition(Column + 1, Row + 1)
                CurrentCell.Tag = ObjectOrAnimalName
                CurrentCell = PlaceBackground(ObjectOrAnimalName, CurrentCell)

                SelectedAnimal.AfterReproduce()
                animal2.AfterReproduce()
                AnimalsInUse(count - 1) = SelectedAnimal
                AnimalsInUse(secondanimalcount) = animal2
                MsgBox("A new animal has been born!! ♥ It's a " & ObjectOrAnimalName)
                AddAnimal(ObjectSelected, AnimalsInUse)

                TbLPField.GetControlFromPosition(Column + 1, Row + 1).BackgroundImage = CurrentCell.BackgroundImage
                TbLPField.GetControlFromPosition(Column + 1, Row + 1).Tag = CurrentCell.Tag

            End If
        End If
        Return AnimalsInUse
    End Function

    Public Function PublicOpinion(ByVal TbLPField As TableLayoutPanel, ByVal PublicCurrentObject As Integer) As Integer
        Randomize()
        Dim RandomOpinion As Integer
        Dim RowCount As Integer = TbLPField.RowCount
        Dim ColumnCount As Integer = TbLPField.ColumnCount
        RandomOpinion = Math.Round(Rnd() * 10)
        'random special quests are sometimes created every three weeks giving the player a task to complete in three weeks time. 
        If RandomOpinion = 2 Then
            MsgBox("The customers want you to have more buildings")
            For Column = 0 To ColumnCount - 1
                For Row = 0 To RowCount - 1
                    Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                    If CellObject.Tag = "Toilet" Or CellObject.Tag = "Popcorn_Shop" Or CellObject.Tag = "Balloon_Shop" Or CellObject.Tag = "Giftshop" Then
                        PublicCurrentObject += 1
                    End If
                Next
            Next
            'if you dont add buildings in the next week, money will be lost. 
            'count the current number of objects in the field. 
        ElseIf RandomOpinion = 4 Then
            MsgBox("The customers want you to have more Lions and Zebras")
            For Column = 0 To ColumnCount - 1
                For Row = 0 To RowCount - 1
                    Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                    If CellObject.Tag = "Lion" Or CellObject.Tag = "Zebra" Then
                        PublicCurrentObject += 1
                    End If
                Next
            Next
            'if the player doesn't add more lions or zebras in 3 weeks then money will be lost
        ElseIf RandomOpinion = 6 Then
            Console.WriteLine("The customers want you to have more Hippos and Rhinos")
            For Column = 0 To ColumnCount - 1
                For Row = 0 To RowCount - 1
                    Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                    If CellObject.Tag = "Hippo" Or CellObject.Tag = "Rhino" Then
                        PublicCurrentObject += 1
                    End If
                Next
            Next
            'if the player doesn't place more hippos or rhinos in 3 weeks then money will be lost
        ElseIf RandomOpinion = 8 Then
            Console.WriteLine("The customers want you to have more Dolphins")
            For Column = 0 To ColumnCount - 1
                For Row = 0 To RowCount - 1
                    Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                    If CellObject.Tag = "Dolphin" Then
                        PublicCurrentObject += 1
                    End If
                Next
            Next
        End If
        Return RandomOpinion
    End Function

    Public Function CheckPublicOpinion(ByRef Popularity As Decimal, ByRef MainCurrency As Integer, ByVal PublicOption As Integer, ByRef PublicCurrentObject As Integer, ByVal TbLPField As TableLayoutPanel, ByVal Week As Integer, ByRef OriginalWeek As Integer)

        Dim NewObjects As Integer = 0
        Dim RowCount As Integer = TbLPField.RowCount
        Dim ColumnCount As Integer = TbLPField.ColumnCount
        If Week Mod 3 = 0 Then
            OriginalWeek = Week
        End If
        'here the system checks if the player has completed the task by checking the number of objects asked for now with the number of objects asked for when the task was set.
        'if the player completed the task, then the popularity of the zoo increases
        If PublicOption = 2 Then
            MsgBox("The customers want you to have more buildings" & vbNewLine & "You have " & 3 - (Week - OriginalWeek) & " week(s) left")
            If Week - OriginalWeek = 3 Then
                For Column = 0 To ColumnCount - 1
                    For Row = 0 To RowCount - 1
                        Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                        If CellObject.Tag = "Toilet" Or CellObject.Tag = "Popcorn_Shop" Or CellObject.Tag = "Balloon_Shop" Or CellObject.Tag = "Giftshop" Then
                            NewObjects += 1
                        End If
                    Next
                Next
                If PublicCurrentObject >= NewObjects Then
                    MainCurrency = MainCurrency - 500
                ElseIf PublicCurrentObject < NewObjects Then
                    Popularity += 0.2
                End If
            End If
            'if you dont add buildings in the next week, money will be lost. 
        ElseIf PublicOption = 4 Then
            MsgBox("The customers want you to have more Lions and Zebras" & vbNewLine & "You have " & 3 - (Week - OriginalWeek) & " week(s) left")
            If Week - OriginalWeek = 3 Then
                For Column = 0 To ColumnCount - 1
                    For Row = 0 To RowCount - 1
                        Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                        If CellObject.Tag = "Lion" Or CellObject.Tag = "Zebra" Then
                            NewObjects += 1
                        End If
                    Next
                Next
                If PublicCurrentObject >= NewObjects Then
                    MainCurrency = MainCurrency - 700
                ElseIf PublicCurrentObject < NewObjects Then
                    Popularity += 0.2
                End If
            End If
        ElseIf PublicOption = 6 Then
            MsgBox("The customers want you to have more Hippos and Rhinos" & vbNewLine & "You have " & 3 - (Week - OriginalWeek) & " week(s) left")
            If Week - OriginalWeek = 3 Then
                For Column = 0 To ColumnCount - 1
                    For Row = 0 To RowCount - 1
                        Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                        If CellObject.Tag = "Hippo" Or CellObject.Tag = "Rhino" Then
                            NewObjects += 1
                        End If
                    Next
                Next
                If PublicCurrentObject >= NewObjects Then
                    MainCurrency = MainCurrency - 400
                ElseIf PublicCurrentObject < NewObjects Then
                    Popularity += 0.2
                End If
            End If
        ElseIf PublicOption = 8 Then
            MsgBox("The customers want you to have more Dolphins" & vbNewLine & "You have " & 3 - (Week - OriginalWeek) & " week(s) left")
            If Week - OriginalWeek = 3 Then
                For Column = 0 To ColumnCount - 1
                    For Row = 0 To RowCount - 1
                        Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                        If CellObject.Tag = "Dolphin" Then
                            NewObjects += 1
                        End If
                    Next
                Next
                If PublicCurrentObject >= NewObjects Then
                    MainCurrency = MainCurrency - 800
                ElseIf PublicCurrentObject < NewObjects Then
                    Popularity += 0.2
                End If
            End If
        End If
        Return MainCurrency
        Return Popularity
    End Function

    Public Function SortOrderInList(ByRef AnimalsInUse As List(Of Animal)) As List(Of Animal)
        Dim previtem As Animal
        Dim selecteditem As Animal
        Dim count As Integer = 1
        Dim AnimalPosition As New List(Of Integer)
        Dim followingitem As Animal
        'very similar to the sorting algorithm used for the inventory, but this time it is for the animals in the list AnimalsInUse
        For x = 1 To AnimalsInUse.Count - 1
            previtem = AnimalsInUse(x - 1)
            If previtem.GetName <> AnimalsInUse(x).GetName Then
                AnimalPosition.Add(x - 1)
            End If
            If x = AnimalsInUse.Count - 1 Then
                AnimalPosition.Add(x)
            End If
            count += 1
        Next
        Dim eliminateposition As Integer
        Dim calculateposition As Integer
        For y = 0 To AnimalPosition.Count - 1
            Try
                selecteditem = AnimalsInUse(AnimalPosition(y))
                For z = 1 To AnimalPosition.Count - 1
                    eliminateposition = z + y
                    followingitem = AnimalsInUse(AnimalPosition(eliminateposition))
                    If selecteditem.GetName = followingitem.GetName Then
                        AnimalPosition.RemoveAt(eliminateposition)
                    End If
                Next
            Catch

            End Try
            calculateposition = 0
        Next
        Dim OrderedAnimals As New List(Of Animal)
        For j = 0 To AnimalPosition.Count - 1
            Dim AnimalName As String
            AnimalName = AnimalsInUse(AnimalPosition(j)).GetName
            Dim AnimalCategorySearch = From AnimalSelected In AnimalsInUse Where AnimalSelected.Name = AnimalName
            For Each individual In AnimalCategorySearch
                OrderedAnimals.Add(individual)
            Next
        Next
        AnimalsInUse = OrderedAnimals
        Return AnimalsInUse
    End Function
End Module
