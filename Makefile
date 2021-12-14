tests:
	dotnet test ./Tests/Tests.csproj

build:
	dotnet build ./App/App.csproj -o ./App/BuildOutput

run:
	./App/BuildOutput/App --flipmodes=Horizontal Vertical --rotatemodes=Rotate90 Rotate180 --grayscale=true --resize=true

help:
	./App/BuildOutput/App --help

publish-mac-clean:
	rm -rf PublishOutput/Mac

publish-mac: publish-mac-clean
	dotnet publish ./App/App.csproj -o PublishOutput/Mac -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true /p:DebugType=None /p:DebugSymbols=false

publish-linux-clean:
	rm -rf PublishOutput/Linux

publish-linux: publish-linux-clean
	dotnet publish ./App/App.csproj -o PublishOutput/Linux -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true /p:DebugType=None /p:DebugSymbols=false

publish-win-clean:
	rm -rf PublishOutput/Win

publish-win: publish-win-clean
	dotnet publish ./App/App.csproj -o PublishOutput/Win -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true /p:DebugType=None /p:DebugSymbols=false