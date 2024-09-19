namespace NetCoreRestAPI.Dtos
{
    public class RegisterDto
    {
        required
        public string username { get; set; }
        required
        public string email { get; set; }
        required
        public string password { get; set; }
    }
}