pushd .\src\Manga.WebApi\
dotnet build
popd
pushd .\test\Manga.Domain.Tests\
dotnet test
popd
pushd .\test\Manga.UseCases.Tests\
dotnet test
popd
pushd .\test\Manga.WebApi.Tests\
dotnet test
popd