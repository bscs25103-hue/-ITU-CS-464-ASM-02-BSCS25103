# -ITU-CS-464-ASM-02-BSCS25103

 CS464 Assignment 02 · Muhammad Zakria Tahir · BSCS25103
 **Video:** [YouTube (unlisted) or Google Drive link: 30–90 s, all five levels]- 
 **Input:** legacy Input with Active Input Handling set to Both
 **Ground check:** Contach Normal
 **Camera:** SmoothDamp with look-ahead 
 **Juice:** Squash and Stretch Effect with EaseOutBack, triggered on landing

## Tuning
| Setting | Value | Why this number |
|---|---|---|
| Speed | [5m/s] | Standard Speed so movement looks natural |
| Jump height | [2m] |Calculated to clear the pit in level 5|
| Time to apex | [1.2s] | Because of jump force and gravity acting on rigid body it is the time taken|
| Fall multiplier | [2.5×] | At this number,proper simulation of force of gravity along with mass acting occurs |
| Coyote time | [0.15s] | For 5 meter jump with jump force and speed acting 1.5 is the accurate cyote time|
| Jump buffer | [0.15s] | Becuase of the camera angle sitting at the top and error time in consideration the jump buffer was set|
| Camera smoothing | [0.3s] | For smoothing effect of camera 0.3s was set |
| Look-ahead | [0.35s] | Because of Player speed, a headset of 0.35 was set |
## Four answers
## Levels
1. **The jump, in numbers.** [speed 5f, jump force 6f, launch speed 5ms, time to apex 1.2ms, distance covered is 5.5m almost ]
2. **Update and FixedUpdate.** [Updates run at every frame it handles input and keep tracks of timers and fixedUpdate runs at fixed times and handles world physics and camera movements , if we swap them input will miss and movement will vary with different framerates]
3. **Vector3.Dot.** [The Dot product is used for checking is grounded by checking normal, and if dot product is +ve surface is facing up, -ve means facing downwards and 0 means wall]
4. **The juice.** [EaseOutCurve, its duration is 0.2 seconds and 12 frames in frames at 60 fps, to create a responsive feedback]
| Level | What the controller must do there | What I changed for this jump |
|---|---|---|
| Level01 | Flat terrain movement, player should move and reaching goal| Simple Player Movement|
| Level02 | Movement across rooms with some covers, Player should move through it | Simple Player Movement|
| Level03 | Moving up the slide and jumping accross the platform and reaching goal| Simple Player Movement|
| Level04 | Moving through the narrow platform and jumping on the platform and reaching goal| Simple Player Movement|
| Level05 | Moving through the course jumping up from the pit and reaching the goal| Simple Player Movement|