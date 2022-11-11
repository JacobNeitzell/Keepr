using Keepr.Interfaces;

namespace Keepr.Repositories;

public class KeepsRepository : BaseRepo, IRepository<Keep, int>
{
  public KeepsRepository(IDbConnection db) : base(db)
  {
  }

  public Keep Create(Keep data)
  {
    throw new NotImplementedException();
  }

  public Keep CreateKeeps(Keep newKeep)
  {
    var sql = @"
    INSERT INTO keeps(name,creatorId, description,img,views
    )
    VALUES(@Name,@CreatorId, @Description, @Img, @Views);
    SELECT LAST_INSERT_ID()
    ;";
    int keepId = _db.ExecuteScalar<int>(sql, newKeep);
    newKeep.Id = keepId;
    return newKeep;
  }

  public void DeleteKeep(Keep foundKeep)
  {
    var sql = "DELETE FROM keeps WHERE id = @Id ;";
    var keepRows = _db.Execute(sql, foundKeep);
    if (keepRows == 0) { throw new Exception("Id does not exist or Data is corrupted "); }

  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Keep> Get()
  {
    throw new NotImplementedException();
  }

  public List<Keep> GetAllKeeps()
  {
    string sql = @"
   SELECT 
   k.*,
   COUNT(vk.id) AS Kept,
   k.id AS KeepsId,
   a.*
   FROM keeps k
   JOIN accounts a on a.id = k.creatorId
   LEFT JOIN vaultkeep vk on vk.keepId = k.id
   GROUP BY k.id
   ;";
    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }).ToList();
  }

  public Keep GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Keep GetKeepById(int keepsId)
  {
    string sql = @"
   SELECT 
   k.*,
   COUNT(vk.id) AS Kept,
   a.*
   FROM keeps k
   JOIN accounts a ON a.id = k.creatorId
   LEFT JOIN vaultkeep vk ON vk.keepId = k.id
   WHERE k.id = @keepsId
   GROUP BY k.id
   ;";
    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keepsId }).FirstOrDefault();
  }

  public Keep Update(Keep data)
  {
    throw new NotImplementedException();
  }

  public Keep UpdateKeep(Keep keepData)
  {
    string sql = @"
    UPDATE keeps SET 
    name = @name,
    description = @description,
    img = @img,
    views = @Views
    WHERE id = @Id
    ;";
    int keepRow = _db.Execute(sql, keepData);
    if (keepRow == 0)
    {
      throw new Exception("Unable to Update Keep");
    }
    return GetKeepById(keepRow);
  }





}