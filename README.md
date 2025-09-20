# Game Design Document

### Title: **Dart: Deadly Dodge**

---

## 1. Game Overview

**Genre:** Arcade / Maze / Obstacle Avoidance
**Platform(s):** PC, Mobile, Web
**Core Loop:**

* Navigate Dart through shifting maze-like arenas.
* Dodge moving hazards and traps.
* Survive as long as possible while racking up score multipliers.

**Elevator Pitch:**
*"Play as Dart, the quick-footed trickster, weaving through shifting mazes packed with relentless hazards. Blink, and you’re toast—hesitate, and you’re crushed. Speed and wit keep you alive in this fast-paced arcade dodge-fest!"*

---

## 2. Character

**Name:** Dart
**Tagline:** “Quick on his feet, quicker with his wit.”
**Bio:** Dart isn’t the strongest, but in a world of shifting mazes and relentless hazards, speed and timing are everything. With lightning reflexes and an instinct for slipping past danger, Dart survives where others collide.

**Visual Style:**

* Bright, glowing neon silhouette (contrasts against darker hazard arenas).
* Expressive animations: darting, dodging, quick turns.
* Feels like a living spark of energy within a digital maze.

---

## 3. Gameplay

### Core Mechanics

* **Movement:** Simple 4-direction (keyboard, controller, swipe/tilt on mobile).
* **Hazards:**

  * Moving blocks.
  * Rolling boulders.
  * Laser grids.
  * Spikes that rise/fall.
* **Maze Shifts:** Layout reconfigures every few seconds (dynamic challenge).
* **Scoring:** Survive longer → higher multiplier. Extra points for near misses.

### Win/Lose Conditions

* **Win:** Survive longest or complete maze section.
* **Lose:** Collide with hazard or run out of time (in timed modes).

### Progression

* Increasing speed and density of hazards.
* Procedurally generated maze shifts (noise-based randomization).
* Unlockable skins/power-ups for Dart.

---

## 4. Art & Style

**Final Visual Identity:**

* **Title:** *Dart: Deadly Dodge*
* **Logo:** Yellow neon **DEADLY DODGE**, cyan accents, Tron-style shards and sparks.
* **Background:** Dark navy with glowing cyan wireframe grid.
* **Mood:** Retro-futuristic arcade (80s Tron + modern neon).

**In-Game:**

* Hazards glow in red/orange neon.
* Maze walls are deep blue with cyan glow edges.
* HUD elements styled in neon cyan/yellow for clarity.

---

## 5. Audio

* **Sound Effects:** Neon zaps, swooshes, impact sparks.
* **Music:** High-energy synthwave soundtrack that speeds up with game difficulty.
* **VO/Callouts:** Arcade-style announcer: “DEADLY DODGE!”, “MAZE SHIFT!”, “NEAR MISS!”

---

## 6. Technical

* **Engine:** Unity 6 (URP for neon visuals).
* **Frameworks:** Unity6CoreFramework (randomization, settings, editor tools).
* **Randomization:** Noise-based procedural generation (maze patterns, hazard timings).
* **Performance Target:** 60 FPS on mobile, 120 FPS+ on PC.

---

## 7. Monetization (optional)

* Free with ads (mobile).
* Cosmetic skins for Dart.
* Endless mode unlocks.

---

## 8. Future Expansions

* **Multiplayer:** Competitive (last Dart standing).
* **Boss Mazes:** Large-scale hazards with unique dodge patterns.
* **Themed Arenas:** Ice grid, lava grid, space station.

---
