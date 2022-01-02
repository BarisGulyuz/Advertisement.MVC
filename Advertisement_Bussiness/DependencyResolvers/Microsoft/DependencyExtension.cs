using AdvertisementApp_Bussiness.Abstract;
using AdvertisementApp_Bussiness.Concrete;
using AdvertisementApp_Bussiness.Mappings.AutoMapper;
using AdvertisementApp_Bussiness.Validation.FluentValidation.AdvertisementUserValidator;
using AdvertisementApp_Bussiness.Validation.FluentValidation.AdvertisementValidator;
using AdvertisementApp_Bussiness.Validation.FluentValidation.GenderValidator;
using AdvertisementApp_Bussiness.Validation.FluentValidation.ServicesValidator;
using AdvertisementApp_Bussiness.Validation.FluentValidation.UserValidator;
using AdvertisementApp_DataAccess.Abstract;
using AdvertisementApp_DataAccess.Concrete;
using AdvertisementApp_DataAccess.Contexts;
using AdvertisementApp_DTOs.AdvertisementDto;
using AdvertisementApp_DTOs.AdvertisementUserDto;
using AdvertisementApp_DTOs.Gender;
using AdvertisementApp_DTOs.Intefaces.ServicesDto;
using AdvertisementApp_DTOs.UserDto;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp_Bussiness.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //DB CONTEXT - SQL
            services.AddDbContext<AdvertisementAppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //UOW
            services.AddScoped<IUoW, UoW>();

            //VALIDATION
            services.AddTransient<IValidator<ServicesCreateDto>, ServicesCreateValidator>();
            services.AddTransient<IValidator<ServicesUpdateDto>, ServicesUpdateValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateValidator>();

            services.AddTransient<IValidator<UserCreateDto>, UserCreateValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateValidator>();

            services.AddTransient<IValidator<AdvertisementUserCreateDto>, AdvertisementUserCreateValidator>();
            services.AddTransient<IValidator<AdvertisementUserUpdateDto>, AdvertisementUserUpdateValidator>();

            //BUSSINES DEPENDENCIES
            services.AddScoped<IServicesService, ServicesManager>();
            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IGenderService, GenderManager>();
            services.AddScoped<IAdvertisementUserService, AdvertisementUserManager>();
        }
    }
}
