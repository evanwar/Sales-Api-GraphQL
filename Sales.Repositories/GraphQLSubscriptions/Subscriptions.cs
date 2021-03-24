namespace Sales.Repositories.GraphQLSubscriptions
{
    using HotChocolate;
    using HotChocolate.Types;
    using Sales.Repositories.Entities;

    public class Subscriptions
    {
        [Subscribe]
        [Topic]
        public Category OnCategorySubscribe([EventMessage] Category category)
        {
            return category;
        }
    }
}
