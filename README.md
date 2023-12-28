# KnapsackProblemResolver

A .NET library supporting the solution of the knapsack problem using a genetic algorithm.

This is an extended version of the application I created for the "Artificial Intelligence" project [[en](docs/README.en.md)][[pl](docs/README.pl.md)] of my engineering studies.

My intention was to organize the application in such a way that it not only solves a complex optimization problem, but also demonstrates the best architectural practices in software design, consistent with [OOP](https://en.wikipedia.org/wiki/Object-oriented_programming) principles and the [DDD](https://en.wikipedia.org/wiki/Domain-driven_design) paradigm, in order to create a clean, easy-to-maintain solution.

## Objective

The primary goal of this project is to solve the Knapsack Problem, a classic problem in combinatorial optimization. The project uses genetic algorithms, a method inspired by natural selection, to find an optimal or near-optimal solution to this problem. This involves selecting items with given weights and values to maximize the total value without exceeding a specified weight limit.

## Structure and Architecture

The solution is structured into several projects, each with distinct responsibilities and functions:

1. **[KnapsackProblem.Core](src/KnapsackProblem.Core)**:
   - **Responsibility**: Contains the domain logic, models, entities, and value objects specific to the knapsack problem. It's the heart of the application.
   - **In DDD Context**: Represents the business core, defining business rules and behaviors. This is where entities, value objects, aggregates, and domain services are defined.
   - **In OOP Context**: Focuses on encapsulation, reusability, and modularization of code, applying OOP principles to model complex business concepts.

2. **[KnapsackProblem.Application](src/KnapsackProblem.Application)**:
   - **Responsibility**: The application layer coordinates activities and manages the business logic flow. It usually acts as the entry point for domain-defined operations.
   - **In DDD Context**: Connects various domain and infrastructure elements, executing the application's use cases.
   - **In OOP Context**: May include orchestrating classes, factories, strategies, and other design patterns that help manage application complexity.

3. **[KnapsackProblem.UnitTests](src/KnapsackProblem.UnitTests)**:
   - **Responsibility**: Contains unit tests for the project, ensuring the correctness of business logic and code.
   - **In DDD and OOP Context**: Maintains code quality by verifying the functionality of domain and application logic.

4. **[KnapsackProblem.Host.Console](src/KnapsackProblem.Host.Console)**:
   - **Responsibility**: Provides a console-based user interface for the application. It facilitates user interaction with the application in a console environment. It uses the [CommandLineParser](https://github.com/commandlineparser/commandline) library to support manipulating command line arguments and display a help screen with a high degree of customization and a simple way to report syntax errors to the end user.
   - **In DDD and OOP Context**: Acts as a thin presentation layer, primarily responsible for user interface, delegating business logic to lower layers.

5. **[KnapsackProblem.Host.GtkApp](src/KnapsackProblem.Host.GtkApp)**:
   - **Responsibility**: Offers a graphical user interface (GUI) for the application, using cross-platform [GtkSharp](https://github.com/GtkSharp/GtkSharp) library.
   - **In DDD and OOP Context**: Similar to the console project, it handles presentation and user interaction, leaving business logic to the application and domain logic layers.
