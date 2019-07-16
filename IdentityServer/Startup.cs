// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.IO;
using IdentityServer4;
using DbAccessLayer.Repository;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IdentityServer
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you wan to add an MVC-based UI
            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               .AddInMemoryApiResources(Config.GetApis())
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryClients(Config.GetClients())
               .AddProfileService<ProfileService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentityServer();


            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to support static files
            //app.UseStaticFiles();


            // uncomment, if you wan to add an MVC-based UI
            //app.UseMvcWithDefaultRoute();
        }
    }
}