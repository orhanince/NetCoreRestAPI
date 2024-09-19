namespace NetCoreRestAPI.Dtos
{
    public class LoginDto
    {
        required
        public string email { get; set; }
        required
        public string password { get; set; }
    }
}
