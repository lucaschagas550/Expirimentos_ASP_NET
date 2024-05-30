using System.ComponentModel.DataAnnotations;

namespace TestTabelaResponivaBoostrap.Utils
{
    public static class EnumHelper<T>
    {
        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes == null) return string.Empty;
                return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Name : value.ToString();
            }
            return value.ToString();
        }

        public static string GetShortNameValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];



                if (descriptionAttributes == null) return string.Empty;
                return descriptionAttributes.Length > 0 ? descriptionAttributes[0].ShortName : value.ToString();
            }
            return value.ToString();
        }
    }
}
