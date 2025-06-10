namespace SandO.Entities.AppClasses.Organization;

public class AppellationForSelection
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}