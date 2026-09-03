TODO:

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

Can I already apply this to API?

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