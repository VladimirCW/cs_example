## Preparations
s

## Run the tests

1. run the selenium image with one of the following command:
    1.1. `cd grid`, `docker run -d -p 4444:4444 -p 5901:5900 -v /Users/vova.dmytriukhin/Projects/webdriver_test2/webdriver_test2/grid/config.toml:/opt/bin/config.toml selenium/standalone-chrome `
    1.2. `cd selenoid`, `docker-compose up`
2. run tests with `dotnet test`
