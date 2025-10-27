Public MustInherit Class TimeDataImportBase
    Inherits FacessoTaskItemBase

    Private myLegatroConnectionString As String

    Public Overrides Function ConfigureGenericInterface() As System.Windows.Forms.DialogResult
        Throw New NotImplementedException("TimeDataImportBase.ConfigureGenericInterface: Nicht implementiert!")
    End Function

    Public Overrides Function ConfigureImportFilter() As System.Windows.Forms.DialogResult
        Throw New NotImplementedException("TimeDataImportBase.ConfigureImportFilter: Nicht implementiert!")
    End Function

    ''' <summary>
    ''' Erstellt eine generische Konvertierungstabelle, 
    ''' die in den jeweiligen Ableitungen für die Zuordnungen FremdID-->Produktiv-Site verantwortlich ist.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Diese wird Indirekt über den Delegaten ConversionItemsDelegate aufgerufen.</remarks>
    Public Overridable Function AssembleConversionItems() As FacessoConversionItemsBase

        Dim locConversionItems As FacessoConversionItemsBase

        'Liste bleibt leer.
        locConversionItems = New FacessoConversionItemsBase
        Return locConversionItems
    End Function

    ''' <summary>
    ''' Ermittelt den Delegaten, der die Funktion zur Verfügung stellt, die die Konvertierungstabelle aufbaut.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property ConversionItemsDelegate() As IFacessoImportTaskItem.GetConversionItemsDelegate
        Get
            Return AddressOf AssembleConversionItems
        End Get
    End Property

    Public Overrides Function GetData(ByVal ProductionDate As Date, ByVal Shift As ShiftCombination) As IImportResultTable
        Throw New NotImplementedException("TimeDataImportBase.GetData: Nicht implementiert!")
    End Function

    Public Overrides ReadOnly Property ImportType() As FacessoImportType
        Get
            Return FacessoImportType.TimeKeepingData
        End Get
    End Property
End Class
