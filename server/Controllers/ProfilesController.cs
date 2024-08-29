namespace keeper.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
// [Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly VaultKeepService _vaultKeepService;
    private readonly VaultsService _vaultsServices;
    private readonly KeepsService _keepsService;
    private readonly ProfilesService _profilesService;

    public ProfilesController(Auth0Provider auth0Provider, ProfilesService profilesService, VaultKeepService vaultKeepService, KeepsService keepsService, VaultsService vaultsServices)
    {
        _auth0Provider = auth0Provider;
        _profilesService = profilesService;
        _vaultKeepService = vaultKeepService;
        _keepsService = keepsService;
        _vaultsServices = vaultsServices;
    }


    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
        try
        {
            Profile profile = _profilesService.GetProfileById(profileId);
            return Ok(profile);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
    {
        try
        {
            List<Keep> keep = _keepsService.GetKeepsByProfileId(profileId);
            return Ok(keep);

        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
    [HttpGet("{profileId}/vaults")]
    public ActionResult<List<Vault>> GetVaultsByProfileId(string profileId)
    {
        try
        {
            List<Vault> vault = _vaultsServices.GetVaultsByProfileId(profileId);
            return Ok(vault);

        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


}
