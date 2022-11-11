namespace Keepr.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string Id)
  {
    return _repo.GetByEmail(Id);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userId)
  {
    Account original = GetProfileByEmail(userId);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    original.ImgUrl = editData.ImgUrl.Length > 0 ? editData.ImgUrl : original.ImgUrl;
    return _repo.Edit(original);
  }

  public List<Vault> GetMyVaults(string creatorId)
  {
    return _repo.GetMyVaults(creatorId);
  }

  internal Account EditAccount()
  {
    throw new NotImplementedException();
  }
}
