nuget install packages.config
pushd '..\test\Manga.Domain.Tests\'
..\..\build\OpenCover.4.6.476-rc\tools\OpenCover.Console.exe -register:user -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test --logger:trx;LogFileName=results1.trx /p:DebugType=full Manga.Domain.Tests.csproj" -filter:"+[Manga.*]* -[*]Tests" -output:"..\..\build\my_app_coverage1.xml" -oldstyle
popd
pushd '..\test\Manga.UseCases.Tests\'
..\..\build\OpenCover.4.6.476-rc\tools\OpenCover.Console.exe -register:user -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test --logger:trx;LogFileName=results2.trx /p:DebugType=full Manga.UseCases.Tests.csproj" -filter:"+[Manga.*]* -[*]Tests" -output:"..\..\build\my_app_coverage2.xml" -oldstyle
popd
pushd '..\test\Manga.WebApi.Tests\'
..\..\build\OpenCover.4.6.476-rc\tools\OpenCover.Console.exe -register:user -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test --logger:trx;LogFileName=results3.trx /p:DebugType=full Manga.WebApi.Tests.csproj" -filter:"+[Manga.*]* -[*]Tests" -output:"..\..\build\my_app_coverage3.xml" -oldstyle
popd
ReportGenerator.2.4.0.0\tools\ReportGenerator.exe "-reports:my_app_coverage*.xml;" -targetdir:coverage
Codecov.1.0.5\tools\codecov.exe -f 'my_app_coverage1.xml' 'my_app_coverage2.xml' 'my_app_coverage3.xml' -t $env:codecov_token