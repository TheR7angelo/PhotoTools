namespace Libs.Folder;

public static class Clean
{
    public static async Task CleanDirectory(this string startLocation)
    {
        var directories = Directory.GetDirectories(startLocation);

        await Parallel.ForEachAsync(directories, async (directory, _) =>
        {
            await CleanDirectory(directory);
            if (Directory.GetFiles(directory).Length == 0 && 
                Directory.GetDirectories(directory).Length == 0)
            {
                Directory.Delete(directory, false);
            }
        });
    }
}