


namespace keeper.Services;
public class VaultsService
{
    private readonly VaultsRepository _vaultsRepository;
    private readonly AccountService _accountService;

    public VaultsService(VaultsRepository vaultsRepository, AccountService accountService)
    {
        _vaultsRepository = vaultsRepository;
        _accountService = accountService;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _vaultsRepository.CreateVault(vaultData);
        return vault;
    }

    internal string DestroyVault(int vaultId, string userId)
    {
        Vault destroyVault = GetVaultById(vaultId);
        if (destroyVault.CreatorId != userId)
        {
            throw new Exception("YOU DID NOT CREATE THIS VAULT AWAY");
        }
        _vaultsRepository.DestroyVault(vaultId);

        return $"{destroyVault.Name} Vault was DELETE";
    }

    internal Vault UpdateVault(int vaultId, string userId, Vault vaultData)
    {
        Vault vaultToUpdate = GetVaultById(vaultId);
        if (vaultToUpdate.CreatorId != userId)
        {
            throw new Exception("YOU CANNOT UPDATE A VAULT YOU DID NOT CREATE, THAT IS FORBIDDEN, PLEASE IGNORE THE 400 ERROR CODE, IT SHOULD BE 403");
        }

        vaultToUpdate.Name = vaultData.Name ?? vaultToUpdate.Name;
        vaultToUpdate.Description = vaultData.Description ?? vaultToUpdate.Description;
        _vaultsRepository.UpdateVault(vaultToUpdate);
        return vaultToUpdate;
    }

    private Vault GetVaultById(int vaultId)
    {
        Vault vault = _vaultsRepository.GetVaultById(vaultId) ?? throw new Exception($"No vault was found with the id of {vaultId}");
        return vault;
    }


    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId);

        if (vault.IsPrivate == true && vault.CreatorId != userId)
        {
            throw new Exception($"No vault was found with the id of {vaultId}");
        }

        return vault;
    }



    internal Vault GetPublicVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId);
        if (vault.CreatorId != userId && vault.IsPrivate == true)
        {
            throw new Exception("NOTHING TO SEE HERE 👀👀👀");
        }
        return vault;
    }

    public Vault GetVaultId(int vaultId)
    {
        Vault vault = _vaultsRepository.GetVaultById(vaultId) ?? throw new Exception($"No vault was found with the id of {vaultId}");
        return vault;
    }

    internal List<Vault> GetVaultsByProfileId(string profileId, string userId)
    {
        if (profileId == userId)
        {
            List<Vault> vault = _accountService.GetVaultByAccount(profileId);
            return vault;
        }


        List<Vault> vaults = _vaultsRepository.GetVaultsByProfileId(profileId);

        return vaults;
    }

}