using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace ActiveDevelop.SqlTools.My.Resources
{
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    internal static class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    resourceMan = new ResourceManager("ActiveDevelop.SqlTools.Resources", typeof(Resources).Assembly);
                }

                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get { return resourceCulture; }
            set { resourceCulture = value; }
        }
    }
}
