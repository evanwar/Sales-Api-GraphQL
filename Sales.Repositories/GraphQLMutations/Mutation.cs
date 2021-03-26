namespace Sales.Repositories.GraphQLMutations
{
    using HotChocolate;
    using HotChocolate.Data;
    using HotChocolate.Subscriptions;
    using Sales.Entitys.Request.Catalogs;
    using Sales.Entitys.Request.DB;
    using Sales.Repositories.Entities;
    using Sales.Repositories.Persistence;
    using System;
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
            await eventSender.SendAsync("OnCategorySubscribe", newCategory);
            return newCategory;
        }





        #region Customers

        [UseDbContext(typeof(DbSalesContext))]
        public async Task<Customer> AddCustomerAsync(CustomerRequest input,
                                                     [ScopedService] DbSalesContext context,
                                                     [Service] ITopicEventSender eventSender,
                                                     CancellationToken cancellationToken)
        {

            try
            {
                var newCustomer = new Customer
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email,
                    PhoneNumber = input.PhoneNumber,
                    Talacheria = input.Talacheria,
                    CreationDate = DateTime.Now,
                    Status = true
                };

                context.Customers.Add(newCustomer);
                await context.SaveChangesAsync();

                return newCustomer;
            }
            catch (Exception ex)
            {
                return null;
            }

        
        }

        #endregion

    }
}
