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
1. **The jump, in numbers.** [launch speed, jumpForce, time to apex, fall time, reach vs your widest gap]
2. **Update and FixedUpdate.** [what each one does in your script, and what breaks if you swap them]
3. **Vector3.Dot.** [the line, where it is or would go, and what its sign means there]
4. **The juice.** [its curve, its duration in seconds and in frames at 60 fps, and why]
| Level | What the controller must do there | What I changed for this jump |
|---|---|---|
| Level01 | | |
| Level02 | | |
| Level03 | | |
| Level04 | | |
| Level05 | | |