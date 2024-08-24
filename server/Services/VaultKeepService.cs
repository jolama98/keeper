
namespace keeper.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vaultKeepRepository;

    public VaultKeepService(VaultKeepRepository vaultKeepRepository)
    {
        _vaultKeepRepository = vaultKeepRepository;
    }
}


