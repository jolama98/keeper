namespace keeper.Models;

public class VaultKeep : RepoItem<int>
{
    public string KeepId { get; set; }
    public string VaultId { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }

}