using MenuFacile.Manager.Application.Services;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MenuFacile.Manager.Api
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

            services.AddControllers();

            services.AddTransient<ISegmentService, SegmentService>();
            services.AddTransient<ISegmentRepository, SegmentRepository>();
            
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();

            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IStateRepository, StateRepository>();

            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductItemService, ProductItemService>();
            services.AddTransient<IProductItemRepository, ProductItemRepository>();

            services.AddTransient<IProductPriceService, ProductPriceService>();
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();

            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();

            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IMenuRepository, MenuRepository>();

            services.AddTransient<IMenuItemService, MenuItemService>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();

            services.AddTransient<IRestaurantUserService, RestaurantUserService>();
            services.AddTransient<IRestaurantUserRepository, RestaurantUserRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MenuFacile.Manager.Api", Version = "v1" });
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MenuFacile.Manager.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
