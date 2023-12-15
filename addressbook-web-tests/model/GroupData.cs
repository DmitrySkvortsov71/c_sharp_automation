﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
  [Table(Name = "group_list")]
  public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
  {
    public GroupData(string name)
    {
      Name = name;
    }

    /// for group data generators\xml serializers
    public GroupData()
    {
    }

    [Column(Name = "group_name")] public string Name { get; set; }

    [Column(Name = "group_header")] public string Header { get; set; }

    [Column(Name = "group_footer")] public string Footer { get; set; }

    [Column(Name = "group_id")]
    [PrimaryKey]
    [Identity]
    public string Id { get; set; }

    public bool Equals(GroupData other)
    {
      if (ReferenceEquals(other, null)) return false;
      if (ReferenceEquals(this, other)) return true;

      // comment hash ..., if you don't need it. 
      // if (GetHashCode() != other.GetHashCode()) return false;

      return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public int CompareTo(GroupData other)
    {
      if (ReferenceEquals(other, null)) return 1;
      return Name.CompareTo(other.Name);
    }

    public override int GetHashCode()
    {
      // return 0; if we don't want hash code equal optimisation.
      return Name.GetHashCode();
    }

    public static List<GroupData> GetAll()
    {
      using (var db = new AddressbookDb())
      {
        return (from g in db.Groups select g).ToList();
      }
    }

    public override string ToString()
    {
      return $"name: {Name} | header: {Header} | footer: {Footer}";
    }
  }
}