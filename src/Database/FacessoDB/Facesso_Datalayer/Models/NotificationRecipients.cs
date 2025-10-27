using System;
using System.Collections.Generic;

namespace Facesso_DatamodelImporter
{
    public partial class NotificationRecipients
    {
        public Guid Idsubsidiary { get; set; }
        public Guid IdnotificationRecipient { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Smtpaddress { get; set; }
        public string SmtpaddressFallOver { get; set; }
        public bool IsGlobal { get; set; }
        public string Tag { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Subsidiaries IdsubsidiaryNavigation { get; set; }
    }
}
