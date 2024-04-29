using PhotoGallery.Server.Services.Interfaces;

namespace PhotoGallery.Server.Services;

/// <summary>
/// Service for managing files.
/// </summary>
public class FileService : IFileService
{
    public async Task<string> SaveFileAsync(IFormFile file, string nameOfFile, Guid userId)
    {
        if (file is null || file.Length == 0)
            throw new ArgumentException("File is empty", nameof(file));

        var path = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot",
            "images",
            userId.ToString(),
            nameOfFile);

        //check if directory exists
        if (!Directory.Exists(Path.GetDirectoryName(path)))
            Directory.CreateDirectory(Path.GetDirectoryName(path));

        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        var relativePath = Path.Combine("images", userId.ToString(), nameOfFile);

        return relativePath;
    }

    public Task DeleteFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(IEnumerable<string> filePaths)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> GetFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }
}