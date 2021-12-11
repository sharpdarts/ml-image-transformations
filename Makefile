tests:
	dotnet test ./Tests/Tests.csproj

build:
	dotnet build ./App/App.csproj -o ./App/BuildOutput

run:
	./App/BuildOutput/App --flipmodes=Horizontal Vertical --rotatemodes=Rotate90 Rotate180 --grayscale=true --resize=true

help:
	./App/BuildOutput/App --help