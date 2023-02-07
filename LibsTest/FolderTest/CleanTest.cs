using Libs.Folder;

namespace LibsTest.FolderTest;

public class CleanTest
{
    [Fact]
    private async void Clean()
    {
        const string pathTest =
            "C:\\Users\\ZP6177\\Creative Cloud Files\\Programmation\\C#\\Personnel\\CleanDirectory\\CleanDirectory\\Test";
        
        await pathTest.CleanDirectory();
    }
}