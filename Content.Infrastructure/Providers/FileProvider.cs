using Content.Application.Common.Contracts.Providers;
using Microsoft.AspNetCore.Http;

namespace Content.Infrastructure.Providers;

public class FileProvider : IFileProvider
{
    public async Task<bool> CheckFileExtensionAsync(IFormFile file, string[] allowedExtensions)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return allowedExtensions.Contains(extension);
    }

    public async Task<string> SaveFileAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }

        return $"/uploads/{fileName}";
    }

    public async Task DeleteFileAsync(string path, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public async Task<bool> FileExistsAsync(string path, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
        return File.Exists(filePath);
    }

    public async Task<string> GetFileUrlAsync(string path, CancellationToken cancellationToken)
    {
        return path;
    }

    public async Task<string> GetFilePathAsync(string path, CancellationToken cancellationToken)
    {
        return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
    }
}