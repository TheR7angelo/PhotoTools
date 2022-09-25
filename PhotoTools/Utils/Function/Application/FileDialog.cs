using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhotoTools.Utils.Constant;

namespace PhotoTools.Utils.Function.Application;

public static class FileDialog
{

    public static FolderFilter DefaultFolderFilter(string? initialFolder = null, List<SaveFileFilter.Filter>? filters = null)
    {
        var ifilter = filters is null ? SaveFileFilter.All.Value : string.Join('|', filters.Select(filter => filter.Value).ToList());
        var iinitialFolder = initialFolder ?? string.Empty;

        return new FolderFilter { Filter = ifilter, InitialFolder = iinitialFolder };
    }

    public static FolderFilter DefaultFolderFilter(string? initialFolder = null, SaveFileFilter.Filter? filter = null)
    {
        var ifilter = filter is null ? SaveFileFilter.All.Value : filter.Value.Value;
        var iinitialFolder = initialFolder ?? string.Empty;
        return new FolderFilter { Filter = ifilter, InitialFolder = iinitialFolder };
    }
    
    public static (string, string) FileDialogResult(IReadOnlyList<SaveFileFilter.Filter>? filters, Microsoft.Win32.FileDialog fileDialog, FolderFilter folderFilter)
    {
        if (fileDialog.ShowDialog() is not true) return (string.Empty, string.Empty);

        var ext = Path.GetExtension(fileDialog.FileName);
        var def = (fileDialog.FileName, ext);

        if (folderFilter.Filter.Equals(string.Empty)) return def;

        var use = filters![fileDialog.FilterIndex - 1];
        if (ext.Equals(use.Extension)) return (fileDialog.FileName, use.Value);

        foreach (var filter in filters.Where(filter => ext.Equals(filter.Extension)))
        {
            return (fileDialog.FileName, filter.Value);
        }

        return def;
    }
    
    public static (string, string) FileDialogResult(SaveFileFilter.Filter? filters, Microsoft.Win32.FileDialog fileDialog, FolderFilter folderFilter)
    {
        if (fileDialog.ShowDialog() is not true) return (string.Empty, string.Empty);

        var ext = Path.GetExtension(fileDialog.FileName);
        var def = (fileDialog.FileName, ext);

        if (folderFilter.Filter.Equals(string.Empty)) return def;

        var use = filters!;
        if (ext.Equals(use.Value.Extension)) return (fileDialog.FileName, use.Value.Value);

        // foreach (var filter in filters.Where(filter => ext.Equals(filter.Extension)))
        // {
        //     return (fileDialog.FileName, filter.Value);
        // }

        return def;
    }

    public struct FolderFilter
    {
        public string InitialFolder = string.Empty;
        public string Filter = string.Empty;

        public FolderFilter()
        {
        }
    }
}