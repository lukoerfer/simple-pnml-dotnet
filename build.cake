#addin nuget:?package=Cake.Coverlet&version=2.3.4

#addin nuget:?package=Cake.Coveralls&version=0.10.0
#tool nuget:?package=coveralls.net&version=0.7.0

#addin nuget:?package=Cake.DocFx&version=0.13.0
#tool nuget:?package=docfx.console&version=2.43.1

var target = Argument("target", "Default");
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

Task("Restore")
	.Does(() =>
{
	DotNetCoreRestore(solution, new DotNetCoreRestoreSettings()
	{
		Verbosity = DotNetCoreVerbosity.Quiet
	});
});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings()
	{
		Configuration = configuration,
		NoRestore = true,
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
		NoRestore = true,
		Verbosity = DotNetCoreVerbosity.Minimal
	}, new CoverletSettings()
	{
		CollectCoverage = true,
		CoverletOutputDirectory = "./artifacts/coverage/coverage",
        CoverletOutputFormat = CoverletOutputFormat.opencover
	});

	if (TravisCI.IsRunningOnTravisCI)
	{
		CoverallsNet("./artifacts/coverage/coverage.opencover.xml", CoverallsNetReportType.OpenCover, new CoverallsNetSettings()
	    {
			ServiceName = "travis-ci",
			JobId = TravisCI.Environment.Job.JobId,
			UseRelativePaths = true,
	        TreatUploadErrorsAsWarnings = true
	    });
	}
});

Task("Pack")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetCorePack(project, new DotNetCorePackSettings() {
		NoRestore = true,
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
	DocFxMetadata(new DocFxMetadataSettings()
	{
		Projects = GetFiles("./docs/docfx.json"),
		LogLevel = DocFxLogLevel.Warning
	});
	DocFxBuild("./docs/docfx.json", new DocFxBuildSettings()
	{
		LogLevel = DocFxLogLevel.Warning
	});
});

RunTarget(target);