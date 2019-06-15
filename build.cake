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
	DotNetCoreRestore(solution, new DotNetCoreRestoreSettings() {
		Verbosity = DotNetCoreVerbosity.Minimal
	});
});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	DotNetCoreBuild(solution, new DotNetCoreBuildSettings() {
		Configuration = configuration,
		NoRestore = true
	});
});

Task("Test")
	.IsDependentOn("Build")
	.Does(() =>
{
	DotNetCoreTest(testProject);
});

Task("Create-Nuget")
	.IsDependentOn("Build")
	.Does(() =>
{
	NuGetPack(project, new NuGetPackSettings() {
		OutputDirectory = "./artifacts/nuget"
	});
});

Task("Publish-Nuget")
	.IsDependentOn("Create-Nuget")
	.Does(() =>
{
	 
});


Task("Generate-Docs")
	.Does(() =>
{
	DocFxMetadata(new DocFxMetadataSettings() {
		Projects = GetFiles("./docs/docfx.json"),
		LogLevel = DocFxLogLevel.Warning
	});
	DocFxBuild("./docs/docfx.json", new DocFxBuildSettings() {
		LogLevel = DocFxLogLevel.Warning
	});
});

RunTarget(target);