using PhotoTools.Utils.Getter;

namespace PhotoTools.Constant;

public static class Directory
{
    public const string GithubPage = @"https://github.com/TheR7angelo/PhotoTools";
    
    public static readonly string BddMain = $"{GetPath.GetCurrentPath}\\Utils\\Sql\\Bdds\\Main.sqlite";
    public static readonly string BddLanguage = $"{GetPath.GetCurrentPath}\\Utils\\Sql\\Bdds\\Language.sqlite";
    public static readonly string BddProgress = $"{GetPath.GetCurrentPath}\\Utils\\Sql\\Bdds\\Progress.sqlite";
}