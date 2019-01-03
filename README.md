# FitnessTracker Server

This repository includes the server code for an open source weight loss app, whose official name is TBD. The web application client will be included in a separate repository.

## Motivation

There are no fitness tracking/weight loss apps on the market that are both (1) open source and (2) well-maintained. This project (once fully developed) will provide several benefits over alternative solutions.

1. All of the data is owned by the user, which means that companies will not sell your data for use in setting market prices.

2. No advertisements will be shown, including annoying "Please upgrade to the Premium version" messages.

3. Advanced analytics and visualization features will not be paywalled.

## Design

This repository includes the RESTful API (server-side code) for FitnessTracker. The programming language of choice is C# (.NET Core), which uses Entity Framework Core to interact with a SQL back-end. The project is documented with Swagger/OpenAPI.

## Roadmap

There are still many features to implement, each of which is designed around a particular use case. The following list shows the prioritized features.

- ✅ Track a user's weight over time
- ✅ Query for the foods eaten in a particular time range
- ❌ Script to populate the database with USDA food data
- ❌ Ability to add "goals" and progress metrics toward those goals
- ❌ Track workouts in a similar way to Jefit
- ❌ Testing and quality assurance
- ✅ Docker build and easy containerization
- ❌ Authentication and security
- ❌ Ability to choose which back-end SQL database to use
- ❌ Localization support
