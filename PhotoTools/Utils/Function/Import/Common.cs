using System.Collections.Generic;
using Microsoft.Win32;
using PhotoTools.Utils.Constant;
using PhotoTools.Utils.Function.Sql;
using PhotoTools.Utils.Strucs;
using FileDialog = PhotoTools.Utils.Function.Application.FileDialog;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static (string, string) GetOpenFile(string title, string? initialFolder = null,
        List<SaveFileFilter.Filter>? filters = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filters);

        var openFileDialog = new OpenFileDialog()
        {
            Title = title,
            InitialDirectory = folderFilter.InitialFolder,
            Filter = folderFilter.Filter
        };
        return FileDialog.FileDialogResult(filters, openFileDialog, folderFilter);
    }

    public static (string, string) GetOpenFile(string title, string? initialFolder = null,
        SaveFileFilter.Filter? filter = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filter);

        var openFileDialog = new OpenFileDialog()
        {
            Title = title,
            InitialDirectory = folderFilter.InitialFolder,
            Filter = folderFilter.Filter
        };
        return FileDialog.FileDialogResult(filter, openFileDialog, folderFilter);
    }

    private static StrucConfig.Themes ParseDictToTheme(this Dictionary<string, string> data)
    {
        var th = new StrucConfig.Themes
        {
            Lock = false,
            Value = new List<StrucConfig.StyleColorBrush>()
        };

        foreach (var key in data.Keys)
        {
            switch (key)
            {
                case "name":
                    th.Name = data[key];
                    break;
                default:
                    th.Value.Add(new StrucConfig.StyleColorBrush
                    {
                        Name = key,
                        StyleValue = data[key].SolidColorBrush()
                    });
                    break;
            }
        }

        return th;
    }

    /// <summary>
    /// 0 = name already exist <br/>
    /// 1 = theme added <br/>
    /// 2 = error <br/>
    /// </summary>
    /// <param name="theme"></param>
    /// <returns><see cref="byte"/></returns>
    public static byte AddNewTheme(StrucConfig.Themes theme)
    {
        if (Query.GetThemeExist(theme.Name!)) return 0;
        return Query.AddTheme(theme) ? (byte)1 : (byte)2;
    }
}