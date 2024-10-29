namespace keeper.Models;

public class VaultKeep : RepoItem<int>
{
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string CreatorId { get; set; }
    // public Profile Creator { get; set; 
}


public class VaultKeepProfile : Profile
{
    public string VaultKeepId { get; set; }
    public int KeepId { get; set; }
}

public class VaultKeepKeep : Keep
{
    public int VaultKeepId { get; set; }
    public int VaultId { get; set; }
    public string AccountId { get; set; }
}