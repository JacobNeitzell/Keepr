namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]


public class KeepsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly KeepsService _ks;

  public KeepsController(Auth0Provider auth0Provider, KeepsService ks)
  {
    _auth0provider = auth0Provider;
    _ks = ks;

  }



  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep newKeep)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newKeep.CreatorId = userInfo.Id;
      Keep createdKeep = _ks.CreateKeep(newKeep);
      createdKeep.Creator = userInfo;
      return Ok(createdKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]

  public ActionResult<List<Keep>> GetAllKeeps()
  {
    try
    {
      List<Keep> keeps = _ks.GetAllKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]

  public ActionResult<Keep> GetKeepById(int keepId)
  {
    try
    {
      Keep foundKeep = _ks.GetKeepById(keepId);
      return Ok(foundKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{keepId}")]
  [Authorize]

  public async Task<ActionResult<Keep>> UpdateKeep([FromBody] Keep keepData, int keepId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.Creator = userInfo;
      keepData.CreatorId = userInfo.Id;
      keepData.Id = keepId;
      Keep keep = _ks.UpdateKeep(keepData, userInfo.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }



  [HttpDelete("{keepId}")]
  [Authorize]

  public async Task<ActionResult<string>> DeleteKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _ks.DeleteKeep(keepId, userInfo.Id);
      return Ok("Keep Has Been Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }


}