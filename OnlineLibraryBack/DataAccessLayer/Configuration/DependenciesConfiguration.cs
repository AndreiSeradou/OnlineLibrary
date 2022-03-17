﻿using System;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection serviceProvider, string connectionString)
        {
            serviceProvider.AddDbContext<ApiDbContext>(
                options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 17))));

            return serviceProvider;
        }
    }
}
