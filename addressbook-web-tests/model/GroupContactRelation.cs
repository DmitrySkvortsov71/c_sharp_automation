using LinqToDB.Mapping;

namespace WebAddressbookTests
{
  [Table(Name = "address_in_groups")]
  public class GroupContactRelation
  {
    [Column(Name = "group_id")] public string GroupId { get; set; }
    [Column(Name = "id")] public string ContactId { get; set; }
  }
}