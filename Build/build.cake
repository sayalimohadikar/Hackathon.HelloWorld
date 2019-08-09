#load tools\Atlas.Build\Content\main.cake

Build.Settings = new BuildSettings 
{
  SolutionPath = @"..\HelloWorld.SimpleWebsite.sln",

  TestProjectFilePattern = @"../Tests/**/*.csproj",

  WebServicePath = @"..\HelloWorld.SimpleWebsite\HelloWorld.SimpleWebsite.csproj",

  UseDotNetCoreBuild = true,

  VersionFormat = "1.0.0.{0}"
};

var target = Argument("target", "Default");
RunTarget(target);
