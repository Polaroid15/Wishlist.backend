﻿using Microsoft.Extensions.DependencyInjection;

namespace WL.Application.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingleton<TService1, TService2, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2
            where TService1 : class
            where TService2 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TImpl>(
            this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3
            where TService1 : class
            where TService2 : class
            where TService3 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TImpl>(
            this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TImpl>(
            this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TService8, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
            where TService8 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7),
                typeof(TService8));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TService8, TService9, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8,
            TService9
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
            where TService8 : class
            where TService9 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7),
                typeof(TService8),
                typeof(TService9));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TService8, TService9, TService10, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8,
            TService9, TService10
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
            where TService8 : class
            where TService9 : class
            where TService10 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7),
                typeof(TService8),
                typeof(TService9),
                typeof(TService10));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TService8, TService9, TService10, TService11, TImpl>(this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8,
            TService9, TService10, TService11
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
            where TService8 : class
            where TService9 : class
            where TService10 : class
            where TService11 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7),
                typeof(TService8),
                typeof(TService9),
                typeof(TService10),
                typeof(TService11));
            return services;
        }

        public static IServiceCollection AddSingleton<TService1, TService2, TService3, TService4, TService5, TService6,
            TService7, TService8, TService9, TService10, TService11, TService12, TImpl>(
            this IServiceCollection services)
            where TImpl : class, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8,
            TService9, TService10, TService11, TService12
            where TService1 : class
            where TService2 : class
            where TService3 : class
            where TService4 : class
            where TService5 : class
            where TService6 : class
            where TService7 : class
            where TService8 : class
            where TService9 : class
            where TService10 : class
            where TService11 : class
            where TService12 : class
        {
            AddSingletonInternal<TImpl>(services, typeof(TService1),
                typeof(TService2),
                typeof(TService3),
                typeof(TService4),
                typeof(TService5),
                typeof(TService6),
                typeof(TService7),
                typeof(TService8),
                typeof(TService9),
                typeof(TService10),
                typeof(TService11),
                typeof(TService12));
            return services;
        }

        private static IServiceCollection AddSingletonInternal<TImpl>(this IServiceCollection services,
            params Type[] tServices)
            where TImpl : class
        {
            if (!services.Any())
            {
                throw new ArgumentNullException("registration services are empty");
            }

            if (services.All(x => x.ServiceType != typeof(TImpl)))
            {
                services.AddSingleton<TImpl>();
            }

            foreach (var item in tServices)
            {
                services.AddSingleton(item, implementationFactory: x => x.GetService<TImpl>());
            }

            return services;
        }
    }
}