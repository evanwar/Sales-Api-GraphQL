namespace Sales.Repositories.GraphQLTypes.MainData
{
    using HotChocolate.Types;
    using Sales.Repositories.Entities;
    public class CustomersType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Description("Hace referencia a los clientes");
        }
    }
}
