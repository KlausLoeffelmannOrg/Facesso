using System;

namespace Facesso
{
    public abstract class FacessoApplicationExceptionBase : ApplicationException
    {
        protected FacessoApplicationExceptionBase() { }

        protected FacessoApplicationExceptionBase(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoGenericApplicationException : FacessoApplicationExceptionBase
    {
        public FacessoGenericApplicationException() { }

        public FacessoGenericApplicationException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoLoginException : FacessoApplicationExceptionBase
    {
        public FacessoLoginException() { }

        public FacessoLoginException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoEndOfSetupException : FacessoApplicationExceptionBase
    {
        public FacessoEndOfSetupException() { }

        public FacessoEndOfSetupException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoSqlDbException : FacessoApplicationExceptionBase
    {
        public FacessoSqlDbException() { }

        public FacessoSqlDbException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoLicenseViolationException : FacessoApplicationExceptionBase
    {
        public FacessoLicenseViolationException() { }

        public FacessoLicenseViolationException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class FacessoUniqueFieldAlreadyExistsException : FacessoApplicationExceptionBase
    {
        public FacessoUniqueFieldAlreadyExistsException() { }

        public FacessoUniqueFieldAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
