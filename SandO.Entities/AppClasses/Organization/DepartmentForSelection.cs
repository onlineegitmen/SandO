﻿namespace SandO.Entities.AppClasses.Organization;

public class DepartmentForSelection
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}