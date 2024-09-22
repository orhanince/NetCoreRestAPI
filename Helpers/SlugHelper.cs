using System.Text;
namespace NetCoreRestAPI.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            // Convert to lower case
            title = title.ToLowerInvariant();

            // Replace spaces with hyphens
            title = title.Replace(" ", "-");

            // Remove invalid characters
            var slug = new StringBuilder();
            foreach (char c in title)
            {
                if (char.IsLetterOrDigit(c) || c == '-')
                {
                    slug.Append(c);
                }
            }

            return slug.ToString();
        }
    }
}

