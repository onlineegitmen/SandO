namespace SandO.Entities.AppClasses.Organization;

/// <summary>
/// Seçim için üretim tesisleri
/// </summary>
public class PlantForSelection
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }

    public override string ToString()
    {
        return Name;
    }
}