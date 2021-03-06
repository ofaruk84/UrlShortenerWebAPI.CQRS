using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using UrlShortener.Infra.Data.Abstract;
using UrlShortener.Infra.Data.Concrete.EntityFramework;

namespace UrlShortener.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddSingleton<IUrlModalDal, EfUrlModalDal>();
            return serviceCollection;
        }


    }
}
