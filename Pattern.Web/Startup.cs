﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pattern.DAL;
using Pattern.Factories;
using Pattern.Mappers;
using Pattern.Component;
namespace Pattern.Web
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
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMapperFactory, MapperFactory>();
            services.AddScoped<IMapperNamesHelper, MapperNamesHelpers>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IProductMapper, NullProductMapper>();
            services.AddScoped<IProductComponent, ProductComponent>();
            services.AddScoped<IProductViewModelMapper, ProductViewModelMapper>();

            services.AddScoped<NullProductMapper>();
            services.AddScoped<ProductMapper>();
            services.AddScoped<ProductViewModelMapper>();
            services.AddScoped<NullProductViewModelMapper>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
