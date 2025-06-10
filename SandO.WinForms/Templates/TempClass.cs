using System;
using System.Collections.Generic;

namespace SandO.WinForms.Templates;

public class TempClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string Guid { get; set; }

    public static List<TempClass> GetRandomValues(int listCount)
    {
        List<TempClass> tempList = new List<TempClass>();
        Random random = new Random();

        for (int i = 0; i < listCount; i++)
        {
            tempList.Add(new TempClass
            {
                Id = i + 1,
                Name = $"Name {i + 1}",
                Description = $"Description for item {i + 1}",
                CreatedAt = DateTime.Now.AddDays(-random.Next(1, 30)),
                UpdatedAt = DateTime.Now.AddDays(-random.Next(1, 30)),
                IsActive = random.Next(0, 2) == 1,
                IsDeleted = random.Next(0, 2) == 1,
                CreatedBy = random.Next(1, 100),
                UpdatedBy = random.Next(1, 100)
            });
        }

        return tempList;
    }
}