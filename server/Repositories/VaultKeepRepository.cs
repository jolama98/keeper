



namespace keeper.Repositories;

public class VaultKeepRepository
{
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeepProfile CreateVaultKeep(VaultKeep vaultKeepData)
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

        // AlbumMemberProfile albumMember = _db.Query<AlbumMember, AlbumMemberProfile, AlbumMemberProfile>(sql, (albumMember, profile) =>
        //    {
        //        profile.AlbumId = albumMember.AlbumId;
        //        profile.AlbumMemberId = albumMember.Id;
        //        return profile;
        //    }, albumMemberData).FirstOrDefault();

        // return albumMember;
        VaultKeepProfile vaultKeep = _db.Query<VaultKeep, VaultKeepProfile, VaultKeepProfile>(sql, (vaultKeep, profile) =>
        {
            profile.KeepId = vaultKeep.KeepId;
            profile.VaultKeepId = vaultKeep.Id;
            return profile;
        }, vaultKeepData).FirstOrDefault();
        return vaultKeep;
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
    // private VaultKeep JoinCreator(VaultKeep vaultKeep, Profile profile)
    // {
    //     vaultKeep.Creator = profile;
    //     return vaultKeep;
    // }
}

