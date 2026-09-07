
This is a restApi project for a library.

Contains book data objects, and user data objects.

Api portion will handle borrow and return requests.


Book object will contain:
1) title
2) borrowed state



API:

EndPoints

ACTION:         Return:      REQUEST:    RESPONSE:    ERROR:    INPUT:    
GetBooks();     List<Book>   GET         200Ok        404?      N/A
GetBook();      <Book>       Get         200ok        404       String;
PostBook();     N/A          POST        201CREATED   400?      String;          




