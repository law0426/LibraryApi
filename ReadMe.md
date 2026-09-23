
This is a restApi project for a library. Has barest functionality
in order to move on to make docker service container structures.

Contains book data objects, and user data objects.

Currently:
Api handles posting and getting books. Gets users.
In the future:
Api portion will handle user ability to borrow and return books via requests.


Book object will contain:
1) ID
2) title
3) borrowed state

User object will contain:
1) ID
2) name
3) List of books they've borrowed.


API:

EndPoints:
Get - Library/users
Get - Library/books
Post - Library/books

ACTION:         Return:      REQUEST:    RESPONSE:    ERROR:    INPUT:    
GetUsers();     List<User>   GET         200Ok        404?      N/A
GetBooks();     List<Book>   GET         200Ok        404?      N/A
PostBook();     N/A          POST        201CREATED   400?      String;          


Why is this above part ugly on github?

