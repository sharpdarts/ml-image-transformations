tests:
	dotnet test ./Tests/Tests.csproj

build:
	dotnet build ./App/App.csproj -o ./App/BuildOutput

run:
	./App/BuildOutput/App --flipmodes=Horizontal Vertical --rotatemodes=Rotate90 Rotate180 --grayscale=true --resize=true

help:
	./App/BuildOutput/App --help

publishclean:
	rm -rf PublishOutput

publish-mac: publishclean
	dotnet publish ./App/App.csproj -o PublishOutput -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true