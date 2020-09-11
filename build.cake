#addin nuget:?package=Cake.Git&version=0.21.0 

#addin nuget:?package=Cake.Coverlet&version=2.3.4



var target = Argument("target", "Build");
var configuration = Argument("configuration", "Debug");

var solution = File("./src/SimplePNML.sln");
var project = File("./src/SimplePNML/SimplePNML.csproj");
var testProject = File("./src/SimplePNML.Tests/SimplePNML.Tests.csproj");

Task("Clean")
    .Does(() =>
{
    CleanDirectory("./artifacts");
    CleanDirectories("./src/**/bin");
    CleanDirectories("./src/**/obj");
});

Task("Build")
    .Does(() =>
{
    DotNetCoreBuild(solution, new DotNetCoreBuildSettings()
    {
        Configuration = configuration,
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest(testProject, new DotNetCoreTestSettings()
    {
		NoBuild = true,
        Verbosity = DotNetCoreVerbosity.Minimal
    },
    new CoverletSettings()
    {
        CollectCoverage = true,
        CoverletOutputDirectory = "./artifacts/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
    });
});

Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCorePack(project, new DotNetCorePackSettings() {
        NoBuild = true,
        OutputDirectory = "./artifacts/nuget",
        Verbosity = DotNetCoreVerbosity.Quiet
    });
});

Task("Push")
    .IsDependentOn("Pack")
    .Does(() =>
{
    var packages = GetFiles("./artifacts/nuget/*.nupkg");

    NuGetPush(packages, new NuGetPushSettings() {
         Source = "https://api.nuget.org/v3/index.json"
    });
});

Task("Documentation")
    .Does(() =>
{
    
});

RunTarget(target);