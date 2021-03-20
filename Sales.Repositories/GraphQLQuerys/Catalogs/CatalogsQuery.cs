
using HotChocolate;
using HotChocolate.Data;
using Sales.Repositories.Entities;
using Sales.Repositories.Persistence;
using System.Linq;
namespace Sales.Repositories.GraphQLQuerys.Catalogs
{
    public class CatalogsQuery
    {
        [UseDbContext(typeof(DbSalesContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategorys([ScopedService] DbSalesContext context)
        {
            return context.Categories;
        }
     
    }
}
