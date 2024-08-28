namespace keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly VaultKeepService _vaultKeepService;
    private readonly Auth0Provider _auth0Provider;
    public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider, VaultKeepService vaultKeepService)
    {
        _vaultsService = vaultsService;
        _auth0Provider = auth0Provider;
        _vaultKeepService = vaultKeepService;
    }

    //SECTION - create vault
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.CreateVault(vaultData);
            return Ok(vault);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    //SECTION - vault by id
    [HttpGet("{vaultId}")]
    public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
            return Ok(vault);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    //SECTION - edit vault
    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.UpdateVault(vaultId, userInfo.Id, vaultData);
            return Ok(vault);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    //SECTION - delete vault
    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult<string>> DestroyVault(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultsService.DestroyVault(vaultId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    //SECTION - public vault
    [Authorize]
    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultKeepKeep>>> GetPublicVault(int vaultId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            List<VaultKeepKeep> vaultKeep = _vaultKeepService.GetPublicVaultKeeps(vaultId, userInfo?.Id);
            return Ok(vaultKeep);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
