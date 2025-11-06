# --- Estágio de Build ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# 1. Copiar apenas os arquivos de solução e de projeto
# Copia o .sln
COPY *.sln .
# Copia o diretório do projeto da API. 
# Adicione mais linhas 'COPY' se tiver outros projetos (ex: .Core, .Infrastructure)
COPY LoLChampionsAPI.API/ ./LoLChampionsAPI.API/

# 2. Restaurar dependências (em uma camada separada para aproveitar o cache)
RUN dotnet restore

# 3. Copiar o restante do código-fonte
COPY . .

# 4. Publicar a aplicação
# É uma boa prática especificar o projeto a ser publicado
RUN dotnet publish "LoLChampionsAPI.API/LoLChampionsAPI.API.csproj" -c Release -o /App/out

# --- Estágio de Runtime (Imagem final) ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build /App/out .

# 5. ATENÇÃO: Corrija o nome da DLL
# O nome da DLL deve ser o nome do seu projeto, não "DotNet.Docker.dll"
ENTRYPOINT ["dotnet", "LoLChampionsAPI.API.dll"]
