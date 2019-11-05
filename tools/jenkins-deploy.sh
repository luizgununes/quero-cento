cd backend/src/
dotnet publish queroCentoBE.csproj -c Release -f netcoreapp2.1
cp Dockerfile /var/lib/jenkins/workspace/prod/backend/src/bin/Release/netcoreapp2.1/publish/
docker build -t querocento /var/lib/jenkins/workspace/prod/backend/src/bin/Release/netcoreapp2.1/publish/
docker run -d -p 777:80 --name app querocento
cd ../tests/
dotnet build queroCentoBETestes.csproj -f netcoreapp2.1 -c Release
dotnet vstest bin/Release/netcoreapp2.1/queroCentoBETestes.dll
docker stop app
docker rm app
docker tag querocento registry.heroku.com/querocento/web
heroku container:login
heroku container:rm web --app querocento
heroku container:release web --app querocento