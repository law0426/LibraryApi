

We're changing the IDprovider system.

What do I need?

A system to provide ID.
Means Generating ID.
Can that be systematic in avoiding overlap?
I need to research ID generation.

I don't know if there's anything I should do about the signature.
I've followed procedure there, so I won't touch it.

Where when what?

It should happen upon contacting the webpage?
And also when registering?
Or just one or the other?
I think a new JWT should be provided, not necessarily
the provider ID, but I'm unsure how this vs a session token
should work. I remember that a new session ID should often
be provided alongside new log-ins, when making important
decisions like for banking, or even just accessing the account
at all - so no long-term logins.

It's also a bit annoying I don't have a cookie system, since
that's how I'd handle some of the functionality - 
it's just something I'll have to keep in mind, and not try
to force the functionality onto the IDprovision

As such, only registered users get IDProviderId.

I also think I might want HTML for UI for the user registration:

Scalar
→ inspect/test endpoints directly

Basic HTML + JS
→ register
→ receive generated user ID
→ log in
→ receive JWT
→ borrow/request books
→ demonstrate user ownership

I've also realized I've gotten yet another categorization
failure: I should have an authservice, as well as the jwt service.

I could treat this as a separate problem for me to fix, but due
to immediate relevancy, it makes sense to address now.





