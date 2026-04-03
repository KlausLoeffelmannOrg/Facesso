using System;
using ActiveDev;
using Microsoft.Win32;

namespace Facesso
{
    [CLSCompliant(false)]
    public sealed class FacessoLicenseManager : ADLicenseManager
    {
        public FacessoLicenseManager(Guid prgGuid, DateTime installDate, DateTime lastRunDate,
                                     DateTime lastRegisteredDate, string serialNumber)
            : base(prgGuid, installDate, lastRunDate, lastRegisteredDate, serialNumber)
        {
            if (!HasValidSerialNo())
                myLicenseInfo.Fallback(1, 2);
        }

        public override bool IsLicensed()
        {
            if (DateTime.Now < myInstallDate)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                }
                catch { }
                throw new ADLicenseUnvalidException(DateTime.Now, ADLicenseUnvalidReason.SystemDateManipulated,
                    "Das aktuelle Datum liegt vor dem Installationsdatum. Facesso kann daher die korrekten Lizenzinformationen nicht überprüfen und wird deswegen nun beendet. Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben!");
            }

            if (DateTime.Now < myLastRunDate)
            {
                try
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                }
                catch { }
                throw new ADLicenseUnvalidException(DateTime.Now, ADLicenseUnvalidReason.SystemDateManipulated,
                    "Das aktuelle Datum liegt vor dem letzten Startdatum von Facesso. Eine Überprüfung der korrekten Lizenzinformationen ist daher nicht möglich. Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben.");
            }

            if (myLicenseInfo.MonthsLimited != 0)
            {
                if (DateTime.Now > BestBefore)
                {
                    try
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ActiveDev\Facesso", "ForceReapplication", true);
                    }
                    catch { }
                    throw new ADLicenseUnvalidException(DateTime.Now, ADLicenseUnvalidReason.Expired,
                        "Die Probe-Frist ist abgelaufen! Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben!");
                }
            }

            if (myLicenseInfo.SoftwareID > 10)
            {
                throw new ADLicenseUnvalidException(DateTime.Now, ADLicenseUnvalidReason.WrongSoftware,
                    "Der Freischaltcode ist nicht für diese Softwareversion gültig! Beim nächsten Start von Facesso können Sie einen neuen Freischaltcode eingeben.");
            }

            if (myLicenseInfo.HasFallenBack)
                return true;
            else
                return base.IsLicensed();
        }

        public FacessoVersionPermissionInfo VersionPermissionInfo
        {
            get { return new FacessoVersionPermissionInfo((FacessoVersion)myLicenseInfo.SoftwareID); }
        }

        public override string ToString()
        {
            bool tmpIsLicenced = false;
            string retText = "Ist Lizensiert: " + (IsLicensed() ? "Ja" : "Nein") + "\r\n";
            tmpIsLicenced = tmpIsLicenced | IsLicensed();
            retText += "Has Fallen Back: " + (myLicenseInfo.HasFallenBack ? "Ja" : "Nein") + "\r\n";
            retText += "Beschränkt auf Monate: " + myLicenseInfo.MonthsLimited;
            tmpIsLicenced = tmpIsLicenced | myLicenseInfo.HasFallenBack;

            if (!tmpIsLicenced) return retText;

            retText += "\r\n" + "Software-ID: " + myLicenseInfo.SoftwareID.ToString() + "\r\n";
            retText += "Für Nutzer: " + myLicenseInfo.Limit1.ToString() + "\r\n";
            retText += "Für Internet-Nutzer: " + myLicenseInfo.Limit2.ToString() + "\r\n";
            retText += "Für Mitarbeiter: " + myLicenseInfo.Limit3.ToString() + "\r\n";
            retText += "Schnittstellenausbau : " + myLicenseInfo.Limit4.ToString() + "\r\n";
            return retText;
        }
    }
}
