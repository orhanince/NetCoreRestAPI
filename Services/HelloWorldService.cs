namespace NetCoreRestAPI.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetGreeting()
        {
            return "Hello from HelloWorldService!";
        }
    }
}