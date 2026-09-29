









# System explanation:

## Developer layer

Models for user, book and library

Library services currently manages all of them.

Library controller calls the service.

Scoped controllers built in the program.cs
Aspnet structure?

Dockerfile compiles webApi to a file with a path.
Also works as a configuration file? Accessed by Docker-compose?

Postgres uses efCore? to manage databases?

Docker-compose.yaml handles additional services/containers (?)
Downloads, assigns, establishes ports and connects them with
Whatever accessibility we establish in the file.

Functions like config and executable.

pgadmin also gets containerized.

pgadmin lets you create an interact with servers and databases which are based on the models previously built.

Security
JWT
USERS
Privileges



## User layer:

The user connects
gets JWT for ID.





Should I change address to 5432? 5050?
5277 is current shit.
I've currently set environment to development
What should change for release? Other term?

# Issue list

By category:

## Lack of features.

Do you actually want to get users?
Maybe as admin.
Getting books. Yes. But filtered in different ways.
with pagination.
Users can have their own borrow history.
Should this be accessible via a table in library or actually stored on the user?
Because the library should have their own borrow history.
Either focus makes sense:
Dates, people and books should all be stored, and sortings can be desirable for any reason.


## Security?

USER ID
JWT
USER REGISTRATION.
TOKEN CREATION
USER ID CREATION?

PW storage.
For admin, and postgres is one thing.




## Categorization?

Models.

Library doesn't have a function atm.
I think that should store borrow history, and other things, though.
Books and users should have their own services and controllers, probably though.


## Industry standards?
No middleware. Should I care?
The server hosting?
Should I care?











# About

## Connection strings and configurations

There's a hierarchy to how configs override each other.

appsettings.json
        ↓
appsettings.Development.json
        ↓
User Secrets
        ↓
Environment variables
        ↓
Command-line arguments

The latest (bottom) Overrides the previous.

All these configurations basically merge into a configuration system that can be addressed for information such as the connectionstring.
This only lives in runtime, however. It isn't compiled into an intermediate .dll.

docker compose up
to run docker.

docker compose ps
gets you the PROCESS STATUS.

## efcore and migrations.

Migration
A set of instructions describing a database schema change.

Creates Database using model data.




Finally go over further readings?



