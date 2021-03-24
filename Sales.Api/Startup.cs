using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sales.Repositories.GraphQLMutations;
using Sales.Repositories.GraphQLQuerys.Querys;
using Sales.Repositories.GraphQLSubscriptions;
using Sales.Repositories.GraphQLTypes.Catalogs;
using Sales.Repositories.GraphQLTypes.MainData;
using Sales.Repositories.Persistence;
using Sales.Resources.Settings;


namespace Sales.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddPooledDbContextFactory<DbSalesContext>(opt => opt.UseSqlServer
             (Configuration.GetConnectionString(ConfigurationResources.DbConnection)));

            services.
                AddGraphQLServer()
                .AddQueryType<Querys>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscriptions>()
                .AddType<CategoryType>()
                .AddType<ProductsType>()
                .AddType<CustomersType>()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddInMemorySubscriptions();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app
               .UseRouting()
               .UseEndpoints(endpPoints =>
               {
                   endpPoints.MapGraphQL();
               });
        }
    }
}
