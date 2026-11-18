#!/bin/bash
EXIT_CODE=0
COMPOSE_FILE=".docker-compose/docker-compose-ci.yaml"
PROJECT_NAME="fantasy-baseball-player"
TEST_RESULTS_DIR=".docker-compose/test-results"

rm -rf "$TEST_RESULTS_DIR"
mkdir -p "$TEST_RESULTS_DIR"

export DOCKER_BUILDKIT=0
docker compose -f "$COMPOSE_FILE" -p "$PROJECT_NAME" up --build --exit-code-from api || EXIT_CODE=$?

CONTAINER_ID=$(docker compose -f "$COMPOSE_FILE" -p "$PROJECT_NAME" ps -aq api)
if [ -z "$CONTAINER_ID" ]; then
  echo "Unable to locate the api container for test result extraction." >&2
  [ "$EXIT_CODE" -eq 0 ] && EXIT_CODE=1
elif ! docker cp "${CONTAINER_ID}:/app/TestResults/." "$TEST_RESULTS_DIR"; then
  echo "Failed to extract test results from the api container." >&2
  [ "$EXIT_CODE" -eq 0 ] && EXIT_CODE=1
fi

if ! docker compose -f "$COMPOSE_FILE" -p "$PROJECT_NAME" down; then
  echo "Failed to shut down docker compose resources." >&2
  [ "$EXIT_CODE" -eq 0 ] && EXIT_CODE=1
fi

exit $EXIT_CODE