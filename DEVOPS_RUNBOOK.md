# DevOps Runbook

Quick reference guide for operating the fantasy-baseball-player microservice.

**Service**: fantasy-baseball-player (Player Data Service)  
**Repository**: https://github.com/nsschultz/fantasy-baseball-player  
**Docker Image**: nschultz/fantasy-baseball-player  
**Health Check**: GET /api/health  
**Port**: 8080

---

## Table of Contents

1. [Quick Start](#quick-start)
2. [Daily Operations](#daily-operations)
3. [Troubleshooting](#troubleshooting)
4. [Emergency Procedures](#emergency-procedures)
5. [Performance Optimization](#performance-optimization)
6. [Monitoring](#monitoring)
7. [Contact Information](#contact-information)

---

## Quick Start

### Starting the Service (Runtime)

```bash
# Navigate to project directory
cd /workspaces/fantasy-baseball-player

# Start all containers
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player up --build -d

# Verify startup (wait 15 seconds)
sleep 15
curl http://localhost:8080/api/health
```

**Expected Output:**
```json
{"status":"Healthy","timestamp":"2024-11-18T12:00:00Z"}
```

### Stopping the Service

```bash
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player down
```

### Starting Development Environment

```bash
# Start dev containers with live code reload
docker compose -f .docker-compose/docker-compose-dev.yaml \
  -p fantasy-baseball-player up --build -d

# Access pgAdmin for database management
# URL: http://localhost:9000
# Email: admin@admin.com
# Password: SuperSecret
```

### Stopping Development Environment

```bash
docker compose -f .docker-compose/docker-compose-dev.yaml \
  -p fantasy-baseball-player down
```

---

## Daily Operations

### Morning Health Check

```bash
#!/bin/bash
echo "=== Fantasy Baseball Player Service - Health Check ==="

# 1. Container status
echo -e "\n1. Container Status:"
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player ps

# 2. API health
echo -e "\n2. API Health:"
curl -s http://localhost:8080/api/health | jq .

# 3. Recent errors
echo -e "\n3. Recent Errors (last 50 lines):"
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs --tail=50 api | grep -i error || echo "No errors found"

# 4. Database connectivity
echo -e "\n4. Database Status:"
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database pg_isready

echo -e "\n=== Health Check Complete ==="
```

### Viewing Logs

```bash
# Real-time logs (follow mode)
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs -f api

# Last 100 lines
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs --tail=100 api

# Since 10 minutes ago
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs --since 10m api

# Grep for errors
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api 2>&1 | grep -i "error\|exception\|warn"
```

### Testing API Endpoints

```bash
# Health check
curl -v http://localhost:8080/api/health

# List all players
curl http://localhost:8080/api/v3/player

# Get single player
curl http://localhost:8080/api/v3/player/{id}

# View Swagger documentation
# Access: http://localhost:8080/api/swagger/index.html
```

### Database Management

```bash
# Connect to PostgreSQL CLI
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres -d player_database

# Common SQL commands:
# \dt                    - List tables
# \d+ player             - Describe player table
# SELECT COUNT(*) FROM player;  - Count players
# \q                     - Exit psql
```

### Checking Resource Usage

```bash
# CPU and Memory usage
docker stats fantasy-baseball-player_api_1

# Disk usage
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database du -sh /var/lib/postgresql/data

# Container size
docker images nschultz/fantasy-baseball-player
```

---

## Troubleshooting

### Service Won't Start

**Symptom:** Container exits immediately or won't start

**Diagnosis:**
```bash
# Check exit code
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api

# Look for:
# - Database connection errors
# - Port 8080 already in use
# - Missing environment variables
# - Insufficient disk space
```

**Solutions:**

1. **Port 8080 already in use:**
   ```bash
   lsof -i :8080
   # Kill process or use different port
   ```

2. **Database not ready:**
   ```bash
   # Restart database
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player restart database
   
   # Wait for health check
   sleep 10
   
   # Restart API
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player restart api
   ```

3. **Environment variables missing:**
   ```bash
   # Verify .docker-compose/docker-compose-runtime.yaml has all required:
   # - PLAYER_DATABASE
   # - PLAYER_DATABASE_HOST
   # - PLAYER_DATABASE_PASSWORD
   # - PLAYER_DATABASE_USER
   # - POSITION_SERVICE_HOST
   # - POSITION_SERVICE_VERSION
   ```

### Health Check Failing

**Symptom:** Health endpoint returns non-200 status

**Diagnosis:**
```bash
# Check health endpoint
curl -v http://localhost:8080/api/health

# Common response codes:
# 200 - Healthy
# 503 - Service unavailable (database issue)
```

**Solutions:**

1. **Database connectivity issue:**
   ```bash
   # Test database connectivity
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player exec api pg_isready -h database -p 5432
   
   # If fails, restart database:
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player restart database
   ```

2. **Connection pool exhausted:**
   ```bash
   # Restart API to reset connections
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player restart api
   ```

3. **Position Service unreachable:**
   ```bash
   # Verify Position Service is running
   curl http://[POSITION_SERVICE_HOST]:5555/api/health
   
   # Update environment variable if needed
   ```

### High Response Times

**Symptom:** API responses taking > 500ms

**Diagnosis:**
```bash
# Check container resource usage
docker stats fantasy-baseball-player_api_1

# Check database query performance
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres -c \
  "SELECT * FROM pg_stat_statements ORDER BY total_time DESC LIMIT 10;"

# Check application logs for slow queries
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api | grep -i "slow\|duration"
```

**Solutions:**

1. **Resource constraints:**
   - Increase container resource limits
   - Check if other services are consuming resources
   - Consider vertical scaling

2. **Database performance:**
   - Check index usage: `EXPLAIN ANALYZE SELECT ...`
   - Look for missing indexes
   - Optimize slow queries
   - See performance-optimization section

3. **Network latency:**
   - Check network connectivity
   - Verify Position Service is responsive
   - Check database host accessibility

### Database Connection Issues

**Symptom:** "Cannot open database connection" errors

**Diagnosis:**
```bash
# Check if database container is running
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player ps database

# Check database logs
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs database

# Test connection from API
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec api \
  pg_isready -h database -U postgres
```

**Solutions:**

1. **Database container crashed:**
   ```bash
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player restart database
   ```

2. **Corrupted database:**
   ```bash
   # Backup data
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player exec database pg_dump -U postgres player_database > backup.sql
   
   # Remove volume and restart
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player down -v
   
   docker compose -f .docker-compose/docker-compose-runtime.yaml \
     -p fantasy-baseball-player up -d
   ```

3. **Network connectivity:**
   ```bash
   # Verify network
   docker network ls
   
   # Inspect network
   docker network inspect fantasy-baseball-player_default
   ```

### API Returning Errors

**Symptom:** API endpoints return 500 or 400 errors

**Check application logs:**
```bash
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api | tail -100

# Look for specific error messages and stack traces
```

**Common errors:**

| Error | Cause | Solution |
|-------|-------|----------|
| 500 Internal Server Error | Unhandled exception | Check logs, may need code fix |
| 400 Bad Request | Invalid input | Verify request format |
| 404 Not Found | Endpoint doesn't exist | Check endpoint path |
| 503 Service Unavailable | Database down | Restart database |

---

## Emergency Procedures

### Complete Service Restart

If service is in unknown state:

```bash
# 1. Stop all containers
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player down

# 2. Remove volumes (WARNING: destructive - backup first if needed)
# docker volume rm fantasy-baseball-player_data_volume

# 3. Start fresh
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player up --build -d

# 4. Wait for startup and verify
sleep 30
curl http://localhost:8080/api/health
```

### Rollback to Previous Version

If new deployment causes issues:

```bash
# 1. Check current version
docker images nschultz/fantasy-baseball-player

# 2. Update docker-compose file to use previous version
# Edit .docker-compose/docker-compose-runtime.yaml
# Change image tag in api service

# 3. Restart with previous version
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player up -d

# 4. Verify health
sleep 15
curl http://localhost:8080/api/health
```

### Database Emergency Recovery

If database is corrupted:

```bash
# 1. Stop service
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player stop api

# 2. Restore from backup (if available)
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres player_database < backup.sql

# 3. Restart service
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player start api

# 4. Verify
curl http://localhost:8080/api/health
```

### Emergency Contacts

**On-Call Engineer**: [Phone number from team contacts]  
**Engineering Lead**: [Name and contact]  
**Platform Team Slack**: #fantasy-baseball-player  
**Email**: platform-engineering@company.com

---

## Performance Optimization

### Database Query Optimization

```bash
# 1. Enable query logging
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres -c \
  "ALTER SYSTEM SET log_min_duration_statement = 1000;" # Log queries > 1 second

# 2. Restart database
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player restart database

# 3. View slow query log
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database tail -f /var/log/postgresql/postgresql.log
```

### Index Management

```bash
# Check index usage
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres player_database -c \
  "SELECT * FROM pg_stat_user_indexes;"

# Create missing index (example)
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres player_database -c \
  "CREATE INDEX idx_player_name ON player(name);"
```

### Connection Pool Tuning

Connection pooling is handled by Entity Framework Core. Adjust in Program.cs if needed.

```csharp
// Connection string configuration
optionsBuilder.UseNpgsql(
  "Server=database;Database=player_database;User Id=postgres;Password=postgres;",
  npgsqlOptions =>
  {
    npgsqlOptions.CommandTimeout(30);
  });
```

### Memory and CPU Limits

Adjust container limits in docker-compose file:

```yaml
services:
  api:
    deploy:
      resources:
        limits:
          cpus: '1'
          memory: 512M
        reservations:
          cpus: '0.5'
          memory: 256M
```

---

## Monitoring

### Key Metrics to Monitor

```bash
# 1. Health status (should be 200)
curl -w "\nStatus: %{http_code}\n" http://localhost:8080/api/health

# 2. Response times (track P95)
# Check application logs and monitoring dashboards

# 3. Error rate (should be near 0%)
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player logs api 2>&1 | grep -c "error"

# 4. Database size (should be stable)
docker compose -f .docker-compose/docker-compose-runtime.yaml \
  -p fantasy-baseball-player exec database psql -U postgres player_database -c \
  "SELECT pg_size_pretty(pg_database_size('player_database'));"
```

### Monitoring Dashboards

- **SonarCloud**: https://sonarcloud.io/project/overview?id=nsschultz_fantasy-baseball-player
- **GitHub Actions**: https://github.com/nsschultz/fantasy-baseball-player/actions
- **Docker Hub**: https://hub.docker.com/r/nschultz/fantasy-baseball-player

### Alert Thresholds

| Alert | Threshold | Action |
|-------|-----------|--------|
| Health check failing | Consecutive 3 failures | Investigate immediately |
| Response time high | P95 > 500ms | Check database/resources |
| Error rate | > 1% | Review logs, escalate if needed |
| Database size | > 90% capacity | Archive or optimize data |
| CPU usage | > 80% | Check for slow queries or scale |
| Memory usage | > 85% | Restart or increase limits |

---

## Contact Information

**On-Call Rotation**: [Link to calendar/rotation]  
**Engineering Lead**: [Name] - [Email] - [Phone]  
**Platform Team**: #fantasy-baseball-player on Slack  
**Email Support**: platform-engineering@company.com  
**GitHub Issues**: https://github.com/nsschultz/fantasy-baseball-player/issues

---

## Related Documentation

- **[DEPLOYMENT.md](./DEPLOYMENT.md)** - Full deployment procedures
- **[README.md](./README.md)** - Project overview
- **[CONTRIBUTING.md](./CONTRIBUTING.md)** - Developer setup and contribution workflow
- **[SLO_SLA.md](./SLO_SLA.md)** - Service level definitions
- **[CHANGELOG.md](./CHANGELOG.md)** - Release history
- **[DevOps Expert Agent](/.github/agents/DevOpsExpert.agent.md)** - DevOps principles

---

**Last Updated**: 2024-11-18  
**Version**: 1.0  
**Maintained By**: Platform Engineering Team

**Next Review**: 2024-12-18
