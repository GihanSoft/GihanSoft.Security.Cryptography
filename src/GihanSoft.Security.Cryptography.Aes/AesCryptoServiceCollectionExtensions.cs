using Microsoft.Extensions.DependencyInjection;
using System;

namespace GihanSoft.Security.Cryptography
{
    public static class AesCryptoServiceCollectionExtensions
    {
        public static IServiceCollection AddAesCrypto(
            this IServiceCollection services,
            Action<AesCryptoOptions> optionsAction
            )
        {
            var options = new AesCryptoOptions();
            optionsAction(options);

            if (options.Password is null)
                throw new ArgumentException(
                    "Password have to be set", nameof(optionsAction));

            services.AddTransient<ICrypto>(o => new AesCrypto(options));
            return services;
        }
    }
}
