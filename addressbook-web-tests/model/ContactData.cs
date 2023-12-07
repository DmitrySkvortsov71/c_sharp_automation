﻿using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
  public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
  {
    private string e_mail;
    private string first_name;
    private string last_name;
    private string main_address = "";
    private string mobile_phone = "";
    private string second_address = "";
    private string work_phone = "";
    private string all_phones;
    private string detailedInformation;

    public ContactData(string first_name, string last_name, string e_mail)
    {
      this.first_name = first_name;
      this.last_name = last_name;
      this.e_mail = e_mail;
    }

    public string FirstName
    {
      get => first_name;
      set => first_name = value;
    }

    public string LastName
    {
      get => last_name;
      set => last_name = value;
    }

    public string EMail
    {
      get => e_mail;
      set => e_mail = value;
    }

    public string DetailedInformation
    {
      
      set => detailedInformation = value;
      get
      {
        if (detailedInformation != null)
          return detailedInformation;
        else
        {
          detailedInformation = "";
          
          if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            detailedInformation += $"{FirstName} {LastName}";
          else
          {
            if (!string.IsNullOrWhiteSpace(FirstName)) detailedInformation += FirstName;
            if (!string.IsNullOrWhiteSpace(LastName)) detailedInformation += LastName;
          }
          
          if (!string.IsNullOrWhiteSpace(MainAddress)) detailedInformation += $"\r\n{MainAddress}";
          if (!string.IsNullOrWhiteSpace(AllPhones)) detailedInformation += $"\r\n\r\n{AllPhones}";
          if (!string.IsNullOrWhiteSpace(EMail)) detailedInformation += $"\r\n\r\n{EMail}";

          return detailedInformation;
        }
      }
    }

    // all phones by one record
    public string AllPhones
    {
      set => all_phones = value;
      get
      {
        if (all_phones != null)
          return all_phones;
        else
          return (PhoneFieldCleanUp(HomePhone) + PhoneFieldCleanUp(MobilePhone)
                                               + PhoneFieldCleanUp(WorkPhone)).Trim();
      }
    }

    private string PhoneFieldCleanUp(string phoneField)
    {
      if (string.IsNullOrEmpty(phoneField))
        return "";
      else
          // return phoneField.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        return Regex.Replace(phoneField, "[ -()]", "") + "\r\n";
    }

    public string HomePhone { set; get; }

    public string MobilePhone
    {
      get => mobile_phone;
      set => mobile_phone = value;
    }

    public string WorkPhone
    {
      get => work_phone;
      set => work_phone = value;
    }

    public string MainAddress
    {
      get => main_address;
      set => main_address = value;
    }

    public string SecondAddress
    {
      get => second_address;
      set => second_address = value;
    }

    public bool Equals(ContactData other)
    {
      if (ReferenceEquals(other, null)) return false;
      if (ReferenceEquals(this, other)) return true;

      if (FirstName == other.FirstName && LastName == other.LastName) return true;
      else
        return false;
    }

    public int CompareTo(ContactData other)
    {
      if (ReferenceEquals(other, null)) return 1;

      var compareLastName = LastName.CompareTo(other.LastName);
      return compareLastName != 0 ? compareLastName : FirstName.CompareTo(other.FirstName);
    }

    public override string ToString()
    {
      return "Last Name: " + LastName + " | First Name: " + FirstName;
    }
  }
}  