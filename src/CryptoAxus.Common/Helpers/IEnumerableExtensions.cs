namespace CryptoAxus.Common.Helpers;

public static class IEnumerableExtensions
{
    public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source, string? fields)
    {
        ArgumentNullException.ThrowIfNull(argument: source, paramName: nameof(source));

        List<ExpandoObject> expandoObjectList = new List<ExpandoObject>();

        List<PropertyInfo> propertyInfoList = new List<PropertyInfo>();

        if (string.IsNullOrWhiteSpace(fields))
        {
            PropertyInfo[] propertyInfos = typeof(TSource).GetProperties(bindingAttr: BindingFlags.IgnoreCase |
                                                                         BindingFlags.Public |
                                                                         BindingFlags.Instance);
            propertyInfoList.AddRange(collection: propertyInfos);
        }
        else
        {
            string[] fieldsAfterSplit = fields.Split(separator: ',');
            foreach (string field in fieldsAfterSplit)
            {
                string propertyName = field.Trim();
                PropertyInfo? propertyInfo = typeof(TSource).GetProperty(name: propertyName, bindingAttr: BindingFlags.IgnoreCase |
                                                                         BindingFlags.Public |
                                                                         BindingFlags.Instance);
                if (propertyInfo == null)
                    throw new Exception(message: $"Property {propertyName} wasn't found on {typeof(TSource)}");
                propertyInfoList.Add(item: propertyInfo);
            }
        }

        foreach (TSource sourceObject in source)
        {
            ExpandoObject dataShapedObject = new ExpandoObject();
            foreach (PropertyInfo? propertyInfo in propertyInfoList)
            {
                object? propertyValue = propertyInfo.GetValue(obj: sourceObject);
                (dataShapedObject as IDictionary<string, object>).Add(key: propertyInfo.Name,
                                                                      value: propertyValue ?? throw new InvalidOperationException());
            }
            expandoObjectList.Add(item: dataShapedObject);
        }

        return expandoObjectList;
    }
}