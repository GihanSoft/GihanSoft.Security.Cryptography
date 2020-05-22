using Microsoft.Extensions.DependencyInjection;
using System;

namespace GihanSoft.Security.Cryptography
{
    public static class StdHashServiceCollectionExtensions
    {
        public static IServiceCollection AddStdHash(
            this IServiceCollection services,
            Action<StdHashOptions> optionsAction
            )
        {
            var options = new StdHashOptions();
            optionsAction(options);

            services.AddTransient<IHash>(o => new StdHash(options));
            return services;
        }
    }
}
