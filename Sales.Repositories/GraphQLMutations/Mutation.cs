namespace Sales.Repositories.GraphQLMutations
{
    using HotChocolate;
    using HotChocolate.Data;
    using HotChocolate.Subscriptions;
    using Sales.Entitys.Request.Catalogs;
    using Sales.Repositories.Entities;
    using Sales.Repositories.Persistence;
    using System.Threading;
    using System.Threading.Tasks;
    public class Mutation
    {
        [UseDbContext(typeof(DbSalesContext))]
        public async Task<Category> AddCategoryAsync(CategoryRequest input,
                                                      [ScopedService] DbSalesContext context,
                                                       [Service] ITopicEventSender eventSender,
                                                        CancellationToken cancellationToken)
        {


            var newCategory = new Category
            {
                Name = input.Name,
                Description = input.Description
            };

            context.Categories.Add(newCategory);
            await context.SaveChangesAsync();
            await eventSender.SendAsync(nameof(Category), newCategory, cancellationToken);
            return newCategory;
        }
    }
}
