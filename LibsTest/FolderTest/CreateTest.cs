using Libs.Folder;

namespace LibsTest.FolderTest;

public class CreateTest
{
    [Fact]
    private async void CreateFolderTest()
    {
        const string path = "G:\\Mes Photo\\Photo";

        var cancellationTokenSource = new CancellationTokenSource();
        
        var middleFolder = new List<string> { "1_Original", "2_Traitement" };

        var task = path.CreateFolder(2023, middleFolder, cancellationTokenSource.Token);
        await task;
    }
}