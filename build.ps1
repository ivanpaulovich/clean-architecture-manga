pushd .\src\Manga.WebApi\
dotnet build
popd
pushd .\tests\Manga.Domain.Tests\
dotnet test
popd
pushd .\tests\Manga.UseCases.Tests\
dotnet test
popd
pushd .\tests\Manga.WebApi.Tests\
dotnet test
popd