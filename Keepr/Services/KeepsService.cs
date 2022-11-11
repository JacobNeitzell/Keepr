namespace Keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _KeepsRepo;


  public KeepsService(KeepsRepository KeepsRepo)
  {
    _KeepsRepo = KeepsRepo;

  }

  internal Keep CreateKeep(Keep newKeep)
  {
    return _KeepsRepo.CreateKeeps(newKeep);

  }

  internal List<Keep> GetAllKeeps()
  {
    return _KeepsRepo.GetAllKeeps();

  }

  internal Keep GetKeepById(int keepId, string Id)
  {
    Keep foundKeep = _KeepsRepo.GetKeepById(keepId);
    if (foundKeep == null)
    {
      throw new Exception("Keep Does not Exist");
    }
    if (foundKeep.CreatorId != Id)
    {
      UpdateViews(foundKeep);
    }
    return foundKeep;
  }

  public void UpdateViews(Keep keep)
  {
    keep.Views++;
    _KeepsRepo.UpdateKeep(keep);
  }



  internal Keep UpdateKeep(Keep keepData, int keepId, string userId)
  {
    Keep original = GetKeepById(keepId, userId);

    if (original.CreatorId != userId)
    {
      throw new Exception("Not today muchacho");
    }
    original.Name = keepData.Name ?? original.Name;
    original.Img = keepData.Img ?? original.Img;
    original.Description = keepData.Description ?? original.Description;
    Keep keep = _KeepsRepo.UpdateKeep(original);
    return keep;
  }


  internal void DeleteKeep(int keepId, string accountId)
  {
    Keep foundKeep = GetKeepById(keepId, accountId);
    if (foundKeep == null)
    {
      throw new Exception("Keep does not Exist");
    }
    if (foundKeep.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete Keep");
    }

    _KeepsRepo.DeleteKeep(foundKeep);

  }



}