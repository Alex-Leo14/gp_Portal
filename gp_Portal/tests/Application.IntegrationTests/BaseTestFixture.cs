using NUnit.Framework;

using static gp_Portal.Application.IntegrationTests.Testing;

namespace gp_Portal.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
