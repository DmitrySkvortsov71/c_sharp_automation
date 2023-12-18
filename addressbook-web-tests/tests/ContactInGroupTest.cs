using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
  public class ContactInGroupTest : ContactTestBase
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

    [Test]
    public void RemoveContactFromGroup()
    {
      // data preparation
      var group = GroupData.GetAll()[0];
      var oldContactsList = group.GetContacts();
      
      // no contacts in group situation
      if (oldContactsList.Count == 0)
      {
        var contactToAdd = ContactData.GetAll()[0];

        app.Contacts.AddContactToGroup(contactToAdd, group);
        oldContactsList = group.GetContacts();
      }
      var contactToRemove = oldContactsList[0];

      // action
      app.Contacts.RemoveContactFromGroup(contactToRemove, group);

      // verification
      var newContactsList = group.GetContacts();
      oldContactsList.RemoveAt(0);

      oldContactsList.Sort();
      newContactsList.Sort();

      Assert.AreEqual(oldContactsList, newContactsList);
    }
  }
}