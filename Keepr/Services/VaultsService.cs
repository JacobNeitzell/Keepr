namespace Keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _vr;

  public VaultsService(VaultsRepository vr)
  {
    _vr = vr;
  }

  internal Vault CreateVault(Vault newVault)
  {
    return _vr.Create(newVault);
  }


  internal Vault GetVaultById(int vaultId, string userInfo)
  {
    Vault foundVault = _vr.GetById(vaultId);
    if (foundVault == null)
    {
      throw new Exception("Vault Does Not Exist");
    }
    if (foundVault.isPrivate == true && foundVault.CreatorId != userInfo)
    {
      throw new Exception("Vault is Prviate");
    }
    return foundVault;
  }



  internal Vault UpdateVault(Vault vaultData, string userId)
  {
    Vault original = GetVaultById(vaultData.Id, vaultData.CreatorId);
    if (vaultData.CreatorId != original.CreatorId)
    {
      throw new Exception("Unauthorized to edit this recipe");
    }
    if (original.CreatorId != userId)
    {
      throw new Exception("blah blah whatetever jefe");
    }
    original.Name = vaultData.Name ?? original.Name;
    original.Description = vaultData.Description ?? original.Description;
    original.Img = vaultData.Img ?? original.Img;
    original.isPrivate = vaultData.isPrivate;
    _vr.Update(original);
    return original;
  }

  internal void DeleteVault(int vaultId, string accountId)
  {
    Vault foundVault = GetVaultById(vaultId, accountId);
    if (foundVault == null)
    {
      throw new Exception("Vault Does not exist");
    }
    if (foundVault.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete Vault");
    }
    _vr.Delete(foundVault);
  }



}