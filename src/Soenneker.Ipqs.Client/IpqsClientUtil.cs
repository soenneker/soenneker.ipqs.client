using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Ipqs.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Ipqs.Client;

/// <inheritdoc cref="IIpqsClientUtil"/>
public sealed class IpqsClientUtil : IIpqsClientUtil
{
    private readonly IHttpClientCache _httpClientCache;

    public IpqsClientUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(IpqsClientUtil), cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async ValueTask DisposeAsync()
    {
        await _httpClientCache.Remove(nameof(IpqsClientUtil));
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(IpqsClientUtil));
    }
}