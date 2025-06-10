namespace SandO.Entities.AppClasses.Organization;

/// <summary>
/// Şirket seçiminde kullanılacak sınıf
/// </summary>
public class CompanyForSelection
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<PlantForSelection> PlantForSelections { get; set; }

    public override string ToString()
    {
        return Name;
    }
}