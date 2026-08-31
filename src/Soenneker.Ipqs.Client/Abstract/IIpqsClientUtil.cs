using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Ipqs.Client.Abstract;

/// <summary>
/// Provides a cached HTTP transport for IPQualityScore API operation packages.
/// </summary>
public interface IIpqsClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared HTTP transport.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the cached client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
