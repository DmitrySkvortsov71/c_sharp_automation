using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin() => app.Auth.Login(new AccountData("admin", "secret"));
    }
}
