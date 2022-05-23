- **Tests made on Python with PyTest.**
- **Tests can be run in Docker Container.**

## To Execute Automatically:

!!!You must have Docker installed on your system!!!

1. Clone the repo
2. Create 2 directories "logs" and "test_results"
3. In the root folder of cloned repo open terminal and enter this command:

```

docker-compose up --build 

```

To see test results in HTML run:

```

allure serve test_results/ 

```

