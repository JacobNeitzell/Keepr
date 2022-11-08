using Keepr.Interfaces;

namespace Keepr.Repositories;

public class VaultsRepository : BaseRepo, IRepository<Vault, int>
{
  public VaultsRepository(IDbConnection db) : base(db)
  {
  }

  public Vault Create(Vault newVault)
  {
    string sql = @"
    INSERT INTO vault(name,description,img,creatorId, isPrivate)
    VALUES(@Name,@Description,@Img,@CreatorId, @isPrivate);
    SELECT LAST_INSERT_ID()
    ;";
    int vaultId = _db.ExecuteScalar<int>(sql, newVault);
    newVault.Id = vaultId;
    return newVault;
  }

  public void Delete(Vault foundVault)
  {
    string sql = @"
   DELETE FROM vault 
   WHERE id = @id 
   ;";
    int vaultRows = _db.Execute(sql, foundVault);
    if (vaultRows == 0)
    {
      throw new Exception("Unable to delete the vault");
    }
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Vault GetById(int vaultId)
  {
    string sql = @"
  SELECT 
  vau.*,
  a.*
  FROM vault vau
  JOIN accounts a on a.id = vau.creatorId
  WHERE vau.id = @vaultId
  ;";
    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
  }

  public Vault Update(Vault original)
  {
    string sql = @"
    UPDATE vault SET 
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @isPrivate
    WHERE id = @Id
    ;";
    _db.Execute(sql, original);
    return original;
  }

  public List<Vault> Get()
  {
    throw new NotImplementedException();
  }
}

