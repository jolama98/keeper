



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
        keeps.*,
        accounts.*
        FROM vaultKeep
        JOIN accounts ON accounts.id = vaultKeep.creatorId
        JOIN keeps ON keeps.id = vaultKeep.keepId
        WHERE vaultKeep.vaultId = @vaultId
        ;";

        List<VaultKeep> vaultKeeps = _db.Query<VaultKeep, Profile, VaultKeep>(sql, JoinCreator, new { vaultId }).ToList();
        return vaultKeeps;

        //         List<JoinedCult> joinedCults = _db.Query<CultMember, JoinedCult, Profile, JoinedCult>(sql,
        //   (cultMember, cult, leader) =>
        //   {
        //       cult.CultMemberId = cultMember.Id;
        //       cult.CultId = cultMember.CultId;
        //       cult.AccountId = cultMember.AccountId;
        //       cult.Leader = leader;
        //       return cult;
        //   }, new { userId }).ToList();

        //         return joinedCults;
    }
    private VaultKeep JoinCreator(VaultKeep vaultKeep, Profile profile)
    {
        vaultKeep.Creator = profile;
        return vaultKeep;
    }
}

