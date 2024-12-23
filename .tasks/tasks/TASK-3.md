---
id: TASK-3
title: implement ball out of play
created: 2024-12-23 07:07:09
priority: Medium
category: Feature
owner: None
board: Done
---

## Description
Implement in the ball a component that is responsible to check if the ball went out of bounds.
Basically when the ball exits the play area, the ball should be destroyed.
Maybe it would be reasonable to create a bounding box around the play area, and check in the ball when it triggers the OnTriggerExit from 
the bounding box.
When a ball is destroyed, it should invoke an event that will be listened by the balls pool.

## Notes


## History
2024-12-23 07:07:09 - Created

2024-12-23 07:18:46 - Moved to In Progress

2024-12-23 07:26:14 - Moved to Done
