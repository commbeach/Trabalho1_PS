# Estágio base para a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

# Estágio de build
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

# Copia apenas o arquivo de projeto e restaura as dependências
COPY ["Gerenciador_Manutencao/Gerenciador_Manutencao.csproj", "Gerenciador_Manutencao/"]
RUN dotnet restore "Gerenciador_Manutencao/Gerenciador_Manutencao.csproj"

# Copia o restante do código
COPY . .

# Define o diretório de trabalho e realiza o build
WORKDIR "/src/Gerenciador_Manutencao"
RUN dotnet build "Gerenciador_Manutencao.csproj" -c $configuration -o /app/build

# Estágio de publicação
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Gerenciador_Manutencao.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gerenciador_Manutencao.dll"]
