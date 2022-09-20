﻿namespace PhotoTools.Utils.Constant;

public static class Directory
{
    public const string GithubPage = @"https://github.com/TheR7angelo/PhotoTools";
    
    public static readonly string BddMain = $"{Function.Get.GetCurrentPath}\\Utils\\Sql\\Bdds\\Main.sqlite";
    public static readonly string BddLanguage = $"{Function.Get.GetCurrentPath}\\Utils\\Sql\\Bdds\\Language.sqlite";
    public static readonly string BddProgress = $"{Function.Get.GetCurrentPath}\\Utils\\Sql\\Bdds\\Progress.sqlite";
}