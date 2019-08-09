FROM microsoft/dotnet:2.1.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 443

COPY Build/output/service/publish .
ENTRYPOINT ["dotnet", "HelloWorld.SimpleWebsite.dll"]