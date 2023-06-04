
# DOTS-Moving-Benchmarking

A Simple Learning Project on Unity DOTS to compare 
Main Thread (SystemBase) vs ISystem + Burst Compile + Job

## Details
Unity Version: 2022.3.0 DX11

Currently the project hasn't support running on build yet

## Project Preview
![](https://github.com/StinkySteak/DOTS-MovingDummy/Resource/ProjectPreview.gif)

## Benchmark

#### Main Thread (SystemBase)
CPU Latency: 0ms (0 FPS)
![](https://github.com/StinkySteak/DOTS-MovingDummy/Resource/ProjectPreview.gif)

#### Worker Thread (ISystem + Burst + Job)
CPU Latency: 0ms (0 FPS)
![](https://github.com/StinkySteak/DOTS-MovingDummy/Resource/ProjectPreview.gif)

## Project Code Structure

### Systems

`CharacterMovementSystem`: Process Character Movement
`RandomPathfindingSystem`: Handles Checking remaining destination distance & Set a new random position
`RandomMovingCharacterSpawnerSystem`: Only active once, Spawn the Character at startup & assign random destination
`CharacterPathfindingMovement`: Manage Character `Movement` velocity based on destination direction 

### Components
#### Singleton Components
`GlobalCharacterMovementSpeed`: Speed for all character

`GlobalRandom`: Global `Unity.Mathematics.Random`

`RandomMovingCharacterSpawningProperty`: Centralized data for character pathfinding config (only for spawning)

`RandomPathfindingProperty`: Centralized data for character pathfinding config (runtime)

#### Basic Components
`Movement`: Store Velocity
`PathfindingDestination`: Store Destination position