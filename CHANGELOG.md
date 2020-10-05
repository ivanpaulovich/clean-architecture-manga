# Changelog

All notable changes to this [project](README.md) will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [3.7.0] - 2020-10-05

### Changed

- Added ReactJs front end.

## [3.6.0] - 2020-09-26

### Changed

- Fix transactions query.

## [3.5.0] - 2020-09-23

### Changed

- Feature Management changed.

## [3.4.0] - 2020-09-22

### Changed

- Input validation moved to composition of use cases.

### Added

- Scrutor library.

## [3.3.1] - 2020-09-20

### Added

- Accounts API Seed.

### Fixed

- docker-compose on Windows and Mac.

## [3.3.0] - 2020-09-13

### Added

- Identity Server 4.
- NGINX

## [3.2.0] - 2020-08-04

### Added

- Health Checks in Web Api.

## [3.1.0] - 2020-07-27

### Added

- Update Customer Use Case.
- End to End tests.
- Notification service that aggregates error messages.
- GitHub Actions.
- Null Object pattern.

### Changed

- Register Account Use Case split in Signup, On-board and Open Account use cases.
- Domain split in Accounts, Customers and Security Bounded Contexts.
- Common project with strong typed IDs.
- Controllers are now built-in Presenters.

### Removed

- FluentMediator.
- Exception thrown from Value Objects.
- Azure Pipelines.

## [3.0.12] - 2020-07-04

### Added

- API Conventions.

### Changed

- Test cases as it starts with a preset Customer and Account.

### Fixed

- Close account calls *Account Cannot be Closed* in case of existing funds.

## [3.0.11] - 2020-07-02

### Changed

- Refactoring.
- Startup instructions on Readme.md.

## [3.0.10] - 2020-07-01

### Added

- Exchange Service.

## [3.0.9] - 2020-06-25

### Changed

- Variable names changed to conform with use cases.

## [3.0.8] - 2020-06-23

### Changed

- Value Objects removed from Input constructors.

## [3.0.7] - 2020-06-23

### Changed

- Test and Presenters clean up.

## [3.0.6] - 2020-06-19

### Changed

- Removed 1591, SA1600, SA1633, SA1602, SA1309, SA1101, SA1124, SA1625 and CA1822 Warnings.

## [3.0.5] - 2020-06-18

### Changed

- Nuget packages upgrade.
- Changed naming to be consistent.

## [3.0.4] - 2020-06-15

### Changed

- Nuget packages upgrades.
- `TransferTransferUseCase` renamed to `TransferUseCase`

## [3.0.3] - 2020-05-24

### Fixed

- [#181](https://github.com/ivanpaulovich/clean-architecture-manga/issues/181) TypeScript Exception.

### Changed

- NPM packages updated.

## [3.0.2] - 2020-05-23

### Security

- .NET Core SDK version to 3.1.300.
- Azure pipeline changed to use .NET Core 3.1.300.

### Changed

- VSCode and Rider environment variables.

### Removed

- Debits and Credits transactions from List Accounts Response.
- Context.SaveChanges from CustomerRepository class. Thanks [@aschle](https://github.com/raschle)!

### Added

- .prettierignore file do ignore markdown.

## [3.0.1] - 2020-05-01

### Changed

- Nullable references fixed.
- Unit Tests naming.

### Added

- Directory.Build.Props to manage assembly versioning.

### Changed

- CI pipeline to include code coverage report.

### Fixed

- Naming.

### Added

- ChangeLog.md, nuget.config.
