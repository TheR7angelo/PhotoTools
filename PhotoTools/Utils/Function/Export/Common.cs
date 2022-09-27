using System.Collections.Generic;
using Microsoft.Win32;
using PhotoTools.Utils.Constant;
using PhotoTools.Utils.Function.Application;
using PhotoTools.Utils.Function.Sql;
using FileDialog = PhotoTools.Utils.Function.Application.FileDialog;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    private static (string, string) SaveFile(string title, string? initialFolder = null, List<SaveFileFilter.Filter>? filters = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filters);
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = folderFilter.Filter,
            InitialDirectory = folderFilter.InitialFolder
        };
        
        return FileDialog.FileDialogResult(filters, saveFileDialog, folderFilter);
    }

    private static string SaveFile(string title, string? initialFolder = null, SaveFileFilter.Filter? filter = null)
    {
        var folderFilter = FileDialog.DefaultFolderFilter(initialFolder, filter);
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = folderFilter.Filter,
            InitialDirectory = folderFilter.InitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
    
    public static void ExportTheme(string name)
    {
        var filter = new List<SaveFileFilter.Filter> { SaveFileFilter.Json, SaveFileFilter.SemiColonCsv, SaveFileFilter.CommaCsv };
        var path = SaveFile(string.Format(Trad.Setting.Theme.SaveFileTitle, name) ,Get.GetDesktop, filter);

        if (path.Item1 == string.Empty) return;

        var theme = Query.GetStyle(name);
        var success = path.Item2 switch
        {
            var value when value.Equals(SaveFileFilter.Json.Value) => path.Item1.ExportJson(theme),
            FileExtension.Json => path.Item1.ExportJson(theme),
            var value when value.Equals(SaveFileFilter.SemiColonCsv.Value) => ExportCsv(path.Item1, theme, FileExtension.Semicolon),
            var value when value.Equals(SaveFileFilter.CommaCsv.Value) => ExportCsv(path.Item1, theme, FileExtension.Comma),
            FileExtension.Csv => ExportCsv(path.Item1, theme, FileExtension.Semicolon),
            _ => false
        };

        var msg = new Window.MessageBox();

        // todo make trad
        if (success)
        {
            msg.SetIcon(msg.MessageIcon.Check);
            msg.SetTitle("Success");
            msg.SetText("Success");
            msg.SetButtonYesNo();
        }
        else
        {
            msg.SetIcon(msg.MessageIcon.Error);
            msg.SetTitle("Error");
            msg.SetText("Error");
            msg.SetButtonOk();
        }

        msg.ShowDialog();
        if (msg.Answer is not null && msg.Answer.Equals(msg.AnswerYes))
        {
            path.Item1.StartFile();
        }
    }
}