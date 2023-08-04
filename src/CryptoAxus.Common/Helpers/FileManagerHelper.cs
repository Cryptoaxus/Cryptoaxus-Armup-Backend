namespace CryptoAxus.Common.Helpers;

public static class FileManagerHelper
{
    public static string WriteFile(IFormFile file, UploadFileType fileType)
    {
        string fileName;
        if (file.Length > 0)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), fileType.Equals(UploadFileType.ProfileImage) ?
                                            $"Upload\\ProfileImages\\{file.FileName}" :
                                            $"Upload\\CoverImages\\{file.FileName}");
            using var stream = new FileStream(imagePath, FileMode.Create);
            stream.Write(fileBytes, 0, fileBytes.Length);
            stream.Flush();
        }

        return file.FileName;
    }
}