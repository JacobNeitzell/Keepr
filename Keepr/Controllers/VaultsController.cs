namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly VaultsService _vs;

  private readonly VaultsKeepService _vks;

  public VaultsController(Auth0Provider auth0Provider, VaultsService vs, VaultsKeepService vks)
  {
    _auth0provider = auth0Provider;
    _vs = vs;
    _vks = vks;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault newVault)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newVault.CreatorId = userInfo.Id;
      Vault createdVault = _vs.CreateVault(newVault);
      createdVault.Creator = userInfo;
      return Ok(createdVault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{vaultId}")]


  public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Vault foundVault = _vs.GetVaultById(vaultId, userInfo?.Id);
      return Ok(foundVault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}/keeps")]

  public ActionResult<List<AllVaultKeep>> GetKeepsinVault(int vaultId)
  {
    if (vaultId == 0)
    {
      throw new Exception("test");
    }
    try
    {
      List<AllVaultKeep> vaultkeep = _vks.GetKeepsByVault(vaultId);
      return Ok(vaultkeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }





  [HttpPut("{vaultId}")]
  [Authorize]

  public async Task<ActionResult<Vault>> UpdateVault([FromBody] Vault vaultData, int vaultId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.Creator = userInfo;
      vaultData.CreatorId = userInfo.Id;
      vaultData.Id = vaultId;
      Vault vault = _vs.UpdateVault(vaultData, userInfo.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpDelete("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteVault(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _vs.DeleteVault(vaultId, userInfo.Id);
      return Ok("Vault Succefully Archived");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}



