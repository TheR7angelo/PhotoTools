using PhotoTools.Utils.Getter;

namespace PhotoTools.Constant;

public static class Directory
{
    public const string GithubPage = @"https://github.com/TheR7angelo/PhotoTools";
    
    public static readonly string BddMain = $"{GetPath.GetCurrentPath}\\Sql\\Bdds\\Main.sqlite";
    public static readonly string BddLanguage = $"{GetPath.GetCurrentPath}\\Sql\\Bdds\\Language.sqlite";
    public static readonly string BddProgress = $"{GetPath.GetCurrentPath}\\Sql\\Bdds\\Progress.sqlite";

    public static readonly string ConfigPath = $"{GetPath.GetCurrentPath}\\app.config";
}