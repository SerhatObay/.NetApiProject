﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) 
            =>services.AddDbContext<RepositoryContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager,RepositoryManager>();
        
        public static void ConfigureServiceManager(this IServiceCollection services)=>
            services.AddScoped<IServiceManager,ServiceManager>();


        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
    }

}