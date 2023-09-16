namespace Owl.Overdrive.Business.Services.Models
{
    public class DataLoaderOptions
    {
        /// <summary>
        /// The number of data objects to be skipped from the start of the resulting set.
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// The number of data objects to be loaded.
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// User search input.
        /// </summary>
        public string? SearchString { get; set; }
    }
}
