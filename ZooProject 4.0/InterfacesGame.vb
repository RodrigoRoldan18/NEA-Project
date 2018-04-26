Module InterfacesGame
    'IFeatures is an interface created for the animals and buildings as they have common properties
    Interface IFeatures
        Property Name As String

        Property Hygiene As Integer
        Property Health As Integer

        Function GetName() As String
        Function GetHygiene() As Integer
        Function GetHealth() As Integer


        Sub ChangeHygiene()
        Sub ChangeHealth()


    End Interface

    'this interface is created for the Simulation class as it is the core of the game and the most important properties are highlighted here to avoid human error
    Interface ICore
        Property Week As Integer
        Property MainCurrency As Integer
        Property Inventory As List(Of String)
        Property Popularity As Decimal
        Property SeasonSelected As String
        Property AnimalsInUse As List(Of Animal)
        Property BuildingsInUse As List(Of Building)
        Property EmployersInUse As List(Of String)
    End Interface

End Module
