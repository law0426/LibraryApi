TODO:

ISSUE: too much time spent. Out of time.


Add test: Post book and Get book matches.




`BOTTLENECK DEBUG: Result: Add appropriate service singleton for controler: ILibraryService.`
``TODO: Collapse or make section ignorable:``
Hold on, my GetUsers_ReturnsOk
Now fails?
Didn't this work before? What is happening now?
The ApiFactory is just Completely impenetrable in tracking down issues.
I can't use it.
This is too much of a bottle neck. I have to give up on the project and just harass an AI
to explain how it works and how to use it.

POSSIBLE ISSUES:
Client isn't created properly
factory isn't created properly
apifactory file isn't created properly
apitest IClassFixture<ApiFactory> interface inheritence isn't right.
Endpoint is wrong.
Every line in the eactual test could be wrong.
Server simulation doesn't launch.
Client doesn't even reach a client.

this is way too much.



`PostBook()`

1) CONVERT ARGUMENT TO STRING.

Current error:
Object reference not set to an instance of an object.
Even interacting directly with the model, is causing issues. How.
I think my list doesn't exist lol. FML. never initialized.

using the factory post, I'm faced with a different issue: convert it to http content.


`Notes:`

Now Linking PostBook controller to Library RegisterBook() service.
Can we return created value?
Created links. Problem is testing this way Makes it unclear where the error is.
If I had a better understanding of how to interact with the http controller systems,
I might not have these issues. But I think I need to reduce the tests now just to 
ensure the error isn't deeper.

Stuck on nullreference error. Don't know what causes it. Might be some issue with await.

I wanted to see if I could add an object like it had its values exposed, but I think I need to give up on that.
The MVP used just a simple string to add a book. Do that for now.



``SIDEQUESTS:``

`PostBook();`
TODO: Actually understand the point and function of a DTO. This is probably what I need.
It was just confusing since I think we used some JSON stuff for DTOS, and don't actually know
what my options are - I've no idea how flexible this part is.

`Markup Language`
Would be nice to make these documents more readable.

`proper usage: Constructors and privacy settings`
I think I need to just leave everything public in my classes until I understand the proper way of exposing
and constructing the variables. Because I've seen so many ways that confuse me.


``ISSUES?``
``Library Model``
Library is halfway between a service an a model. I don't know what to do about it.
I technically want to store data in it. But it also makes sense to have functions on it.
Otherwise I have to leave variables exposed for the library service - which I don't want?
I don't think I have clear understanding of how to balance keeping things safe, and segregated.

`TDD flow`
I've deviated a lot from the original mold, which makes sense to me when it's part of development
but don't know if I'll be penalized for it.
EG. I decided I need to add the PostBook feature in order to properly test the GetBook feature.

`definitions`
I still struggle with some of the nomenclature.
I don't like having a vague understanding of MVP and "main flow"
when I'm going to be graded on it.
Because I couldn't get clarity on some things from the beginning, like
Verification that my project even theoretically fits the criteria,
I've just been shooting the dark.

`LEARNED`
Whatever the library controller inherits needs to be added as a service - as a possible singleton
So in this case, IlibraryService was needed.


======================================

`Part 5 Summary:`
Controllers that link to the domain logic.
AKA, controllers, to services to models.

"Don't make new functions just for the API"
Except I already did because I don't feel like I can test the get requests without post.

When green, test with Scalar.
Ensure responses match part 3 definitions. 

So I still don't understand the expected structure for testing the API and getting them green.
And then if I've done that - why using Scalar afterwards?
Do they mean Calling the controllers?
Using client?
Factory?
Call the services?
Social services because I need help?
It'd be nice to know how many layers of errors I'm supposed to expect to have to sift through
Before I make a guess and am up to neck and beyond in ones I wasn't supposed to even have in the first place.



`Part 4 Summary:`
Make tests the describe API behaviour.
Checklist:
GetUsersAsync();
GetBooksAsync();
PostBookAsync();



Part 3 Summary:
API.md or readm.md, describing the API?
What descriptions are required?:
Endpoint? - Controllers? - HTTP Methods.
Input data. - Data transfer objects?
Return values. Status codes.





Return item.

Build container classes. Convert for DB use later.
POCO? Need to simplify them later for DB conversion.

all code can be moved around later.

Formatter: Prettier not working. Why? Or rather, works where I don't want it, viceversa.

Part 1:

Hvilket problem løser systemet?
Hvem er brukeren?
Hva er den viktigste flyten systemet må støtte?
Hvilke objekter trengs for denne flyten?
Hva er minimum for at systemet gir mening?

Hold MVP-en avgrenset til én hovedflyt (end-to-end).
Hovedflyten kan bestå av flere steg og operasjoner, men skal dekke én konkret brukeroppgave fra start til slutt.

Så er det de mener, f.eks:
(forgive the goofy order)

User requests books alphabetically.

library.csv
eller db fil?
list<books> from library.csv.

get books => linq expression, sorted alphabetically.
Paginated?
Presented to user through ui?

Alt det er en sequence, så det telles som "hovedflyten"?

Weird use of MVP.
Sliter også med terminologibruken
MVP er det minste featuresettet man forventer at en bruker er villig til å betale for. En halvferdig backend med en single call stack tror jeg ikke noen ville betalt for lol.

=====================WORK LOG============================
ran test for borrowing. We're in green.

Next test:
Borrow fails if already borrowed.
Setup test for return:
Return.
Create: User.
User can add book to their profile when borrowing.
User receiving book RED=>GREEN. DONE.

Going to use the HTTPHealth_ReturnsOk test and see if I can consistently
use this formula to test my API project.
This requires building the controller?
I'm doing this ahead of building services, which might be a bit backwards, but that's what I find most important.
Test: Red. I cannot connect to the localhost. The target machine actively refused it.

Since I can't track down how the example test succeeded in the first place,
and I keep getting told I either have to run in parallel, I'm giving up on that.

I've set up the Factory test environment.
I'm getting error. I can't tell if it's due to the address not working or something else. Frustrating.
Will setup controller to make sure it works?

I was hoping the logger could help me since despite the wall of text, I can't actually track the call stack
And since the logger doesn't activate, I have to assume, I'm not going the correct path.
Is there a way for me to know the function route as well as the route I'm actually calling?
Everything's implicit, and completely unhelpful.

of course I spent ages because I forgot to build the controller and map it.


Next is building the Service linking the library.
But in order to get any data from library we need to be able to add to it.
So I need to add a Create Book.

I had to add Json usage to test. - well, it was recommended.
Will now see how that goes.



======================NOTES:=====================

I had already built the exception ahead of test. I feel like this way of working is counterintuitive.
I need to slow my roll I guess.
Which will make it take even longer.
FML. And then there's understanding the syntax for the assertions. I have to look up a lot.
I feel like I'm being punished for thinking ahead.
Who thought this was a good idea?
I think I skipped steps again. Should've tested if user can be built.
Then check if name is correct.
Then check if book can be added.

I've been told I don't have to be excessively incremental.
I'll try to use my own judgement and test what I find to be important.

======================= BRAINSTORM: =============================
Where do I want to store information?

on the one hand, it's nice to be able to look up the user and see their book history.

on the other hand, in case the profile disappears, it'd be nice to store the ID on the book lending history.
With dates as well.

But I'm supposed to ignore this planning and pretend I'm stupid just to use xunit and give it
credit for any revelations in development?

What else needs to be tested?

We need to check we reach the server? I can't run that at the same time? yes I can. Run it as a task lol?

that'd be crazy.

Ok, what about the services. Look over how I set up the controllers and services last time. I think I need a starting point.

First thing is we send a Get Request.??

No. First step is interactin directly with the service. AKA, using a task. In my context,
that would be what the todo context did in my previous project.

THEN after setting up a service, link the behaviour to a controller?
Then test the controller? What does a controller test even look like? I have to use client interactions then, don't I?

================ Testing for WebApi========================
What is the problem?

What am I testing?
Behaviour.
Which ones?
Services
Controller
URL?

What do I have access to?
Services
-No problem
Controllers
-Can call directly - but not the natural environment
-Call via http? - has to be simulated. Use client?
-Server also need to be up to have something to connect to
-so I need to launch a server, and create a client.
-And then start interactions

How easily can I set up this sort of test environment?
Can I just run the program.cs app as a server in the test?

OVERVIEW OF THE REQUIREMENTS:

AM I ACTUALLY MAKING THE API PORTION?
OR JUST DESCRIBING IT?

It looks like they mean we just summarize the interactions without implementation?
As in pseudocoding?
But then they still want us to test it?

ISSUES:
Should BORROWED be a book parameter when the user can add books to their profile?
This is a library-side value.but also, bloats the system, and requires more classes etc.


PRETTIER CANNOT FORMAT C#?!






