using Microsoft.Extensions.DependencyInjection;

namespace GihanSoft.Security.Cryptography
{
    public static class AesCryptoServiceCollectionExtensions
    {
        public static IServiceCollection AddAesCrypto(
            this IServiceCollection services, AesCryptoOptions options)
        {
            services.AddScoped<ICrypto>(o => new AesCrypto(options));
            return services;
        }
    }
}
