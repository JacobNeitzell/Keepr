namespace Keepr.Repositories;

public class ProfileRepository : BaseRepo
{
  public ProfileRepository(IDbConnection db) : base(db)
  {
  }


  internal Profile GetById(string Id)
  {
    string sql = @"
  SELECT * 
  FROM accounts where id = @id
  ;";
    return _db.QueryFirstOrDefault<Profile>(sql, new { Id });
  }


  internal List<MyKeeps> GetKeepsByProfile(string creatorId)
  {
    string sql = @"
    SELECT
  k.*,
  a.*
  FROM keeps k
  JOIN accounts a ON a.id = k.creatorId
  WHERE k.creatorId = @creatorId
  ;";
    return _db.Query<MyKeeps, Profile, MyKeeps>(sql, (mk, p) =>
    {
      mk.Creator = p;
      return mk;
    }, new { creatorId }).ToList();
  }
  internal List<MyVault> GetVaultsByProfile(string creatorId)
  {
    string sql = @"
    SELECT
  v.*,
  a.*
  FROM vault v
  JOIN accounts a ON a.id = v.creatorId
  WHERE v.creatorId = @creatorId
  ;";
    return _db.Query<MyVault, Profile, MyVault>(sql, (mv, p) =>
    {
      mv.Creator = p;
      return mv;
    }, new { creatorId }).ToList();
  }

}