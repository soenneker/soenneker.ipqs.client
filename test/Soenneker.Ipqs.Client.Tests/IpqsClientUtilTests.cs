using Soenneker.Ipqs.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Ipqs.Client.Tests;

[Collection("Collection")]
public class IpqsClientUtilTests : FixturedUnitTest
{
    private readonly IIpqsClientUtil _util;

    public IpqsClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IIpqsClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
