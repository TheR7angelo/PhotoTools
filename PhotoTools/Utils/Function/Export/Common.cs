using Microsoft.Win32;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    public static string SaveFile(string title, string? initialFolder = null, string[]? filter = null)
    {
        var ifilter = filter is null ? string.Empty : string.Join('|', filter);
        var iinitialFolder = initialFolder is null ? string.Empty : initialFolder;

        // "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs"
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
    
    public static string SaveFile(string title, string? initialFolder = null, string? filter = null)
    {
        var ifilter = filter is null ? string.Empty : filter;
        var iinitialFolder = initialFolder is null ? string.Empty : initialFolder;
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
}