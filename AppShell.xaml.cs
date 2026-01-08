namespace ImageViewer;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//// Source - https://stackoverflow.com/a
// Posted by Ingo, modified by community. See post 'Timeline' for change history
// Retrieved 2025-12-28, License - CC BY-SA 4.0

// msbuild /restore /t:build /p:TargetFramework=net6.0-windows10.0.19041 /p:configuration=release /p:WindowsAppSDKSelfContained=true /p:Platform=x64 /p:WindowsPackageType=None /p:RuntimeIdentifier=win10-x64

	}
}
