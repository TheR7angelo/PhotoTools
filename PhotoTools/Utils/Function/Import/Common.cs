using System.Collections.Generic;
using Microsoft.Win32;
using PhotoTools.Utils.Constant;
using FileDialog = PhotoTools.Utils.Function.Application.FileDialog;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static (string, string) GetOpenFile(string title, string? initialFolder = null, List<SaveFileFilter.Filter>? filters = null)
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
}