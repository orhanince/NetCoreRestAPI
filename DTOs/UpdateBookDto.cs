namespace NetCoreRestAPI.Dtos
{
    public class UpdateBookDto
    {
        /// <summary>
        /// Book title.
        /// </summary>
        required
        public string title { get; set; }

        /// <summary>
        /// Book author.
        /// </summary>
        required
        public int authorID { get; set; }
    }
}