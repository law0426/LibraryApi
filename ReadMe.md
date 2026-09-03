
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
Register();     N/A          POST        201CREATED   dunno               


Beskriv:

Hvilke endepunkter trenger API-et?
Hvilke HTTP-metoder skal brukes?
GET
POST
PATCH
DELETE
Hvilke data skal klienten sende inn?
Hva skal API-et returnere?
Hvilke HTTP-statuskoder skal brukes?
Det holder med å skrive noe som for eksempel dette:

POST /players
Request: { "name": "Ole" }
Response: 201 Created

PATCH /players/{id}/xp
Request: { "amount": 100 }
Response: 200 OK

GET /players/{id}
Response: 200 OK

