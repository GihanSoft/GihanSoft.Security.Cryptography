using Microsoft.Extensions.DependencyInjection;
using System;

namespace GihanSoft.Security.Cryptography
{
    public static class Pbkdf2HashServiceCollectionExtensions
    {
        public static IServiceCollection AddPbkdf2Hash(
            this IServiceCollection services,
            Action<Pbkdf2HashOptions> optionsAction
            )
        {
            var options = new Pbkdf2HashOptions();
            optionsAction(options);

            if (options.Salt is null)
                throw new ArgumentException(
                    "Salt have to be set", nameof(optionsAction));

            services.AddTransient<IHash>(o => new Pbkdf2Hash(options));
            return services;
        }
    }
}
