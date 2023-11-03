namespace WebAddressbookTests
{
    public class AccountData
    {
        private string username;
        private string password;


        public AccountData(string username, string password)
        {
            this.password = password;
            this.username = username;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

    }
}
