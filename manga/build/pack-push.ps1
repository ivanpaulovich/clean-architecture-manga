nuget.exe pack ../template/Paulovich.Manga.nuspec
nuget.exe setApiKey $env:NUGET_API_KEY -Source $env:NUGET_SOURCE
nuget.exe push Paulovich.Manga.*.nupkg -Source $env:NUGET_SOURCE