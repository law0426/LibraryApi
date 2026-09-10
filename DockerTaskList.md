


Building healthcheck test - but DOCKER COMPOSE must use it.

Dockerfile:
Made. Run?

Except My Docker Desktop app which I'm apparently completely reliant on won't run properly
Most likely due to admin privileges, which I haven't received after several months...
What was supposed to be my most productive day is now likely my least productive day
since i need to track error messages and see if I can find a way around an issue
I shouldn't be having in the first place.

I need to figure out if there's literally anything else I can do given this bottleneck.




`tasks`
``Part1: COMPLETE!``

<details> 
<summary>Task Details</summary>
1) Make docker file. Sure.
2) run api in docker-container. <== The product file? Output? Nope; the launched image. the application?
3) Run: 
    docker build -t navnet-på-ditt-api
    docker run -p 8080:8080 navnet-på-ditt-api
-t means tag, just gives it a name.
-p? Port.

Your C# source code ``Base: source code``
        ↓
   Docker build ``action: via config``
        ↓
   Docker image ``result: file``
   "webapi"
        ↓
   docker run   ``action: user launch or run``
        ↓
 Docker container ``result: process``
   (running API)
        ↓
   Scalar / HTTP requests ``action: user interaction``
</details>

<Part2: 'incomplete'>
<details>
<summary>PostgreSQLizing</summary>
Use PostgreSQL as database and get database image.
confirm:
1) API connects to database through connection string
2) data can be stored
3) data can be pulled
4) data is persistent after API-container restarts.
</details>

<Part3: 'incomplete'>
Add pgAdmin
To make data more manageable, add pgAdmin to Docker Compose.
Confirm:
1) pgAdmin launches
2) pgAdmin connects to PostgreSQL
3) API data is accessible. (cross refference with endpoint.)

(Github as guide.)

<Part4_Handin: 'incomplete'>
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








