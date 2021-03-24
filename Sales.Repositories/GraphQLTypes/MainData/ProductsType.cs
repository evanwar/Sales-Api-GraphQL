namespace Sales.Repositories.GraphQLTypes.MainData
{
    using HotChocolate;
    using HotChocolate.Types;
    using Sales.Repositories.Entities;
    using Sales.Repositories.Persistence;
    using System.Linq;

    public class ProductsType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Representa los productos vendidos");

            descriptor.
                Field(p => p.IdCategoryNavigation)
                //.ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<DbSalesContext>()
                .Description("Categoria por producto");
        }

        private class Resolvers
        {
            public IQueryable<Category> GetCommands(Product product, [ScopedService] DbSalesContext context)
            {
                return context.Categories.Where(p => p.IdCategory == product.IdCategory);
            }
        }
    }
}
