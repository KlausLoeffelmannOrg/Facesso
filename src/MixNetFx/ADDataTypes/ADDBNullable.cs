using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ActiveDev
{
    public interface IADDBNullableValue
    {
        bool IsNull { get; }
        bool HasValue { get; }
        object Value { get; }
    }

    public static class ADDBNullable
    {
        public static ADDBNullable<PrimType> FromObject<PrimType>(object value)
            where PrimType : IComparable
        {
            var locNullable = new ADDBNullable<PrimType>();
            if (value == null || value is DBNull)
            {
                return locNullable;
            }

            if (value is PrimType typedValue)
            {
                locNullable.myValue = typedValue;
                locNullable.myNotNull = true;
                return locNullable;
            }

            try
            {
                locNullable.myValue = (PrimType)Convert.ChangeType(value, typeof(PrimType));
                locNullable.myNotNull = true;
                return locNullable;
            }
            catch (Exception)
            {
                throw new InvalidCastException("Object is not of the correct type!");
            }
        }

        public static object ToObject<PrimType>(ADDBNullable<PrimType> value)
            where PrimType : IComparable
        {
            if (!value.HasValue)
            {
                return null;
            }

            return (PrimType)value.Value;
        }
    }

    [CLSCompliant(true)]
    [Serializable]
    public struct ADDBNullable<PrimType> : IComparable, IADDBNullableValue, ISerializable
        where PrimType : IComparable
    {
        internal PrimType myValue;
        internal bool myNotNull;

        public ADDBNullable(PrimType value)
        {
            if (typeof(PrimType) == typeof(string) && Convert.ToString(value) == string.Empty)
            {
                myNotNull = false;
                myValue = default(PrimType);
                return;
            }

            myNotNull = !ReferenceEquals(value, null);
            myValue = value;
        }

        public bool IsNull
        {
            get { return !myNotNull; }
        }

        public bool HasValue
        {
            get { return myNotNull; }
        }

        [XmlIgnore]
        public object Value
        {
            get { return IsNull ? (object)DBNull.Value : myValue; }
        }

        public PrimType TypedValue
        {
            get
            {
                if (IsNull)
                {
                    throw new InvalidCastException("Can't cast DBNull to its native type");
                }

                return myValue;
            }
        }

        public static implicit operator ADDBNullable<PrimType>(PrimType value)
        {
            return new ADDBNullable<PrimType>(value);
        }

        public static implicit operator ADDBNullable<PrimType>(DBNull value)
        {
            return new ADDBNullable<PrimType>();
        }

        public static implicit operator PrimType(ADDBNullable<PrimType> value)
        {
            if (value.IsNull)
            {
                return default(PrimType);
            }

            return value.myValue;
        }

        public static bool operator ==(ADDBNullable<PrimType> value1, PrimType value2)
        {
            return value1.CompareTo(value2) == 0;
        }

        public static bool operator ==(ADDBNullable<PrimType> value1, ADDBNullable<PrimType> value2)
        {
            return value1.CompareTo(value2.Value) == 0;
        }

        public static bool operator !=(ADDBNullable<PrimType> value1, PrimType value2)
        {
            return value1.CompareTo(value2) != 0;
        }

        public static bool operator !=(ADDBNullable<PrimType> value1, ADDBNullable<PrimType> value2)
        {
            return value1.CompareTo(value2.Value) != 0;
        }

        public static bool operator >(ADDBNullable<PrimType> value1, PrimType value2)
        {
            return value1.CompareTo(value2) == 1;
        }

        public static bool operator >(ADDBNullable<PrimType> value1, ADDBNullable<PrimType> value2)
        {
            return value1.CompareTo(value2.Value) == 1;
        }

        public static bool operator <(ADDBNullable<PrimType> value1, PrimType value2)
        {
            return value1.CompareTo(value2) == -1;
        }

        public static bool operator <(ADDBNullable<PrimType> value1, ADDBNullable<PrimType> value2)
        {
            return value1.CompareTo(value2.Value) == -1;
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() == typeof(DBNull))
            {
                return IsNull ? 0 : 1;
            }

            return myValue.CompareTo(obj);
        }

        public override bool Equals(object obj)
        {
            if (obj is ADDBNullable<PrimType> nullableValue)
            {
                return this == nullableValue;
            }

            if (obj is PrimType typedValue)
            {
                return this == typedValue;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return IsNull ? 0 : myValue.GetHashCode();
        }

        public override string ToString()
        {
            return IsNull ? string.Empty : myValue.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (IsNull)
            {
                info.SetType(typeof(DBNull));
                info.AddValue("ADDBNullable", DBNull.Value);
            }
            else
            {
                info.SetType(typeof(PrimType));
                info.AddValue("ADDBnullable", TypedValue);
            }
        }
    }
}
