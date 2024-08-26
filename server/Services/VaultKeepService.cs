


namespace keeper.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vaultKeepRepository;
    private readonly VaultsService _vaultsService;
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



    internal List<VaultKeep> GetPublicVault(int vaultId, string userId)
    {
        _vaultsService.GetPublicVault(vaultId, userId);

        List<VaultKeep> vaultKeep = _vaultKeepRepository.GetPublicVault(vaultId);
        return vaultKeep;

    }

    //? internal List<Report> GetReportsByRestaurantId(int restaurantId, string userId)
    //? {
    //?     // Just need the checks to run in the other service (is it shut down / are you the creator)
    //?     _restaurantsService.GetRestaurantById(restaurantId, userId);
    //?     List<Report> reports = _repository.GetReportsByRestaurantId(restaurantId);
    //?     return reports;
    //? }

}