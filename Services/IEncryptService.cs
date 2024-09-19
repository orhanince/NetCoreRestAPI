using NetCoreRestAPI.Dtos;

namespace NetCoreRestAPI.Services
{
    public interface IEncryptService
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hashedPassword);
    }
}
