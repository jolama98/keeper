
namespace keeper.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keeps(name, img, description, creatorId)
        VALUES(@name, @img, @description, @creatorId);

 
        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.id = LAST_INSERT_ID();";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, keepData).FirstOrDefault();
        return keep;
    }

    internal void DestroyKeep(int keepId)
    {
        string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1";

        int rowsAffected = _db.Execute(sql, new { keepId });

        if (rowsAffected == 0) throw new Exception("DELETE FAILED");
        if (rowsAffected > 1) throw new Exception("DELETE WAS OVER POWERED!!!!!!!");

    }

    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
    SELECT
    keeps.*,
    COUNT(vaultKeep.id) AS Kept,
    accounts.*
    FROM keeps
    JOIN accounts ON accounts.id = keeps.creatorId
    LEFT JOIN vaultKeep ON vaultKeep.keepId = keeps.id
    GROUP BY (keeps.id)
    ;";

        List<Keep> keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }).ToList();

        return keep;
    }

    internal Keep GetKeepById(int keepId)
    {
        string sql = @"
        SELECT
            keeps.*,
            COUNT(vaultKeep.id) AS Kept,
            accounts.*
            FROM keeps
            JOIN accounts ON accounts.id = keeps.creatorId
            LEFT JOIN vaultKeep ON vaultKeep.keepId = keeps.id
            WHERE keeps.id = @keepId
            GROUP BY (keeps.id)
        ;";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, new
        {
            keepId
        }).FirstOrDefault();

        return keep;
    }
    internal List<Keep> GetKeepsByProfileId(string profileId)
    {
        string sql = @"
        SELECT
        *
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE accounts.id = @profileId
        ;";

        List<Keep> keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, new
        {
            profileId
        }).ToList();
        return keep;
    }
    internal Keep GetKeepByKeepId(int keepId)
    {
        throw new NotImplementedException();
    }

    internal void UpdateKeep(Keep keepToUpdate)
    {

        string sql = @"
        UPDATE keeps
        Set
        description = @Description,
        views = @Views,
        name = @Name
        WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, keepToUpdate);
        if (rowsAffected == 0) throw new Exception("UPDATE FAILED");
        if (rowsAffected > 1) throw new Exception("UPDATE DID NOT FAIL, BUT THAT IS STILL A PROBLEM");
    }
    // UPDATE restaurants
    // SET
    // name = @Name,
    // description = @Description,
    // imgUrl = @ImgUrl,
    // isShutDown = @IsShutDown,
    // visits = @Visits
    // WHERE id = @Id LIMIT 1;

    // SELECT
    // restaurants.*,
    // accounts.*
    // FROM restaurants
    // JOIN accounts ON accounts.id = restaurants.creatorId
    // WHERE restaurants.id = @Id;";


    internal void UpdateViews(Keep keep)
    {
        throw new NotImplementedException();
    }

    private Keep JoinCreator(Keep keep, Profile profile)
    {
        keep.Creator = profile;
        return keep;
    }
}

