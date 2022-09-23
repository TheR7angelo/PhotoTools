using Microsoft.Win32;

namespace PhotoTools.Utils.Function;

public partial class Export
{
    public static string SaveFile(string? initialFolder = null, string[]? filter = null)
    {
        var ifilter = filter is null ? string.Empty : string.Join('|', filter);
        var iinitialFolder = initialFolder is null ? string.Empty : string.Join('|', initialFolder);

        // "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs"
        var saveFileDialog = new SaveFileDialog {
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
    
    public static string SaveFile(string? initialFolder = null, string? filter = null)
    {
        var ifilter = filter is null ? string.Empty : string.Join('|', filter);
        var iinitialFolder = initialFolder is null ? string.Empty : string.Join('|', initialFolder);
        
        var saveFileDialog = new SaveFileDialog {
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
}