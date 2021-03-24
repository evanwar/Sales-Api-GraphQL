namespace Sales.Repositories.GraphQLSubscriptions
{
    using HotChocolate;
    using HotChocolate.Execution;
    using HotChocolate.Subscriptions;
    using HotChocolate.Types;
    using Sales.Repositories.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class Subscriptions
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Category>> OnCategorySubscribe([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Category>(nameof(OnCategorySubscribe), cancellationToken);
        }
    }
}
