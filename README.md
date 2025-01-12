# Using LLM in .NET C#

## Install ollama and download phi3 model
- Install ollama on the system or as a docker container
- Download a model which you wish to use, here we use- phi3

## Install dot net 9 SDK
- Create a console application in dot net 9
- Add the below 3 nuget packages:
    1. Include="Microsoft.Extensions.AI" Version="9.0.1-preview.1.24570.5"
    2. Include="Microsoft.Extensions.AI.Ollama" Version="9.0.1-preview.1.24570.5"
    3. Include="Microsoft.Extensions.Hosting" Version="9.0.0"
- `dotnet build`
- `dotnet run`

