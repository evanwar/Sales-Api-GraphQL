namespace Sales.Repositories.GraphQLQuerys.Querys
{
    using HotChocolate;
    using HotChocolate.Data;
    using Sales.Repositories.Entities;
    using Sales.Repositories.Persistence;
    using System.Linq;
    public class Querys
    {
        [UseDbContext(typeof(DbSalesContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategorys([ScopedService] DbSalesContext context)
        {
            return context.Categories;
        }


        [UseDbContext(typeof(DbSalesContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts([ScopedService] DbSalesContext context)
        {
            return context.Products;
        }


        [UseDbContext(typeof(DbSalesContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([ScopedService] DbSalesContext context)
        {
            return context.Customers;
        }

    }
}
