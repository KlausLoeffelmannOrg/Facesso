using System;
using System.Collections.Generic;

namespace FacessoSetup
{
    internal class BackupFile
    {
        public string LogicalName { get; set; }
        public string PhysicalName { get; set; }
        public string Type { get; set; }
    }

    internal sealed class AdminPasswordUpdateResult
    {
        public int UpdatedUsers { get; set; }
        public bool InsertedUser { get; set; }
        public bool PromotedExistingUser { get; set; }
    }

    internal sealed class DemoConversionOptions
    {
        public bool IsSilent { get; set; }
        public TimeSpan GeneralTimeOffset { get; set; }
        public int RandomJitterSeconds { get; set; }
        public DateTime TargetLastDate { get; set; }
        public string NewSubsidiaryName { get; set; }
        public bool RegenerateUserNames { get; set; }
        public bool RegenerateWorkgroupNames { get; set; }
    }

    internal sealed class DemoConversionCliOptions
    {
        public bool Silent { get; set; }
        public TimeSpan? GeneralTimeOffset { get; set; }
        public int? RandomJitterSeconds { get; set; }
        public DateTime? TargetLastDate { get; set; }
        public string NewSubsidiaryName { get; set; }
        public bool? RegenerateUserNames { get; set; }
        public bool? RegenerateWorkgroupNames { get; set; }
    }

    internal sealed class DemoAnalysisInfo
    {
        public string DatabaseName { get; set; }
        public string CurrentSubsidiaryName { get; set; }
        public DateTime? MinBookingStart { get; set; }
        public DateTime? MaxBookingEnd { get; set; }
        public int WeekendShiftBucketCount { get; set; }
        public List<DemoShiftWindowInfo> ShiftDefinitions { get; set; } = new List<DemoShiftWindowInfo>();
        public List<DemoShiftWindowInfo> AverageByShift { get; set; } = new List<DemoShiftWindowInfo>();
        public List<DemoWorkgroupShiftSummary> AverageByWorkgroup { get; set; } = new List<DemoWorkgroupShiftSummary>();
        public List<ShiftProgressItem> ShiftProgressItems { get; set; } = new List<ShiftProgressItem>();
    }

    internal sealed class DemoShiftWindowInfo
    {
        public byte Shift { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }
        public int EntryCount { get; set; }
    }

    internal sealed class DemoWorkgroupShiftSummary
    {
        public string WorkgroupName { get; set; }
        public List<DemoShiftWindowInfo> Shifts { get; set; } = new List<DemoShiftWindowInfo>();
    }

    internal sealed class DatabaseBackupInfo
    {
        public string Path { get; set; }
        public long SizeBytes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    internal sealed class ShiftProgressItem
    {
        public object IDSubsidiary { get; set; }
        public DateTime ProductionDate { get; set; }
        public byte Shift { get; set; }
        public object IDWorkGroup { get; set; }
        public string WorkgroupName { get; set; }
        public DateTime? OriginalStart { get; set; }
        public DateTime? OriginalEnd { get; set; }
        public double? DegreeOfTime { get; set; }
        public double? DegreeOfTimeAdj { get; set; }
        public int EntryCount { get; set; }
    }

    internal sealed class ShiftBucketKey : IEquatable<ShiftBucketKey>
    {
        public ShiftBucketKey(object idSubsidiary, DateTime productionDate, byte shift)
        {
            IDSubsidiary = idSubsidiary;
            ProductionDate = productionDate.Date;
            Shift = shift;
        }

        public object IDSubsidiary { get; }
        public DateTime ProductionDate { get; }
        public byte Shift { get; }

        public bool Equals(ShiftBucketKey other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Equals(IDSubsidiary, other.IDSubsidiary)
                   && ProductionDate == other.ProductionDate
                   && Shift == other.Shift;
        }

        public override bool Equals(object obj) => Equals(obj as ShiftBucketKey);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = IDSubsidiary?.GetHashCode() ?? 0;
                hash = (hash * 397) ^ ProductionDate.GetHashCode();
                hash = (hash * 397) ^ Shift.GetHashCode();
                return hash;
            }
        }
    }

    internal sealed class PersonIdentity
    {
        public PersonIdentity(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }

    internal sealed class EmployeeRecord
    {
        public object IDSubsidiary { get; set; }
        public object IDEmployee { get; set; }
        public object IDAddressDetails { get; set; }
        public int PersonnelNumber { get; set; }
    }

    internal sealed class UserRecord
    {
        public object IDSubsidiary { get; set; }
        public object IDUser { get; set; }
        public object IDAddressDetails { get; set; }
        public string UserName { get; set; }
    }

    internal sealed class DescriptorRecord
    {
        public object IDSubsidiary { get; set; }
        public object ItemId { get; set; }
        public int Number { get; set; }
        public string CurrentName { get; set; }
    }

    internal sealed class LabourValueRecord
    {
        public object IDSubsidiary { get; set; }
        public object ItemId { get; set; }
        public int Number { get; set; }
        public string CurrentName { get; set; }
        public string Dimension { get; set; }
    }
}
