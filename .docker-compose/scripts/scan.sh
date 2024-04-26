#!/bin/bash
rm -rf coverage-results/
VERSION=$(cat version.txt)
dotnet build
dotnet sonarscanner begin \
  /o:"nsschultz" \
  /k:nsschultz_fantasy-baseball-player \
  /n:fantasy-baseball-player \
  /d:sonar.token="$SONAR_TOKEN" \
  /v:$VERSION \
  /d:"sonar.cs.opencover.reportsPaths=coverage-results/coverage.opencover.xml" \
  $([ -n "Database/Migrations/*.cs" ] && echo "/d:sonar.coverage.exclusions=\"Database/Migrations/*.cs\"") \
  $([ -n "Database/Migrations/*.cs" ] && echo "/d:sonar.exclusions=\"Database/Migrations/*.cs\"")
dotnet test --no-build \
  "/p:CollectCoverage=true" \
  "/p:CoverletOutput=../coverage-results/" \
  "/p:CoverletOutputFormat=\"json,opencover\"" \
  "/p:MergeWith=../coverage-results/coverage.json"
dotnet sonarscanner end token="$SONAR_TOKEN"