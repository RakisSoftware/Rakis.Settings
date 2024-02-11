namespace Rakis.Settings.UnitTests;

using Rakis.Logging;
using Rakis.Settings;
using Rakis.Settings.Files;
using System.IO;

public class TestJsonFileSettings
{
    private static string TestFile(string contents) {
        var path = Path.GetTempFileName();
        File.WriteAllText(path, contents);
        return path;
    }

    [Fact]
    public void TestLoadingJsonFile()
    {
        Logger.ClearLoggers();
        Logger.DefaultConfiguration().WithRootConsoleLogger(LogLevel.DEBUG).AddToConfig().Build();
        var log = Logger.GetLogger(typeof(TestJsonFileSettings));

        log.Debug?.Log("Creating settings");
        string testName = "title";
        string testTitle = "Hello world!";
        var file = TestFile("{ \"" + testName + "\": \"" + testTitle + "\" }");
        log.Debug?.Log("Loading settings");
        var setting = new JsonFileSettings(file, Context.None, SettingsType.AbsolutePath);
        log.Debug?.Log($"We now have {setting.Count} entries.");

        Assert.Equal(1, setting.Count);
        Assert.False(setting [testName].IsNull);
        Assert.Equal(testTitle, setting [testName].AsString);
    }
}