using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Ipqs.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the IPQualityScore client
/// </summary>
public interface IIpqsClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}