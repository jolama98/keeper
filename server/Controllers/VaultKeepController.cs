namespace keeper.Controllers;

public class VaultKeepController : ControllerBase
{
    private readonly VaultKeepService _vaultKeepService;
    private readonly Auth0Provider _auth0Provider;

    public VaultKeepController(VaultKeepService vaultKeepService, Auth0Provider auth0Provider)
    {
        _vaultKeepService = vaultKeepService;
        _auth0Provider = auth0Provider;
    }

}
