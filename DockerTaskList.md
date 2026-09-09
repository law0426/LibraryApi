


Building healthcheck test - but DOCKER COMPOSE must use it.

Dockerfile:
Made. Run?




`tasks`
1) Make docker file. Sure.
2) run api in docker-container. Look it up.
3) Run: 
    docker build -t navnet-på-ditt-api
    docker run -p 8080:8080 navnet-på-ditt-api
-t means tag, just gives it a name.
-p?

Part 2
Use PostgreSQL as database and get database image.
confirm:
1) API connects to database through connection string
2) data can be stored
3) data can be pulled
4) data is persistent after API-container restarts.

Part 3
Add pgAdmin
To make data more manageable, add pgAdmin to Docker Compose.
Confirm:
1) pgAdmin launches
2) pgAdmin connects to PostgreSQL
3) API data is accessible. (cross refference with endpoint.)

(Github as guide.)

Part 4 Handin.

1) Commit changes to github repo
2) find link to that specific commit (URL)
3) hand in that commit.



Evaluations:
Dockerfile:
1) exists
2) build API correctly
3) API can start isolated.

Docker Compose:
1) docker-compose.yaml exists
2) Activates all necessary services.
3) compose has:
    API
    PostgreSQL
    pgAdmin
    Datamanagment:
        Data can be stored
        data can be pulled.
        Data is persistent
    pgAdmin
        Runs in own container
        connects to postgreSQL
        data viewable via pgAdmin

    Health Check -``WOAH WHERE DID THIS THING COME FROM?``
    Don't think we ever went through this. Was just used in passing. Don't know why. just need to google it.
        API exposes health endpoint
        Docker Compose uses healthcheck
        health status verifiable.

    Scope
        No new functionality
        Focus on containerising existing system.








