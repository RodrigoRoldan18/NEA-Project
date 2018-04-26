Public Class BuildingFeatures
    'these are the characteristics of buildings where everything is implemented from the IFeatures interface
    Implements IFeatures
    Public Property Name As String Implements IFeatures.Name

    Public Property Hygiene As Integer Implements IFeatures.Hygiene
    Public Property Health As Integer Implements IFeatures.Health
    Public Overridable Sub ChangeHygiene() Implements IFeatures.ChangeHygiene
        Hygiene = Hygiene - 10
    End Sub
    Public Overridable Sub ChangeHealth() Implements IFeatures.ChangeHealth
        Health = Health - 2
    End Sub

    Public Function GetName() As String Implements IFeatures.GetName
        Return Name
    End Function
    Public Function GetHygiene() As Integer Implements IFeatures.GetHygiene
        Return Hygiene
    End Function
    Public Function GetHealth() As Integer Implements IFeatures.GetHealth
        Return Health
    End Function
End Class

Public Class AnimalFeatures
    'these are the characteristics of the animals that will be placed in the zoo. Some properties come from the Interface and others are created here.
    Implements IFeatures
    Public Property Food As Integer
    Public Property Water As Integer
    Public Property Love As Integer
    Public Property Name As String Implements IFeatures.Name
    Public Property Nickname As String
    Public Property Hygiene As Integer Implements IFeatures.Hygiene
    Public Property Health As Integer Implements IFeatures.Health
    Public Overridable Sub ChangeHygiene() Implements IFeatures.ChangeHygiene
        Hygiene = Hygiene - 10
    End Sub
    Public Overridable Sub ChangeHealth() Implements IFeatures.ChangeHealth
        Health = Health - 5
    End Sub
    Public Overridable Sub ChangeFood()
        Food = Food - 20
    End Sub
    Public Overridable Sub ChangeWater()
        Water = Water - 20
    End Sub
    Public Overridable Sub ChangeLove()
        Love = Love - 5
    End Sub
    Public Sub RestoreHealth()
        Health = Health + 2
    End Sub
    Public Sub RestoreFood()
        Food = Food + 10
    End Sub
    Public Sub RestoreHygiene()
        Hygiene = Hygiene + 5
    End Sub
    Public Sub RestoreWater()
        Water = Water + 10
    End Sub
    Public Sub RestoreLove()
        Love = Love + 2
    End Sub

    Public Function GetFood()
        Return Food
    End Function
    Public Function GetWater()
        Return Water
    End Function
    Public Function GetLove()
        Return Love
    End Function
    Public Function GetName() As String Implements IFeatures.GetName
        Return Name
    End Function
    Public Function GetHygiene() As Integer Implements IFeatures.GetHygiene
        Return Hygiene
    End Function
    Public Function GetHealth() As Integer Implements IFeatures.GetHealth
        Return Health
    End Function
    Public Function GetNickname() As Object
        Return Nickname
    End Function

    Public Sub PartnerLove()
        Love = Love + 5
    End Sub
    Public Sub AfterReproduce()
        Love = Love - 50
    End Sub
    Public Sub BrokenPipe()
        Water = Water - 40
    End Sub
    Public Sub Diseasehealth()
        Health = Health - 30
    End Sub
    Public Sub SandStorm()
        Hygiene = Hygiene - 40
    End Sub
    Public Sub FoodMissing()
        Food = Food - 30
    End Sub

End Class

Public Class Animal
    'An animal has this properties and the characteristics are inherited from the AnimalFeatures class for manipulation later on
    Inherits AnimalFeatures
    Public Sub New(ByVal ObjectSelected As String, ByVal answer As String)
        Name = ObjectSelected
        Health = 100
        Food = 100
        Hygiene = 100
        Water = 100
        Love = 50
        Nickname = answer
    End Sub
    Public Sub New()
        Name = ""
        Nickname = ""
        Health = 0
        Food = 0
        Hygiene = 0
        Water = 0
        Love = 0
    End Sub
End Class
Public Class Building
    'the buildings have these features and stats and the characteristics are inherited from the BuildingFeatures class to manipulate the object later on
    Inherits BuildingFeatures
    Public Sub New(ByVal ObjectSelected As String)
        Name = ObjectSelected
        Health = 100
        Hygiene = 100
    End Sub
    Public Sub New()
        Name = ""
        Health = 0
        Hygiene = 0
    End Sub
End Class