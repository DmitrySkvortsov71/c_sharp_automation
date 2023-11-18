using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // preparation
            app.Auth.Logout();
            
            // action
            var account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            
            // verification
            Assert.IsTrue(app.Auth.IsLoggedIn());
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
            
        }
        
        [Test]
        public void LoginWithNotValidCredentials()
        {
            // preparation
            app.Auth.Logout();
            
            // action
            var account = new AccountData("tempo", "tempo");
            app.Auth.Login(account);
            
            // verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
        
    }
}