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

**Win / Lose Conditions:**

* **Win:** Survive as long as possible; score accumulates from survival time and near-miss multipliers.
* **Lose:** Collide with a hazard. Game ends and score summary is shown.

---

## 2. Character – **Dart**

**Tagline:** “Quick on his feet, quicker with his wit.”

**Bio:** Dart isn’t the strongest, but in a world of shifting mazes and relentless hazards, speed and timing are everything. With lightning reflexes and an instinct for slipping past danger, Dart survives where others collide.

**Final Visual Design:**

* Sleek neon silhouette hero (Tron-inspired).
* Colors: Cyan body glow, yellow eyes/highlights.
* Effects: Light trails, pulse when dodging.
* Animations: Idle, Run, Dodge, Hit/Death.

---

## 3. Gameplay

* **Movement:** Simple 4-way (keyboard/controller, swipe/tilt mobile).
* **Hazards:** Spikes, rolling boulders, moving blocks, laser grids.
* **Maze Shifts:** Layout reconfigures dynamically.
* **Scoring:** Survival time + near-miss multipliers.

**Difficulty Curve Example (first 60s):**

* 0–30s → Slow hazards, sparse maze shifts.
* 30–60s → Faster hazards, denser shifts, tighter corridors.

---

## 4. Controls

* **PC:** Arrow keys / WASD = Move, Space = Dodge.
* **Controller:** Left Stick = Move, A (or Cross) = Dodge.
* **Mobile:** Swipe = Move, Tap = Dodge.

---

## 5. UI Flow

* **Title Screen** → Start Game / Options / Exit.
* **Game Screen** → Score, Timer, Multiplier, Callouts.
* **Game Over Screen** → Score summary + Restart / Back to Title.

---

## 6. Art & Assets

### 🎮 Core Character

* [x] **Dart model** – sleek neon silhouette.
* [ ] Alternate skins (color swaps, glow variations).
* [ ] Emissive neon materials with bloom.
* [x] Animation set: idle, run, dodge, hit, death.

### 🧱 Environment (Maze Tileset)

* [ ] Floor tiles (neon glow edges).
* [ ] Wall tiles (straight, corner, T-junction, cross).
* [ ] Animated gates/doors (optional).
* [ ] Hazard markers (warning panels, floor lights).

### ⚠️ Hazards

* [ ] **Spikes** (animated up/down).
* [ ] **Rolling boulders** (glowing spheres).
* [ ] **Laser beams** (turrets + beam FX).
* [ ] **Moving blocks** (sliding neon panels).
* [ ] Explosion/shatter VFX for destroyed hazards (optional).

### 💎 Pickups (Optional / Power-ups)

* [ ] Energy orbs / neon shards (for score or health).
* [ ] Power-ups:

  * [ ] Shield (short invulnerability).
  * [ ] Dash (speed burst).
  * [ ] Slow-Mo (hazards slow briefly).

### 📊 UI / HUD

* [ ] Title screen background (cyan/yellow neon grid). (Concept Done)
* [ ] Score counter (yellow neon).
* [ ] Multiplier display (cyan neon).
* [ ] Timer (white neon).
* [ ] Callouts: “DEADLY DODGE!”, “MAZE SHIFT!” (red/cyan neon bursts).
* [ ] Menu overlays: Pause, Game Over, Restart.
* [ ] Buttons styled with neon borders/glow.

### ✨ VFX

* [ ] **Character Trails:** Yellow neon streaks when Dart moves.
* [ ] **Dodge Flash:** Cyan shockwave pulse.
* [ ] **Near Miss:** Quick screen shake + red HUD pulse.
* [ ] **Pickups:** Sparkle burst + light flare.
* [ ] **Hazard Impacts:** Sparks, shatter particles.

### 🔊 Audio

* **Music:** Fast-paced synthwave track that ramps intensity. Tempo increases with difficulty.
* **SFX:**

  * Dodge “whoosh”
  * Hazard trigger (spikes snap, lasers zap, blocks crash)
  * Pickup collect (chime/glow)
  * Game Over (descending synth)
* **VO Callouts:** Arcade announcer for “DEADLY DODGE!” / “MAZE SHIFT!”

---

## 7. Technical

* **Engine:** Unity 6 (URP, Bloom).
* **Frameworks:** Unity6CoreFramework (randomization, settings).
* **Procedural:** Maze + hazard layouts use noise functions (SquirrelNoise64Bit, HashBasedNoiseUtils).
* **Performance:** 60 FPS mobile, 120+ FPS PC.
* **Art Pipeline:** Models created with Meshy AI → imported into Unity → refined with URP emissive neon materials.

---

## 8. Future Expansions

* Multiplayer: competitive dodge arenas.
* Boss Hazards: large rolling crushers, sweeping laser walls.
* Themed Arenas: Ice Grid, Lava Grid, Corrupted Grid.

---