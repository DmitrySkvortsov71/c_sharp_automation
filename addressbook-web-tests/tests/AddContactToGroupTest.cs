using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
  public class AddContactToGroupTest : AuthTestBase
  {
    [Test]
    public void AddContactToGroup()
    {
      //  data preparation
      var group = GroupData.GetAll()[0];
      var oldList = group.GetContacts();
      var contact = ContactData.GetAll().Except(oldList).First();

      // actions
      app.Contacts.AddContactToGroup(contact, group);

      // verification
      var newList = group.GetContacts();

      oldList.Add(contact);
      newList.Sort();
      oldList.Sort();

      Assert.AreEqual(oldList, newList);
    }
  }
}