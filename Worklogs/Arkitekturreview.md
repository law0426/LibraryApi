
# ======== This is just the task review file ===========


TODO:
REMEMBER TO GET THE NEW EXCALIDRAW DIAGRAM FOR THE PROJECT.









Immediately fristet til å bare dumpe alle problemene.


Take inventory.

How did it go. What did I learn
What should I improve?
Even simpler: what could I change?



Weaknesses?

Security?
I don't use the middleware - how much of an issue is that?
Isn't the algorithm the same?
Is there some sort of stamp of approval on those like cerficates?



Summary:

From the get-go I made the app too simple, to the point where testing things was made difficult due to the incomplete feature set.
At least, Having get requests, with no prebuilt dataset meant I'd need some form
of injection so I'd have something to work with.
There's plenty of features to add.
Return books with their borrowed status displayed.
Filter by borrowed status.

Have some basic interface to display this.

The borrow history.
Some summary of the state of the book.
Author and additional book details.







(Oh yeah, I never set up traefik. This was for 
redirective purposes? better than typing ports in.)


There's a real temptation to just dump the project onto chat GPT for review, and I eventually want to see what it has to say, and compare notes, but I've got pretty clear opinions. Question is whether I've been able to keep track of it all. I don't actually want to go back over old notes.

I don't think I actually save time doing that. But thinking chronologically can definitely help.


I kind of want to go through my code line-by-line.
I'm worried there's elements there that should change.
I remember setting up some TODO notes.





TASK:

================= PART 1 ================

Make an overview of how my system works today.
Make a diagram of the components in my solution and how
they communicate.

EG:

client -> API -> Backend -> Database.

(Ok, but I can make this extremely granular.)

Include the components in your ACTUAL solution.

show:

    - How to run components.
    - how they communicate
    - how data is stored
    - how to identify user
    - which components rely on each other.

(So this would mean, like docker compose. They communicate
via the API, but also Pgadmin interfaced with postgres.)
(Should I consider postgres and DB separate?)
(Data is stored by postgres via migrations to SQL files?)
(Are they SQL files? what's the actual component?)
(User ID - I can have several layers. Atm, Give token. Check token. Shouldn't I have a system that decides the ID for the user?)
(I can make a dependency map. How do they define component, though?)


=================== PART 2 ====================
Find weaknesses (vulnerabilities)


Perform a small arkitekture review of the system
find at least 3 things to improve.

For each weakness, describe:
    - problem: what's the problem.
    - consequence: WHY is it a problem?
    - solution: what would you change?
    - priorty: How important is this to fix?

EG:
Problem: API uses a connection string that sits
directly in the configuration file.
Consequence: sensitive information can be exposed if the config is committed to github.
solution: move sensitive configurations to environment variables or secrets.
Priority: high.

There are no correct answers in this task. The most important thing is that you can identify real problems and justify why you think it's a problem.

(Thankfully this was one of the things that got pointed out for me before. But it's still confusing how I'm supposed to approach this PW exposure vulnerability issue in entirety as I apparently should even avoid it being logged in the terminal.)
(Hashes are supposed to be less of an issue, but still an issue. So I don't know to what degree I need to build a habit around this sort of thing, but I've started. Made it a bit of a shit show to code and find roundabout commands to not expose the password, and even flush the terminal's memory of it - as far as I could tell, at least. But it's probably better to be overly cautious at the start and reel it in if it's not that big of a deal, than to realize it's an issue and I've developed a bad habit.)

============ Part 3 Architectural decision =========

=================== 3 A) =======================
Pick a problem you found, explore at least 2 possible solutions.

EG: we need to handle configuration.

Option A: Environment variables
Option B: Secret management

Compare the options by:

    - Pros
    - Cons
    - Complexity
    - Security.
    - Maintenance

(This was a little strange to me. I was suggested the user secrets for the connectionstring, but not the (other) password. The secret manager I do not like as it's hidden.
It requires me to keep it mind and have a habit, not to mention ability to begin with, to check them. So that makes oversight an issue for me. It's clearly safer as you cannot accidentally upload it to github, etc.)
(does it make maintenance more difficult? Not sure about that)

3B) choose a solution and justify the choice.

The goal is to show your ability to evaluat trade-offs and not just choose the first solution you find. Document the decision in an ADR.md (Architecture Decision Record.) with the following structure:

# Architecture Decision Record

## Problem

## Alternatives

## Decision

## Why?


## Consequences

(I believe there should be additional hashtags after problem, but ok.
Also, wouldn't alternative be solutions?
A Location was not specified. Assume root.)

I can write it in norwegian or english. The important part is the contents are clear and you can explain your decisions. it doesn't have to be long. Focus on the problem, alternatives, the choice and the consequences.

Why document the architectural decision?

In a real development project, many technical decisions are made.
An ADR is used to document which problems were had, which options were considered, choices made and why.
This makes it easier for other devs to understand why the system is built as it is, and makes future decisions easier.

Evaluation, making technical decisions and documenting architectural decisions are also relevant experiences to place on a CV when seeking Praxis.

================ Part 4 ======================

Implement the improvement you chose.

You should make at least one concrete architectural improvement in the project.
The improvement doesn't have to be big. The most important thing is to show the problem, the change, and why.

=============== HAND-IN =====================
Link the project. Commit history point, not necessary.


