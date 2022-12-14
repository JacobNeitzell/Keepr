using Keepr.Interfaces;

namespace Keepr.Repositories;


public class VaultsKeepRepository : BaseRepo, IRepository<VaultKeep, int>
{
  public VaultsKeepRepository(IDbConnection db) : base(db)
  {
  }

  public VaultKeep Create(VaultKeep newVKeep)
  {
    string sql = @"
   INSERT INTO vaultkeep
   (creatorId,vaultId,keepId)
   VALUES (@CreatorId,@VaultId,@KeepId);
   SELECT LAST_INSERT_ID()
   ;";
    int id = _db.ExecuteScalar<int>(sql, newVKeep);
    newVKeep.Id = id;
    return newVKeep;
  }

  public void Delete(AllVaultKeep savedKeep)
  {
    string sql = @"
    DELETE FROM
    vaultkeep
    WHERE id = @Id LIMIT 1
    ;";
    _db.Execute(sql, savedKeep);
  }



  public AllVaultKeep GetByKeepIdInVault(int vaultkeepId)
  {
    string sql = @"
SELECT 
*,
COUNT(vk.id) AS Kept,
vk.id AS vaultkeepId
FROM vaultkeep vk
WHERE id = @vaultkeepId
GROUP BY vk.id
;";
    return _db.QueryFirstOrDefault<AllVaultKeep>(sql, new { vaultkeepId });
  }

  public VaultKeep Update(VaultKeep data)
  {
    throw new NotImplementedException();
  }

  public List<AllVaultKeep> GetKeepInVault(int vaultId)
  {
    string sql = @"
SELECT
vk.*,
COUNT(vk.id) AS Kept,
vk.id AS vaultKeepId,
 vk.CreatorId AS VaultKeepCreatorId,
k.*,
a.*
FROM vaultkeep vk
JOIN keeps k ON k.id = vk.keepId
JOIN accounts a ON a.id = k.creatorId
WHERE vk.vaultId = @vaultId
GROUP BY vk.id
;";
    return _db.Query<AllVaultKeep, Profile, AllVaultKeep>(sql, (keep, p) =>
    {
      keep.Creator = p;
      return keep;
    }, new { vaultId }).ToList();
  }


  public List<VaultKeep> Get()
  {
    throw new NotImplementedException();
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public VaultKeep GetById(int id)
  {
    throw new NotImplementedException();
  }
}