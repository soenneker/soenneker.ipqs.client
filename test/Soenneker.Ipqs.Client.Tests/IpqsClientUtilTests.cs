using Soenneker.Ipqs.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Ipqs.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class IpqsClientUtilTests : HostedUnitTest
{
    private readonly IIpqsClientUtil _util;

    public IpqsClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IIpqsClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
