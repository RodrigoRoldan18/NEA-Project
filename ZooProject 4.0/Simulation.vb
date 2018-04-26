Imports ZooProject_4._0

Public Class Simulation
    Implements ICore
    Property Season As New List(Of String)
    Property ItemsInZoo As Integer
    Property PublicOption As Integer
    Property PublicCurrentObject As Integer
    Property OldItems As Integer
    Property EventPlus As Decimal
    Property ObjectSelected As String
    Property ObjectSelectedCount As Integer
    Property OriginalObSelCount As Integer
    Property OriginalWeek As Integer

    Private ShopMenuForm As ShopMenu
    Private InventoryShowForm As InventoryForm
    Private ObjectStatsForm As ObjectsStats

    Public Property FileName As String
    Property SeasonNumber As Integer
    Property EventType As Integer
    Property EventTime As Integer
    Public Property Week As Integer Implements ICore.Week
    Public Property MainCurrency As Integer Implements ICore.MainCurrency
    Public Property Inventory As New List(Of String) Implements ICore.Inventory 'I added the new feature (as integer) instead of (as object)' 
    Public Property Popularity As Decimal Implements ICore.Popularity
    Public Property EmployersInUse As New List(Of String) Implements ICore.EmployersInUse
    Public Property AnimalsInUse As New List(Of Animal) Implements ICore.AnimalsInUse
    Public Property BuildingsInUse As New List(Of Building) Implements ICore.BuildingsInUse
    Public Property SeasonSelected As String Implements ICore.SeasonSelected

    Public Sub New(ByVal FileNameOriginal As String, ByVal CreateLoad As String)
        ' This call is required by the designer.
        InitializeComponent()
        'CREATE is false LOAD is true
        Me.Text = FileNameOriginal
        FileName = FileNameOriginal
        If CreateLoad = "Load" Then
            'If the player decided to load a game, then the file is accessed and the data is extracted. 
            ModuleLoad.LoadFile(FileName, TbLPField)
            Inventory = ModuleLoad.LoadInventory(FileName, Inventory)
            ModuleLoad.LoadCurrencyAndPopularity(FileName, MainCurrency, Popularity, Week, SeasonSelected, SeasonNumber, EventType, EventTime)
            ModuleLoad.LoadAnimalsInUse(FileName, AnimalsInUse, BuildingsInUse, EmployersInUse)
        Else
            'If the player decided to create a game, then the important properties will be set to the original values.
            Week = 1
            Popularity = 1
            ItemsInZoo = 0
            EventType = 0
            EventTime = 0
            EventPlus = 1
            ObjectSelected = ""
            PrepareSeasons(Season, SeasonNumber)
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New()
        ' This call is required by the designer.
        'If the player decides to look at the tutorial, then the form will be initialised with this subroutine
        InitializeComponent()
        Me.Text = "Tutorial"
        LbCurrency.Text = "Your currency is: " & MainCurrency
        PrepareSeasons(Season, SeasonNumber)
        LbSeason.Text = "Season: " & SeasonSelected
        Week = 1
        LbWeek.Text = "Week: " & Week
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Function PrepareSeasons(ByRef Season As List(Of String), ByRef SeasonNumber As Integer)
        'The season will be selected at random if the player is creating a game
        Season.Add("Spring")
        Season.Add("Summer")
        Season.Add("Autumn")
        Season.Add("Winter")
        If Week = Nothing Then
            Week = 0
        End If
        If Len(SeasonSelected) = 0 Then
            Randomize()
            Dim RandomNumber As Integer
            RandomNumber = Math.Round(Rnd() * 3)
            SeasonSelected = Season(RandomNumber)
        End If
        Return Season
        Return SeasonSelected
        Return Week
        Return SeasonNumber
    End Function
    Private Function CheckEvent(ByRef EventPlus As Decimal) As Integer
        'In case the player has an event active, the subroutine will check what event it is and say how long it is active for. 
        If EventType = 1 Then
            EventPlus = 1.5
            LbEvent.Text = "The event: Entry Discount is active for: " & EventTime & " weeks"
            EventTime -= 1
            If EventTime = 0 Then
                EventType = 0
            End If
            Return EventPlus
        ElseIf EventType = 2 Then
            EventPlus = 2
            LbEvent.Text = "The event: Season Event is active for: " & EventTime & " weeks"
            EventTime -= 1
            If EventTime = 0 Then
                EventType = 0
            End If
            Return EventPlus
        Else
            LbEvent.Hide()
        End If
        Return EventType
    End Function
    Private Function Currency(ByVal EventPlus As Decimal, ByVal Popularity As Decimal) As Integer
        'The currency is updated every week giving the player money depending on the popularity and if there is an event active. 
        MainCurrency = MainCurrency + ((Popularity * EventPlus) * 1000)
        LbCurrency.Text = "Your currency is: " & MainCurrency
        Return MainCurrency
    End Function

    Private Sub BtShop_Click(sender As Object, e As EventArgs) Handles BtShop.Click
        'When the player presses the button, if the text of the button says "Shop Menu", then a form will be open to display the shop
        If BtShop.Text = "Shop Menu" Then
            ShopMenuForm = New ShopMenu(Me)
            ShopMenuForm.Show()
            Me.Hide()
        ElseIf BtShop.Text = "Back" Then
            'If the button otherwise says "Back", then it means that the player wants to remove the animals that have just been placed on the field.
            'therefore the system removes the objects placed from the lists and from the tablelayoutpanel. 
            For Each ControlTable As Control In TbLPField.Controls
                If OriginalObSelCount > 0 And ObjectSelectedCount = 0 Then
                    If ControlTable.Tag = ObjectSelected Then
                        ControlTable.Tag = "Path"
                        ControlTable.BackgroundImage = My.Resources.stonefloor
                        OriginalObSelCount -= 1
                        If ObjectSelected = "Snake" Or ObjectSelected = "Rhino" Or ObjectSelected = "Hippo" Or ObjectSelected = "Lion" Or ObjectSelected = "Zebra" Or ObjectSelected = "Dolphin" Then
                            Dim AnimalCategorySearch = From AnimalLive As Animal In AnimalsInUse Where AnimalLive.GetName = ObjectSelected
                            AnimalsInUse.Remove(AnimalCategorySearch(0))
                        ElseIf ObjectSelected = "Toilet" Or ObjectSelected = "Popcorn_Shop" Or ObjectSelected = "Balloon_Shop" Or ObjectSelected = "Giftshop" Or ObjectSelected = "Drink_Shop" Or ObjectSelected = "Burger_Shop" Then
                            Dim BuildingCategorySearch = From BuildingLive As Building In BuildingsInUse Where BuildingLive.GetName = ObjectSelected
                            BuildingsInUse.Remove(BuildingCategorySearch(0))
                        End If
                        'then the object removed is added back to the inventory list. 
                        Inventory.Add(ObjectSelected)
                    End If
                ElseIf ObjectSelectedCount > 0 Then
                    'this is the same as the one above.
                    If ControlTable.Tag = ObjectSelected Then
                        ControlTable.Tag = "Path"
                        ControlTable.BackgroundImage = My.Resources.stonefloor
                        ObjectSelectedCount -= 1
                        If ObjectSelected = "Snake" Or ObjectSelected = "Rhino" Or ObjectSelected = "Hippo" Or ObjectSelected = "Lion" Or ObjectSelected = "Zebra" Or ObjectSelected = "Dolphin" Then
                            Dim AnimalCategorySearch = From AnimalLive As Animal In AnimalsInUse Where AnimalLive.GetName = ObjectSelected
                            AnimalsInUse.Remove(AnimalCategorySearch(0))
                        ElseIf ObjectSelected = "Toilet" Or ObjectSelected = "Popcorn_Shop" Or ObjectSelected = "Balloon_Shop" Or ObjectSelected = "Giftshop" Or ObjectSelected = "Drink_Shop" Or ObjectSelected = "Burger_Shop" Then
                            Dim BuildingCategorySearch = From BuildingLive As Building In BuildingsInUse Where BuildingLive.GetName = ObjectSelected
                            BuildingsInUse.Remove(BuildingCategorySearch(0))
                        End If
                        Inventory.Add(ObjectSelected)
                    End If
                    If ObjectSelectedCount = 0 Then
                        'once there are no more objects to remove, the properties are resetted
                        OriginalObSelCount = 0
                    End If
                End If
            Next
            ObjectSelected = ""
            InventoryShowForm.Show()
        End If
    End Sub

    Private Sub BtMove_Click(sender As Object, e As EventArgs) Handles BtMove.Click
        'The layout of the form is changed to inform the player that now he can move objects around the field
        If BtMove.Text = "Move Objects" Then
            BtNextWeek.Text = "Finish"
            LbMenuOptions.Text = "Move Objects"
            BtShop.Hide()
            BtMove.Hide()
            BtSell.Hide()
            BtAnimalStats.Hide()
            BtBuildingStats.Hide()
            BtEmployerStats.Hide()
            BtPopularity.Hide()
            BtInventory.Hide()
        ElseIf BtMove.Text = "Place Object" Then
            'When the player goes to the next week, the player can place items from the inventory to the field.
            'Here the system opens the inventory form again for the player to select a new object to place.
            If Inventory.Count <> 0 Then
                InventoryShowForm = New InventoryForm(Me)
                InventoryShowForm.Show()
                Me.Hide()
            Else
                MsgBox("You don't have more items in your inventory")
            End If
        End If

    End Sub

    Private Sub BtAnimalStats_Click(sender As Object, e As EventArgs) Handles BtAnimalStats.Click
        If BtAnimalStats.Text = "Check Animal Stats" Then
            'Another form is openned to see the stats of the animals. 
            If AnimalsInUse.Count <> 0 Then
                'If inventory is nothing then       this was previously used 
                ObjectStatsForm = New ObjectsStats(AnimalsInUse)
                ObjectStatsForm.Show()
            Else
                'If the player has no animals on the field, then the system ddisplays this 
                MsgBox("You have no animals in your zoo")
            End If
        ElseIf BtAnimalStats.Text = "Continue" Then
            'After the player pressed "Go to next week" and placed the animals on the field. Some subroutines will be called to alter the field and the properties.
            ObjectSelected = ""
            ItemsInZoo = PrepareNextWeek.CheckItemsInZoo(ItemsInZoo, TbLPField)
            PrepareNextWeek.TimeEffect(AnimalsInUse, BuildingsInUse)
            MainCurrency = PrepareNextWeek.BuildingOutcome(MainCurrency, BuildingsInUse, Popularity, EventPlus)
            LbCurrency.Text = "Your currency is: " & MainCurrency
            If ItemsInZoo <= OldItems Then
                'If the player did not place anything on the field, then the popularity decreases as a punishment
                Popularity = Popularity - 0.2
            End If
            ItemsInZoo = 0
            PrepareNextWeek.RestoreAnimal(AnimalsInUse, MainCurrency, TbLPField, EmployersInUse)
            PrepareNextWeek.Diseases(AnimalsInUse)
            PrepareNextWeek.KillAnimal(AnimalsInUse, TbLPField)
            PrepareNextWeek.CheckSurrounding(TbLPField, AnimalsInUse)
            If Week Mod 3 = 0 Then
                'Every three weeks, the player might be given a special task that has to be completed
                PublicOption = PrepareNextWeek.PublicOpinion(TbLPField, PublicCurrentObject)
            End If
            If PublicOption = 2 Or PublicOption = 4 Or PublicOption = 6 Or PublicOption = 8 Then
                'If the player has a current task, he will be reminded every week.
                PrepareNextWeek.CheckPublicOpinion(Popularity, MainCurrency, PublicOption, PublicCurrentObject, TbLPField, Week, OriginalWeek)
            End If
            'The original layout of the form is restored. 
            RestoreOriginalUI()
        End If

    End Sub

    Private Sub BtBuildingStats_Click(sender As Object, e As EventArgs) Handles BtBuildingStats.Click
        If BuildingsInUse.Count <> 0 Then
            'Another form is openned to see the stats of the buildings if the player has some on the field
            'If inventory is nothing then       this was previously used 
            ObjectStatsForm = New ObjectsStats(BuildingsInUse)
            ObjectStatsForm.Show()
        Else
            'Otherwise this message will be displayed
            MsgBox("You have no buildings in your zoo")
        End If
    End Sub

    Private Sub BtEmployerStats_Click(sender As Object, e As EventArgs) Handles BtEmployerStats.Click
        If EmployersInUse.Count <> 0 Then
            'Another form is openned to see the employers and how many animals can be treated
            'If inventory is nothing then       this was previously used 
            ObjectStatsForm = New ObjectsStats(EmployersInUse)
            ObjectStatsForm.Show()
        Else
            MsgBox("You have no employers working in your zoo")
        End If
    End Sub

    Private Sub BtSell_Click(sender As Object, e As EventArgs) Handles BtSell.Click
        'The layout of the form is changed to inform the player that now objects on the field can be sold
        BtNextWeek.Text = "Finish"
        LbMenuOptions.Text = "Sell Objects"
        BtShop.Hide()
        BtMove.Hide()
        BtSell.Hide()
        BtAnimalStats.Hide()
        BtBuildingStats.Hide()
        BtEmployerStats.Hide()
        BtPopularity.Hide()
        BtInventory.Hide()
    End Sub

    Private Sub BtPopularity_Click(sender As Object, e As EventArgs) Handles BtPopularity.Click
        'The popularity of the zoo is displayed
        MsgBox("The popularity of the zoo is: " & Popularity)
    End Sub

    Private Sub BtNextWeek_Click(sender As Object, e As EventArgs) Handles BtNextWeek.Click
        If BtNextWeek.Text = "Go to next week" Then
            If Inventory.Count <> 0 Then
                'If the player has items in the inventory. The player can access the list and select one type of object
                AnimalsInUse = PrepareNextWeek.SortOrderInList(AnimalsInUse)
                InventoryShowForm = New InventoryForm(Me)
                InventoryShowForm.Show()
            Else
                'If the player does not have items in the inventory, then functions will be called to alter the game and go to the next week.
                ObjectSelected = ""
                ItemsInZoo = PrepareNextWeek.CheckItemsInZoo(ItemsInZoo, TbLPField)
                PrepareNextWeek.TimeEffect(AnimalsInUse, BuildingsInUse)
                MainCurrency = PrepareNextWeek.BuildingOutcome(MainCurrency, BuildingsInUse, Popularity, EventPlus)
                LbCurrency.Text = "Your currency is: " & MainCurrency
                If ItemsInZoo <= OldItems Then
                    Popularity = Popularity - 0.2
                End If
                ItemsInZoo = 0

                PrepareNextWeek.RestoreAnimal(AnimalsInUse, MainCurrency, TbLPField, EmployersInUse)
                PrepareNextWeek.Diseases(AnimalsInUse)
                PrepareNextWeek.KillAnimal(AnimalsInUse, TbLPField)
                PrepareNextWeek.CheckSurrounding(TbLPField, AnimalsInUse)
                If Week Mod 3 = 0 Then
                    PublicOption = PrepareNextWeek.PublicOpinion(TbLPField, PublicCurrentObject)
                End If
                If PublicOption = 2 Or PublicOption = 4 Or PublicOption = 6 Or PublicOption = 8 Then
                    PrepareNextWeek.CheckPublicOpinion(Popularity, MainCurrency, PublicOption, PublicCurrentObject, TbLPField, Week, OriginalWeek)
                End If
                RestoreOriginalUI()
            End If
        ElseIf BtNextWeek.Text = "Finish" Then
            'The layout of the form is restored to the original layout
            BtNextWeek.Text = "Go to next week"
            LbMenuOptions.Text = "Select one of the" & vbNewLine & "following options"
            LbCurrency.Text = "Your currency is: " & MainCurrency
            BtShop.Show()
            BtMove.Show()
            BtSell.Show()
            BtAnimalStats.Show()
            BtBuildingStats.Show()
            BtEmployerStats.Show()
            BtPopularity.Show()
            BtInventory.Show()
        End If
    End Sub

    Private Sub BtInventory_Click(sender As Object, e As EventArgs) Handles BtInventory.Click
        If Inventory.Count <> 0 Then
            'The inventory form is openned to display the items in the list. 
            'If inventory is nothing then       this was previously used 
            InventoryShowForm = New InventoryForm(Inventory)
            InventoryShowForm.Show()
        Else
            MsgBox("You have no items in your inventory")
        End If
    End Sub

    Private Sub Display_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When the form is loaded, it checks the important properties to check if anything needs to be updated
        If Week Mod 8 = 0 Then
            SeasonNumber += 1
            If SeasonNumber > 3 Then
                SeasonNumber = 0
            End If
            SeasonSelected = Season(SeasonNumber)
        End If
        CheckEvent(EventPlus)
        Currency(EventPlus, Popularity)
        LbCurrency.Text = "Your currency is: " & MainCurrency
        LbSeason.Text = "Season: " & SeasonSelected
        LbWeek.Text = "Week: " & Week
    End Sub

    Private Sub MyButtons_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click, Button43.Click, Button44.Click, Button45.Click, Button46.Click, Button47.Click, Button48.Click, Button49.Click, Button50.Click, Button51.Click, Button52.Click, Button53.Click, Button54.Click, Button55.Click, Button56.Click, Button57.Click, Button58.Click, Button59.Click, Button60.Click, Button61.Click, Button62.Click, Button63.Click, Button64.Click, Button65.Click, Button66.Click, Button67.Click, Button68.Click, Button69.Click, Button70.Click, Button71.Click, Button72.Click, Button73.Click, Button74.Click, Button75.Click, Button76.Click, Button77.Click, Button78.Click, Button79.Click, Button80.Click, Button81.Click, Button82.Click, Button83.Click, Button84.Click, Button85.Click, Button86.Click, Button87.Click, Button88.Click, Button89.Click, Button90.Click, Button91.Click, Button92.Click, Button93.Click, Button94.Click, Button95.Click, Button96.Click, Button97.Click, Button98.Click, Button99.Click, Button100.Click
        Dim myButton As Button = CType(sender, Button)
        If LbMenuOptions.Text = "Move Objects" Then
            'When the player is moving objects on the field. 
            If ObjectSelected = "" Then
                'If the player hasn't selected anything, then the button clicked will become "Path" and the system will store the name of the previous item that was representing that button
                ObjectSelected = myButton.Tag
                myButton.Tag = "Path"
                myButton.BackgroundImage = My.Resources.stonefloor
            ElseIf ObjectSelected <> "" Then
                'If the player has selected an object before, it will be placed where the player has just clicked.
                If myButton.Tag = "Path" Then
                    Select Case ObjectSelected
                        Case "Rhino"
                            myButton.BackgroundImage = My.Resources.rhinoceros
                            myButton.Tag = "Rhino"
                        Case "Snake"
                            myButton.BackgroundImage = My.Resources.snake
                            myButton.Tag = "Snake"
                        Case "Hippo"
                            myButton.BackgroundImage = My.Resources.hippopotamus
                            myButton.Tag = "Hippo"
                        Case "Lion"
                            myButton.BackgroundImage = My.Resources.lion
                            myButton.Tag = "Lion"
                        Case "Zebra"
                            myButton.BackgroundImage = My.Resources.zebra
                            myButton.Tag = "Zebra"
                        Case "Dolphin"
                            myButton.BackgroundImage = My.Resources.dolphin
                            myButton.Tag = "Dolphin"

                        Case "Toilet"
                            myButton.BackgroundImage = My.Resources.toilet
                            myButton.Tag = "Toilet"
                        Case "Popcorn_Shop"
                            myButton.BackgroundImage = My.Resources.popcorn
                            myButton.Tag = "Popcorn_Shop"
                        Case "Balloon_Shop"
                            myButton.BackgroundImage = My.Resources.balloons
                            myButton.Tag = "Balloon_Shop"
                        Case "Giftshop"
                            myButton.BackgroundImage = My.Resources.gift
                            myButton.Tag = "Giftshop"
                        Case "Drink_Shop"
                            myButton.BackgroundImage = My.Resources.drink
                            myButton.Tag = "Drink_Shop"
                        Case "Burger_Shop"
                            myButton.BackgroundImage = My.Resources.burger
                            myButton.Tag = "Burger_Shop"
                    End Select
                    ObjectSelected = ""
                Else
                    'Only if the button represents a "Path" otherwise this message will be displayed and the player will have to select a new location
                    MsgBox("There is an animal placed there, please select other cell")
                End If
            End If
        End If
        If LbMenuOptions.Text = "Sell Objects" Then
            'When the player is selling objects from the field.
            If ObjectSelected = "" Then
                'If the player hasn't selected an item before, the button clicked will become "Path" and the object that was represented by that button will be stored
                ObjectSelected = myButton.Tag
                myButton.Tag = "Path"
                myButton.BackgroundImage = My.Resources.stonefloor
                'The currency will be updated adding the price of the object that has just been sold
                MainCurrency = MainCurrency + PriceofObject(ObjectSelected)
                If ObjectSelected = "Snake" Or ObjectSelected = "Rhino" Or ObjectSelected = "Hippo" Or ObjectSelected = "Lion" Or ObjectSelected = "Zebra" Or ObjectSelected = "Dolphin" Then
                    Dim Animal As Animal
                    Dim AnimalCategorySearch = From AnimalSelected In AnimalsInUse Where AnimalSelected.Name = ObjectSelected 'LINQ
                    'If the object sold was an animal, then an animal from the same species will be removed from the list
                    Animal = AnimalCategorySearch(0)
                    AnimalsInUse.Remove(Animal)
                ElseIf ObjectSelected = "Toilet" Or ObjectSelected = "Popcorn_Shop" Or ObjectSelected = "Balloon_Shop" Or ObjectSelected = "Giftshop" Or ObjectSelected = "Drink_Shop" Or ObjectSelected = "Burger_Shop" Then
                    Dim Building As Building
                    Dim BuildingCategorySearch = From BuildingSelected In BuildingsInUse Where BuildingSelected.Name = ObjectSelected
                    'Similarly, if the object was a building, then a building from the same building type will be removed from the list
                    Building = BuildingCategorySearch(0)
                    BuildingsInUse.Remove(Building)
                End If
                MsgBox("Your currency is now: £" & MainCurrency)
                ObjectSelected = ""
            End If
        End If
        If ObjectSelected <> "" Then
            'The button to continue will be visible if the player already placed the object when the player selected the option "Move Objects"
            'This is a way of error checking to make sure that no animals are lost when manipulating the field
            BtNextWeek.Visible = False
        ElseIf ObjectSelected = "" Then
            BtNextWeek.Visible = True
        End If
        If ObjectSelectedCount <> 0 Then
            'This part is used when the player clicked on "Go to next week" and already selected what object is going to place on the field
            If OriginalObSelCount = 0 Then
                'The quantity of the object is stored here so that the player can only place that number of the same items.
                OriginalObSelCount = ObjectSelectedCount
            End If
            Select Case ObjectSelected
                'Depending on the name of the object, it will have a different representation on the field.
                'Once placed it is then removed from the inventory list and added to the new list as well as removing one from the quantity of the object
                Case "Rhino"
                    myButton.BackgroundImage = My.Resources.rhinoceros
                    myButton.Tag = "Rhino"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)
                Case "Snake"
                    myButton.BackgroundImage = My.Resources.snake
                    myButton.Tag = "Snake"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)
                Case "Hippo"
                    myButton.BackgroundImage = My.Resources.hippopotamus
                    myButton.Tag = "Hippo"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)
                Case "Lion"
                    myButton.BackgroundImage = My.Resources.lion
                    myButton.Tag = "Lion"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)
                Case "Zebra"
                    myButton.BackgroundImage = My.Resources.zebra
                    myButton.Tag = "Zebra"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)
                Case "Dolphin"
                    myButton.BackgroundImage = My.Resources.dolphin
                    myButton.Tag = "Dolphin"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddAnimal(ObjectSelected, AnimalsInUse)

                Case "Toilet"
                    myButton.BackgroundImage = My.Resources.toilet
                    myButton.Tag = "Toilet"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
                Case "Popcorn_Shop"
                    myButton.BackgroundImage = My.Resources.popcorn
                    myButton.Tag = "Popcorn_Shop"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
                Case "Balloon_Shop"
                    myButton.BackgroundImage = My.Resources.balloons
                    myButton.Tag = "Balloon_Shop"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
                Case "Giftshop"
                    myButton.BackgroundImage = My.Resources.gift
                    myButton.Tag = "Giftshop"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
                Case "Drink_Shop"
                    myButton.BackgroundImage = My.Resources.drink
                    myButton.Tag = "Drink_Shop"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
                Case "Burger_Shop"
                    myButton.BackgroundImage = My.Resources.burger
                    myButton.Tag = "Burger_Shop"
                    ObjectSelectedCount -= 1
                    Inventory.Remove(ObjectSelected)
                    PrepareNextWeek.AddBuilding(ObjectSelected, BuildingsInUse)
            End Select
        End If

    End Sub

    Function PriceofObject(ByVal ObjectSelected As String) As Integer
        'The price of the objects when sold are determined here
        Dim ObjectOrAnimal As String = ObjectSelected
        Dim price As Integer = 0
        If ObjectOrAnimal = "Rhino" Then
            price += 10

        ElseIf ObjectOrAnimal = "Snake" Then
            price += 20

        ElseIf ObjectOrAnimal = "Hippo" Then
            price += 50

        ElseIf ObjectOrAnimal = "Lion" Then
            price += 100

        ElseIf ObjectOrAnimal = "Zebra" Then
            price += 150

        ElseIf ObjectOrAnimal = "Dolphin" Then
            price += 200

        ElseIf ObjectOrAnimal = "Toilet" Then
            price += 20

        ElseIf ObjectOrAnimal = "Popcorn_Shop" Then
            price += 50

        ElseIf ObjectOrAnimal = "Balloon_Shop" Then
            price += 50

        ElseIf ObjectOrAnimal = "Giftshop" Then
            price += 100

        ElseIf ObjectOrAnimal = "Drink_Shop" Then
            price += 50

        ElseIf ObjectOrAnimal = "Burger_Shop" Then
            price += 50

        End If
        Return price
    End Function

    Private Sub RestoreOriginalUI()
        'The original layout of the form is restored here
        LbMenuOptions.Text = "Select one of" & vbNewLine & "the following options:"
        BtShop.Text = "Shop Menu"
        BtMove.Text = "Move Objects"
        BtAnimalStats.Text = "Check Animal Stats"
        BtBuildingStats.Text = "Check Building Stats"
        BtEmployerStats.Text = "Check Employers"
        BtSell.Text = "Sell Objects"
        BtPopularity.Text = "Check Popularity"
        BtInventory.Text = "Check Inventory"
        BtNextWeek.Text = "Go to next week"

        BtShop.Show()
        BtMove.Show()
        BtAnimalStats.Show()
        BtBuildingStats.Show()
        BtEmployerStats.Show()
        BtInventory.Show()
        BtPopularity.Show()
        BtSell.Show()
        BtNextWeek.Show()
        'It also checks if there have been any changes like any new events active calling this function
        UpdateData()

    End Sub

    Private Sub BtExit_Click(sender As Object, e As EventArgs) Handles BtExit.Click
        Dim ObjectsInField As New List(Of String)
        Dim RowCount As Integer = TbLPField.RowCount
        Dim ColumnCount As Integer = TbLPField.ColumnCount
        'When the player decides to exit the game, all the objects on the field are stored in a list
        For Column = 0 To ColumnCount - 1
            For Row = 0 To RowCount - 1
                Dim CellObject As Control = TbLPField.GetControlFromPosition(Column, Row)
                Select Case CellObject.Tag
                    Case "Path"
                        ObjectsInField.Add("Path")
                    Case "Rhino"
                        ObjectsInField.Add("Rhino")
                    Case "Snake"
                        ObjectsInField.Add("Snake")
                    Case "Hippo"
                        ObjectsInField.Add("Hippo")
                    Case "Lion"
                        ObjectsInField.Add("Lion")
                    Case "Zebra"
                        ObjectsInField.Add("Zebra")
                    Case "Dolphin"
                        ObjectsInField.Add("Dolphin")

                    Case "Toilet"
                        ObjectsInField.Add("Toilet")
                    Case "Popcorn_Shop"
                        ObjectsInField.Add("Popcorn_Shop")
                    Case "Balloon_Shop"
                        ObjectsInField.Add("Balloon_Shop")
                    Case "GiftShop"
                        ObjectsInField.Add("Giftshop")
                    Case "Drink_Shop"
                        ObjectsInField.Add("Drink_Shop")
                    Case "Burger_Shop"
                        ObjectsInField.Add("Burger_Shop")
                End Select
            Next
        Next
        'Then all the important properties are sent and saved to a text file.
        If Me.Text <> "Tutorial" Then
            FileName = ModuleSave.SaveZoo(FileName, ObjectsInField)
            ModuleSave.SaveInventory(Inventory, FileName)
            ModuleSave.SaveCurrencyAndPopularity(MainCurrency, Popularity, FileName, Week, SeasonSelected, SeasonNumber, EventType, EventTime)
            ModuleSave.SaveAnimalsInUse(AnimalsInUse, FileName, BuildingsInUse, EmployersInUse)
            Me.Dispose()
        Else
            Dim StartAgain As StartMenu
            StartAgain = New StartMenu
            StartAgain.Show()
            Me.Dispose()
        End If

    End Sub

    Private Sub UpdateData()
        'In here the system checks and updates the labels of the form to display the values up to date.
        Week += 1
        If Week Mod 8 = 0 Then
            SeasonNumber += 1
            If SeasonNumber > 3 Then
                SeasonNumber = 0
            End If
            SeasonSelected = Season(SeasonNumber)
        End If
        CheckEvent(EventPlus)
        MainCurrency = Currency(EventPlus, Popularity)
        LbCurrency.Text = "Your currency is: " & MainCurrency
        LbSeason.Text = "Season: " & SeasonSelected
        LbWeek.Text = "Week: " & Week
    End Sub

    Private Sub BtPubTask_Click(sender As Object, e As EventArgs) Handles BtPubTask.Click
        'In case the player has a special task and wants to see it again.
        If PublicOption = 2 Or PublicOption = 4 Or PublicOption = 6 Or PublicOption = 8 Then
            PrepareNextWeek.CheckPublicOpinion(Popularity, MainCurrency, PublicOption, PublicCurrentObject, TbLPField, Week, OriginalWeek)
        Else
            MsgBox("You have no current tasks")
        End If
    End Sub
End Class

''animal icons made by flaticon.com
''https://www.flaticon.com/


