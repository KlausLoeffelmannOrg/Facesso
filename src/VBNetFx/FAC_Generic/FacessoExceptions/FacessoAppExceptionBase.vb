Public MustInherit Class FacessoApplicationExceptionBase
    Inherits ApplicationException

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.New(Message, innerException)
    End Sub

End Class

Public Class FacessoGenericApplicationException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, InnerException)
    End Sub

End Class

Public Class FacessoLoginException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, InnerException)
    End Sub

End Class

Public Class FacessoEndOfSetupException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, innerException)
    End Sub

End Class

Public Class FacessoSqlDbException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, InnerException)
    End Sub

End Class

Public Class FacessoLicenseViolationException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, InnerException)
    End Sub

End Class

Public Class FacessoUniqueFieldAlreadyExistsException
    Inherits FacessoApplicationExceptionBase

    Sub New()
    End Sub

    Sub New(ByVal Message As String, ByVal innerException As Exception)
        MyBase.new(Message, InnerException)
    End Sub

End Class


