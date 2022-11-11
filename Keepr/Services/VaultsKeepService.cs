namespace Keepr.Services;

public class VaultsKeepService
{
  private readonly VaultsKeepRepository _vkr;
  private readonly VaultsRepository _vr;
  private readonly KeepsRepository _kr;
  private readonly VaultsService _vs;


  public VaultsKeepService(VaultsKeepRepository vkr, VaultsRepository vr, KeepsRepository kr, VaultsService vs)
  {
    _vkr = vkr;
    _vr = vr;
    _kr = kr;
    _vs = vs;
  }


  internal VaultKeep CreateVaultKeep(VaultKeep vaultData, string accountId)
  {
    Vault vault = _vs.GetVaultById(vaultData.VaultId, accountId);
    if (vaultData.CreatorId != vault.CreatorId)
    {
      throw new Exception("Unauthorized");
    }

    VaultKeep vaultkeep = _vkr.Create(vaultData);
    if (vaultkeep == null)
    {
      throw new Exception("it be null");
    }
    return vaultkeep;



  }


  internal List<AllVaultKeep> GetKeepsByVault(int vaultId, string userInfo)
  {
    Vault vault = _vs.GetVaultById(vaultId, userInfo);
    if (vault.isPrivate == true && vault.CreatorId != userInfo)
    {
      throw new Exception("Vault is Private no keeps for you.");
    }

    List<AllVaultKeep> vaultKeeps = _vkr.GetKeepInVault(vaultId);
    return vaultKeeps;
  }

  internal void RemoveKeep(int vaultkeepId, string userId)
  {
    AllVaultKeep foundKeep = _vkr.GetByKeepIdInVault(vaultkeepId);
    if (foundKeep == null)
    {
      throw new Exception("unable to find keep");
    }
    if (foundKeep.CreatorId != userId)
    {
      throw new Exception("Unauthorized you do not have permission");

    }
    _vkr.Delete(foundKeep);
  }





}