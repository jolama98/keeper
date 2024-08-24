

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
        vaultKeep( keepId , vaultId,creatorId)
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

    private VaultKeep JoinCreator(VaultKeep vaultKeep, Profile profile)
    {
        vaultKeep.Creator = profile;
        return vaultKeep;
    }
}

