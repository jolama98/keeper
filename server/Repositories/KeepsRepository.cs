
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

        //     restaurants.*,
        // accounts.*
        // FROM restaurants
        // JOIN accounts ON accounts.id = restaurants.creatorId
        // WHERE restaurants.id = LAST_INSERT_ID(); ";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, JoinCreator, keepData).FirstOrDefault();
        return keep;
    }

    private Keep JoinCreator(Keep keep, Profile profile)
    {
        keep.Creator = profile;
        return keep;
    }
}

