using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ShoppingCart.Business.Managers.ShoppingCart;
using ShoppingCart.Business.Managers.ShoppingCart.Helpers;
using ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository;
using ShoppingCart.Data.Repositories.Couchbase.SoppingCartRepository.BucketProvider;
using System;

namespace ShoppingCart.API
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
            services.AddSingleton<IShoppingCartManager, ShoppingCartManager>();

            var options = new ClusterOptions
            {
                QueryTimeout = TimeSpan.FromSeconds(10)
            };

            services.AddCouchbase(options =>
            {
                Configuration.GetSection("Couchbase").Bind(options);
            }).AddCouchbaseBucket<IShoppingCartBucketProvider>("shoppingcart-bucket");


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingCart.API", Version = "v1" });
            });


            services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton<IShoppingCartValidations, ShoppingCartValidations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCart.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close();
            });
        }
    }
}
