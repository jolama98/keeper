


namespace keeper.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vaultKeepRepository;
    private readonly VaultsService _vaultsService;





    private readonly KeepsService _keepsService;

    public VaultKeepService(VaultKeepRepository vaultKeepRepository, KeepsService keepsService, VaultsService vaultsService)
    {
        _vaultKeepRepository = vaultKeepRepository;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        Keep keep = _keepsService.GetKeepById(vaultKeepData.KeepId, vaultKeepData.CreatorId);
        if (keep.CreatorId != vaultKeepData.CreatorId)
        {
            throw new Exception($"You are the owner of {keep.Name}, and you are not allowed to leave reviews for your own restaurant.");
        }

        VaultKeep vaultKeep = _vaultKeepRepository.CreateVaultKeep(vaultKeepData);
        return vaultKeep;
    }

    internal List<VaultKeep> GetPublicVault(int vaultId, string userId)
    {
        _vaultsService.GetPublicVault(vaultId, userId);

        List<VaultKeep> vaultKeep = _vaultKeepRepository.GetPublicVault(vaultId);
        return vaultKeep;

    }
}