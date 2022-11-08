using Keepr.Interfaces;

namespace Keepr.Models;


public class Vault : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  // [Required]
  public string Name { get; set; }

  // [Required(ErrorMessage = "Please provide a description for your Vault.")]
  public string Description { get; set; }
  public string Img { get; set; }
  public bool isPrivate { get; set; }

  public Profile Creator { get; set; }
  public string CreatorId { get; set; }
}


public class MyVault : Vault
{
  public Keep Keep { get; set; }

}