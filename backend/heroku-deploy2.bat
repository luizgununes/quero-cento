docker push registry.heroku.com/querocento/web
heroku container:rm web --app querocento
heroku container:release web --app querocento

