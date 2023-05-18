using AutoMapper;
using BackendExam.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendExam.Application
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            #region Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            #region Mediatr

            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(executingAssembly));

            #endregion


            return services;
        }
    }
}
