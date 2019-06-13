var target = Argument("target", "Default");

Task("Clean")
	.Does(() =>
{

});

Task("Build")
	.Does(() =>
{
	MSBuild("src/SimplePNML.sln", settings =>
	{
		settings.SetVerbosity(Verbosity.Minimal);
	});
});

Task("Generate-Docs")
	.Does(() =>
{

});

Task("Create-Nuget-Package")
	.Does(() =>
{
	NuGetPack("src/SimplePNML/SimplePNML.nuspec", new NuGetPackSettings());
});

Task("Publish-Nuget")
	.Does(() =>
{
	
});

RunTarget(target);