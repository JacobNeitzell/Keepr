namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]


public class ProfilesController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly KeepsService _ks;
  private readonly ProfileService _ps;
  public ProfilesController(Auth0Provider auth0Provider, KeepsService ks, ProfileService ps)
  {
    _auth0provider = auth0Provider;
    _ks = ks;
    _ps = ps;
  }


  [HttpGet("{id}")]
  public ActionResult<Profile> GetProfile(string id)
  {
    try
    {
      Profile profile = _ps.GetProfile(id);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]

  public async Task<ActionResult<List<MyKeeps>>> GetKeepsByProfile(string profileId)
  {
    try
    {
      var userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      var myKeeps = _ps.GetKeepsByProfile(profileId);
      return Ok(myKeeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpGet("{profileId}/vaults")]

  public async Task<ActionResult<List<MyVault>>> GetVaultsByProfile(string profileId)
  {
    try
    {
      var userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      var myVaults = _ps.GetVaultsByProfile(profileId);
      return Ok(myVaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



}