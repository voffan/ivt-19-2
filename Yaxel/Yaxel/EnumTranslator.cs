using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Yaxel
{
    internal static class EnumDictionaries
    {
        public static Dictionary<string, string> CompStatus = EnumTranslator.DescriptionAttributes<Classes.Status>.RetrieveBackConverter();
        public static Dictionary<string, string> AttrTypeTranslation = EnumTranslator.DescriptionAttributes<Classes.AttrType>.RetrieveBackConverter();
        public static Dictionary<string, string> ComponentTypeTranslation = EnumTranslator.DescriptionAttributes<Classes.ComponentType>.RetrieveBackConverter();
        public static Dictionary<string, string> PeripheryStatus = EnumTranslator.DescriptionAttributes<Classes.Status>.RetrieveBackConverter();
        public static Dictionary<string, string> TranslationType = EnumTranslator.DescriptionAttributes<Classes.PeripheryType>.RetrieveBackConverter();
        public static Dictionary<string, string> EmployeePosition = EnumTranslator.DescriptionAttributes<Classes.Position>.RetrieveBackConverter();
     
    }

    internal class EnumTranslator
    {
        public static class DescriptionAttributes<T>
        {
            public static Dictionary<string, string> RetrieveBackConverter()
            {
                Dictionary<string, string> Attributes = new Dictionary<string, string>();

                foreach (var memberInfo in typeof(T).GetMembers())
                {
                    DescriptionAttribute[] list = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().ToArray();
                    if (list.Length > 0)
                    {
                        Attributes[memberInfo.Name] = list[0].Description;
                    }
                }

                return Attributes;
            }

            public static Dictionary<string, string> RetrieveAttributes()
            {
                Dictionary<string, string> Attributes = new Dictionary<string, string>();

                foreach (var memberInfo in typeof(T).GetMembers())
                {
                    DescriptionAttribute[] list = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>().ToArray();
                    if (list.Length > 0)
                    {
                        Attributes[list[0].Description] = memberInfo.Name;
                    }
                }

                return Attributes;
            }
        }
    }
}
