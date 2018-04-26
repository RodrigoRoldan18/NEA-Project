Public Class ShopMenu
    Public Property MainCurrencyShop As Integer
    Public Property inventoryShop As New List(Of String)
    Public Property eventtypeShop As Integer
    Public Property eventtimeShop As Integer
    Public Property EmployersInUseShop As New List(Of String)
    Public Property QuantityShop As Integer
    Public Property ObjectSelected As String
    Public Property ObjectPrice As Integer

    'maybe change this and implement the interface ICore

    Private Simulation As Simulation

    Public Sub New(data As Simulation)
        ' Esta llamada es exigida por el diseñador.
        'When the form is called by another one it prepares the layout and the values of the properties
        InitializeComponent()
        BtOpt5.Hide()
        BtOpt6.Hide()
        Simulation = data
        MainCurrencyShop = Simulation.MainCurrency
        If Simulation.Inventory IsNot Nothing Then
            inventoryShop = Simulation.Inventory
        End If
        If Simulation.EmployersInUse IsNot Nothing Then
            EmployersInUseShop = Simulation.EmployersInUse
        End If
        eventtypeShop = Simulation.EventType
        eventtimeShop = Simulation.EventTime

        LbCurrency.Text = "Your currency is: " & MainCurrencyShop

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub GetQuantity()
        'Once the player selected an item to buy, the layout is changed to obtain the quantity
        LbTitle.Text = "Please enter a quantity: "
        BtOpt1.Hide()
        BtOpt2.Show()
        BtOpt3.Hide()
        BtOpt4.Hide()
        BtOpt5.Hide()
        BtOpt6.Hide()
        Dim Quantity As New TextBox
        Quantity = New TextBox
        Quantity.Name = "TbxQuantity"
        Quantity.Location = New Point(35, 120)
        Quantity.Size = New Size(325, 33)
        Quantity.Font = New Drawing.Font("Tahoma", 16)

        AddHandler Quantity.KeyPress, AddressOf TextBox1_KeyPress

        Me.Controls.Add(Quantity)

        BtOpt2.Text = "Confirm"
        BtOpt2.Location = New Point(35, 167)
        BtOpt2.Size = New Size(324, 37)

    End Sub

    Private Sub AnimalOption()
        'This changes the layout of the form to display the animals available to purchase
        LbTitle.Text = "Please select one of the animals available:"
        LbCurrency.Text = "Your currency is: " & MainCurrencyShop
        BtOpt1.Text = "Rhino (£1000)"
        BtOpt2.Text = "Snake (£200)"
        BtOpt3.Text = "Hippo (£1200)"
        BtOpt4.Text = "Lion (£1500)"
        BtOpt5.Text = "Zebra (£2000)"
        BtOpt6.Text = "Dolphin (£3000)"

        BtOpt1.Show()
        BtOpt2.Show()
        BtOpt3.Show()
        BtOpt4.Show()
        BtOpt5.Show()
        BtOpt6.Show()

    End Sub

    Private Sub BuildingOption()
        'This also changes the layout of the form to display the buildings available to buy
        LbTitle.Text = "Please select one of the buildings available:"
        LbCurrency.Text = "Your currency is: " & MainCurrencyShop
        BtOpt1.Text = "Toilet (£200)"
        BtOpt2.Text = "Popcorn Shop (£500)"
        BtOpt3.Text = "Balloon Shop (£300)"
        BtOpt4.Text = "Giftshop (£600)"
        BtOpt5.Text = "Drinks Shop (£400)"
        BtOpt6.Text = "Burger Shop (£500)"

        BtOpt1.Show()
        BtOpt2.Show()
        BtOpt3.Show()
        BtOpt4.Show()
        BtOpt5.Show()
        BtOpt6.Show()
    End Sub

    Private Sub EventOption()
        'The layout is changed to display the events available for purchase
        LbTitle.Text = "Please select one of the events available"
        LbCurrency.Text = "Your currency is: " & MainCurrencyShop
        BtOpt1.Text = "50% off the entry (£700 per week)"
        BtOpt2.Text = "Seasonal event(Christmas, Halloween...) (£1000 per week)"

        BtOpt1.Size = New Size(325, 100)
        BtOpt2.Size = New Size(325, 100)
        BtOpt2.Location = New Point(35, 222)

        BtOpt1.Show()
        BtOpt2.Show()
        BtOpt3.Hide()
        BtOpt4.Hide()
        BtOpt5.Hide()
        BtOpt6.Hide()
    End Sub

    Private Sub EmployerOption()
        'The layout of the form is changed to show the employers that could be hired
        LbTitle.Text = "Please select one of the employers available: "
        LbCurrency.Text = "Your currency is: " & MainCurrencyShop
        BtOpt1.Text = "Food employer (£1200)"
        BtOpt2.Text = "Water employer (£1200)"
        BtOpt3.Text = "Cleaner employer (£1500)"

        BtOpt1.Show()
        BtOpt2.Show()
        BtOpt3.Show()
        BtOpt4.Hide()
        BtOpt5.Hide()
        BtOpt6.Hide()
    End Sub

    Private Sub BtOpt1_Click(sender As Object, e As EventArgs) Handles BtOpt1.Click
        'Depending on the layout of the form, when the button is clicked, different instructions will be followed
        'It can either update the layout of the form or select an object to purchase
        If BtOpt1.Text = "Buy Animals" Then
            AnimalOption()
        ElseIf BtOpt1.Text.Contains("Rhino") Then
            ObjectSelected = "Rhino"
            ObjectPrice = 1000
            GetQuantity()
        ElseIf BtOpt1.Text.Contains("Toilet") Then
            ObjectSelected = "Toilet"
            ObjectPrice = 200
            GetQuantity()
        ElseIf BtOpt1.Text.Contains("50%") Then
            eventtypeShop = 1
            ObjectSelected = "Entry_discount"
            ObjectPrice = 700
            GetQuantity()
        ElseIf BtOpt1.Text.Contains("Food") Then
            ObjectSelected = "FoodEmployer"
            ObjectPrice = 1200
            GetQuantity()
        End If
    End Sub

    Private Sub BtOpt2_Click(sender As Object, e As EventArgs) Handles BtOpt2.Click
        'Depending on the layout of the form, when the button is clicked, different instructions will be followed
        'It can either update the layout of the form or select an object to purchase or confirm the quantity wanted 
        If BtOpt2.Text = "Buy Buildings" Then
            BuildingOption()
        ElseIf BtOpt2.Text.Contains("Snake") Then
            ObjectSelected = "Snake"
            ObjectPrice = 200
            GetQuantity()
        ElseIf BtOpt2.Text.Contains("Popcorn") Then
            ObjectSelected = "Popcorn_Shop"
            ObjectPrice = 500
            GetQuantity()
        ElseIf BtOpt2.Text.Contains("Water") Then
            ObjectSelected = "WaterEmployer"
            ObjectPrice = 1200
            GetQuantity()
        ElseIf BtOpt2.Text = "Confirm" Then
            Dim Quantity As TextBox = Me.Controls.Item("TbxQuantity")
            QuantityShop = Quantity.Text
            Me.Controls.Item("TbxQuantity").Dispose()
            CheckBuy()
            RestoreDefault()
        End If

    End Sub

    Private Sub BtOpt3_Click(sender As Object, e As EventArgs) Handles BtOpt3.Click
        'Depending on the layout of the form, when the button is clicked, different instructions will be followed
        'It can either update the layout of the form or select an object to purchase
        If BtOpt3.Text = "Buy Events" Then
            EventOption()
        ElseIf BtOpt3.Text.Contains("Hippo") Then
            ObjectSelected = "Hippo"
            ObjectPrice = 1200
            GetQuantity()
        ElseIf BtOpt3.Text.Contains("Balloon") Then
            ObjectSelected = "Balloon_Shop"
            ObjectPrice = 300
            GetQuantity()
        ElseIf BtOpt3.Text.Contains("Seasonal") Then
            eventtypeShop = 2
            ObjectSelected = "Seasonal_event"
            ObjectPrice = 1000
            GetQuantity()
        ElseIf BtOpt3.Text.Contains("Cleaner") Then
            ObjectSelected = "Cleaner"
            ObjectPrice = 1500
            GetQuantity()
        End If
    End Sub

    Private Sub BtOpt4_Click(sender As Object, e As EventArgs) Handles BtOpt4.Click
        'Depending on the layout of the form, when the button is clicked, different instructions will be followed
        'It can either update the layout of the form or select an object to purchase
        If BtOpt4.Text = "Hire Employers" Then
            EmployerOption()
        ElseIf BtOpt4.Text.Contains("Lion") Then
            ObjectSelected = "Lion"
            ObjectPrice = 1500
            GetQuantity()
        ElseIf BtOpt4.Text.Contains("Giftshop") Then
            ObjectSelected = "Giftshop"
            ObjectPrice = 600
            GetQuantity()
        End If
    End Sub

    Private Sub BtOpt5_Click(sender As Object, e As EventArgs) Handles BtOpt5.Click
        'Depending on the layout of the form, when the button is clicked, different instructions will be followed
        ' it will select an object to purchase
        If BtOpt5.Text.Contains("Zebra") Then
            ObjectSelected = "Zebra"
            ObjectPrice = 2000
            GetQuantity()
        ElseIf BtOpt5.Text.Contains("Drink") Then
            ObjectSelected = "Drink_Shop"
            ObjectPrice = 400
            GetQuantity()
        End If
    End Sub

    Private Sub BtOpt6_Click(sender As Object, e As EventArgs) Handles BtOpt6.Click
        If BtOpt6.Text.Contains("Dolphin") Then
            ObjectSelected = "Dolphin"
            ObjectPrice = 3000
            GetQuantity()
        ElseIf BtOpt6.Text.Contains("Burger") Then
            ObjectSelected = "Burger_Shop"
            ObjectPrice = 500
            GetQuantity()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        'This is a way of error check that the player is only typing numbers in the textbox to avoid any crashes
        'If the player types anything that is not a number, it will not be recognised and displayed in the textbox
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub CheckBuy()
        'The purchase is checked here to make sure that the player can buy it if the player has enough currency.
        If QuantityShop > 0 Then
            If MainCurrencyShop < QuantityShop * ObjectPrice Then
                MsgBox("You don't have enough currency")
            ElseIf MainCurrencyShop >= QuantityShop * ObjectPrice Then
                If ObjectSelected = "Entry_discount" Or ObjectSelected = "Seasonal_event" Then
                    If eventtimeShop = 0 Then
                        MsgBox("You hired " & QuantityShop & " week(s) of the event " & ObjectSelected)
                        eventtimeShop = QuantityShop
                        Simulation.EventType = eventtypeShop
                        Simulation.EventTime = eventtimeShop
                        eventtypeShop = 0
                        MainCurrencyShop = MainCurrencyShop - (QuantityShop * ObjectPrice)
                    Else
                        MsgBox("There is an event active, you cannot buy another one")
                    End If
                ElseIf ObjectSelected = "FoodEmployer" Or ObjectSelected = "WaterEmployer" Or ObjectSelected = "Cleaner" Then
                    MsgBox("You hired " & QuantityShop & " " & ObjectSelected & "(s)")
                    For i = 1 To QuantityShop
                        EmployersInUseShop.Add(ObjectSelected)
                    Next
                    MainCurrencyShop = MainCurrencyShop - (QuantityShop * ObjectPrice)
                Else
                    MsgBox("You bought " & QuantityShop & " " & ObjectSelected & "(s)")
                    For i = 1 To QuantityShop
                        inventoryShop.Add(ObjectSelected)
                    Next
                    MainCurrencyShop = MainCurrencyShop - (QuantityShop * ObjectPrice)
                End If
            End If
            End If
        QuantityShop = 0
    End Sub

    Private Sub RestoreDefault()
        'The original layout is restored here
        LbTitle.Text = "Welcome to the shop, select one of the following options:"
        LbCurrency.Text = "Your currency is: " & MainCurrencyShop
        BtOpt1.Text = "Buy Animals"
        BtOpt2.Text = "Buy Buildings"
        BtOpt3.Text = "Buy Events"
        BtOpt4.Text = "Hire Employers"

        BtOpt1.Size = New Size(324, 37)
        BtOpt2.Size = New Size(324, 37)
        BtOpt2.Location = New Point(35, 167)

        BtOpt1.Show()
        BtOpt2.Show()
        BtOpt3.Show()
        BtOpt4.Show()
        BtOpt5.Hide()
        BtOpt6.Hide()

    End Sub

    Private Sub ShopMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QuantityShop = 0
    End Sub

    Private Sub BtBack_Click(sender As Object, e As EventArgs) Handles BtBack.Click
        'If the player decides to go back at any point, the system will check depending on the layout of the form what to do
        If BtOpt2.Text = "Buy Buildings" Then
            'If the player is viewing the original layout, then the form will be closed and the properties will be updated. 
            Me.Hide()
            Simulation.MainCurrency = MainCurrencyShop
            Simulation.Inventory = inventoryShop
            Simulation.EmployersInUse = EmployersInUseShop
            Simulation.LbCurrency.Text = "Your currency is: " & Simulation.MainCurrency
            If Simulation.EventType = 1 Then
                Simulation.LbEvent.Text = "The event Entry discount is active for " & Simulation.EventTime & " week(s)"
                Simulation.LbEvent.Show()
            ElseIf Simulation.EventType = 2 Then
                Simulation.LbEvent.Text = "The event Seasonal event is active for " & Simulation.EventTime & " week(s)"
            End If
            Simulation.Show()
        ElseIf BtOpt2.Text.Contains("Snake") Or BtOpt2.Text.Contains("Popcorn") Or BtOpt2.Text.Contains("Seasonal") Or BtOpt2.Text.Contains("Water") Then
            RestoreDefault()
        ElseIf BtOpt2.Text = "Confirm" Then
            If BtOpt1.Text.Contains("Rhino") Then
                AnimalOption()
            ElseIf BtOpt1.Text.Contains("Toilet") Then
                BuildingOption()
            ElseIf BtOpt1.Text.Contains("50%") Then
                EventOption()
            ElseIf BtOpt1.Text.Contains("Food") Then
                EmployerOption()
            End If
            Me.Controls.Item("TbxQuantity").Dispose()
        End If
    End Sub

    ''This is for the change of background for the buttons when they are displaying animals
    Private Sub RhinoOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt1.MouseEnter
        If BtOpt1.Text.Contains("Rhino") Then
            BtOpt1.BackgroundImage = My.Resources.rhino_skin
        End If
    End Sub
    Private Sub RhinoOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt1.MouseLeave
        BtOpt1.BackgroundImage = Nothing
    End Sub
    Private Sub SnakeOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt2.MouseEnter
        If BtOpt2.Text.Contains("Snake") Then
            BtOpt2.BackgroundImage = My.Resources.snake_skin
        End If
    End Sub
    Private Sub SnakeOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt2.MouseLeave
        BtOpt2.BackgroundImage = Nothing
    End Sub
    Private Sub HippoOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt3.MouseEnter
        If BtOpt3.Text.Contains("Hippo") Then
            BtOpt3.BackgroundImage = My.Resources.hippo_skin
        End If
    End Sub
    Private Sub HippoOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt3.MouseLeave
        BtOpt3.BackgroundImage = Nothing
    End Sub
    Private Sub LionOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt4.MouseEnter
        If BtOpt4.Text.Contains("Lion") Then
            BtOpt4.BackgroundImage = My.Resources.lion_skin
        End If
    End Sub
    Private Sub LionOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt4.MouseLeave
        BtOpt4.BackgroundImage = Nothing
    End Sub
    Private Sub ZebraOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt5.MouseEnter
        If BtOpt5.Text.Contains("Zebra") Then
            BtOpt5.BackgroundImage = My.Resources.zebra_skin
        End If
    End Sub
    Private Sub ZebraOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt5.MouseLeave
        BtOpt5.BackgroundImage = Nothing
    End Sub
    Private Sub DolphinOption_MouseEnter(sender As Object, e As EventArgs) Handles BtOpt6.MouseEnter
        If BtOpt6.Text.Contains("Dolphin") Then
            BtOpt6.BackgroundImage = My.Resources.dolphin_skin
        End If
    End Sub
    Private Sub DolphinOption_MouseLeaves(sender As Object, e As EventArgs) Handles BtOpt6.MouseLeave
        BtOpt6.BackgroundImage = Nothing
    End Sub
End Class