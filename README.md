## Player Service

- This is the source of truth for the player data.
- Exposes the CRUD functionality needed to maintain the player data.
- Exposes an endpoint to retrieve the player data as a CSV.

---

### Healthcheck:

- The service will fail a healthcheck if database cannot be accessed.
- The service will also fail if it cannot connect to the position service.

---

### Build Image

```
version=$(cat version.txt) && docker build -t nschultz/fantasy-baseball-player:$version .
```

---

### Dev Containers

- Command for starting/stopping dev containers:

```
export app_version=$(cat version.txt) && docker compose -f _dev/docker-compose-dev.yaml -p fantasy-baseball-player up --build -d
export app_version=$(cat version.txt) && docker compose -f _dev/docker-compose-dev.yaml -p fantasy-baseball-player down
```

- Extensions are in the extensions.json file and should prompt to install on start
- Tasks are setup in tasks.json.

---

### Runtime Containers

- Command for starting/stopping runtime containers:

```
docker compose -f _dev/docker-compose-runtime.yaml -p fantasy-baseball-player up --build -d
docker compose -f _dev/docker-compose-runtime.yaml -p fantasy-baseball-player down
```

---

### Local Connections

- Player API
  - View Swagger/Test Endpoints: http://localhost:8080/api/v2/player/swagger/index.html
- PG Admin
  - GUI: http://localhost:9000
- Postgres Database
  - Available at database:5432 (not outside of the containers)
- Montebank
  - GUI: http://localhost:2525
  - Postions API available on http://mock-positions:5555
