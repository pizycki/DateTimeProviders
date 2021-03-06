#tool "nuget:?package=xunit.runner.console"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var mode = Argument("mode", "Debug");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories
var projectDirs = 
    new [] {
        Directory("./src/IzzyDev.DateTimeProviders"),
        Directory("./src/IzzyDev.DateTimeProviders.Tests")
    };

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////


Task("Full-Clean")
    .IsDependentOn("Clean")
    .IsDependentOn("Clean-Nuget-Packages")
    .IsDependentOn("Clean-Cake-Tools")
    .Does(() =>
{
    // Full clean further instructions
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./src/**/bin/*");
    CleanDirectories("./src/**/obj/*");
});

Task("Clean-Nuget-Packages")
    .Does(() =>
{
    CleanDirectory("./src/packages");
});

Task("Clean-Cake-Tools")
    .Does(() =>
{
    CleanDirectory("cake-tools");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean-Nuget-Packages")
    .Does(() =>
{
    NuGetRestore("./src/IzzyDev.DateTimeProviders.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild("./src/IzzyDev.DateTimeProviders.sln", settings => 
        settings.SetConfiguration(mode));
});

Task("Unit-Tests")
    .WithCriteria(() => mode == "Debug")
    .IsDependentOn("Build")
    .Does(() =>
{
    // mode must be set to Debug so Shouldly could use *.pdb files.
    XUnit2("./src/**/bin/Debug/*.Tests.dll", 
        new XUnit2Settings 
        {
            Parallelism = ParallelismOption.All
        });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);