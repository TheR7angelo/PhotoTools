using System;
using System.Configuration;
using System.IO;
using Directory = PhotoTools.Constant.Directory;

namespace PhotoTools.Utils.Getter;

public static class GetPath
{
    public static string GetCurrentPath { get; } = Environment.CurrentDirectory;
}