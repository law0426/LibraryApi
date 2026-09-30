

# Architecture Decision Record

Note: is there method or filter for gauging whether
something is a weakness in my project?
I'm just going by what bothers me.

Also note:
I don't think I understand this layout after the instructions given by lecturer.
EG. "Why?" can encapsulate both the sections of problem, and consequence, just less specifically.

## Problem
List:


======== Features =========

1) completely lack UI
    - Should have input fields
    - data output display with pages.
    - Feedback for errors?

2) No traefik for easier navigation?
    - not that important for now, but still.


======= Security =======
1) PW storage:
    - Connection string is in secrets
    - password in .env. do I know the difference?
    - there's also docker secrets?
(Neither of the above is secure? Still exposed text, just stored somewhere else)

2) User ID:
    - User currently is provided a signed JWT with a ProviderID that they personally assign? 

======= categorization =======
1) Models should probably change
2) 


## Alternatives
Current situation:
User ID:
    - User currently is provided a signed JWT with a ProviderID that they personally assign?

Problem: 
Users can assign their own ID, making the security weak, and making overlap possible, meaning they'll - given lack of user registration - be able access each other's content.
It also shouldn't require manual input at all.
So it's a bad and confusing user experience, ontop the 
security and other erroneous behaviours.

Solution:
1) Use middleware.
    Pro: Simple, quick, and probably more reliable.
    Con: I don't learn how this works.
    Complexity: simple
    Security: high.
    Maintenance: automatic?
2) Implement random non-duplicate ID generation?
    Pro: I learn
    Con: I have no idea if/how this is correct without research.
    Complexity: unknown
    Security: unkown
    Maintenance: unkown.
3) there is no 3, because I have no idea what my options are.
    Pro: I learn.
    Con: I make mistakes.

Priority: highest.
Justification: I can't have done it correctly.

## Decision
2) Implement random non-duplicate ID generation?
    Well - Research how to set up my own IDprovision.
    The implementation comes after.

## Why?



## Consequences

I