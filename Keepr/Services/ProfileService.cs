namespace Keepr.Services;


public class ProfileService
{
  private readonly ProfileRepository _pr;
  private readonly VaultsService _vs;

  public ProfileService(ProfileRepository pr, VaultsService vs)
  {
    _pr = pr;
    _vs = vs;
  }



  internal Profile GetProfile(string Id)
  {
    Profile profile = _pr.GetById(Id);
    return profile;

  }


  public List<MyKeeps> GetKeepsByProfile(string creatorId)
  {
    return _pr.GetKeepsByProfile(creatorId);
  }

  public List<Vault> GetVaultsByProfile(string creatorId)
  {
    return _pr.GetVaultsByProfile(creatorId);
  }


  public Vault GetMyVaultById(Vault newVault)
  {
    return _pr.GetMyVaultById(newVault);
  }





}