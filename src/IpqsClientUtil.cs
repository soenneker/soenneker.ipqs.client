using System;
using System.Net.Http;
using System.Threading.Tasks;
using Soenneker.Ipqs.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Ipqs.Client;

/// <inheritdoc cref="IIpqsClientUtil"/>
public class IpqsClientUtil : IIpqsClientUtil
{
    private readonly IHttpClientCache _httpClientCache;

    public IpqsClientUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get()
    {
        return _httpClientCache.Get(nameof(IpqsClientUtil));
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _httpClientCache.Remove(nameof(IpqsClientUtil));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.Remove(nameof(IpqsClientUtil));
    }
}
