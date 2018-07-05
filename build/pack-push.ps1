nuget.exe pack ../template/Paulovich.Manga.nuspec
nuget.exe setApiKey $NUGET_API_KEY -Source $NUGET_SOURCE
nuget.exe push ../template/Paulovich.Manga.*.nupkg -Source $NUGET_SOURCE