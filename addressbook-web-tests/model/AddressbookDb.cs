using LinqToDB;
using LinqToDB.Data;

namespace WebAddressbookTests
{
  public class AddressbookDb : DataConnection
  {
    // check app.config for Addressbook
    public AddressbookDb() : base("AddressBook")
    {
    }

    public ITable<GroupData> Groups => this.GetTable<GroupData>();
    public ITable<ContactData> Contacts => this.GetTable<ContactData>();
    public ITable<GroupContactRelation> Gcr => this.GetTable<GroupContactRelation>();
  }
}