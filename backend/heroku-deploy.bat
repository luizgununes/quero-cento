docker build -t querocento C:\\Dev\\QueroCento\\backend\\bin\\Release\\netcoreapp2.1\publish
docker tag querocento registry.heroku.com/querocento/web
heroku container:login
docker push registry.heroku.com/querocento/web
heroku container:rm web --app querocento
heroku container:release web --app querocento

