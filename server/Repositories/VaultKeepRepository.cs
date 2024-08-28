




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
        *
        FROM vaultKeep
        WHERE vaultKeep.id = LAST_INSERT_ID();";
        // Keep keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, keepData).FirstOrDefault();
        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
        return vaultKeep;
    }

    internal void DestroyVaultKeep(int vaultKeepId)
    {
        // string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1";
        string sql = "DELETE FROM vaultKeep WHERE id = @vaultKeepId LIMIT 1; ";
        int rowsAffected = _db.Execute(sql, new { vaultKeepId });

        if (rowsAffected == 0)
        {
            throw new Exception("DELETE FAILED. CHECK YOUR SQL MANUAL AND YOUR SQL SYNTAX FOR THE ERROR");
        }
        if (rowsAffected > 1)
        {
            throw new Exception("DELETED MORE THAN ONE ROW. CHECK YOUR SQL MANUAL AND YOUR SQL SYNTAX FOR THE ERROR");
        }
    }

    internal List<VaultKeepKeep> GetKeepsInVault(int vaultId, string userId)
    {
        string sql = @"
        SELECT
        vaultKeep.*,
        keeps.*,
        accounts.*
        FROM vaultKeep
        JOIN accounts ON accounts.id = vaultKeep.creatorId
        JOIN keeps ON keeps.id = vaultKeep.keepId
        WHERE vaultKeep.vaultId = @vaultId
        ;";

        List<VaultKeepKeep> vaultKeepKeep = _db.Query<VaultKeep, VaultKeepKeep, Profile, VaultKeepKeep>(sql, (vaultKeep, keep, profile) =>
        {
            keep.AccountId = vaultKeep.CreatorId;
            keep.VaultKeepId = vaultKeep.Id;
            keep.Creator = profile;
            return keep;
        }, new { userId, vaultId }).ToList();
        return vaultKeepKeep;


    }

    internal VaultKeep GetVaultKeepKeepById(int vaultKeepId)
    {
        string sql = "SELECT * FROM vaultKeep WHERE id = @vaultKeepId ;";
        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
        return vaultKeep;
    }
    // private VaultKeep JoinCreator(VaultKeep vaultKeep, Profile profile)
    // {
    //     vaultKeep.CreatorId = profile;
    //     return vaultKeep;
    // }
}

