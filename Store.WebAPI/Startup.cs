using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.BLL.Abstract;
using Store.BLL.StoreServices;
using Store.Core.Data.UnitofWork;
using Store.DAL;
using Store.Mapping.ConfigProfile;

namespace Store.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            MapperConfig.RegisterMappers();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(z => z.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "StoreAPI", Version = "v1" }));
           
            services.AddControllers();

            services.AddSingleton<DbContext, StoreDbContext>();
            services.AddSingleton<IUnitofWork, UnitofWork>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDealerService, DealerService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderService, OrderService>();  
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRecPersonService, RecPersonService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISurveyService, SurveyService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IProductSupplierService, ProductSupplierService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(z =>
            
                z.SwaggerEndpoint("/swagger/v1/swagger.json" , "StoreAPI"));
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
