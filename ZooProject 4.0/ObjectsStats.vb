Public Class ObjectsStats
    Property ShowAnimals As List(Of Animal)
    Property ShowBuildings As List(Of Building)
    Property ShowEmployers As List(Of String)
    Public Sub New(ByVal AnimalsInUse As List(Of Animal))
        ' This call is required by the designer.
        'When the player wants to see the animal stats this subroutine will initialise the form
        InitializeComponent()
        ShowAnimals = AnimalsInUse
        DisplayAnimalTable(ShowAnimals)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal BuildingsInUse As List(Of Building))
        ' This call is required by the designer.
        'When the player wants to see the building stats this subroutine will initialise the form
        InitializeComponent()
        ShowBuildings = BuildingsInUse
        DisplayBuildingTable(ShowBuildings)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal EmployersInUse As List(Of String))
        ' This call is required by the designer.
        'When the player wants to see the employers hired this subroutine will initialise the form
        InitializeComponent()
        ShowEmployers = EmployersInUse
        DisplayEmployerTable(ShowEmployers)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DisplayAnimalTable(ByVal ShowAnimals As List(Of Animal))
        'Depending on the animals in the list, the system will add records on the table. 
        Dim Animal As Animal
        For x = 0 To ShowAnimals.Count - 1
            Animal = ShowAnimals(x)
            Dim LbSpecie As Label = New Label
            LbSpecie.Text = Animal.GetName
            LbSpecie.Font = New Drawing.Font("Tahoma", 12)
            Dim LbNickname As Label = New Label
            LbNickname.Text = Animal.GetNickname
            LbNickname.Font = New Drawing.Font("Tahoma", 12)
            Dim LbHealth As Label = New Label
            LbHealth.Text = Animal.GetHealth
            LbHealth.Font = New Drawing.Font("Tahoma", 12)
            Dim LbHygiene As Label = New Label
            LbHygiene.Text = Animal.GetHygiene
            LbHygiene.Font = New Drawing.Font("Tahoma", 12)
            Dim LbFood As Label = New Label
            LbFood.Text = Animal.GetFood
            LbFood.Font = New Drawing.Font("Tahoma", 12)
            Dim LbWater As Label = New Label
            LbWater.Text = Animal.GetWater
            LbWater.Font = New Drawing.Font("Tahoma", 12)
            Dim LbLove As Label = New Label
            LbLove.Text = Animal.GetLove
            LbLove.Font = New Drawing.Font("Tahoma", 12)

            TbLPObjectStats.Controls.Add(LbSpecie, 0, x + 1)
            TbLPObjectStats.Controls.Add(LbNickname, 1, x + 1)
            TbLPObjectStats.Controls.Add(LbHealth, 2, x + 1)
            TbLPObjectStats.Controls.Add(LbHygiene, 3, x + 1)
            TbLPObjectStats.Controls.Add(LbFood, 4, x + 1)
            TbLPObjectStats.Controls.Add(LbWater, 5, x + 1)
            TbLPObjectStats.Controls.Add(LbLove, 6, x + 1)
        Next
    End Sub

    Private Sub DisplayBuildingTable(ByVal ShowBuildings As List(Of Building))
        'The system will add records on the table proportional to the number of buildings on the list
        Dim Building As Building
        LbTitle.Text = "These are the building stats:"
        TbLPObjectStats.ColumnCount = 3
        LbSpecieTitle.Text = "Name"
        LbNicknameTitle.Text = "Hygiene"
        LbFoodTitle.Hide()
        LbHygiene.Hide()
        LbWaterTitle.Hide()
        LbLoveTitle.Hide()

        For x = 0 To ShowBuildings.Count - 1
            Building = ShowBuildings(x)
            Dim LbName As Label = New Label
            LbName.Text = Building.GetName
            LbName.Font = New Drawing.Font("Tahoma", 12)
            Dim LbHygiene As Label = New Label
            LbHygiene.Text = Building.GetHygiene
            LbHygiene.Font = New Drawing.Font("Tahoma", 12)
            Dim LbHealth As Label = New Label
            LbHealth.Text = Building.GetHealth
            LbHealth.Font = New Drawing.Font("Tahoma", 12)

            TbLPObjectStats.Controls.Add(LbName, 0, x + 1)
            TbLPObjectStats.Controls.Add(LbHygiene, 1, x + 1)
            TbLPObjectStats.Controls.Add(LbHealth, 2, x + 1)
        Next
    End Sub

    Private Sub DisplayEmployerTable(ByVal ShowEmployers As List(Of String))
        'Depending on the number of employers hired, the system will display the type of employer and the animals covered
        Dim Employer As String
        Dim EmployerCategorySearch As Integer
        Dim SameEmployers As Integer
        Dim TypeOfEmployer As Integer
        LbTitle.Text = "These are the employer stats:"
        TbLPObjectStats.ColumnCount = 2
        LbSpecieTitle.Text = "Job Role"
        LbNicknameTitle.Text = "Animals Covered"
        LbHealth.Hide()
        LbFoodTitle.Hide()
        LbHygiene.Hide()
        LbWaterTitle.Hide()
        LbLoveTitle.Hide()
        'the table will only show the foodemployer once on the table
        If ShowEmployers.Contains("FoodEmployer") Then
            TypeOfEmployer += 1
            Employer = "FoodEmployer"
            Dim LbJobRole As Label = New Label
            LbJobRole.Text = Employer
            LbJobRole.Font = New Drawing.Font("Tahoma", 12)
            Dim LbAnimalsCovered As Label = New Label
            For i = 0 To ShowEmployers.Count - 1
                If ShowEmployers(i) = "FoodEmployer" Then
                    SameEmployers += 1
                End If
            Next
            'the quantity will be added and displayed as the number of animals covered
            EmployerCategorySearch = SameEmployers * 10
            LbAnimalsCovered.Text = EmployerCategorySearch
            LbAnimalsCovered.Font = New Drawing.Font("Tahoma", 12)
            TbLPObjectStats.Controls.Add(LbJobRole, 0, TypeOfEmployer)
            TbLPObjectStats.Controls.Add(LbAnimalsCovered, 1, TypeOfEmployer)
            EmployerCategorySearch = 0
            SameEmployers = 0
        End If
        If ShowEmployers.Contains("WaterEmployer") Then
            TypeOfEmployer += 1
            Employer = "WaterEmployer"
            Dim LbJobRole As Label = New Label
            LbJobRole.Text = Employer
            LbJobRole.Font = New Drawing.Font("Tahoma", 12)
            Dim LbAnimalsCovered As Label = New Label
            For i = 0 To ShowEmployers.Count - 1
                If ShowEmployers(i) = "WaterEmployer" Then
                    SameEmployers += 1
                End If
            Next
            EmployerCategorySearch = SameEmployers * 10
            LbAnimalsCovered.Text = EmployerCategorySearch
            LbAnimalsCovered.Font = New Drawing.Font("Tahoma", 12)
            TbLPObjectStats.Controls.Add(LbJobRole, 0, TypeOfEmployer)
            TbLPObjectStats.Controls.Add(LbAnimalsCovered, 1, TypeOfEmployer)
            EmployerCategorySearch = 0
            SameEmployers = 0
        End If
        If ShowEmployers.Contains("Cleaner") Then
            TypeOfEmployer += 1
            Employer = "Cleaner"
            Dim LbJobRole As Label = New Label
            LbJobRole.Text = Employer
            LbJobRole.Font = New Drawing.Font("Tahoma", 12)
            Dim LbAnimalsCovered As Label = New Label
            For i = 0 To ShowEmployers.Count - 1
                If ShowEmployers(i) = "Cleaner" Then
                    SameEmployers += 1
                End If
            Next
            EmployerCategorySearch = SameEmployers * 10
            LbAnimalsCovered.Text = EmployerCategorySearch
            LbAnimalsCovered.Font = New Drawing.Font("Tahoma", 12)
            TbLPObjectStats.Controls.Add(LbJobRole, 0, TypeOfEmployer)
            TbLPObjectStats.Controls.Add(LbAnimalsCovered, 1, TypeOfEmployer)
            EmployerCategorySearch = 0
            SameEmployers = 0
        End If
    End Sub

    Private Sub BtBack_Click(sender As Object, e As EventArgs) Handles BtBack.Click
        Me.Dispose()
    End Sub
End Class