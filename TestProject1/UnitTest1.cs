namespace TestProject1;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void Test1()
    {
        TestContext.Out.WriteLine("Test1");
        Assert.Pass();
    }

    [TestCase("86585705003401300277665544000000000000000000206701120000")]
    [TestCase("86585705003401300244556677000000000A00000000206901000000")]
    public void TestWaterMeterResponse(string input)
    {

        TestContext.Out.WriteLine("TestWaterMeterResponse");
        TestContext.Out.WriteLine($"Input data is {input}");
        var result = SimpleTcpServer.Utils.ParseWaterMeterData(input);
        TestContext.Out.WriteLine(result);
    }
}