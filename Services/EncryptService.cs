namespace NetCoreRestAPI.Services
{
    public class EncryptService : IEncryptService
    {
        public async Task<string> HashPasswordAsync(string password)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(password));
        }

        public async Task<bool> VerifyPasswordAsync(string password, string hashedPassword)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, hashedPassword));
        }
    }
}