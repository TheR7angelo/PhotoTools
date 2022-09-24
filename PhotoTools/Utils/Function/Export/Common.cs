using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using PhotoTools.Utils.Constant;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    public static (string, string) SaveFile(string title, string? initialFolder = null, List<SaveFileFilter.Filter>? filters = null)
    {
        //var ifilter = filters is null ? string.Empty : filters.Aggregate("", (current, filter) => $"{current}|{filter}");
        
        var ifilter = filters is null ? string.Empty : string.Join('|', filters.Select(filter => filter.Value).ToList());
        
        var iinitialFolder = initialFolder ?? string.Empty;
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        
        if (saveFileDialog.ShowDialog() is not true) return (string.Empty, string.Empty);

        if (!ifilter.Equals(string.Empty)) return (saveFileDialog.FileName, filters![saveFileDialog.FilterIndex].Value);
        {
            var use = string.Empty;
            var ext = Path.GetExtension(saveFileDialog.FileName);
            foreach (var filter in filters!.Where(filter => filter.Extension.Equals(ext)))
            {
                use = filter.Value;
                break;
            }
            return (saveFileDialog.FileName, use);
        }
    }
    
    public static string SaveFile(string title, string? initialFolder = null, SaveFileFilter.Filter? filter = null)
    {
        var ifilter = filter is null ? string.Empty : filter.Value.Value;
        var iinitialFolder = initialFolder ?? string.Empty;
        
        var saveFileDialog = new SaveFileDialog {
            Title = title,
            Filter = ifilter,
            InitialDirectory = iinitialFolder
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : saveFileDialog.FileName;
    }
}