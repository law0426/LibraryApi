TODO:

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
