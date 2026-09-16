



Part 2?

I'm currently trying to set up the postgresql functionality

issues?
I don't know if I'm doing things in the wrong order.
This is very clearly part 2
Yet, it seems a docker.yaml was created prior to this step in the example project

Does this step rely on docker.yaml?
what does docker.yaml actually do?
since it manages the different services, it seems like I should do it afterwards.

It's shockingly hard to get a straight answer of how to get started on this part.
I'm installing postgress 18. so what was the package I added earlier lol?

After doing this part, I need to set up the context and do the db saving etc.?
and call it from the correct parts. It was just an extra layer?

I feel like I've got a clear idea of what to do, but I want to see what the AI
is suggesting for these steps. Hopefully I'm not learning bad habits.

We're running a lot of tests and steps to validate installations. I should
probably make note of them.
dotnet ef database update --project Data --startup-project WebApi
read up on that line further?

Despite the massive digression, it seems the AI actually got back on the same
track as I wanted by itself, once we finished the installation, setting up
migrations and updating the ef database.

Cool.

Now I'm going to update the tests so I can actually test persistence?
I could also use Scalar or something?





<details>

Building healthcheck test - but DOCKER COMPOSE must use it.

Dockerfile:
Made. Run?

Except My Docker Desktop app which I'm apparently completely reliant on won't run properly
Most likely due to admin privileges, which I haven't received after several months...
What was supposed to be my most productive day is now likely my least productive day
since i need to track error messages and see if I can find a way around an issue
I shouldn't be having in the first place.

I need to figure out if there's literally anything else I can do given this bottleneck.
</details>


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




`NOTES:`

Can I and should I structure my models in preparation of DB context usage?
How does this work, exactly?
I think understanding this is kind of important, because I still
have a weak grasp of how property accessibility should work
in the first place, and this relates to that.
Some of it just seems to be semantic /syntactic.
so there's no issue in setting it up like that in the first place.

PRIVATE CONSTRUCTOR IN MODEL:

The private constructor is essentially what enables EF Core to build
the C# class object from the database row data WITHOUT other applications
being to access it and create bad/empty data objects with it.

WHY THE PROPERTY ACCESSIBILITY CHANGE?

But why change the Accessibility in EG Title?
Again, because EF Core has private access - or rather it USES private
access, but it needs to be made explicit?

ID

The database handles that, so it just needs to be made accessible, but
shouldn't be modified or part of any constructor since you don't want
other parts of the code to access it.
AKA DB EXCLUSIVE.


FURTHER:

my models should be POCO? Plain old something object.

They shouldn't contain any logic, inluding contstructor logic?

But should/could I make them like that before DB context?
And does it cause issues?

Making the models POCO doesn't seem practical for several reason.
If I want to allow other developers to build upon the project,
there's not a simple way to enforce interactions with the models purely
through the services, especially not, when they're segregated into
different projects.

keeping the rules of interaction within the data container itself
is the best and simplest enforcement.

There seems to some kind of bellcurve here where anemic models
become less useful in larger projects.

I think what the AI is trying to help me with proves its misunderstanding.
Need to talk to it again.

how and when do I use the docker.yaml file?
am I suppsosed to set it up BEFORE postgreSQL?

The task guide doesn't acknowledge it
but the evaluation references it...?

in the controller, you take functions with the IEnumerable<T>
type, and return it via the OK(); or other result equivallent.





Future changes:
Remove Library model
Separate library service into:
    user service
    and book service

Proper functionality lol?



