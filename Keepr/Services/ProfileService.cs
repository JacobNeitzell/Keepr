namespace Keepr.Services;


public class ProfileService
{
  private readonly ProfileRepository _pr;

  public ProfileService(ProfileRepository pr)
  {
    _pr = pr;

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

  public List<MyVault> GetVaultsByProfile(string creatorId)
  {
    return _pr.GetVaultsByProfile(creatorId);
  }








}