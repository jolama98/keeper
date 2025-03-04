


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
        // Keep keep = _keepsService.GetKeepById(vaultKeepData.KeepId, vaultKeepData.CreatorId);
        Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);

        if (vaultKeepData.CreatorId != vault.CreatorId)
        {
            throw new Exception($"You are NOT the owner of {vault.Name}.");
        }

        VaultKeep vaultKeep = _vaultKeepRepository.CreateVaultKeep(vaultKeepData);
        return vaultKeep;
    }

    internal string DestroyVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepKeepById(vaultKeepId);

        Vault vault = _vaultsService.GetVaultId(vaultKeep.VaultId);

        if (vaultKeep.CreatorId != userId)
        {
            throw new Exception($"This is not yours to destroy {vaultKeep.CreatorId}");
        }

        _vaultKeepRepository.DestroyVaultKeep(vaultKeepId);
        return "Vault Keep has been dealt with";
    }
    private VaultKeep GetVaultKeepKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _vaultKeepRepository.GetVaultKeepKeepById(vaultKeepId) ?? throw new Exception($"No vault keep found with the id of {vaultKeepId}");
        return vaultKeep;
    }

    internal List<VaultKeepKeep> GetPublicVaultKeeps(int vaultId, string userId)
    {
        Vault vault = _vaultsService.GetPublicVault(vaultId, userId);
        List<VaultKeepKeep> vaultKeeps = _vaultKeepRepository.GetKeepsInVault(vaultId, userId);
        return vaultKeeps;

    }
}