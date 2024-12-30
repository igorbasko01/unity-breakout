---
id: TASK-4
title: make the ball bounce direction from paddle relative to center
created: 2024-12-23 07:15:14
priority: Medium
category: Feature
owner: None
board: In Progress
---

## Description
When the ball hits the paddle, the ball should bounce in a direction relative to the center of the paddle.
The direction should be calculated based on the collision point and the center of the paddle.

2024-12-30 - I have created two script components for bounce. One for walls and bricks that bounce the ball to the opposite direction.
The other script component is for the paddle that bounces the ball to the opposite direction, but relative to the center of the object (paddle).

The script components are called "BounceDirectionChanger" and "RelativeBounceDirectionChanger".

## Notes


## History
2024-12-23 07:15:14 - Created

2024-12-28 09:14:09 - Moved to In Progress
