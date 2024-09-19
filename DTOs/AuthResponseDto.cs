namespace NetCoreRestAPI.Dtos
{
    public class AuthResponseDto
    {
        required
        public int userID { get; set; }

        required
        public string? AccessToken { get; set; }

        required
        public int ExpiresIn { get; set; }

        required
        public string? RefreshToken { get; set; }

        required
        public int RefreshTokenExpiresIn { get; set; }
    }
}
