using System.Text;
using Slugify;
namespace NetCoreRestAPI.Helpers
{
    public static class SlugGenerator
    {
        public static string GenerateSlug(string title)
        {
            var config = new SlugHelperConfiguration();
            config.AllowedChars.Add('I');
            config.AllowedChars.Add('ı');
            config.StringReplacements = new Dictionary<string, string> {
                [" "] = "-",
                ["ı"] = "i",
                ["I"] = "i"
            };
            return new SlugHelper(config).GenerateSlug(title);
        }
    }
}