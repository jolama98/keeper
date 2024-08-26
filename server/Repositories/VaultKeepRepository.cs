



namespace keeper.Repositories;

public class VaultKeepRepository
{
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vaultKeep( keepId , vaultId, creatorId)
        VALUES( @keepId, @vaultId, @creatorId);

        SELECT
        vaultKeep.*,
        accounts.*
        FROM vaultKeep
        JOIN accounts ON accounts.id = vaultKeep.creatorId
        WHERE vaultKeep.id = LAST_INSERT_ID();";

        VaultKeep vaultKeep = _db.Query<VaultKeep, Profile, VaultKeep>(sql, JoinCreator, vaultKeepData).FirstOrDefault();
        return vaultKeep;
    }

    internal List<VaultKeep> GetPublicVault(int vaultId)
    {
        string sql = @"
        SELECT
        vaultKeep.*,
        accounts.*
        FROM vaultKeep
        JOIN accounts ON accounts.id = vaultKeep.creatorId
        WHERE vaultKeep.vaultId = @vaultId
        ;";

        List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Profile, VaultKeep>(sql, JoinCreator, new { vaultId }).ToList();
        return vaultKeeps;
    }



    // internal List<Report> GetReportsByRestaurantId(int restaurantId)
    // {
    //     string sql = @"
    // SELECT
    // reports.*,
    // accounts.*
    // FROM reports
    // JOIN accounts ON accounts.id = reports.creatorId
    // WHERE reports.restaurantId = @restaurantId;";

    //     List<Report> reports = _db.Query<Report, Profile, Report>(sql, JoinCreator, new { restaurantId }).ToList();
    //     return reports;
    // }
    private VaultKeep JoinCreator(VaultKeep vaultKeep, Profile profile)
    {
        vaultKeep.Creator = profile;
        return vaultKeep;
    }
}

