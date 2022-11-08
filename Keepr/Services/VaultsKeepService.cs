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


  internal VaultKeep CreateVaultKeep(VaultKeep newVKeep, string accountId)
  {
    Keep keep = _kr.GetKeepById(newVKeep.KeepId);
    if (keep.CreatorId != newVKeep.CreatorId)
    {
      throw new Exception("Unauthorized");
    }
    return _vkr.Create(newVKeep);
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