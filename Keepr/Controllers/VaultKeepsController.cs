namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly VaultsKeepService _vk;


  public VaultKeepsController(Auth0Provider auth0Provider, VaultsKeepService vk)
  {
    _auth0provider = auth0Provider;

    _vk = vk;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep newVKeep)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newVKeep.CreatorId = userInfo.Id;
      VaultKeep createdVaultKeep = _vk.CreateVaultKeep(newVKeep, userInfo.Id);
      return Ok(createdVaultKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultKeepId}")]
  [Authorize]

  public async Task<ActionResult<string>> RemoveKeep(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _vk.RemoveKeep(vaultKeepId, userInfo.Id);
      return Ok("removed from vault");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }


  }



}
