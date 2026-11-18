# CHANGELOG

All notable changes to the fantasy-baseball-player project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- TODO: Document unreleased changes

### Changed
- TODO: Document behavior changes

### Fixed
- TODO: Document bug fixes

### Deprecated
- TODO: Document deprecated features

### Removed
- TODO: Document removed features

### Security
- TODO: Document security improvements

## [3.3.0] - 2024-11-18

### Added
- Comprehensive DevOps documentation (DEPLOYMENT.md, DEVOPS_RUNBOOK.md, SLO_SLA.md)
- GitHub Actions PR validation workflow for automated testing and quality checks
- Docker image "latest" tag on release for easy reference
- Container health check in Dockerfile for orchestration compatibility
- .env.example template for environment configuration
- Multi-platform Docker builds (amd64, arm64)

### Changed
- Updated CI/CD pipeline for improved reliability
- Enhanced logging and monitoring capabilities

### Fixed
- Improved container health check configuration
- Better error handling in API endpoints

### Security
- Enhanced security scanning with Trivy
- Dependency vulnerability tracking via SonarCloud

## [3.2.0] - 2024-11-01

### Added
- Integration with SonarCloud for code quality analysis
- Comprehensive test coverage (25+ tests)
- CSV export functionality for player data
- Projection data merge endpoints

### Fixed
- Database connection handling
- API response formatting

## [3.1.0] - 2024-10-15

### Added
- Position Service health check integration
- Swagger/OpenAPI documentation
- Comprehensive integration tests

### Changed
- Updated to .NET 10 SDK
- Improved database query performance

## [3.0.0] - 2024-09-20

### Added
- Complete CRUD operations for player data
- RESTful API endpoints
- PostgreSQL database integration
- Docker containerization
- Multi-environment support (dev, CI, runtime)

### Changed
- **BREAKING**: API endpoint structure updated from v0 to v1
- **BREAKING**: Database schema redesigned for performance

### Migration Notes
- Database migrations run automatically on first startup
- API consumers must update endpoints to use `/api/v1/player`

## [2.0.0] - 2024-08-15

### Added
- Basic player data management
- Simple REST API

### Changed
- **BREAKING**: Complete rewrite of core functionality

## [1.0.0] - 2024-07-01

### Added
- Initial release
- Basic player data storage and retrieval

---

## Version Guidelines

### Semantic Versioning (MAJOR.MINOR.PATCH)

- **MAJOR** (1.0.0 → 2.0.0): Breaking API changes, incompatible database schema changes, major functionality overhauls
- **MINOR** (1.0.0 → 1.1.0): Backward-compatible new features, new API endpoints, new data fields
- **PATCH** (1.0.0 → 1.0.1): Bug fixes, performance improvements, documentation updates, security patches

### Release Categories

| Category | MAJOR | MINOR | PATCH | Example |
|----------|-------|-------|-------|---------|
| New Feature (backward-compatible) | ✗ | ✓ | ✗ | New optional field in response |
| New Feature (breaking) | ✓ | ✗ | ✗ | Rename endpoint from /v1 to /v2 |
| Bug Fix | ✗ | ✗ | ✓ | Fix data parsing error |
| Security Fix | ✗ | ✗ | ✓ | Patch dependency vulnerability |
| Performance Improvement | ✗ | ✗ | ✓ | Optimize database query |
| Breaking Change | ✓ | ✗ | ✗ | Remove deprecated endpoint |

## Release Process

1. **Update version.txt** with new version number
2. **Add CHANGELOG entry** with all changes in this release
3. **Create Git tag** with version: `git tag -a v3.3.0 -m "Release v3.3.0: Description"`
4. **Push tag** to trigger automated Docker build: `git push origin v3.3.0`
5. **Create GitHub Release** with CHANGELOG content and release notes
6. **Notify downstream services** of breaking changes or new features

## Migration Notes

### Upgrading from v3.2.0 to v3.3.0
- No breaking changes
- No database migrations required
- Fully backward compatible
- New features are optional

### Upgrading from v3.0.0 to v3.1.0+
- Position Service integration required
- Ensure Position Service is accessible at configured endpoint

### Upgrading to v3.0.0+
- Database schema migration required (runs automatically)
- API endpoints changed from /api/v0 to /api/v1
- Update downstream service configurations
- Review new CRUD endpoints documentation

## Support

- **Current Version**: See [version.txt](./version.txt)
- **Latest Release**: https://github.com/nsschultz/fantasy-baseball-player/releases/latest
- **Issues**: https://github.com/nsschultz/fantasy-baseball-player/issues
- **Code Quality**: https://sonarcloud.io/project/overview?id=nsschultz_fantasy-baseball-player

---

**How to Report Issues:**

When reporting a bug or proposing a feature:

1. Check existing issues first
2. Include current version number
3. Describe expected vs. actual behavior
4. Provide steps to reproduce
5. Include relevant logs or error messages

**How to Contribute:**

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Make changes with descriptive commits
4. Update CHANGELOG with your changes (Unreleased section)
5. Submit a pull request with detailed description
6. Ensure all checks pass (tests, quality gates, security scans)

---

**Last Updated**: 2024-11-18  
**Maintained By**: Development Team
