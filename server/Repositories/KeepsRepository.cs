



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

    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
    SELECT
    keeps.*,
    accounts.*
    FROM keeps
    JOIN accounts ON accounts.id = keeps.creatorId
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
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.id = @keepId
        ;";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, new
        {
            keepId
        }).FirstOrDefault();

        return keep;

    }

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

