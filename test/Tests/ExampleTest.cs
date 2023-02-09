using test;
using NUnit.Framework;
using PageObjects;

namespace Tests;

[TestFixture]
public class ExampleTest : TestBase
{
    [Test]
    public void Test1()
    {
        LoginAsAdmin();
        Assert.Fail();
    }
}
