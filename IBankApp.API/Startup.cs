using iBankApp.API.Automapper;
using iBankApp.Core.Data.Model;
using iBankApp.Core.Domain.Repository;
using iBankApp.Data.Setup;
using iBankApp.Interfaces.Data;
using iBankApp.Services;
using iBankApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace IBankApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;


            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<iBankAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("iBankConnection")));

            services.AddScoped(typeof(ICustomerServices), typeof(CustomerServices));
            services.AddScoped(typeof(ITransactionServices), typeof(TransactionService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(CustomerRepository<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(AccountRepository<>));


            var mapperConfiguration = new AutoMapperConfiguration();
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().AddJsonOptions(o =>
            {
                if (o.SerializerSettings.ContractResolver == null) return;
                var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                castedResolver.NamingStrategy = null;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();

            //  NOTE: this must go at the end of Configure
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<iBankAppContext>();
                dbContext.Database.EnsureCreated();
                new iBankDataSetup(dbContext).SetUpData();
            }

            //Initial data setup
        }
    }
}