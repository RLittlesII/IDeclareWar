using Nuke.Common;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Script : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Script>(x => x.Build);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            DotNetClean();
        });

    Target Restore => _ => _
        .Executes(() => DotNetRestore());

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild();
        });


    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest();
        });

    Target Build => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
        });
    Target Release => _ => _.OnlyWhenStatic(() => Configuration == Configuration.Release).Executes();
}
