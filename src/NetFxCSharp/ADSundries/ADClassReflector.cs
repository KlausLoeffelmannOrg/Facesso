using System.Collections.ObjectModel;
using System.Reflection;

namespace ActiveDev
{

    public static class ADClassReflector
    {

        public static ADPropertyInfoCollection GetProperties(object classInstance)
        {
            PropertyInfo[] locPropertyInfos = classInstance.GetType().GetProperties();
            if (locPropertyInfos.Length == 0)
                return null;
            var retPropertyInfoCollection = new ADPropertyInfoCollection();
            foreach (PropertyInfo locPropertyInfo in locPropertyInfos)
                retPropertyInfoCollection.Add(locPropertyInfo);
            return retPropertyInfoCollection;
        }

    }

    public class ADPropertyInfoCollection : KeyedCollection<string, PropertyInfo>
    {

        protected override string GetKeyForItem(PropertyInfo item)
        {
            return item.Name;
        }
    }
}