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

    public async ValueTask DisposeAsync()
    {
        await _httpClientCache.Remove(nameof(IpqsClientUtil));
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(IpqsClientUtil));
    }
}