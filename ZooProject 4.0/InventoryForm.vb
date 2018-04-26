Public Class InventoryForm
    Private Simulation As Simulation

    Public Sub New(ByVal inventory As List(Of String))
        ' This call is required by the designer.
        'The form is initialised through here when the player wants to see the inventory
        InitializeComponent()
        If inventory.Count > 1 Then
            SortInventory(inventory)
        End If

        DisplayObjects(inventory)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef data As Simulation)
        ' This call is required by the designer.
        'The form is initialised through here when the player wants to go to the next week and has to place an item
        InitializeComponent()
        Simulation = data
        If Simulation.Inventory.Count > 1 Then
            SortInventory(Simulation.Inventory)
        End If

        DisplaySelectObject(Simulation.Inventory, Simulation.ObjectSelected)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function SortInventory(ByRef Inventory As List(Of String)) As List(Of String)
        'The inventory list is sorted in order
        Dim previtem As String
        Dim selecteditem As String
        Dim count As Integer = 1
        Dim ItemPosition As New List(Of Integer)
        Dim followingitem As String

        For x = 1 To Inventory.Count - 1
            'the second item and the previous one are compared
            previtem = Inventory(x - 1)
            If previtem <> Inventory(x) Then
                'if the objects hav not the same name, the position of the second item is added to a list
                'in order to determine the positions on the inventory where the animals are not the same
                ItemPosition.Add(x - 1)
            End If
            If x = Inventory.Count - 1 Then
                'when the loop reaches the end the system will add the position of the last item to the new list
                ItemPosition.Add(x)
            End If
            count += 1
        Next
        Dim eliminateposition As Integer
        Dim calculateposition As Integer
        For y = 0 To ItemPosition.Count - 1
            'depending on the number of division of objects in the list
            Try
                selecteditem = Inventory(ItemPosition(y))
                'the selected item is the first object after another type of object different to itself
                For z = 1 To ItemPosition.Count - 1
                    eliminateposition = z + y
                    followingitem = Inventory(ItemPosition(eliminateposition))
                    'the system gets the next object from the inventory list
                    If selecteditem = followingitem Then
                        'if the both objects are the same, then the position of the second item is removed from the second list as the type of object is repeated
                        ItemPosition.RemoveAt(eliminateposition)
                    End If
                Next
            Catch

            End Try
            calculateposition = 0
        Next
        Dim OrderedItems As New List(Of String)
        For j = 0 To ItemPosition.Count - 1
            'once the ItemPosition list removed the position of the repeated objects
            Dim ItemName As String
            ItemName = Inventory(ItemPosition(j))
            'the selected item comes from the inventory but the position is determined by the ItemPosition list as it does not have repeated data.
            Dim ItemCategorySearch = From ItemSelected In Inventory Where ItemSelected = ItemName
            'A LINQ table is created to get the quantity of the objects in the original Inventory list
            For Each item In ItemCategorySearch
                'With the name of the object and the quantity obtained, a new ordered list is created
                OrderedItems.Add(item)
            Next
        Next
        'then the inventory list is substituted by the new ordered list
        Inventory = OrderedItems
        Return Inventory
    End Function

    Private Sub DisplayObjects(ByRef Inventory As List(Of String))
        Dim NoofItems As Integer = Inventory.Count
        Dim timesNumber As Integer = 1
        Dim typeofanimal As Integer = 1
        Dim previtem As String
        Dim totalTimesNumber As New List(Of Integer)
        'the items in the inventory will be displayed in the format "x6 Rhinos" for example
        'grouping them in terms of species not displaying them one by one
        If NoofItems > 1 Then
            For x = 1 To (NoofItems - 1)
                previtem = Inventory(x - 1)
                'the second item and the previous one are compared
                If previtem = Inventory(x) Then
                    timesNumber += 1
                    'if the items are the same, the system will keep track of the quantity
                Else
                    'otherwise the program will display the record of the attribute on the list
                    Dim LbQuantity As Label = New Label
                    LbQuantity.Text = "x " & timesNumber
                    LbQuantity.Font = New Drawing.Font("Tahoma", 12)
                    Dim LbObject As Label = New Label
                    LbObject.Text = Inventory(x - 1)
                    LbObject.Font = New Drawing.Font("Tahoma", 12)
                    TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
                    TbLPInventory.Controls.Add(LbObject, 1, typeofanimal)
                    totalTimesNumber.Add(timesNumber)
                    typeofanimal += 1
                    timesNumber = 1
                End If
                If x = (NoofItems - 1) Then
                    'if the list reached the end, then the system will display the object with the current quantity collected
                    Dim LbQuantity As Label = New Label
                    LbQuantity.Text = "x " & timesNumber
                    LbQuantity.Font = New Drawing.Font("Tahoma", 12)
                    Dim LbObject As Label = New Label
                    LbObject.Text = Inventory(x)
                    LbObject.Font = New Drawing.Font("Tahoma", 12)
                    TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
                    TbLPInventory.Controls.Add(LbObject, 1, typeofanimal)
                    totalTimesNumber.Add(timesNumber)
                End If
            Next
        Else
            'if the player has only one item, it will automatically be displayed
            Dim LbQuantity As Label = New Label
            LbQuantity.Text = "x " & timesNumber
            LbQuantity.Font = New Drawing.Font("Tahoma", 12)
            Dim LbObject As Label = New Label
            LbObject.Text = Inventory(0)
            LbObject.Font = New Drawing.Font("Tahoma", 12)
            TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
            TbLPInventory.Controls.Add(LbObject, 1, typeofanimal)
            totalTimesNumber.Add(timesNumber)
        End If

    End Sub

    Private Sub DisplaySelectObject(ByVal Inventory As List(Of String), ByVal ObjectSelected As String)
        ''this is exactly the same as displayobjects but instead of labels, buttons are used so that the user can select an object
        Dim NoofItems As Integer = Inventory.Count
        Dim timesNumber As Integer = 1
        Dim typeofanimal As Integer = 1
        Dim previtem As String
        Dim totalTimesNumber As New List(Of Integer)
        If NoofItems > 1 Then
            For x = 1 To (NoofItems - 1)
                previtem = Inventory(x - 1)
                If previtem = Inventory(x) Then
                    timesNumber += 1
                Else
                    Dim LbQuantity As Label = New Label
                    LbQuantity.Text = "x " & timesNumber
                    LbQuantity.Font = New Drawing.Font("Tahoma", 12)
                    Dim BtObject As Button = New Button
                    BtObject.Text = Inventory(x - 1)
                    BtObject.Font = New Drawing.Font("Tahoma", 12)
                    BtObject.FlatStyle = FlatStyle.Flat
                    BtObject.BackColor = Color.Transparent
                    BtObject.FlatAppearance.MouseOverBackColor = Color.White
                    AddHandler BtObject.Click, AddressOf BtObject_Click
                    TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
                    TbLPInventory.Controls.Add(BtObject, 1, typeofanimal)
                    totalTimesNumber.Add(timesNumber)
                    typeofanimal += 1
                    timesNumber = 1
                End If
                If x = (NoofItems - 1) Then
                    Dim LbQuantity As Label = New Label
                    LbQuantity.Text = "x " & timesNumber
                    LbQuantity.Font = New Drawing.Font("Tahoma", 12)
                    Dim BtObject As Button = New Button
                    BtObject.Text = Inventory(x)
                    BtObject.Font = New Drawing.Font("Tahoma", 12)
                    BtObject.FlatStyle = FlatStyle.Flat
                    BtObject.BackColor = Color.Transparent
                    BtObject.FlatAppearance.MouseOverBackColor = Color.White
                    AddHandler BtObject.Click, AddressOf BtObject_Click
                    TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
                    TbLPInventory.Controls.Add(BtObject, 1, typeofanimal)
                    totalTimesNumber.Add(timesNumber)
                End If
            Next
        Else
            Dim LbQuantity As Label = New Label
            LbQuantity.Text = "x " & timesNumber
            LbQuantity.Font = New Drawing.Font("Tahoma", 12)
            Dim BtObject As Button = New Button
            BtObject.Text = Inventory(0)
            BtObject.Font = New Drawing.Font("Tahoma", 12)
            BtObject.FlatStyle = FlatStyle.Flat
            BtObject.BackColor = Color.Transparent
            BtObject.FlatAppearance.MouseOverBackColor = Color.White
            AddHandler BtObject.Click, AddressOf BtObject_Click
            TbLPInventory.Controls.Add(LbQuantity, 0, typeofanimal)
            TbLPInventory.Controls.Add(BtObject, 1, typeofanimal)
            totalTimesNumber.Add(timesNumber)
        End If
        BtBack.Text = "Don't place items"
        BtBack.Font = New Drawing.Font("Tahoma", 10)
    End Sub
    Private Sub BtObject_Click(sender As Object, e As EventArgs)
        'when the player has selected an object from the inventory list
        Dim ButtonClicked As Button = CType(sender, Button)
        Dim QuantityClicked As Integer
        Dim ItemCategorySearch = From ItemSelected In Simulation.Inventory Where ItemSelected = ButtonClicked.Text
        For Each item In ItemCategorySearch
            QuantityClicked += 1
        Next
        'the name of the item clicked is stored and the quantity is obtained from the inventory list and this information is sent back to the Simulation form
        'the layout of the Simulation form is also changed so that the player knows that an item is expected to be placed on the field
        Simulation.ObjectSelected = ButtonClicked.Text
        Simulation.LbMenuOptions.Text = Simulation.ObjectSelected & " selected"
        Simulation.BtShop.Text = "Back"
        Simulation.BtMove.Text = "Place Object"
        Simulation.BtAnimalStats.Text = "Continue"

        Simulation.ObjectSelectedCount = QuantityClicked
        Simulation.BtBuildingStats.Hide()
        Simulation.BtEmployerStats.Hide()
        Simulation.BtInventory.Hide()
        Simulation.BtPopularity.Hide()
        Simulation.BtSell.Hide()
        Simulation.BtNextWeek.Hide()

        Simulation.Show()
        Me.Hide()

    End Sub

    Private Sub InventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TbLPInventory.Show()
    End Sub

    Private Sub BtBack_Click(sender As Object, e As EventArgs) Handles BtBack.Click
        Me.Dispose()
        'in case the player decides to keep the items in the inventory and not place anything
        If BtBack.Text = "Don't place items" Then
            Simulation.LbMenuOptions.Text = "Items will not be placed"
            Simulation.BtShop.Text = "Back"
            Simulation.BtMove.Text = "Place Object"
            Simulation.BtAnimalStats.Text = "Continue"

            Simulation.BtBuildingStats.Hide()
            Simulation.BtEmployerStats.Hide()
            Simulation.BtInventory.Hide()
            Simulation.BtPopularity.Hide()
            Simulation.BtSell.Hide()
            Simulation.BtNextWeek.Hide()

            Simulation.Show()
            Me.Hide()
        End If
    End Sub
End Class