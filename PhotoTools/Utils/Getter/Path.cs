using System;
using System.Configuration;
using System.IO;using System.Reflection;
using Directory = PhotoTools.Constant.Directory;

namespace PhotoTools.Utils.Getter;

public static class GetPath
{
    public static string GetCurrentPath { get; } = Environment.CurrentDirectory;
    public static Configuration GetConfig()
    {

        var configPath = Directory.ConfigPath;

        if (!File.Exists(configPath))
        {
            return Config.Config.InitConfig(configPath);
        }
        var map = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
        return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
    }
}