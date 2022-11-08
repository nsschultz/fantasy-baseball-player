## Player Service

- This service adds a layer of indirection so that the other services don't have to change when the Database becomes the source of truth.
- Proxies

  - /api/v1/action/export => player-export-service
  - /api/v1/action/merge => player-merge-service
  - /api/v1/player => player-database-service
  - /api/v2/player => player-database-service
  - /api/v1/projection => player-projection-service

---

### Healthcheck:

- The service will fail a healthcheck if either of the CSV service is unreachable (since it can still function without the Database service).

---

### Build Image

```
version=$(cat version.txt) && docker build -t nschultz/fantasy-baseball-player:$version .
```
