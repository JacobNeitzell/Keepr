using System.ComponentModel.DataAnnotations;
using Keepr.Interfaces;

namespace Keepr.Models;

public class Keep : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string CreatorId { get; set; }

  [Required(ErrorMessage = "Please provide a description for your Keep.")]
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; } = 0;
  public int Kept { get; set; }

  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

public class AllVaultKeep : Keep
{
  public int VaultKeepId { get; set; }

  public int VaultId { get; set; }

  public int KeepId { get; set; }

  public string VaultKeepCreatorId { get; set; }

}

public class MyKeeps : Keep
{
  public Vault Vault { get; set; }

  public Vault isPrivate { get; set; }

  public new Profile Creator { get; set; }
}
