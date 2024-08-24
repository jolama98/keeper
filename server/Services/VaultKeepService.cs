

namespace keeper.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vaultKeepRepository;
    private readonly KeepsService _keepsService;

    public VaultKeepService(VaultKeepRepository vaultKeepRepository, KeepsService keepsService)
    {
        _vaultKeepRepository = vaultKeepRepository;
        _keepsService = keepsService;
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
}

