## Player Service
* This service adds a layer of indirection so that the other services don't have to change when the Database becomes the source of truth.

---
### Endpoints:
* `GET api/player` - Gets all of the players from the CSV Service.
* `POST api/player` - Sends the same list of players to both the CSV and Database services.

---
### Healthcheck:
* The service will fail a healthcheck if either of the CSV service is unreachable (since it can still function without the Database service).