
namespace MSTestSample
{
  

  [TestClass]
  [TestCategory("FixtureCategory")]
  public class MockTestFixture
  {
    // fail
    [TestMethod]
    public void FailingTest()
    {
      Assert.Fail();
    }

    // inconclusive
    [TestMethod]
    public void InconclusiveTest()
    {
      Assert.Inconclusive();
    }

    // description
    [TestMethod]
    [Description("Mock Test #1")]
    public void MockTest1()
    {
    }

    // priority + second category
    [TestMethod]
    [Priority(1)]
    [Description("This is a really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really long description")]
    [TestCategory("MockCategory")]
    public void MockTest2()
    {
    }

    // multiple categories
    [TestMethod]
    [TestCategory("AnotherCategory")]
    [TestCategory("MockCategory")]
    public void MockTest3()
    {
    }

    // ignore
    [TestMethod]
    [Ignore]
    [TestCategory("Foo")]
    public void MockTest4()
    {
    }

    // not runnable?
    [TestMethod]
    public void MockTest5()
    {
    }

    // not runnable?
    [TestMethod]
    public void NotRunnableTest(int arg1)
    {

    }

    [TestMethod]
    public void TestWithException()
    {
      throw new NotImplementedException();
    }

    [TestMethod]
    [TestProperty("TargetMethod", "SomeClassName")]
    [TestProperty("Size", "5")]
    public void TestWithManyProperties()
    {

    }
  }

  [TestClass]
  public class FixtureWithTestCases
  {
    [TestMethod]
    [DataRow(1)]
    public void TestWithArg(int arg)
    {

    }
  }

  [TestClass]
  public class FixtureWithTestCaseAttachments
  {
    private static TestContext Context;

    [ClassInitialize]
    public static void SetupTests(TestContext context)
    {
      Context = context;
    }

    [TestMethod]
    public void AddOneAttachment()
    {
      Thread.Sleep(100);
      SaveAttachment("C:\\dev\\code\\_Experiments\\NUnitSample\\MSTestSample\\dummy1.txt");      
    }

    [TestMethod]
    public void AddTwoAttachments()
    {
      Thread.Sleep(500);

      var files = new string[]
      {
        "C:\\dev\\code\\_Experiments\\NUnitSample\\MSTestSample\\dummy2.txt",
        "C:\\dev\\code\\_Experiments\\NUnitSample\\MSTestSample\\dummy3.txt",
      };
      foreach(var file in files)
      {
        SaveAttachment(file);
      }
    }

    private void SaveAttachment(string source)
    {
      if (File.Exists(source))
      {
        string file = Path.GetFileName(source);
        string destination = Path.Combine(Context.TestResultsDirectory!, file);

        File.Copy(source, destination);
        Context.AddResultFile(destination);
      }
      
    }
  }
}