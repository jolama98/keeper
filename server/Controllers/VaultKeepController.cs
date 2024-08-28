namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultkeepsController : ControllerBase
{
    private readonly VaultKeepService _vaultKeepService;
    private readonly Auth0Provider _auth0Provider;

    public VaultkeepsController(VaultKeepService vaultKeepService, Auth0Provider auth0Provider)
    {
        _vaultKeepService = vaultKeepService;
        _auth0Provider = auth0Provider;
    }

    [HttpPost]
    // [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            vaultKeepData.CreatorId = userInfo.Id;
            VaultKeep vaultKeep = _vaultKeepService.CreateVaultKeep(vaultKeepData);
            return Ok(vaultKeep);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


    [HttpDelete("{vaultKeepId}")]
    [Authorize]
    public async Task<ActionResult<string>> DestroyVaultKeep(int vaultKeepId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultKeepService.DestroyVaultKeep(vaultKeepId, userInfo.Id);
            return Ok(message);

        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
