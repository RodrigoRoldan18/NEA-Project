Module ModuleLoad
    Function FindFile(ByRef FileName As String, ByRef validate As Boolean)
        'when the game starts, in both cases the player is asked to enter a file name. 
        Dim FileHandle As IO.StreamReader
        Dim FullFileName As String
        FullFileName = FileName & ".txt"
        Try
            FileHandle = New IO.StreamReader(FullFileName)
            validate = True
            If StartMenu.CreateLoad = "Create" Then
                'if the player wants to create a game, the system makes sure that the name selected is not already in use
                validate = False
                MsgBox("The file already exists, please enter another Zoo name")
            End If
        Catch
            If StartMenu.CreateLoad = "Load" Then
                'otherwise if the player wants to load a game, the system makes sure that the name selected is in use
                MsgBox("The file does not exist...Please enter the correct Zoo name")
                validate = False
            End If
            If StartMenu.CreateLoad = "Create" Then
                validate = True
            End If
        End Try

        Return validate
    End Function

    Function LoadCurrencyAndPopularity(ByVal FileName As String, ByRef MainCurrency As Integer, ByRef Popularity As Decimal, ByRef Week As Integer, ByRef SeasonSelected As String, ByRef SeasonNumber As Integer, ByRef eventtype As Integer, ByRef eventtime As Integer)
        Dim FileHandle As IO.StreamReader
        Dim FullFileName As String
        Dim Field As String
        Dim inventory As String
        FullFileName = FileName & ".txt"
        'In here the file is openned and the data is extracted. However, the Field and inventory information are not returned as they have been returned in another function
        Try
            FileHandle = New IO.StreamReader(FullFileName, True)
            Field = FileHandle.ReadLine
            inventory = FileHandle.ReadLine
            MainCurrency = FileHandle.ReadLine
            Popularity = FileHandle.ReadLine
            Week = FileHandle.ReadLine
            SeasonSelected = FileHandle.ReadLine
            SeasonNumber = FileHandle.ReadLine
            eventtype = FileHandle.ReadLine
            eventtime = FileHandle.ReadLine

        Catch
            MsgBox("Error loading in-game currency")
        End Try

        Return MainCurrency
        Return Popularity
        Return Week
        Return SeasonSelected
        Return SeasonNumber
        Return eventtype
        Return eventtime
    End Function

    Function LoadInventory(ByVal FileName As String, ByRef inventory As List(Of String)) As List(Of String)
        Dim FileHandle As IO.StreamReader
        Dim listOfItems() As String
        Dim allItems As String
        Dim FullFileName As String
        Dim Field As String
        FullFileName = FileName & ".txt"
        'In here the inventory data is extracted from the file. The field information is also extracted but this one is not sent as it has been sent already
        Try
            FileHandle = New IO.StreamReader(FullFileName, True)
            Field = FileHandle.ReadLine
            allItems = FileHandle.ReadLine
            listOfItems = allItems.Split(",")
            For i = 0 To listOfItems.Count - 2      'the limit is set to the number of items on the list - 2 because in the file, every item is followed by ","
                'therefore the system considers the last value as an empty value.
                inventory.Add(listOfItems(i))
            Next
            If allItems = "" Then
                inventory.Clear()
            End If
        Catch
            MsgBox("Error loading in-game inventory")
        End Try

        Return inventory
    End Function

    Function LoadFile(ByVal FileName As String, TbLPField As TableLayoutPanel)
        Dim Row As Integer
        Dim Column As Integer
        Dim FileHandle As IO.StreamReader
        Dim FullFileName As String
        Dim count As Integer = 0
        FullFileName = FileName & ".txt"
        'in here the information for the field is extracted and sent to the main form. 
        Try
            FileHandle = New IO.StreamReader(FullFileName)
            'all the information for the field is stored in a variable
            Dim WholeField As String = FileHandle.ReadLine
            'then the values are split into an array using the symbol "|" as a divider.
            Dim SelectedItem() As String = WholeField.Split("|")
            For Column = 0 To TbLPField.ColumnCount - 1
                For Row = 0 To TbLPField.RowCount - 1
                    Dim Cell As Button = TbLPField.GetControlFromPosition(Column, Row)
                    'for every cell in the Field table, an item will be placed from the SelectedItem array.
                    Select Case SelectedItem(count)
                        Case "Path"
                            Cell.BackgroundImage = My.Resources.stonefloor
                            Cell.Tag = "Path" 'do this for the rest of the options
                            count += 1
                        Case "Rhino"
                            Cell.BackgroundImage = My.Resources.rhinoceros
                            Cell.Tag = "Rhino"
                            count += 1
                        Case "Snake"
                            Cell.BackgroundImage = My.Resources.snake
                            Cell.Tag = "Snake"
                            count += 1
                        Case "Hippo"
                            Cell.BackgroundImage = My.Resources.hippopotamus
                            Cell.Tag = "Hippo"
                            count += 1
                        Case "Lion"
                            Cell.BackgroundImage = My.Resources.lion
                            Cell.Tag = "Lion"
                            count += 1
                        Case "Zebra"
                            Cell.BackgroundImage = My.Resources.zebra
                            Cell.Tag = "Zebra"
                            count += 1
                        Case "Dolphin"
                            Cell.BackgroundImage = My.Resources.dolphin
                            Cell.Tag = "Dolphin"
                            count += 1

                        Case "Toilet"
                            Cell.BackgroundImage = My.Resources.toilet
                            Cell.Tag = "Toilet"
                            count += 1
                        Case "Popcorn_Shop"
                            Cell.BackgroundImage = My.Resources.popcorn
                            Cell.Tag = "Popcorn_Shop"
                            count += 1
                        Case "Balloon_Shop"
                            Cell.BackgroundImage = My.Resources.balloons
                            Cell.Tag = "Balloon_Shop"
                            count += 1
                        Case "Giftshop"
                            Cell.BackgroundImage = My.Resources.gift
                            Cell.Tag = "Giftshop"
                            count += 1
                        Case "Drink_Shop"
                            Cell.BackgroundImage = My.Resources.drink
                            Cell.Tag = "Drink_Shop"
                            count += 1
                        Case "Burger_Shop"
                            Cell.BackgroundImage = My.Resources.burger
                            Cell.Tag = "Burger_Shop"
                            count += 1
                    End Select
                    TbLPField.GetControlFromPosition(Column, Row).BackgroundImage = Cell.BackgroundImage
                    TbLPField.GetControlFromPosition(Column, Row).Tag = Cell.Tag
                Next
            Next
            FileHandle.Close()
        Catch
            MsgBox("Error loading")
        End Try

        Return TbLPField
    End Function

    Function LoadAnimalsInUse(ByVal FileName As String, ByRef AnimalsInUse As List(Of Animal), ByRef BuildingsInUse As List(Of Building), ByRef EmployersInUse As List(Of String))
        Dim FileHandle As IO.StreamReader
        Dim FullFileName As String
        Dim listOfAnimals() As String
        Dim allanimals As String
        Dim allbuildings As String
        Dim allemployers As String
        Dim Features() As String
        Dim listOfBuildings() As String
        Dim listOfEmployers() As String
        Dim Field, inventory, SeasonSelected As String
        Dim MainCurrency, Popularity, Week, SeasonNumber, eventtype, eventtime As Integer
        'in here the animals in use, buildings in use and employers in use are sent to the main form
        FullFileName = FileName & ".txt"
        Try
            FileHandle = New IO.StreamReader(FullFileName, True)
            'All the previous values have to be read first but they are not sent again to the Simulation form.
            Field = FileHandle.ReadLine
            inventory = FileHandle.ReadLine
            MainCurrency = FileHandle.ReadLine
            Popularity = FileHandle.ReadLine
            Week = FileHandle.ReadLine
            SeasonSelected = FileHandle.ReadLine
            SeasonNumber = FileHandle.ReadLine
            eventtype = FileHandle.ReadLine
            eventtime = FileHandle.ReadLine
            allanimals = FileHandle.ReadLine
            allbuildings = FileHandle.ReadLine
            allemployers = FileHandle.ReadLine
            listOfAnimals = allanimals.Split(",")
            listOfBuildings = allbuildings.Split(",")
            listOfEmployers = allemployers.Split(",")
            For x = 0 To listOfAnimals.Count - 2
                'Similar to the inventory function, the process of extracting the objects and their properties is the same. 
                'With "," as dividers between objects and "/" as dividers for stats inside the object
                Features = listOfAnimals(x).Split("/")
                AnimalsInUse.Add(New Animal With {.Name = Features(0), .Nickname = Features(1), .Health = Features(2), .Food = Features(3), .Hygiene = Features(4), .Water = Features(5), .Love = Features(6)})
            Next
            For x = 0 To listOfBuildings.Count - 2
                Features = listOfBuildings(x).Split("/")
                BuildingsInUse.Add(New Building With {.Name = Features(0), .Health = Features(1), .Hygiene = Features(2)})
            Next
            For x = 0 To listOfEmployers.Count - 2
                EmployersInUse.Add(listOfEmployers(x))
            Next
        Catch
            MsgBox("Error loading in-game Animals in use.")
        End Try

        Return AnimalsInUse
        Return BuildingsInUse
        Return EmployersInUse
    End Function

End Module
