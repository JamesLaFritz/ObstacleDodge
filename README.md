# Game Design Document

[<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/unity/unity-original.svg" title="Unity" alt="Unity" width="40" height="40"/> Play on Unity Play](https://play.unity.com/en/games/bc2d1a27-aef2-4230-bb3d-e653a7cc9601/dart-deadly-dodge)

[![Play on Itch.io](https://img.shields.io/badge/Play%20On%20Itch.io-FA5C5C?style=for-the-badge&logo=Itch.io&logoColor=white)](https://ktmarine1999.itch.io/dart-deadly-dodge)

### Title: **Dart: Deadly Dodge**

*(my title for the Obstacle Dodge project)*

Based off the [**GameDev.tv course Complete Unity 3D Developer: Design & Develop Games in Unity 6 using C#**](https://www.gamedev.tv/courses/unity6-complete-3d) - ***Obstacle Dodge*** section.

---

## 1. Game Overview

**Genre:** Arcade / Maze / Obstacle Avoidance

**Platform(s):** Web, (Optional: PC, Mobile, Switch, Xbox, Playstation)

**Core Loop:**
* Navigate Dart through maze-like arenas.
* Avoid or dodge hazards to conserve time.
* Race against the clock to reach the goal with maximum score.

**Win / Lose Conditions:**
* **Win:** Reach the end before the timer runs out. Score is based on time remaining plus bonuses.
* **Lose:** Time runs out before reaching the end.

---

## 2. Character – **Dart** *(original course name: “Dodgey”)*

**Tagline:** “Quick on his feet, quicker with his wit.”

**Bio:** Dart isn’t the strongest, but in a world of shifting mazes and relentless hazards, speed and timing are everything.

**Final Visual Design:**
* Sleek neon silhouette hero (Tron-inspired).
* Colors: Cyan body glow, yellow eyes/highlights.
* Effects: Light trails, pulse when dodging.
* Animations: Idle, Run, Dodge (optional), Hit/Death.

---

## 3. Gameplay

* **Movement:** Rigidbody-driven 4-way control (keyboard/controller, swipe/tilt mobile).
* **Hazards:** Spikes, rolling boulders, moving blocks, laser grids, Hazard3D with one-shot or resettable behavior.
* **Timer System:**
  * Level starts with a countdown timer.
  * Collisions subtract time (configurable in inspector).
  * If timer reaches zero → Game Over.
* **Scoring:**
  * Base score = time remaining at level completion.
  * Bonus = avoiding all hazards (no hits).

**Optional Features:**
* **Dodge Move:** Quick sidestep/dash move (core ability or collectible).
* **Maze Shifts:** Arena layout can dynamically reconfigure.
* **Random Maze Layouts:** Procedural mazes can be generated for replay variety.

**Difficulty Curve Example (first 60s):**
* 0–30s → Generous timer, hazards slow.
* 30–60s → Timer pressure, hazards faster/denser.

---

## 4. Controls

**Implementation:** Unity’s **New Input System** (`InputActionAsset`)

* **Dynamic Device Detection:**
  * Detects last used input device (Keyboard/Mouse, Gamepad, Mobile).
  * Controls screen defaults to that device.

* **Action Maps:**
  * **Player**:
    * `Move` → Vector2 → Rigidbody locomotion.
    * `Dodge` → Optional action (dash ability).
  * **UI**:
    * `Navigate`, `Submit`, `Cancel`.

* **Controls Screen:**
  * Opens automatically on first start.
  * Tabs for Keyboard, Gamepad, Mobile.
  * Shows active device bindings.

* **In-Game Access:**
  * Pause Menu → “Controls”.

---

## 5. UI Flow

* **Title Screen** → Start → Controls Screen.
* **Controls Screen** → Tabs (Keyboard, Gamepad, Mobile) → Start Game.
* **Game Screen** → HUD (Countdown Timer, Score, Bonus Indicators).
* **Pause Menu** → Resume / Controls / Quit.
* **Game Over Screen** → Final Score (Time Remaining + Bonus).

---

## 6. Controls Screen Wireframe

### Keyboard/Mouse Tab

```
| MOVE    : WASD / Arrow Keys
| DODGE   : Space (Optional)
| PAUSE   : Esc
| SUBMIT  : Enter
| CANCEL  : Backspace
```

### Gamepad Tab

```
| MOVE    : Left Stick / D-Pad
| DODGE   : A / Cross (Optional)
| PAUSE   : Start / Menu Button
| SUBMIT  : A / Cross
| CANCEL  : B / Circle
```

### Mobile Tab

```
| MOVE    : Swipe (any direction)
| DODGE   : Tap Screen (Optional)
| PAUSE   : Two-Finger Tap
| SUBMIT  : Tap Button
| CANCEL  : Back Gesture
```

---

## 7. Art & Assets

### 🎮 Core Character

* [x] Dart model – sleek neon silhouette.
* [ ] Alternate skins.
* [ ] Emissive neon materials.
* [x] Idle/Run/Hit/Death animations.
* [ ] Dodge animation (optional).

### 🧱 Environment (Maze Tileset)

* [ ] Floor tiles (neon edge).
* [ ] Wall tiles (straight, corner, T-junction, cross).
* [ ] Hazard markers.
* [ ] Gates/doors (optional).

### ⚠️ Hazards

* [ ] Spikes (up/down).
* [ ] Rolling boulders.
* [ ] Laser beams.
* [ ] Moving blocks.
* [x] Hazard3D: One-Shot or Resettable (material color + tag reset).

### 💎 Pickups (Optional)

* [ ] Energy orbs.
* [ ] Power-ups: Shield, Dash, Slow-Mo.

### 📊 UI / HUD

* [ ] Countdown timer.
* [x] Score summary (time remaining + bonus).
* [ ] Collision feedback: “-TIME!”.
* [ ] Bonus callouts: “BONUS!”.

### ✨ VFX

* [ ] Neon trails on Dart.
* [ ] Impact sparks.
* [ ] Dodge pulse (optional).
* [ ] Pickup flares.

### 🔊 Audio

* **Music:** Synthwave track, intensity ramps with timer.
* **SFX:** Dodge, hazards, pickups, Game Over.
* **VO Callouts:** “DEADLY DODGE!”, “-TIME!”, “BONUS!”.

---

## 8. Technical

* **Engine:** Unity 6 (URP + Bloom).
* **Frameworks:** Unity6CoreFramework.
* **Movement:** Rigidbody-based physics, not CharacterController.
* **Timer System:** Central `GameTimer` script manages countdown & penalties.
* **Score System:** Remaining time + collision-free bonus.
* **Performance:** 60 FPS mobile, 120 FPS PC.

---

## 9. Project Layout

```
Assets/_DeadlyDodge/
 ├── Art/
 ├── Audio/
 ├── Materials/
 ├── Models/
 ├── Prefabs/
 ├── Scenes/
 ├── Scripts/
 │    ├── Core/ (GameManager, GameTimer, ScoreSystem)
 │    ├── Gameplay/ (PlayerRigidbodyController, Hazard3D, etc.)
 │    ├── UI/ (HUDController, ControlsScreen)
 │    └── Systems/ (AudioManager, Save/Load)
 ├── ScriptableObjects/
 ├── Settings/
 └── VFX/
```

Key Scenes: Boot → Title → Controls → Game → GameOver.

---

## 10. Future Expansions

* Multiplayer: competitive arenas.
* Boss hazards (giant crushers, sweeping lasers).
* Themed arenas (Ice, Lava, Corruption).
* Unlock progression: Dodge, Maze Shifts.

---

## 11. Minimum Demo / Prototype (Beginner-Friendly)

**Goal:** Learn Unity + C# basics with a stripped prototype.

**Features:**

* Player cube using `Mover`.
* Hazards: Dropper, Spinner, FlyAtPlayer, TriggerProjectile.
* `Scorer` script counts hits.
* Scene: `GamePrototype`.
* Input: Hardcoded.

✅ Player moves & collides.
✅ Logs hits to console.
✅ Shows obstacle-dodging basics.

---

## 12. Milestone Breakdown

### 🎯 Milestone 1 – **Beginner Prototype (GameDev.tv Path)**

* Cube player movement.
* Hazards functional.
* `Scorer` tracks hit counter.
* Ends on collision/hit count.

**Outcome:** Prototype scene works, score = hits.

---

### ⚡ Milestone 2 – **MVP (Playable Game)**

* Dart (Rigidbody movement).
* Hazards upgraded (spikes, lasers, Hazard3D).
* Countdown timer replaces hit counter.
* Collisions subtract time.
* Reaching goal before timer ends = Win.
* Score = Time left + no-hit bonus.

**Outcome:** Fully playable timed loop.

---

### 🚀 Milestone 3 – **Polish & Optional Features**

* Dodge move.
* Maze Shifts + procedural layouts.
* Pickups: Shield, Dash, Slow-Mo.
* Stylized UI, neon callouts, announcer VO.
* Juice: trails, particles, VFX.

**Outcome:** Replayable polished version, PC/Web-ready.

---

### 🌍 Milestone 4 – **Future Expansions**

* Multiplayer competitive arenas.
* Boss hazards + themed arenas.
* Unlock systems.
* Platforms: Steam, Mobile, Consoles.

**Outcome:** Full-featured, cross-platform release.

---