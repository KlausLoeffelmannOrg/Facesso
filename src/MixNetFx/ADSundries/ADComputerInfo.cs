using System;
using System.Linq;
using System.Management;

namespace ActiveDev
{

    public static class ADComputerInfo
    {

        /// <summary>
        /// Ermittelt einen Identifier als String aus der Seriennummer der Hauptplatine. 
        /// HINWEIS: Nicht alle Hauptplatinen unterstützen diese Funktion, und liefern keinen eindeutigen String zurück!
        /// </summary>
        /// <returns>String mit eindeutigen Identifier der Hauptplatine.</returns>
        /// <remarks></remarks>
        public static string GetBoardInfoString()
        {
            var locQuery = new WqlObjectQuery("select * from Win32_BaseBoard");
            var locSearcher = new ManagementObjectSearcher(locQuery);
            string locBaseBoardID = "";

            foreach (ManagementObject locBaseBoardObj in locSearcher.Get().Cast<ManagementObject>())
            {
                try
                {
                    locBaseBoardID = locBaseBoardObj["Product"].ToString();
                }
                catch (Exception ex)
                {
                    locBaseBoardID = "XdFeR45";
                }

                try
                {
                    locBaseBoardID += locBaseBoardObj["Version"].ToString();
                }
                catch (Exception ex)
                {
                    locBaseBoardID = "5GhzU87";
                }
                break;
            }

            return locBaseBoardID;
        }

        /// <summary>
        /// Ermittelt einen Typnamen der Hauptplatine als String, der sich aus dem Herstellertyp des verwendeten 
        /// Mother-Boards ergibt. HINWEIS: Erfahrungsgemäß unterstützen alle Hauptplatinen diese Funktion, 
        /// und liefern eindeutige Strings zurück, die sich bei gleichen Boards natürlich ähneln.
        /// </summary>
        /// <returns>String mit dem Brand-Namen des Mother-Boards.</returns>
        /// <remarks></remarks>
        public static string GetBiosInfoString()
        {
            var locQuery = new WqlObjectQuery("select * from Win32_DiskDrive");
            var locSearcher = new ManagementObjectSearcher(locQuery);
            string locBIOSID = "";

            foreach (ManagementObject locBIOSObj in locSearcher.Get().Cast<ManagementObject>())
            {
                locBIOSID = (string)(locBIOSObj["Model"] ?? "JeDF59KK");
                locBIOSID += (string)(locBIOSObj["Signature"] ?? "SdFFg3Ed");

                break;
            }

            return locBIOSID;
        }

        /// <summary>
        /// Ermittelt, ob es sich bei der verwendeten Hardware um einen virtuellen PC vom Typ Microsoft Virtual PC handelt.
        /// </summary>
        /// <returns>True, wenn es Microsoft Virtual PC ist.</returns>
        /// <remarks></remarks>
        public static bool IsVPC()
        {
            if (GetBoardInfoString().IndexOf("VirtualPC") > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}