using System;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace SurveyMonkey.Converters
{
    public class DefaultEnumMapConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type myType = value.GetType();
            writer.WriteValue(EnumRenameMap.MappedName(myType.Name, Enum.GetName(myType, value)));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object myType = null;
            // This is really tacky, but I am not sure how else to grab the real type and real name.
            string EnumName = Regex.Replace(objectType.FullName, @".*SurveyMonkey\.(.*), Survey.*", "$1");
            Type enumType = EnumRenameMap.GetEnumObject(EnumName);
            if (enumType == null)
            {
                enumType = objectType;
                EnumName = objectType.Name;
            }

            string mappedValue = EnumRenameMap.MappedValue(EnumName, (string)reader.Value);

            myType = Enum.Parse(enumType, mappedValue);

            return myType;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

    }
}
