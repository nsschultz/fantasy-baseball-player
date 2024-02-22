#!/bin/bash
set -e
EXIT_CODE=0
docker compose -f .docker-compose/docker-compose-ci.yaml -p fantasy-baseball-player up --build --exit-code-from api || EXIT_CODE=$?
docker compose -f .docker-compose/docker-compose-ci.yaml -p fantasy-baseball-player down
docker volume rm fantasy-baseball-player_data_volume
exit $EXIT_CODE