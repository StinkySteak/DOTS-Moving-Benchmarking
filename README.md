
# DOTS-Moving-Benchmarking

A Simple Learning Project on Unity DOTS to compare 
Main Thread (SystemBase) vs ISystem + Burst Compile + Job

## Details
Unity Version: 2022.3.0 DX11

URP Forward+

20,000 Entities

No Shadow

GPU Instancing

Currently the project hasn't support running on build yet

## Project Preview
![](https://github.com/StinkySteak/DOTS-MovingDummy/blob/master/Resource/ProjectPreview.gif)

## Benchmark
Windows 10 Build 19045

Dell G15 5515 x64, i7-11800H (8c/16t) @2.30 GHz 32GB Ram 3200Mhz Dual Channel, RTX 3050M, Nvidia 531.41

#### Main Thread (SystemBase)
CPU Latency: ~7ms (142 FPS)
![](https://github.com/StinkySteak/DOTS-MovingDummy/blob/master/Resource/MainThread.gif)

#### Worker Thread (ISystem + Burst + Job)
CPU Latency: ~1.35ms (740 FPS)
![](https://github.com/StinkySteak/DOTS-MovingDummy/blob/master/Resource/WorkerThread.gif)

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
