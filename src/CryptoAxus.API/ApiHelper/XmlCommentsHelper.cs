namespace CryptoAxus.API.ApiHelper;

public static class XmlCommentsHelper
{
    public static string XmlCommentsFilePath()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
        return Path.Combine(basePath, fileName);
    }
}