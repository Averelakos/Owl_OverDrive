using Owl.Overdrive.Business.Services.Models;

namespace Owl.Overdrive.Business.Services
{
    public class DataSourceLoaderContext
    {
        private readonly DataLoaderOptions _options;
        public DataSourceLoaderContext(DataLoaderOptions options)
        {
            _options = options;
        }

        public int Skip => _options.Skip;
        public int Take => _options.Take;
        public string? SearchInput => _options.SearchString;

        public bool HasPaging
        {
            get
            {
                if (Skip <= 0)
                {
                    return Take > 0;
                }

                return true;
            }
        }

        public bool HasSearchInput
        {
            get
            {
                if (SearchInput is not null && SearchInput.Length > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}