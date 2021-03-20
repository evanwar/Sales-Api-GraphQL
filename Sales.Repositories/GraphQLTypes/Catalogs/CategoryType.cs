namespace Sales.Repositories.GraphQLTypes.Catalogs
{
    using HotChocolate;
    using HotChocolate.Types;
    using Sales.Repositories.Entities;
    using Sales.Repositories.Persistence;
    using System.Linq;


    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Description("Representa la categoria de productos");

            descriptor
             .Field(p => p.Products)
             .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
             .UseDbContext<DbSalesContext>()
             .Description("Lista de productos por categoria");
        }

        private class Resolvers
        {
            public IQueryable<Product> GetCommands(Category category, [ScopedService] DbSalesContext context)
            {
                return context.Products.Where(p => p.IdCategory == category.IdCategory);
            }
        }
    }
}
