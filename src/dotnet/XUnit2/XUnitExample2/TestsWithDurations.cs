using System.Threading.Tasks;
using Xunit;

namespace XUnitExample2
{
  // dotnet test --logger "xunit;LogFilePath=TestResults.xml"
  public class TestsWithDurations
  {
    [Fact]
    public async Task NoDuration()
    {
      await Task.Delay(0);
    }

    [Fact]
    public async Task Duration10Ms()
    {
      await Task.Delay(10);
    }

    [Fact]
    public async Task TestCase167_Duration1s()
    {
      await Task.Delay(1000);
    }

  }
}
