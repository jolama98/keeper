


namespace keeper.Services;

public class KeepsService
{
    private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository)
    {
        _keepsRepository = keepsRepository;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _keepsRepository.CreateKeep(keepData);
        return keep;
    }

    internal string DestroyKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);
        if (keep.CreatorId != userId)
        {
            throw new Exception("YOU DID NOT CREATE THIS KEEP 'KEEP' AWAY");
        }
        _keepsRepository.DestroyKeep(keepId);


        return $"Keep was DELETED!";

    }


    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _keepsRepository.GetKeepById(keepId);

        if (keep == null)
        {
            throw new Exception($"No keep found with the id of {keepId}");
        }
        return keep;
    }
    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keep = _keepsRepository.GetAllKeeps();
        return keep;
    }

    internal Keep UpdateKeep(int keepId, string userId, Keep keepData)
    {
        Keep keepToUpdate = GetKeepById(keepId);
        if (keepToUpdate.CreatorId != userId)
        {
            throw new Exception("YOU CANNOT UPDATE A KEEP YOU DID NOT CREATE, THAT IS FORBIDDEN, PLEASE IGNORE THE 400 ERROR CODE, IT SHOULD BE 403");
        }

        keepToUpdate.Name = keepData.Name ?? keepData.Name;
        keepToUpdate.Description = keepData.Description ?? keepData.Description;

        _keepsRepository.UpdateKeep(keepToUpdate);

        return keepToUpdate;
    }
}

