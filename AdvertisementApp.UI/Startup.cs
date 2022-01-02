using AdvertisementApp.UI.Mappings.AutoMapper;
using AdvertisementApp.UI.Models.User;
using AdvertisementApp.UI.ValidationRulesVM.FluentValidation;
using AdvertisementApp_Bussiness.DependencyResolvers.Microsoft;
using AdvertisementApp_Bussiness.Mappings;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI
{
    public class Startup
    {
        IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(_configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

            //Custom Based Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.Cookie.Name = "myAdvetisementCookie";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(7);
                opt.LoginPath = new PathString("/UserAccount/Login");
                opt.LogoutPath = new PathString("/UserAccount/Logout");
                opt.AccessDeniedPath = new PathString("/UserAccount/AccessDenied");
            });


            services.AddControllersWithViews();

            //AUTOMAPPER CONFIG
            var profiles = MappingHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());
            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Services}/{action=Index}/{id?}");
            });
        }
    }
}
