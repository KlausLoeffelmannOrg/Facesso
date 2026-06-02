using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ActiveDev
{
    [CLSCompliant(false)]
    public class ADLicenseManager
    {
        protected ADLicenseInfo myLicenseInfo;
        private string myGuid;
        private byte[] myGivenTotalSerialNumber;
        private byte[] myGivenSerialNumber;
        private byte[] myGivenLicenseInfo;
        private byte[] myCalcSerialNumber;
        protected DateTime myInstallDate;
        protected DateTime myLastRunDate;

        public ADLicenseManager(Guid prgGUID, DateTime installationDate, DateTime lastRunDate, DateTime lastRegisteredDate, string serialNumber)
        {
            if (serialNumber == null)
            {
                serialNumber = new string('A', 30);
            }
            else
            {
                serialNumber = serialNumber.Replace(' ', '0');
                serialNumber = serialNumber.Replace("-", string.Empty);
                if (serialNumber.Length < 30)
                {
                    serialNumber = new string('0', 30 - serialNumber.Length) + serialNumber;
                }
            }

            ulong locGivenSerialNumber;
            try
            {
                locGivenSerialNumber = ADNumberSystems.Parse(serialNumber.Substring(0, 15), 20).Value;
            }
            catch (Exception)
            {
                locGivenSerialNumber = 0;
            }

            ulong locGivenLicenseInfo;
            try
            {
                locGivenLicenseInfo = ADNumberSystems.Parse(serialNumber.Substring(15), 20).Value;
            }
            catch (Exception)
            {
                locGivenLicenseInfo = 0;
            }

            locGivenLicenseInfo ^= 0xFFEEDDCCBBAA9988UL;
            myLicenseInfo = new ADLicenseInfo(locGivenLicenseInfo);
            myInstallDate = installationDate;
            myLastRunDate = lastRunDate;

            var locKeyString = new ADNumberSystems(locGivenLicenseInfo, 20).ToString(16) + lastRegisteredDate.ToString("ddMMyyyy");
            var locMACTripleDES = new MACTripleDES(ADCryptography.ToByteArray(locKeyString));
            var locPreSerial = GetPreSerialNo(prgGUID, installationDate);

            myCalcSerialNumber = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locPreSerial));
            myGivenSerialNumber = BitConverter.GetBytes(locGivenSerialNumber);
        }

        public static string GetPreSerialNo(Guid prgGuid, DateTime installationDate)
        {
            var locComputerInfoString = ADComputerInfo.GetBiosInfoString();
            locComputerInfoString += ADComputerInfo.GetBoardInfoString();
            locComputerInfoString += prgGuid.ToString();
            locComputerInfoString += installationDate.ToString();

            var locMACTripleDES = new MACTripleDES(ADCryptography.ToByteArray("Nicht genügend Speicher!"));
            var locPreSerial = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locComputerInfoString));
            var locULongTemp = BitConverter.ToUInt64(locPreSerial, 0);
            return new ADNumberSystems(locULongTemp, 20).ToString(15);
        }

        public virtual ADLicenseInfo LicenseInfo()
        {
            return myLicenseInfo;
        }

        public virtual bool IsLicensed()
        {
            return HasValidSerialNo();
        }

        protected virtual bool HasValidSerialNo()
        {
            for (var locCount = 0; locCount <= myCalcSerialNumber.Length - 1; locCount++)
            {
                if (myCalcSerialNumber[locCount] != myGivenSerialNumber[locCount])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSerialNoValid
        {
            get { return HasValidSerialNo(); }
        }

        public DateTime BestBefore
        {
            get
            {
                var locDate = myInstallDate;
                locDate = locDate.AddMonths(myLicenseInfo.MonthsLimited);
                return locDate;
            }
        }
    }

    [CLSCompliant(false)]
    [StructLayout(LayoutKind.Explicit)]
    public struct ADLicenseInfo
    {
        [FieldOffset(0)] private ulong myCompleteStructure;
        [FieldOffset(0)] private byte mySoftwareID;
        [FieldOffset(1)] private byte myMonthsLimited;
        [FieldOffset(2)] private byte myLimit1;
        [FieldOffset(3)] private byte myLimit2;
        [FieldOffset(4)] private ushort myLimit3;
        [FieldOffset(6)] private ushort myLimit4;
        [FieldOffset(8)] private bool myHasFallenBack;

        public ADLicenseInfo(byte softwareID, byte monthsLimited, byte limit1, byte limit2, ushort limit3, ushort limit4)
            : this()
        {
            mySoftwareID = softwareID;
            myMonthsLimited = monthsLimited;
            myLimit1 = limit1;
            myLimit2 = limit2;
            myLimit3 = limit3;
            myLimit4 = limit4;
        }

        public ADLicenseInfo(string infoKey)
            : this()
        {
            var locNumberSystems = ADNumberSystems.Parse(infoKey, 32);
            myCompleteStructure = locNumberSystems.Value;
        }

        public ADLicenseInfo(byte[] infoKeyBits)
            : this()
        {
            var locADLicenceInfo = new ADLicenseInfo(BitConverter.ToUInt64(infoKeyBits, 0));
            mySoftwareID = locADLicenceInfo.SoftwareID;
            myMonthsLimited = locADLicenceInfo.MonthsLimited;
            myLimit1 = locADLicenceInfo.Limit1;
            myLimit2 = locADLicenceInfo.Limit2;
            myLimit3 = locADLicenceInfo.Limit3;
            myLimit4 = locADLicenceInfo.Limit4;
        }

        public ADLicenseInfo(ADLicenseInfo li)
            : this()
        {
            mySoftwareID = li.SoftwareID;
            myMonthsLimited = li.MonthsLimited;
            myLimit1 = li.Limit1;
            myLimit2 = li.Limit2;
            myLimit3 = li.Limit3;
            myLimit4 = li.Limit4;
        }

        internal ADLicenseInfo(ulong completeStructure)
            : this()
        {
            myCompleteStructure = completeStructure;
        }

        public override string ToString()
        {
            return new ADNumberSystems(myCompleteStructure, 32).ToString();
        }

        public byte[] ToByteArray()
        {
            return BitConverter.GetBytes(myCompleteStructure);
        }

        public void Fallback(byte toMonths, byte id)
        {
            if (toMonths > 3)
            {
                toMonths = 1;
            }

            if (toMonths < 2)
            {
                toMonths = 2;
            }

            myHasFallenBack = true;
            myMonthsLimited = toMonths;
            mySoftwareID = id;
        }

        public byte SoftwareID
        {
            get { return mySoftwareID; }
        }

        public byte MonthsLimited
        {
            get { return myMonthsLimited; }
        }

        public byte Limit1
        {
            get { return myLimit1; }
        }

        public byte Limit2
        {
            get { return myLimit2; }
        }

        public ushort Limit3
        {
            get { return myLimit3; }
        }

        public ushort Limit4
        {
            get { return myLimit4; }
        }

        public ulong CompleteStructure
        {
            get { return myCompleteStructure; }
        }

        public bool HasFallenBack
        {
            get { return myHasFallenBack; }
        }
    }

    public class ADLicenseUnvalidException : ApplicationException
    {
        private DateTime myBestBefore;
        private ADLicenseUnvalidReason myReason;

        public ADLicenseUnvalidException(DateTime bestBefore, ADLicenseUnvalidReason reason, string message)
            : base(message)
        {
            myBestBefore = bestBefore;
        }

        public DateTime BestBefore
        {
            get { return myBestBefore; }
            set { myBestBefore = value; }
        }

        public ADLicenseUnvalidReason Reason
        {
            get { return myReason; }
            set { myReason = value; }
        }
    }

    public enum ADLicenseUnvalidReason
    {
        Expired,
        SystemDateManipulated,
        WrongSoftware
    }
}
