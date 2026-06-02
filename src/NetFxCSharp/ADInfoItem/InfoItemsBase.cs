using ActiveDev.Controls;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Reflection;

namespace ActiveDev
{
    [CLSCompliant(true)]
    public interface IInfoItem
    {
        int DataID { get; }
        string DisplayName { get; }
        void AssignFieldsFromNullableControls(ADNullableValueControls controls);
        void AssignFieldsToNullableControls(ADNullableValueControls controls);
        void AssignFieldsFromDataReader(SqlDataReader dr);
    }

    [CLSCompliant(true)]
    public abstract class InfoItemBase : IInfoItem
    {
        public abstract int DataID { get; }

        public abstract string DisplayName { get; }

        public virtual void AssignFieldsToNullableControls(ADNullableValueControls controls)
        {
            var locADDBNullableType = typeof(ADDBNullable);

            foreach (IADNullableValueControl c in controls)
            {
                var locDatafieldName = c.IndependentDatafieldName;

                if (!string.IsNullOrEmpty(locDatafieldName))
                {
                    var locCurrentProperty = GetType().GetProperty(c.IndependentDatafieldName);

                    if (locCurrentProperty.PropertyType.IsGenericType)
                    {
                        c.Value = (IADDBNullableValue)locCurrentProperty.GetValue(this, null);
                    }
                    else
                    {
                        var locGenericBasedType = c.Value.GetType().GetGenericArguments()[0];
                        var locToObjectMethod = locADDBNullableType.GetMethod("FromObject");
                        locToObjectMethod = locToObjectMethod.MakeGenericMethod(new[] { locGenericBasedType });
                        var locObject = locToObjectMethod.Invoke(this, new object[] { locCurrentProperty.GetValue(this, null) });
                        c.Value = (IADDBNullableValue)locObject;
                    }
                }
            }
        }

        public virtual void AssignFieldsFromNullableControls(ADNullableValueControls controls)
        {
            var locADDBNullableType = typeof(ADDBNullable);

            foreach (IADNullableValueControl c in controls)
            {
                var locDatafieldName = c.IndependentDatafieldName;
                if (!string.IsNullOrEmpty(locDatafieldName))
                {
                    var locCurrentProperty = GetType().GetProperty(c.IndependentDatafieldName);
                    if (locCurrentProperty.PropertyType.IsGenericType)
                    {
                        locCurrentProperty.SetValue(this, c.Value, null);
                    }
                    else
                    {
                        var locGenericBasedType = c.Value.GetType().GetGenericArguments()[0];
                        var locToObjectMethod = locADDBNullableType.GetMethod("ToObject");
                        locToObjectMethod = locToObjectMethod.MakeGenericMethod(new[] { locGenericBasedType });
                        var locObjTemp = locToObjectMethod.Invoke(this, new object[] { c.Value });
                        locCurrentProperty.SetValue(this, Convert.ChangeType(locObjTemp, locCurrentProperty.PropertyType), null);
                    }
                }
            }
        }

        public virtual void AssignFieldsFromDataReader(SqlDataReader dr)
        {
            var locProperties = ADClassReflector.GetProperties(this);
            var locADDBNullableType = typeof(ADDBNullable);
            PropertyInfo locCurrentProperty = null;

            for (var locCount = 0; locCount <= dr.FieldCount - 1; locCount++)
            {
                var locFieldname = dr.GetName(locCount);

                if (locProperties.Contains(locFieldname))
                {
                    locCurrentProperty = locProperties[locFieldname];
                    if (locCurrentProperty.PropertyType.IsGenericType &&
                        locCurrentProperty.PropertyType.GetGenericTypeDefinition() == typeof(ADDBNullable<>))
                    {
                        var locGenericBasedType = locCurrentProperty.PropertyType.GetGenericArguments()[0];
                        var locFromObjectMethod = locADDBNullableType.GetMethod("FromObject");
                        locFromObjectMethod = locFromObjectMethod.MakeGenericMethod(new[] { locGenericBasedType });
                        locCurrentProperty.SetValue(this, locFromObjectMethod.Invoke(this, new object[] { dr.GetValue(locCount) }), null);
                    }
                    else
                    {
                        locCurrentProperty.SetValue(this, dr.GetValue(locCount), null);
                    }
                }
            }
        }

        public string NumFormatString(byte precision)
        {
            var locret = "#,##0";

            if (precision > 0)
            {
                locret += "." + new string('0', precision);
            }

            return locret;
        }

        public DateTime? SelectionDate { get; set; }
    }

    public class InfoItems<InfoItemType> : KeyedCollection<IntKey, InfoItemType>
        where InfoItemType : IInfoItem
    {
        protected override IntKey GetKeyForItem(InfoItemType item) 
            => new IntKey(item.DataID);
    }

    public class InfoItemInfo : Attribute
    {
        private readonly string myTitel;
        private readonly bool mySortable;
        private readonly int myOrderID;
    }

    public struct IntKey
    {
        private int myValue;

        public IntKey(int value)
        {
            myValue = value;
        }

        public int Value
        {
            get { return myValue; }
            set { myValue = value; }
        }
    }
}
