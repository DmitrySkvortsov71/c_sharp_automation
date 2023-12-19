using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactInGroupTest : ContactTestBase
  {
    
    public static object[] NewContactAndGroupData =
    {
        
        new object[]
        {
            new GroupData() { Name = GenerateRandomNumber(1000, 10000) },
            new ContactData()
            {
                FirstName = GenerateRandomNumber(1000, 10000),
                LastName = GenerateRandomNumber(1000, 10000)
            }
        },
    };
    
    [Test]
    [TestCaseSource(nameof(NewContactAndGroupData))]
    public void AddContactToGroup(GroupData groupToCreate, ContactData contactToCreate)
    {
      //  data preparation
      app.Groups.Create(groupToCreate);
      app.Contacts.Create(contactToCreate);
      
      var group = GroupData.GetAll().Find(g => g.Name == groupToCreate.Name);
      var contact = ContactData.GetAll().Find(
          c => c.FirstName == contactToCreate.FirstName && c.LastName == contactToCreate.LastName);
      var oldList = group.GetContacts();
      // var contact = ContactData.GetAll().Except(oldList).First();

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
    [TestCaseSource(nameof(NewContactAndGroupData))]
    public void RemoveContactFromGroup(GroupData groupToCreate, ContactData contactToCreate)
    {
      
      // data preparation
      if (GroupData.GetAll().Count == 0) app.Groups.Create(groupToCreate);
      if (ContactData.GetAll().Count == 0) app.Contacts.Create(contactToCreate);
      
      var allContacts = ContactData.GetAll();
      var allGroups = GroupData.GetAll();
      var group = new GroupData();
      var contact = new ContactData();
      var dataFound = false;
      
      foreach (var g in allGroups)
      {
        var groupContacts = g.GetContacts();
        var diff = allContacts.Except(groupContacts).ToList();
        if (diff.Count != 0)
        {
          contact = allContacts.Except(groupContacts).First();
          group = g;
          app.Contacts.AddContactToGroup(contact, group);
          
          dataFound = true;
          break;
        }
      }
      
      if (!dataFound) // no any contact without group allocation
      {
        app.Groups.Create(groupToCreate);
        app.Contacts.Create(contactToCreate);
        group = GroupData.GetAll().Find(g => g.Name == groupToCreate.Name);
        contact = ContactData.GetAll().Find(
            c => c.FirstName == contactToCreate.FirstName 
                 && c.LastName == contactToCreate.LastName);
        
        app.Contacts.AddContactToGroup(contact, group);
      }
      
      var oldContactsList = group.GetContacts();
      var contactToRemove = contact;

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