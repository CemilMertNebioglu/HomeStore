using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.BLL.Abstract;
using Store.BLL.StoreServices;
using Store.Core.Data.UnitofWork;
using Store.DAL;
using Store.Mapping.ConfigProfile;
using Store.WebUI.Clients.Abstract;
using Store.WebUI.Clients.Services;

namespace Store.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfig.RegisterMappers();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IUnitofWork, UnitofWork>();
            services.AddSingleton<DbContext, StoreDbContext>();

            #region HttpClients
            services.AddHttpClient<ICategoryClient, CategoryClient>(client =>
               {
                   client.DefaultRequestHeaders.Add("Accept", "application/json");
               });

            services.AddHttpClient<IContractClient, ContractClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<ICustomerClient, CustomerClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IDealerClient, DealerClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IDepartmentClient, DepartmentClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IOrderClient, OrderClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IOrderDetailClient, OrderDetailClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IProductClient, ProductClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IProductSupplierClient, ProductSupplierClient>(client =>
             {
                 client.DefaultRequestHeaders.Add("Accept", "application/json");
             });
            services.AddHttpClient<IRecPersonClient, RecPersonClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<IRoleClient, RoleClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<ISupplierClient, SupplierClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient<ISurveysClient, SurveyClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                #region CategoryRoute
                endpoints.MapControllerRoute(
                           name: "Categories",
                           pattern: "Categories/GetAll",
                           defaults: new { controller = "Admin", action = "CategoryList" });
                endpoints.MapControllerRoute(
                   name: "Categories",
                   pattern: "Categories/Add",
                   defaults: new { controller = "Admin", action = "CategoryAdd" });
                endpoints.MapControllerRoute(
                   name: "Categories",
                   pattern: "Categories/Update",
                   defaults: new { controller = "Admin", action = "CategoryEdit" });
                endpoints.MapControllerRoute(
                   name: "Categories",
                   pattern: "Categories/Delete",
                   defaults: new { controller = "Admin", action = "CategoryDelete" });
                #endregion

                #region ContractRoute
                endpoints.MapControllerRoute(
                         name: "Contracts",
                         pattern: "Contracts/GetAll",
                         defaults: new { controller = "Admin", action = "ContractList" });

                endpoints.MapControllerRoute(
                   name: "Contracts",
                   pattern: "Contracts/Add",
                   defaults: new { controller = "Admin", action = "ContractAdd" });

                endpoints.MapControllerRoute(
                   name: "Contracts",
                   pattern: "Contracts/Update",
                   defaults: new { controller = "Admin", action = "ContractEdit" });

                endpoints.MapControllerRoute(
                   name: "Contracts",
                   pattern: "Contracts/Delete",
                   defaults: new { controller = "Admin", action = "ContractDelete" });
                #endregion

                #region CustomerRoute
                endpoints.MapControllerRoute(
                           name: "Customers",
                           pattern: "Customers/GetAll",
                           defaults: new { controller = "Admin", action = "CustomersList" });

                endpoints.MapControllerRoute(
                   name: "Customers",
                   pattern: "Customers/Add",
                   defaults: new { controller = "Admin", action = "CustomerAdd" });
                endpoints.MapControllerRoute(
                  name: "Customers",
                  pattern: "Customers/Update",
                  defaults: new { controller = "Admin", action = "CustomerEdit" });
                endpoints.MapControllerRoute(
                  name: "Customers",
                  pattern: "Customers/Delete",
                  defaults: new { controller = "Admin", action = "CustomerDelete" });
                #endregion

                #region DealerRoute
                endpoints.MapControllerRoute(
                       name: "Dealers",
                       pattern: "Dealers/GetAll",
                       defaults: new { controller = "Admin", action = "DealerList" });
                endpoints.MapControllerRoute(
                  name: "Dealers",
                  pattern: "Dealers/Add",
                  defaults: new { controller = "Admin", action = "DealerAdd" });
                endpoints.MapControllerRoute(
                  name: "Dealers",
                  pattern: "Dealers/Update",
                  defaults: new { controller = "Admin", action = "DealerEdit" });
                endpoints.MapControllerRoute(
                  name: "Dealers",
                  pattern: "Dealers/Delete",
                  defaults: new { controller = "Admin", action = "DealerDelete" });
                #endregion

                #region DepartmentRoute
                endpoints.MapControllerRoute(
                         name: "Department",
                         pattern: "Department/GetAll",
                         defaults: new { controller = "Admin", action = "DepartmentList" });
                endpoints.MapControllerRoute(
                 name: "Department",
                 pattern: "Department/Add",
                 defaults: new { controller = "Admin", action = "DepartmentAdd" });
                endpoints.MapControllerRoute(
                 name: "Department",
                 pattern: "Department/Update",
                 defaults: new { controller = "Admin", action = "DepartmentEdit" });
                endpoints.MapControllerRoute(
                 name: "Department",
                 pattern: "Department/Delete",
                 defaults: new { controller = "Admin", action = "DepartmentDelete" });
                #endregion

                #region OrderRoute
                endpoints.MapControllerRoute(
                                 name: "Orders",
                                 pattern: "Orders/GetAll",
                                 defaults: new { controller = "Admin", action = "OrdersList" });
                endpoints.MapControllerRoute(
                        name: "Orders",
                        pattern: "Orders/Add",
                        defaults: new { controller = "Admin", action = "OrdersAdd" });
                endpoints.MapControllerRoute(
                        name: "Orders",
                        pattern: "OrderDetails/Add",
                        defaults: new { controller = "Admin", action = "OrderDetailAdd" });
                endpoints.MapControllerRoute(
                        name: "Orders",
                        pattern: "Orders/Update",
                        defaults: new { controller = "Admin", action = "OrdersEdit" });
                endpoints.MapControllerRoute(
                        name: "Orders",
                        pattern: "Orders/Delete",
                        defaults: new { controller = "Admin", action = "OrdersDelete" });
                #endregion

                #region ProductRoute
                endpoints.MapControllerRoute(
                                        name: "Products",
                                        pattern: "Products/GetAll",
                                        defaults: new { controller = "Admin", action = "ProductList" });
                endpoints.MapControllerRoute(
                               name: "Products",
                               pattern: "Products/Add",
                               defaults: new { controller = "Admin", action = "ProductAdd" });
                endpoints.MapControllerRoute(
                               name: "Products",
                               pattern: "Products/Update",
                               defaults: new { controller = "Admin", action = "ProductEdit" });
                endpoints.MapControllerRoute(
                               name: "Products",
                               pattern: "Products/Delete",
                               defaults: new { controller = "Admin", action = "ProductDelete" });
                #endregion

                #region RecPersonRoute
                endpoints.MapControllerRoute(
                                       name: "RecPersons",
                                       pattern: "RecPersons/GetAll",
                                       defaults: new { controller = "Admin", action = "RecPersonList" });
                endpoints.MapControllerRoute(
                          name: "RecPersons",
                          pattern: "RecPersons/Add",
                          defaults: new { controller = "Admin", action = "RecPersonAdd" });
                endpoints.MapControllerRoute(
                          name: "RecPersons",
                          pattern: "RecPersons/Update",
                          defaults: new { controller = "Admin", action = "RecPersonEdit" });
                endpoints.MapControllerRoute(
                          name: "RecPersons",
                          pattern: "RecPersons/Delete",
                          defaults: new { controller = "Admin", action = "RecPersonDelete" });
                #endregion

                #region RoleRoute
                endpoints.MapControllerRoute(
                                            name: "Roles",
                                            pattern: "Roles/GetAll",
                                            defaults: new { controller = "Admin", action = "RoleList" });
                endpoints.MapControllerRoute(
                                     name: "Roles",
                                     pattern: "Roles/Add",
                                     defaults: new { controller = "Admin", action = "RoleAdd" });
                endpoints.MapControllerRoute(
                                     name: "Roles",
                                     pattern: "Roles/Update",
                                     defaults: new { controller = "Admin", action = "RoleEdit" });
                endpoints.MapControllerRoute(
                                     name: "Roles",
                                     pattern: "Roles/Delete",
                                     defaults: new { controller = "Admin", action = "RoleDelete" });
                #endregion

                #region SupplierRoute
                endpoints.MapControllerRoute(
                                             name: "Suppliers",
                                             pattern: "Suppliers/GetAll",
                                             defaults: new { controller = "Admin", action = "SupplierList" });
                endpoints.MapControllerRoute(
                                  name: "Suppliers",
                                  pattern: "Suppliers/Add",
                                  defaults: new { controller = "Admin", action = "SupplierAdd" });
                endpoints.MapControllerRoute(
                                  name: "Suppliers",
                                  pattern: "Suppliers/Update",
                                  defaults: new { controller = "Admin", action = "SupplierEdit" });
                endpoints.MapControllerRoute(
                                  name: "Suppliers",
                                  pattern: "Suppliers/Delete",
                                  defaults: new { controller = "Admin", action = "SupplierList" });
                #endregion

                #region SurveyRoute

                endpoints.MapControllerRoute(
                                         name: "Surveys",
                                         pattern: "Surveys/GetAll",
                                         defaults: new { controller = "Admin", action = "SurveyList" });
                endpoints.MapControllerRoute(
                           name: "Surveys",
                           pattern: "Surveys/Add",
                           defaults: new { controller = "Admin", action = "SurveyAdd" });
                endpoints.MapControllerRoute(
                           name: "Surveys",
                           pattern: "Surveys/Update",
                           defaults: new { controller = "Admin", action = "SurveyEdit" });
                endpoints.MapControllerRoute(
                           name: "Surveys",
                           pattern: "Surveys/Delete",
                           defaults: new { controller = "Admin", action = "SurveyDelete" }); 
                #endregion
            });
        }
    }
}
