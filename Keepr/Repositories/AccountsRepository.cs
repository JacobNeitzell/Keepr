namespace Keepr.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @userId";
    return _db.QueryFirstOrDefault<Account>(sql, new { userId });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture,
              imgUrl = @ImgUrl
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }


  internal List<Vault> GetMyVaults(string creatorId)
  {
    string sql = @"
    SELECT
  v.*,
  a.*
  FROM vault v
  JOIN accounts a ON a.id = v.creatorId
  WHERE v.creatorId = @creatorId
  ;";
    return _db.Query<Vault, Account, Vault>(sql, (mv, a) =>
    {
      mv.Creator = a;
      return mv;
    }, new { creatorId }).ToList();
  }
}

