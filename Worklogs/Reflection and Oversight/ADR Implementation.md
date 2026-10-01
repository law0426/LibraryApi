

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


 ## ====== Summary 1 =============

First I changed the user model to accomodate for the variables
old provider id went from string to guid
Added password for proper login and registration testing.
created constructor for new structure.
(I should still move contstructor logic over to services.
to fit industry standards better. For consistency, not yet.)

Changed user registration and authentication i library service
which got moved over to authservices.
JWT services also got changed to fit the GUID system.
Tried to minimize guid to and from string conversions.

With the changes, the callstacks also needed to change.
auth controller had to remove the old get token path
as it was just for testing with a predetermined providerID.

Added the authservice and its interface scoped to program.cs

Authservices handles the registering of the user and creation
of the overall id. JWT handles the tokenization.
Library services manages models and privileges.


# More work.

I should also review the comments - I've been blindly
working my way around them. Ignoring them.
They were there as either reminders and markers for future change
or explanations of current implementation.
As they weren't pseudocode, I've not given them much thought
once I started making changes.
They were helpful when trying to understand some 
implementations, though, so I still want to keep the structure.


Tested the chain. We're creating a user.
User persists in the database.
user can input their username and password.
We return a jwt for testing.
The jwt is used to return borrowed books.

Had to mess around with migrations which I still don't really
understand, but it worked.


Created a fairly pointless dto, but I need SOME experience with them.
I also feel like I immediately do, once reminded I could expand it with author and genre and other things.
so there's still a data collection for input.
But hey.

Man there's a lot of things I'm adding to test this functionality... Wait I think I'm done implementing the actual important part lol?
I'm now building a more thorough collection of data
and behaviours
to gain proper experience for how an API with users
and authorization properly functions.

This isn't technically required but definitely good for several
reasons.

due to the absolutely anemic initial draft I had for the API
I've had to constantly update and adjust the feature set
just to be able to properly test features
since, obviously, in order to look up data
I first need data to look up.
at which point there's not that much difference
between doing a lot of manual injection
and creating a proper posting system.
At which I might as well make the posting system
for extra experience.

I think I could also go back to trying more TDD for the
remainder of this.


