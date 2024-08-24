
namespace keeper.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO
        vaults(name, img, description, isPrivate , creatorId)
        VALUES(@name, @img, @description, @isPrivate, @creatorId);

        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = LAST_INSERT_ID();";

        Vault vault = _db.Query<Vault, Profile, Vault>(sql, JoinCreator, vaultData).FirstOrDefault();
        return vault;
    }

    internal void DestroyVault(int vaultId)
    {
        string sql = @"
        DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { vaultId });
        if (rowsAffected == 0) throw new Exception("DELETE FAILED");
        if (rowsAffected > 1) throw new Exception("DELETE WAS OVER POWERED!!!!!!!");
    }


    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = @vaultId
        ;";

        Vault vault = _db.Query<Vault, Profile, Vault>(sql, JoinCreator, new
        {
            vaultId
        }).FirstOrDefault();
        return vault;

    }

    internal void UpdateVault(Vault vaultToUpdate)
    {
        string sql = @"
        UPDATE
        vaults
        Set
        name = @name,
        IsPrivate = @IsPrivate
        WHERE id = @id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, vaultToUpdate);
        if (rowsAffected == 0) throw new Exception("UPDATE FAILED");
        if (rowsAffected > 1) throw new Exception("UPDATE DID NOT FAIL, BUT THAT IS STILL A PROBLEM");
    }

    private Vault JoinCreator(Vault vault, Profile profile)
    {
        vault.Creator = profile;
        return vault;
    }
}

