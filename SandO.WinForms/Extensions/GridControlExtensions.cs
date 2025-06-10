using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace SandO.WinForms.Extensions;

public static class GridControlExtensions
{
    public static void SetInitialization(this GridView gridView)
    {

    }

    public static void SaveLayout(this GridView gridView)
    {
        gridView.SaveLayoutToXml(gridView.GetGridViewLayoutFile());
    }

    public static void RestoreLayout(this GridView gridView)
    {
        string layoutFile = gridView.GetGridViewLayoutFile();
        if (File.Exists(layoutFile))
        {
            gridView.RestoreLayoutFromXml(layoutFile);
        }
    }

    public static string GetGridViewLayoutFile(this GridView gridView)
    {
        Form form = gridView.GridControl.FindForm();
        string gridViewName = String.Concat(form.Name, "_", gridView.Name + ".xml");
        string layoutPath = Path.Combine(GlobalVariables.LayoutsDirectory, gridViewName);
        return layoutPath;
    }
}