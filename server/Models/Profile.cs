namespace keeper.Models;
public class Profile : RepoItem<string>
{

    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
}
