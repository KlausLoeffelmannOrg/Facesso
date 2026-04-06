using System;

namespace Facesso
{
    [Serializable]
    public class FacessoGeneralOptions
    {
        private bool mySaturdayIsWorkday;
        private bool mySundayIsWorkday;
        private bool myDontLookForInterfaceAssemblies;
        private bool myAutomateMainFormUpdate;
        private int myAutomateMainFormUpdateInterval;
        private bool myShowTimeLogPriorToImport;
        private bool myShowIssueListPriorToImport;

        public FacessoGeneralOptions()
        {
            myAutomateMainFormUpdateInterval = 60;
        }

        public FacessoGeneralOptions(bool saturdayIsWorkday, bool sundayIsWorkday,
            bool dontLookForInterfaceAssemblies, bool automateMainFormUpdate,
            int automateMainFormUpdateInterval)
        {
            mySaturdayIsWorkday = saturdayIsWorkday;
            mySundayIsWorkday = sundayIsWorkday;
            myDontLookForInterfaceAssemblies = dontLookForInterfaceAssemblies;
            myAutomateMainFormUpdate = automateMainFormUpdate;
            myAutomateMainFormUpdateInterval = 60;
        }

        public bool SaturdayIsWorkday
        {
            get { return mySaturdayIsWorkday; }
            set { mySaturdayIsWorkday = value; }
        }

        public bool SundayIsWorkday
        {
            get { return mySundayIsWorkday; }
            set { mySundayIsWorkday = value; }
        }

        public bool DontLookForInterfaceAssemblies
        {
            get { return myDontLookForInterfaceAssemblies; }
            set { myDontLookForInterfaceAssemblies = value; }
        }

        public bool AutomateMainFormUpdate
        {
            get { return myAutomateMainFormUpdate; }
            set { myAutomateMainFormUpdate = value; }
        }

        public int AutomateMainFormUpdateInterval
        {
            get { return myAutomateMainFormUpdateInterval; }
            set { myAutomateMainFormUpdateInterval = value; }
        }

        public bool ShowTimeLogPriorToImport
        {
            get { return myShowTimeLogPriorToImport; }
            set { myShowTimeLogPriorToImport = value; }
        }

        public bool ShowIssueListPriorToImport
        {
            get { return myShowIssueListPriorToImport; }
            set { myShowIssueListPriorToImport = value; }
        }
    }
}
