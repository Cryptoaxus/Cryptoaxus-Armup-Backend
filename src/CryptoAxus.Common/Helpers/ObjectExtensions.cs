using MongoDB.Bson;

namespace CryptoAxus.Common.Helpers;

public static class ObjectExtensions
{
    public static ExpandoObject ShapeData<TSource>(this TSource source, string fields)
    {
        ArgumentNullException.ThrowIfNull(argument: source, paramName: nameof(source));

        ExpandoObject dataShapedObject = new ExpandoObject();
        if (string.IsNullOrWhiteSpace(value: fields))
        {
            // All public properties should be in the ExpandoObject 
            PropertyInfo[] propertyInfos = typeof(TSource).GetProperties(bindingAttr: BindingFlags.IgnoreCase |
                                                                         BindingFlags.Public |
                                                                         BindingFlags.Instance);

            foreach (var propertyInfo in propertyInfos)
            {
                // Get the value of the property on the source object
                object? propertyValue = propertyInfo.GetValue(obj: source);

                // Add the field to the ExpandoObject
                (dataShapedObject as IDictionary<string, object>).Add(key: propertyInfo.Name, value: propertyValue);
            }

            return dataShapedObject;
        }

        // The field are separated by ",", so we split it.
        string[] fieldsAfterSplit = fields.Split(separator: ',');

        foreach (string field in fieldsAfterSplit)
        {
            // Trim each field, as it might contain leading 
            // Or trailing spaces. Can't trim the var in foreach,
            // So use another var.
            string propertyName = field.Trim();

            // Use reflection to get the property on the source object
            // We need to include public and instance, b/c specifying a 
            // Binding flag overwrites the already-existing binding flags.
            PropertyInfo? propertyInfo = typeof(TSource).GetProperty(name: propertyName, bindingAttr: BindingFlags.IgnoreCase |
                                                                     BindingFlags.Public |
                                                                     BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new Exception(message: $"Property {propertyName} wasn't found on {typeof(TSource)}");
            }

            // Get the value of the property on the source object
            object? propertyValue = propertyInfo.GetValue(obj: source);

            // Add the field to the ExpandoObject
            (dataShapedObject as IDictionary<string, object>).Add(key: propertyInfo.Name, value: propertyValue);
        }

        // Return the list
        return dataShapedObject;
    }

    public static ObjectId ToObjectId(this object? value)
    {
        return new ObjectId(value?.ToString());
    }
}