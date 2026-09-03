TODO:

Return item.

Build container classes. Convert for DB use later.
POCO? Need to simplify them later for DB conversion.

all code can be moved around later.

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
User can add book to their profile when borrwing.

======================NOTES:=====================

I had already built the exception ahead of test. I feel like this way of working is counterintuitive.
I need to slow my roll I guess.
Which will make it take even longer.
FML. And then there's understanding the syntax for the assertions. I have to look up a lot.
I feel like I'm being punished for thinking ahead.
Who thought this was a good idea?

======================= BRAINSTORM: =============================
Where do I want to store information?

on the one hand, it's nice to be able to look up the user and see their book history.

on the other hand, in case the profile disappears, it'd be nice to store the ID on the book lending history.
With dates as well.

But I'm supposed to ignore this planning and pretend I'm stupid just to use xunit and give it
credit for any revelations in development?
