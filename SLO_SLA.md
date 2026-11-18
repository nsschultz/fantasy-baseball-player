# Service Level Objectives & Agreements (SLO/SLA)

This document defines the service level objectives and agreements for the fantasy-baseball-player microservice.

## Overview

The fantasy-baseball-player service is a critical component that provides the single source of truth for player data across the fantasy baseball platform. This document outlines our commitment to reliability, performance, and quality.

**Service Owner**: Platform Engineering Team  
**On-Call Contact**: See DEVOPS_RUNBOOK.md  
**Last Updated**: 2024-11-18

## Service Level Objectives (SLOs)

Service Level Objectives are targets we commit to meet. These drive operational decisions and infrastructure investments.

### Availability SLO

**Target: 99.5% uptime**

- **Definition**: Percentage of requests that receive a successful response (HTTP 2xx/3xx)
- **Measurement**: Health check responses + successful API calls
- **Calculation**: (Successful requests) / (Total requests) × 100%
- **Error Budget**: 36 minutes of downtime per month
- **Monitoring**: Continuous health checks, log aggregation, alerts

**Acceptable Downtime by Period:**

| Period | Total Minutes | Acceptable Downtime | Exceeded If |
|--------|---------------|-------------------|------------|
| Month (30 days) | 43,200 | 36 minutes | > 36 min |
| Week (7 days) | 10,080 | 8.6 minutes | > 8.6 min |
| Day (24 hours) | 1,440 | 1.2 minutes | > 1.2 min |
| Hour | 60 | 18 seconds | > 18 sec |

### Response Time SLO

**Target: P95 response time < 200ms**

- **Definition**: 95th percentile of API response times (excluding health checks)
- **Measurement**: Application performance monitoring, response logs
- **Scope**: All GET endpoints (read-only operations typically faster)
- **Excludes**: Initial startup responses (< 10% of requests)
- **Monitoring**: Log aggregation, performance dashboards

**Response Time Targets by Operation:**

| Operation | Target P95 | Target P99 | Notes |
|-----------|-----------|-----------|-------|
| GET /api/v1/player (list) | < 200ms | < 500ms | Most common operation |
| GET /api/v1/player/{id} | < 100ms | < 300ms | Single record lookup |
| POST /api/v1/player (create) | < 300ms | < 800ms | Includes database write |
| PUT /api/v1/player/{id} (update) | < 300ms | < 800ms | Includes database write |
| DELETE /api/v1/player/{id} | < 300ms | < 800ms | Includes database write |
| GET /api/health | < 50ms | < 100ms | Health check must be fast |
| GET /api/swagger/index.html | < 500ms | < 1000ms | Documentation only |

### Code Quality SLO

**Target: ≥ 80% code coverage**

- **Definition**: Percentage of code lines executed by test suite
- **Measurement**: SonarCloud coverage reports
- **Enforcement**: Quality gate blocks merge if coverage drops
- **Trend**: Maintain or increase coverage with each release
- **Monitoring**: SonarCloud dashboard, GitHub quality gates

**Coverage Targets by Component:**

| Component | Target | Tool |
|-----------|--------|------|
| Controllers | ≥ 85% | Unit + Integration Tests |
| Services | ≥ 85% | Unit Tests |
| Repositories | ≥ 80% | Unit Tests |
| Utilities | ≥ 85% | Unit Tests |
| Overall | ≥ 80% | SonarCloud |

### Security SLO

**Target: Zero critical/high vulnerabilities in releases**

- **Definition**: No unpatched security vulnerabilities in production image
- **Measurement**: Trivy security scanning, dependency checks
- **Frequency**: Scan every build (PR + main branch)
- **Resolution**: Critical/high issues must be fixed before release
- **Monitoring**: GitHub security tab, Trivy scan results

**Vulnerability Response Times:**

| Severity | Discovery | Resolution | Release |
|----------|-----------|-----------|---------|
| Critical | Immediate alert | < 24 hours | ASAP |
| High | Daily digest | < 1 week | Next minor |
| Medium | Weekly review | < 2 weeks | Next minor |
| Low | Monthly review | < 1 month | Next release |

## Service Level Agreements (SLAs)

Service Level Agreements are contractual commitments to customers. SLAs typically use more conservative targets than SLOs.

### Availability SLA

**Commitment: 99.5% monthly uptime**

- **Target**: Minimum 99.5% availability for calendar month
- **Measurement**: End-to-end monitoring including upstream dependencies
- **Exclusions**: 
  - Planned maintenance (communicated 48 hours in advance)
  - Upstream service outages (Position Service, Database)
  - User configuration errors
  - Force majeure events
- **Credits**: Service credits issued per penetration:
  - 99.0-99.5%: 10% credit
  - 95.0-99.0%: 25% credit
  - < 95.0%: 50% credit

### Performance SLA

**Commitment: P95 response time < 300ms for 99% of requests**

- **Target**: 99% of requests respond within 300ms
- **Exceptions**:
  - Requests > 100MB payload
  - Initial service startup (first 60 seconds)
  - Maintenance windows
- **Measurement**: Application performance monitoring logs

## Error Budget

The error budget is the amount of downtime or failures we can tolerate while still meeting our SLOs.

### Monthly Error Budget Calculation

**Total Minutes per Month**: 30 days × 24 hours × 60 minutes = 43,200 minutes

**For 99.5% SLO:**
- Acceptable downtime: 43,200 × 0.5% = 216 minutes (3.6 hours)
- **Remaining budget if no incidents**: 216 minutes
- **Status**: 🟢 Healthy if incidents < 216 minutes
- **Status**: 🟡 At Risk if incidents > 108 minutes (50% consumed)
- **Status**: 🔴 Exhausted if incidents > 216 minutes

### Error Budget Usage Strategy

| Budget Remaining | Action |
|-----------------|--------|
| > 75% (> 162 min) | Proceed with normal releases and experiments |
| 50-75% (108-162 min) | Cautious with deployment windows, enhanced testing |
| 25-50% (54-108 min) | Conservative: only critical fixes, avoid major changes |
| < 25% (< 54 min) | Freeze: halt releases, focus on reliability improvements |

## Key Performance Indicators (KPIs)

Metrics used to track service health and operational effectiveness:

### Availability Metrics

| Metric | Target | Actual | Trend |
|--------|--------|--------|-------|
| Monthly Uptime | 99.5% | TBD | Monitor |
| Health Check Pass Rate | 100% | TBD | Monitor |
| Mean Time Between Failures (MTBF) | > 720 hours | TBD | Improve |
| Mean Time To Recovery (MTTR) | < 15 minutes | TBD | Improve |

### Performance Metrics

| Metric | Target | Actual | Trend |
|--------|--------|--------|-------|
| P50 Response Time | < 50ms | TBD | Monitor |
| P95 Response Time | < 200ms | TBD | Monitor |
| P99 Response Time | < 500ms | TBD | Monitor |
| Max Response Time | < 2000ms | TBD | Monitor |
| Requests/sec @ SLA | > 1000 | TBD | Monitor |

### Quality Metrics

| Metric | Target | Actual | Trend |
|--------|--------|--------|-------|
| Code Coverage | ≥ 80% | TBD | Improve |
| Test Pass Rate | 100% | TBD | Maintain |
| Build Success Rate | > 99% | TBD | Maintain |
| Security Issues | 0 Critical | TBD | Maintain |
| Code Quality Grade | A/B | TBD | Improve |

### Reliability Metrics (DORA)

| Metric | Target | Current | Goal |
|--------|--------|---------|------|
| Deployment Frequency | Daily | TBD | Improve |
| Lead Time for Changes | < 1 day | TBD | Reduce |
| Mean Time to Recovery | < 15 min | TBD | Reduce |
| Change Failure Rate | < 15% | TBD | Reduce |

## Monitoring and Alerting

### Monitoring Dashboards

1. **GitHub Actions Dashboard**
   - Build/test pipeline status
   - Workflow success rates
   - Deployment frequency
   - URL: https://github.com/nsschultz/fantasy-baseball-player/actions

2. **SonarCloud Dashboard**
   - Code quality metrics
   - Code coverage trends
   - Security findings
   - URL: https://sonarcloud.io/project/overview?id=nsschultz_fantasy-baseball-player

3. **Docker Hub Statistics**
   - Image pull statistics
   - Platform distribution
   - Version tracking
   - URL: https://hub.docker.com/r/nschultz/fantasy-baseball-player

### Alert Configuration

| Alert | Trigger | Severity | Action |
|-------|---------|----------|--------|
| Availability Drop | < 99.5% over 5 min | Critical | Page on-call, investigate immediately |
| Response Time High | P95 > 500ms for 5 min | High | Monitor closely, check dependencies |
| Coverage Drop | < 80% at merge | High | Block merge, require test fixes |
| Security Scan Failed | Critical vulnerability | Critical | Halt release, patch immediately |
| Build Failure | Test suite fails | High | Notify team, fix immediately |
| Deployment Failed | Docker push fails | High | Investigate, retry or rollback |

## Maintenance and Planned Downtime

### Planned Maintenance Windows

- **Window**: Sunday 2:00 AM - 4:00 AM UTC (weekly)
- **Frequency**: As needed for infrastructure updates
- **Communication**: Announced 48 hours in advance
- **Impact**: Service unavailable during window
- **Alternative**: Requests routed to backup (when available)

**Maintenance Activities:**
- Database migrations
- Infrastructure updates
- Security patching
- Dependency upgrades
- Performance optimization

### Maintenance Notifications

```
Subject: Planned Maintenance - fantasy-baseball-player

Scheduled Start: [DATE] [TIME] UTC
Estimated Duration: 1-2 hours
Impact: Service unavailable

This maintenance is required to [reason].
We apologize for any inconvenience.

Questions? Contact: platform-engineering@company.com
```

## Escalation Procedures

### Severity Levels

| Level | Description | Response | Resolution |
|-------|-------------|----------|-----------|
| Critical | Service down, customers blocked | Immediate | < 1 hour |
| High | Service degraded, some impact | 15 minutes | < 4 hours |
| Medium | Reduced functionality, workaround available | 1 hour | < 1 day |
| Low | Minor issue, no customer impact | 4 hours | < 1 week |

### On-Call Escalation

1. **Alert Triggered** → Automated notification to on-call engineer
2. **Initial Response** (5 min) → Acknowledge alert, begin investigation
3. **Diagnosis** (15 min) → Identify root cause
4. **Mitigation** (30 min) → Apply immediate fix or workaround
5. **Resolution** (target based on severity) → Full fix and verification
6. **Post-Mortem** (within 24 hours) → Document lessons learned

**Escalation Chain:**
- Primary: On-call engineer (page immediately)
- Secondary: Team lead (page if no response in 15 min)
- Tertiary: Engineering manager (page if no resolution in 1 hour for critical)

## Review and Improvement

### Monthly Review Checklist

- [ ] Review SLO/SLA compliance for the month
- [ ] Analyze incidents and root causes
- [ ] Update error budget and consumption
- [ ] Review DORA metrics and trends
- [ ] Identify improvement opportunities
- [ ] Plan infrastructure or process improvements
- [ ] Update this document if needed

### Quarterly Business Review

- [ ] Present metrics to stakeholders
- [ ] Review SLO/SLA targets (adjust if needed)
- [ ] Plan major initiatives based on data
- [ ] Share incident learnings
- [ ] Celebrate improvements and achievements

### Annual Planning

- [ ] Review annual trends and patterns
- [ ] Set SLO/SLA targets for next year
- [ ] Plan major architecture or infrastructure changes
- [ ] Allocate resources for reliability improvements
- [ ] Update this document with lessons learned

## Related Documentation

- **[DEPLOYMENT.md](./DEPLOYMENT.md)** - Deployment procedures and strategies
- **[DEVOPS_RUNBOOK.md](./DEVOPS_RUNBOOK.md)** - Quick reference for operations
- **[CHANGELOG.md](./CHANGELOG.md)** - Release history and version information
- **[README.md](./README.md)** - Project overview
- **[DevOps Expert Agent](/.github/agents/DevOpsExpert.agent.md)** - DevOps principles and practices

## Support and Contact

**For SLO/SLA Questions:**
- Engineering Lead: See team contacts
- On-Call: Page from monitoring system
- Email: platform-engineering@company.com
- Slack: #fantasy-baseball-player

---

**Last Updated**: 2024-11-18  
**Version**: 1.0  
**Maintained By**: Platform Engineering Team

**Next Review**: 2024-12-18
