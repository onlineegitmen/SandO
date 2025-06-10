using SandO.Entities.AppClasses;
using SandO.Entities.Db;
using SandO.Extensions;

namespace SandO.Bll.Validators;

public class GroupValidator
{
    public Group Group { get; }

    public GroupValidator(Group group)
    {
        Group = group;
    }

    public ProgressResult Validate()
    {
        ProgressResult result = new ProgressResult(true);

        if (Group.Name.IsNullOrEmptyOrWhiteSpace())
        {
            result.AddMessage("Grup adı boş bırakılamaz.");
            result.Result = false;
        }
        else if (Group.Name.IsMoreThanMaxLength(50))
        {
            result.AddMessage("Grup adı en fazla 50 karakter olabilir.");
            result.Result = false;
        }

        if (Group.Desc != null && Group.Desc.IsMoreThanMaxLength(500))
        {
            result.AddMessage("Açıklama en fazla 500 karakter olabilir.");
            result.Result = false;
        }

        if (GroupNameExists(Group))
        {
            result.AddMessage("Bu isimde bir grup zaten mevcut.");
            result.Result = false;
        }

        return result;
    }

    private bool GroupNameExists(Group group)
    {
        using SandOContext context = new(GlobalVariables.DbContextOptions);
        return context.Groups.Any(g => g.Name == group.Name && g.Id != group.Id);
    }
}