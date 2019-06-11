#addin "Cake.DocFx"
#tool "docfx.console"

var target = Argument("target", "Default");

Task("Build")
	.Does(() =>
{
	if (IsRunningOnWindows())
	{
		MSBuild("SimplePNML.sln");
	}
	else
	{
		XBuild("SimplePNML.sln");
	}
});

Task("Documentation")
	.Does(() =>
{
	DocFxMetadata();
	DocFxBuild();
});

RunTarget(target);