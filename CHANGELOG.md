# Changelog

All notable changes to this [project](README.md) will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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
