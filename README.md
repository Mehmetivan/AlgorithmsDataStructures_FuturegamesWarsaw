# Algorithms & Data Structures – Unity

A Unity-based project focused on implementing and exploring fundamental algorithms and data structures through practical programming tasks.

The project uses a modular, ScriptableObject-based task architecture to execute operations on employee data, demonstrating concepts such as task scheduling, heaps, sorting, searching, and data processing.

## About the Project

The main objective is to apply algorithms and data structures to practical problems while maintaining a reusable and extensible architecture.

Rather than implementing everything inside a single manager class, the project separates individual operations into independent tasks. These tasks can receive input, process data, and pass their results to subsequent tasks.

## Features & Implementations

### 1. Task-Based Architecture

A modular task system built using Unity ScriptableObjects.

- Base `Task` class for defining executable operations.
- Generic `Task<TOutput>` for tasks with typed outputs.
- Independent tasks that can receive and return data.
- Task execution managed through a central scheduler.

### 2. Min Heap & Task Scheduler

A custom Min Heap implementation used to organise and execute scheduled tasks.

- Tasks are organised according to priority.
- The task with the lowest priority value is executed first.
- Efficient insertion and extraction operations.
- `TaskScheduler` manages task execution.

### 3. Employee Data Processing

The project uses employee records loaded from JSON files.

Each employee contains:

- Name
- Employee ID
- Engine room clearance status
- Last entrance time into the engine room
- Last exit time from the engine room

The JSON data is parsed into an `Employee[]` array, which can then be passed between different tasks.

### 4. Sorting Algorithms

Implementation of sorting algorithms to organise employee records.

- **Quick Sort:** Used to sort employee records based on their engine room entrance timestamps.
- Supports ascending and descending ordering.

### 5. Searching Algorithms

Implementation of searching algorithms to retrieve employee records based on specific criteria.

- **Binary Search:** Searches sorted employee records using their engine room entrance timestamps.
- Uses lower and upper index boundaries to narrow down the search range.
- Designed to work with sorted employee data.

## Architecture & Data Flow

The project follows a task-based execution pipeline:

1. `ReadEmployeesTask` reads and parses employee data from a JSON file.
2. The resulting `Employee[]` array is passed to subsequent tasks.
3. `SortTask` organises employee records using Quick Sort.
4. `SearchTask` searches through sorted employee records using Binary Search.
5. `TaskScheduler` manages the execution order of scheduled tasks using a Min Heap.

## Technologies

- **Engine:** Unity
- **Language:** C#
- **Data Format:** JSON
- **JSON Library:** LitJson
- **Architecture:** ScriptableObjects
- **Version Control:** Git / GitHub

## Project Structure

The project is organised around reusable tasks and data structures.

```text
Assets/
├── Scripts/
│   ├── Environment/
│   │   └── Tasks/
│   │       ├── Task.cs
│   │       ├── ReadEmployeesTask.cs
│   │       ├── SortTask.cs
│   │       └── SearchTask.cs
│   ├── DataStructures/
│   │   └── MinHeap.cs
│   ├── Scheduling/
│   │   └── TaskScheduler.cs
│   └── Models/
│       └── Employee.cs
└── StreamingAssets/
    └── employees.json
```

*Note: The structure above is illustrative and can be adjusted to match the actual Unity project folders.*

## Project Status

**In Development**

The project is being expanded with additional algorithms, data structures, and task implementations.

## Learning Objectives

- Understand and implement fundamental algorithms and data structures.
- Apply sorting and searching algorithms to real-world-style datasets.
- Understand the functionality and efficiency of Min Heaps.
- Practise generic programming and object-oriented design in C#.
- Build modular systems using Unity ScriptableObjects.
- Understand data flow and task scheduling.

---

Developed as part of my game programming studies at Futuregames Warsaw.
