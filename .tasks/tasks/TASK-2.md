---
id: TASK-2
title: create balls pool to handle balls
created: 2024-12-23 07:05:41
priority: Medium
category: Feature
owner: None
board: Done
---

## Description
Create a pool of balls to handle multiple balls in the game.
It should allow balls to be reused, and spawned when needed.
Spawn logic should be implemented in the pool. 
The logic is simple, when a ball is destroyed it should be replaced by a new one.

2024-12-24 - On Second Thought, I think that for now I will just go with a new component (MonoBehaviour) that will handle the spawning of the ball.
and it will be attached to the ball itself. In the future when we will decide to allow multiple attempts, we will create the relevant implementations.

## Notes


## History
2024-12-23 07:05:41 - Created

2024-12-24 22:07:49 - Moved to In Progress

2024-12-24 22:41:37 - Moved to Done
