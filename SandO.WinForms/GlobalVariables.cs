using System;
using System.IO;

namespace SandO.WinForms;

public static class GlobalVariables
{
    public static string RootDirectory
    {
        get
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SandO");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }

    

    public static string UserRootDirectory
    {
        get
        {
            string path = Path.Combine(RootDirectory, Bll.GlobalVariables.LoggedInUserId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }

    public static string LayoutsDirectory
    {
        get
        {
            string path = Path.Combine(UserRootDirectory, "Layouts");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }

    public static string ProjectName => "SandO";
}