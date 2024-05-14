using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Ipqs.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Ipqs.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the IPQualityScore client
/// </summary>
public static class IpqsClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IIpqsClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddIpqsClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<IIpqsClientUtil, IpqsClientUtil>();
    }

    /// <summary>
    /// Adds <see cref="IIpqsClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddIpqsClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<IIpqsClientUtil, IpqsClientUtil>();
    }
}
