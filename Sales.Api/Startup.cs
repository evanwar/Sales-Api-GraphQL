using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sales.Repositories.GraphQLQuerys.Catalogs;
using Sales.Repositories.GraphQLTypes.Catalogs;
using Sales.Repositories.Persistence;
using Sales.Resources.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .AddQueryType<CatalogsQuery>()
                .AddType<CategoryType>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();

       
                                                      

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
               .UseRouting()
               .UseEndpoints(endpPoints =>
               {
                   endpPoints.MapGraphQL();
               });
        }
    }
}
