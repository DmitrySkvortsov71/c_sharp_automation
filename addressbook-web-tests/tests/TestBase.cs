using NUnit.Framework;

namespace WebAddressbookTests
{
  public class TestBase
  {
    public ApplicationManager app;

    [SetUp]
    public void SetupApplicationManager()
    {
      app = ApplicationManager.GetInstance();
    }
  }
}