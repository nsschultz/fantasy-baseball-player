# Deployment Guide

This document outlines the complete deployment procedures for the fantasy-baseball-player microservice.

## Overview

The fantasy-baseball-player service is deployed as a Docker container to production environments. The service provides player data management with CRUD operations, CSV export capabilities, and integration with the position service.

**Service Details:**
- **Image Repository**: `docker.io/nschultz/fantasy-baseball-player`
- **Container Port**: 8080
- **Health Check Endpoint**: `GET /api/health`
- **Database**: PostgreSQL (required dependency)

## Prerequisites

Before deploying, ensure:

- ✅ Docker and Docker Compose are installed (Docker Engine 20.10+)
- ✅ PostgreSQL database is accessible and initialized
- ✅ Position Service is running and accessible at configured host
- ✅ All environment variables are configured
- ✅ Docker image exists and is tagged correctly
- ✅ All quality gates have passed (coverage ≥ 80%, security scan clean)

## Deployment Environments

### Development Environment

For local development with Docker containers:

```bash
cd /workspaces/fantasy-baseball-player
docker compose -f .docker-compose/docker-compose-dev.yaml -p fantasy-baseball-player up --build -d
```

**Features:**
- Uses local source code with live reload
- Includes pgAdmin for database management
- Includes Mountebank mock for Position Service
- Database persists in Docker volume

**Stopping Development Environment:**

```bash
docker compose -f .docker-compose/docker-compose-dev.yaml -p fantasy-baseball-player down
```

### Runtime/Production Environment

For production-like deployments:

```bash
docker compose -f .docker-compose/docker-compose-runtime.yaml -p fantasy-baseball-player up --build -d
```

**Configuration Options:**

Before starting, edit `.docker-compose/docker-compose-runtime.yaml` to:
- Change `POSITION_SERVICE_HOST` if Position Service is on a different server
- Update database connection settings if needed
- Adjust resource limits based on your infrastructure

**Stopping Runtime Environment:**

```bash
docker compose -f .docker-compose/docker-compose-runtime.yaml -p fantasy-baseball-player down
```

## Release Process

### Step 1: Version Update

Update the semantic version in `version.txt` following [Semantic Versioning](https://semver.org/):

```bash
# Determine version bump based on changes
# MAJOR: Breaking API changes (e.g., 3.0.0 -> 4.0.0)
# MINOR: Backward-compatible new features (e.g., 3.3.0 -> 3.4.0)
# PATCH: Bug fixes and patches (e.g., 3.3.0 -> 3.3.1)

echo "3.3.1" > version.txt
git add version.txt
git commit -m "Bump version to 3.3.1"
```

### Step 2: Update CHANGELOG

Document changes in `CHANGELOG.md` following the format:

```markdown
## [3.3.1] - 2024-11-18

### Added
- TODO: Document new features

### Fixed
- TODO: Document bug fixes

### Changed
- TODO: Document behavior changes

### Breaking Changes
- None

### Migration Notes
- Run database migrations automatically on startup
```

### Step 3: Quality Gate Verification

Ensure all quality gates pass before creating a release:

```bash
# 1. All tests passing
docker compose -f .docker-compose/docker-compose-ci.yaml -p fantasy-baseball-player up --build

# 2. Code coverage ≥ 80%
# Check SonarCloud dashboard: https://sonarcloud.io/project/overview?id=nsschultz_fantasy-baseball-player

# 3. No security vulnerabilities
# Trivy scan results available in GitHub Actions

# 4. Code formatting validated
# Checked automatically in PR validation workflow
```

**Quality Checklist:**
- [ ] All tests passing (unit + integration)
- [ ] Code coverage ≥ 80%
- [ ] SonarCloud quality gate passing
- [ ] No critical/high security vulnerabilities
- [ ] Code formatting consistent
- [ ] CHANGELOG updated
- [ ] README documentation current
- [ ] API documentation (Swagger) accurate

### Step 4: Create Git Tag

Create an annotated tag for the release:

```bash
git tag -a v3.3.1 -m "Release v3.3.1: Player Service improvements"
git push origin v3.3.1
```

This triggers the automated Docker image build workflow.

### Step 5: Verify Docker Image

After tagging, verify the image was built and pushed to Docker Hub:

```bash
# Wait for GitHub Actions workflow to complete
# Check: https://github.com/nsschultz/fantasy-baseball-player/actions

# Verify image exists
docker pull nschultz/fantasy-baseball-player:3.3.1

# Verify multi-platform support
docker buildx imagetools inspect nschultz/fantasy-baseball-player:3.3.1
```

### Step 6: Create GitHub Release

Create a release notes entry on GitHub:

```bash
# Release notes should include:
# - Version number and date
# - Link to CHANGELOG.md
# - Highlights of key changes
# - Any breaking changes and migration steps
# - Contributors and acknowledgments
```

**Example Release Notes Template:**

```markdown
# Release v3.3.1 - Player Service Improvements

## Overview
This release includes improvements and bug fixes.

## What's Changed
See [CHANGELOG.md](./CHANGELOG.md#331---2024-11-18) for detailed changes.

## Breaking Changes
⚠️ None in this release.

## Migration Notes
Database migrations run automatically on startup.

## Contributors
- @nsschultz

## Verification
- [Test Results](https://github.com/nsschultz/fantasy-baseball-player/actions)
- [Code Quality](https://sonarcloud.io/project/overview?id=nsschultz_fantasy-baseball-player)
```

## Production Deployment

### Pre-Deployment Verification

Before deploying to production, verify:

```bash
# 1. Health check endpoint working
curl http://localhost:8080/api/health

# 2. API endpoints responding
curl http://localhost:8080/api/v3/player
curl http://localhost:8080/api/v3/player/{id}

# 3. Database connectivity
# (included in health check)

# 4. Swagger documentation accessible
curl http://localhost:8080/api/swagger/index.html

# 5. Downstream services can reach this service
# Verify Position Service integration
```

### Deployment Procedure

1. **Pull the latest image:**
   ```bash
   docker pull nschultz/fantasy-baseball-player:3.3.1
   ```

2. **Update environment variables** in `.docker-compose/docker-compose-runtime.yaml`:
   - Database credentials and host
   - Position Service host and version
   - Any other service-specific settings

3. **Stop the current deployment** (if exists):
   ```bash
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player down
   ```

4. **Start the new deployment:**
   ```bash
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player up --build -d
   ```

5. **Monitor startup logs:**
   ```bash
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player logs -f api
   ```

6. **Verify health after startup:**
   ```bash
   # Wait 10-15 seconds for startup
   sleep 15
   curl http://localhost:8080/api/health
   ```

7. **Run smoke tests:**
   ```bash
   # Test basic endpoints
   curl http://localhost:8080/api/v3/player
   curl http://localhost:8080/api/health
   ```

### Post-Deployment Verification

After successful deployment:

```bash
# 1. Verify health endpoint returns 200 OK
curl -v http://localhost:8080/api/health

# 2. Check container is running
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player ps

# 3. Verify no error logs
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api | grep -i error

# 4. Test API functionality
curl http://localhost:8080/api/v3/player
curl http://localhost:8080/api/health

# 5. Verify Swagger documentation
# Access: http://localhost:8080/api/swagger/index.html
```

**Success Criteria:**
- ✅ Container running and healthy
- ✅ Health check endpoint returns 200 OK
- ✅ API endpoints responding correctly
- ✅ No error messages in logs
- ✅ Database connectivity confirmed
- ✅ Downstream services can connect

## Deployment Strategies

### Rolling Deployment (Recommended)

Gradually replace instances while maintaining availability:

1. Update one instance at a time
2. Health check passes before moving to next instance
3. Monitor error rates and response times
4. Rollback if issues detected

**Procedure:**
```bash
# Current instance
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player down

# Update compose file with new version
# (or pull new image)

docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player up --build -d
```

### Blue-Green Deployment (Future Enhancement)

Maintain two production environments (Blue = Current, Green = New):

1. Deploy new version to Green
2. Verify all checks pass on Green
3. Switch traffic from Blue to Green
4. Keep Blue running for immediate rollback

### Canary Deployment (Future Enhancement)

Route small percentage of traffic to new version:

1. Deploy new version alongside current
2. Route 5% of traffic to new version
3. Monitor error rates and performance
4. Gradually increase traffic if healthy
5. Complete migration or rollback based on metrics

## Rollback Procedures

### Immediate Rollback

If deployment fails or issues are detected:

```bash
# 1. Stop current deployment
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player down

# 2. Update compose file to previous version
# Edit .docker-compose/docker-compose-runtime.yaml
# Change version in image tag

# 3. Start previous version
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player up --build -d

# 4. Verify health
sleep 10
curl http://localhost:8080/api/health

# 5. Notify stakeholders
# Log incident and trigger post-mortem if needed
```

### Database Rollback

If database schema changes cause issues:

1. **For EF Core Migrations:**
   ```bash
   # Previous migration is available in Git history
   # Revert code to previous tag
   git checkout v1.2.3
   
   # EF Core will apply database migrations on startup
   # (may need to handle rollback manually depending on migration)
   ```

2. **For Manual Migrations:**
   - Refer to `DEVOPS_RUNBOOK.md` for rollback scripts
   - Database backups should be maintained
   - Coordinate with database team for restore

## Deployment Metrics

Track these metrics for each deployment:

| Metric | Target | How to Measure |
|--------|--------|----------------|
| Deployment Duration | < 5 minutes | From start to health check passing |
| Time to Detect Issues | < 2 minutes | From deployment to alert/detection |
| Time to Rollback | < 5 minutes | From decision to fully reverted |
| Success Rate | > 95% | Successful deployments / total attempts |
| Zero-Downtime | 100% | Health checks pass throughout |

## Troubleshooting

### Service Fails to Start

```bash
# Check logs for errors
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api

# Common issues:
# - Database not accessible
# - Environment variables missing or incorrect
# - Port 8080 already in use
# - Insufficient disk space
```

### Database Connectivity Issues

```bash
# Verify database is running
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs database

# Test connection from api container
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec api \
  pg_isready -h database -p 5432

# Check environment variables
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player ps
```

### Health Check Failing

```bash
# View health check logs
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api | grep -i health

# Manual health check
curl -v http://localhost:8080/api/health

# Common causes:
# - Database not ready
# - Position Service unreachable
# - API not fully initialized
```

## Related Documentation

- **[README.md](./README.md)** - Project overview and quick start
- **[CONTRIBUTING.md](./CONTRIBUTING.md)** - Developer setup and contribution workflow
- **[DEVOPS_RUNBOOK.md](./DEVOPS_RUNBOOK.md)** - Quick reference for operations
- **[SLO_SLA.md](./SLO_SLA.md)** - Service level objectives and agreements
- **[CHANGELOG.md](./CHANGELOG.md)** - Version history and release notes
- **[DevOps Expert Agent](/.github/agents/DevOpsExpert.agent.md)** - DevOps principles and practices

## Support and Escalation

For deployment issues:

1. **Check DEVOPS_RUNBOOK.md** for common troubleshooting steps
2. **Review recent GitHub Actions logs** for build/test failures
3. **Check application logs** for runtime errors
4. **Review SonarCloud** for code quality issues
5. **Contact DevOps team** for infrastructure issues

---

**Last Updated**: 2024-11-18  
**Version**: 1.0  
**Maintained By**: DevOps Team
