using Keepr.Interfaces;

namespace Keepr.Models;

public class Keep : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string CreatorId { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }

  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}

public class AllVaultKeep : Keep
{
  public int vaultKeepId { get; set; }

  public int keepId { get; set; }

}

public class MyKeeps : Keep
{
  public Vault Vault { get; set; }

  public new Profile Creator { get; set; }
}
