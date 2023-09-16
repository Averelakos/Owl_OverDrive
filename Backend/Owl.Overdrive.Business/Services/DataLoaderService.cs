using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Infrastructure.Persistence.Migrations;
using System.Collections;

namespace Owl.Overdrive.Business.Services
{
    public class DataLoaderService<S>
    {
        private readonly IQueryable<S> Source;
        private readonly DataSourceLoaderContext Context;

        public DataLoaderService(IQueryable<S> source, DataLoaderOptions options)
        {
            Source = source;
            Context = new DataSourceLoaderContext(options);
        }

        public async Task<DataResult<S>> LoadResult()
        {
            DataResult<S> result = new DataResult<S>();
            result.Data = Source.ToList();

            if (Context.HasPaging)
            {
                result.Data = Paginate(result.Data, Context.Skip, Context.Take);
            }

            result.TotalCount = TotalCount(result.Data);

            result.TotalPages = TotalPages(result.TotalCount, Context.Take);

            return result;
        }

        private static IEnumerable<T> Paginate<T>(IEnumerable<T> data, int skip, int take)
        {
            if (skip < 1 && take < 1)
            {
                return data;
            }

            IEnumerable<T> enumerable = data.Cast<T>();

            if (skip > 0)
            {
                enumerable = enumerable.Skip(skip);
            }

            if (take > 0)
            {
                enumerable = enumerable.Take(take);
            }

            return enumerable;
        }

        private static int TotalCount(IEnumerable data)
        {
            if (data is null)
                return 0;

            ICollection collection = data.Cast<object>().ToList();

            if (collection is not null && collection.Count > 0)
            {
                return collection.Count;
            }

            return 0;
        }

        private static int TotalPages(int totalCount, int pageSize)
        {
            if (totalCount is 0 || pageSize is 0)
                return 0;

            return (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        
    }
}
