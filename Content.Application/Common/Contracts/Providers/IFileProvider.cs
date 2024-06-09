using Microsoft.AspNetCore.Http;

namespace Content.Application.Common.Contracts.Providers;

public interface IFileProvider
{
    public Task<bool> CheckFileExtensionAsync(IFormFile file, string[] allowedExtensions);

    public Task<string> SaveFileAsync(IFormFile file, CancellationToken cancellationToken);

    public Task DeleteFileAsync(string path, CancellationToken cancellationToken);

    public Task<bool> FileExistsAsync(string path, CancellationToken cancellationToken);

    public Task<string> GetFileUrlAsync(string path, CancellationToken cancellationToken);

    public Task<string> GetFilePathAsync(string path, CancellationToken cancellationToken);
}