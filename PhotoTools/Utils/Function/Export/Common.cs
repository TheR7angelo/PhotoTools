using System.Collections.Generic;
using Microsoft.Win32;
using PhotoTools.Utils.Constant;
using FileDialog = PhotoTools.Utils.Function.Application.FileDialog;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    public static (string, string) SaveFile(string title, string? initialFolder = null, List<SaveFileFilter.Filter>? filters = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filters);
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = folderFilter.Filter,
            InitialDirectory = folderFilter.InitialFolder
        };
        
        return FileDialog.FileDialogResult(filters, saveFileDialog, folderFilter);
    }

    public static string SaveFile(string title, string? initialFolder = null, SaveFileFilter.Filter? filter = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filter);
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = folderFilter.Filter,
            InitialDirectory = folderFilter.InitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
}