# Game Design Document

### Title: **Dart: Deadly Dodge** (my title for the Obstacle Dodge project)

Based off the [**GameDev.tv course Complete Unity 3D Developer: Design & Develop Games in Unity 6 using C#**](https://www.gamedev.tv/courses/unity6-complete-3d) - ***Obstacle Dodge*** section.

See Section **11. Minimum Demo / Prototype (Beginner-Friendly)** and **Milestone 1** off section **12**

---

## 1. Game Overview

**Genre:** Arcade / Maze / Obstacle Avoidance
**Platform(s):** Web, (Optional: PC, Mobile, Switch, Xbox, Playstation) 

**Core Loop:**

* Navigate Dart through maze-like arenas.
* Dodge (optional) or avoid moving hazards and traps.
* Survive as long as possible while racking up score multipliers.

**Win / Lose Conditions:**

* **Win:** Survive as long as possible; score accumulates from survival time and near-miss multipliers.
* **Lose:** Collide with a hazard. Game ends and score summary is shown.

---

## 2. Character – **Dart** *(original course name: “Dodgey”)*

**Tagline:** “Quick on his feet, quicker with his wit.”

**Bio:** Dart isn’t the strongest, but in a world of shifting mazes and relentless hazards, speed and timing are everything. With lightning reflexes and an instinct for slipping past danger, Dart survives where others collide.

**Final Visual Design:**

* Sleek neon silhouette hero (Tron-inspired).
* Colors: Cyan body glow, yellow eyes/highlights.
* Effects: Light trails, pulse when dodging.
* Animations: Idle, Run, Dodge (optional), Hit/Death.

---

## 3. Gameplay

* **Movement:** Simple 4-way (keyboard/controller, swipe/tilt mobile).
* **Hazards:** Spikes, rolling boulders, moving blocks, laser grids.
* **Scoring:** Survival time + near-miss multipliers.

**Optional Features:**

* **Dodge Move:** Quick sidestep/dash move (core ability or collectible).
* **Maze Shifts:** Arena layout can dynamically reconfigure.
* **Random Maze Layouts:** Procedural mazes can be generated for replay variety.

**Difficulty Curve Example (first 60s):**

* 0–30s → Slow hazards, sparse arena.
* 30–60s → Faster hazards, denser obstacles.

---

## 4. Controls

**Implementation:** Unity’s **New Input System** (`InputActionAsset`)

* **Dynamic Device Detection:**

  * Detects last used input device (Keyboard/Mouse, Gamepad, Mobile).
  * Controls screen defaults to that device.

* **Action Maps:**

  * **Player**

    * `Move` → 2D Vector (Keyboard WASD/Arrows, Gamepad Stick/D-Pad, Swipe).
    * `Dodge` → Optional action (Space, Gamepad South Button, Tap).
  * **UI**

    * `Navigate`, `Submit`, `Cancel` per device.

* **Controls Screen (Interactive):**

  * Opens automatically when game starts (after Title).
  * Defaults to **active device tab**.
  * Tabs for all device types (Keyboard/Mouse, Gamepad, Mobile).
  * Each tab shows icons, labels, and bindings.

* **In-Game Access:**

  * Pause Menu → “Controls” → same Controls screen.
  * Resume returns to game.

* **Future Option:**

  * Full rebinding UI with persistent profiles.

---

## 5. UI Flow

* **Title Screen** → Start → **Controls Screen** (active device tab).
* **Controls Screen** → Tabs (Keyboard, Gamepad, Mobile) → Start Game.
* **Game Screen** → Score/Timer/Multiplier.
* **Pause Menu** → Resume / Controls / Quit.
* **Game Over Screen** → Score summary + Restart / Back to Title.

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

* [x] **Dart model** – sleek neon silhouette.
* [ ] Alternate skins (color swaps, glow variations).
* [ ] Emissive neon materials with bloom.
* [x] Animation set: idle, run, hit, death.
* [ ] Dodge animation (optional).

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
* [ ] **Dodge Flash:** Cyan shockwave pulse (optional).
* [ ] **Near Miss:** Quick screen shake + red HUD pulse.
* [ ] **Pickups:** Sparkle burst + light flare.
* [ ] **Hazard Impacts:** Sparks, shatter particles.

### 🔊 Audio

* **Music:** Fast-paced synthwave track that ramps intensity. Tempo increases with difficulty.
* **SFX:**

  * Dodge “whoosh” (optional)
  * Hazard trigger (spikes snap, lasers zap, blocks crash)
  * Pickup collect (chime/glow)
  * Game Over (descending synth)
* **VO Callouts:** Arcade announcer for “DEADLY DODGE!” / “MAZE SHIFT!”

---

## 8. Technical

* **Engine:** Unity 6 (URP, Bloom).
* **Frameworks:** Unity6CoreFramework (imported as package, not inside project).
* **Input:** Unity’s New Input System with dynamic device detection.
* **Procedural:**

  * MVP → Static maze layouts.
  * Optional → Maze shifts & random maze layouts.
* **Performance:** 60 FPS mobile, 120+ FPS PC.
* **Art Pipeline:** Models created with Meshy AI → imported into Unity → refined with URP emissive neon materials.

---

## 9. Project Layout

All game content lives inside:

```
Assets/_DeadlyDodge/
```

### Folder Structure

```
_DeadlyDodge/
 ├── Art/                 # 2D textures, icons
 ├── Audio/               # Music & SFX
 ├── Materials/           # Emissive neon materials
 ├── Models/              # 3D models (Dart, hazards, maze pieces)
 ├── Prefabs/             # Prefabs for Dart, hazards, tiles, UI
 ├── Scenes/              # Boot, Title, Controls, Game, GameOver
 ├── Scripts/
 │    ├── Core/           # GameManager, ScoreSystem, DifficultyDirector
 │    ├── Gameplay/       # PlayerController, Hazard logic
 │    ├── UI/             # HUDController, ControlsScreen, Pause Menu
 │    └── Systems/        # Save/Load, AudioManager, Event routing
 ├── ScriptableObjects/   # Hazard definitions, difficulty profiles, theme configs
 ├── Settings/            # Game-specific project settings
 └── VFX/                 # Trails, flashes, sparks, near-miss effects
```

### Key Scenes

* **Boot** → Loads initial settings, moves to Title.
* **Title** → Main menu, Start → Controls Screen.
* **Controls** → Shows bindings for last-used input device, tabs for others.
* **Game** → Core gameplay arena, HUD active.
* **GameOver** → Score summary, restart option.

---

## 10. Future Expansions

* Multiplayer: competitive dodge arenas.
* Boss Hazards: large rolling crushers, sweeping laser walls.
* Themed Arenas: Ice Grid, Lava Grid, Corrupted Grid.
* Dodge Move as a permanent upgrade or power-up.
* Maze Shifts + Random Layouts as alternate modes.

---

## 11. Minimum Demo / Prototype (Beginner-Friendly)

**Goal:**
A stripped-down prototype for learning and testing the **core programming** before building the full project. Designed for beginners following the [GameDev.tv Unity 6 Course](https://www.gamedev.tv/courses/unity6-complete-3d).

**Features Included:**
* Player as a simple **cube**.
  * `Mover` – moves the Player.
  * `Scorer` – on collision with an object, increment a hit counter and Debug.Log the number of hits.
* Single **Game Scene** (no Title, no Controls screen, no Menus).
* Hardcoded input (no Input Actions, no UI).
* Hazards (each uses `ObjectHit`):
  * Walls
  * `Dropper` – a cube that falls from the sky after a delay
  * `Spinner` – a rotating obstacle (spins continuously)
  * `FlyAtPlayer` (Projectile) – a sphere that moves toward the player’s position on Start
  * `TriggerProjectiles` (Trigger Volume) – spawns/launches multiple projectiles when the player enters
  
Assets/_DeadlyDodge/
 ├── Scripts/Prototype/
 │    ├── Mover.cs
 │    ├── ObjectHit.cs
 │    ├── Scorer.cs
 │    ├── Dropper.cs
 │    ├── Spinner.cs
 │    ├── MoveTowardsTarget.cs
 │    └── TriggerProjectile.cs
 └── Scenes/
      └── GamePrototype.unity

Note That the prefabs I am using in the prototyp refrence assets from [POLYGON Prototype - Low Poly 3D Art by Synty](https://assetstore.unity.com/packages/essentials/tutorial-projects/polygon-prototype-low-poly-3d-art-by-synty-137126) If you do not own this asset you will have to update the prefabs and scene to use your own assets or simple shapes, i.e. cubes and spheres

---

### Prototype Scene Setup

* **Scene:** `GamePrototype`
* **Objects:**
  * Player Cube (`PlayerCube`)
  * Floor Plane (`Ground`)
  * Simple Obstacles (e.g., walls, spinner, dropper, projectiles)

---

### Input Handling

#### Option A — Old Input (from GameDev.tv course)

```csharp
void MovePlayer()
{
    float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    float yValue = 0f;
    float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    transform.Translate(xValue, yValue, zValue);
}
```

---

#### Option B — New Input (manual polling, no `InputActionAsset`)

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var gamepad = Gamepad.current;
        var keyboard = Keyboard.current;
        Vector3 move = Vector3.zero;

        if (gamepad != null)
        {
            var stick = gamepad.leftStick.ReadValue();
            move.x = stick.x;
            move.z = stick.y;
        }

        if (keyboard != null && move == Vector3.zero)
        {
            if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed) move.x = -1f;
            if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed) move.x = 1f;
            if (keyboard.upArrowKey.isPressed || keyboard.wKey.isPressed) move.z = 1f;
            if (keyboard.downArrowKey.isPressed || keyboard.sKey.isPressed) move.z = -1f;
        }
		
        transform.Translate(move .normalized * _moveSpeed * Time.deltaTime);
    }
}
```

---

### Success Criteria

✅ Player cube moves smoothly in 3D.
✅ Input works with keyboard **and/or** gamepad.
✅ Scene demonstrates **basic movement** loop without menus or extra features.

---

## 12. Milestone Breakdown

### 🎯 Milestone 1 – **Beginner Prototype (GameDev.tv Path)**

Goal: Learn Unity basics, C#, and build a functional sandbox.

**Learning Modules:**

* Intro: Player + simple obstacles sandbox.
* `Start()` & `Update()` basics.
* Variables & `SerializeField` usage.
* C# formatting & conventions.
* Movement with `Input.GetAxis()`.
* `Time.deltaTime` for frame independence.
* Cinemachine follow camera.
* Collisions & `OnCollisionEnter()`.
* Methods & refactoring.
* `GetComponent()` to access components.
* Score counter (`Scorer` script).
* `Time.time` & timed hazards (`Dropper`).
* If statements for hazard logic.
* Cached references for efficiency.
* Tags for hazard filtering (`ObjectHit`).
* Rotating hazards (`Spinner`).
* Projectiles: `FlyAtPlayer` + `Destroy()`.
* Trigger volumes launching hazards.
* Prefabs (player + hazards).
* Unity execution order basics.
* Level layout assembly.

**Outcome:**

* A **cube player** moves & collides.
* Hazards (walls, spinners, droppers, projectiles) are functional.
* Score increases on collision.
* Prototype scene demonstrates obstacle-dodging basics.

---

### ⚡ Milestone 2 – **MVP (Playable Game)**

Goal: Ship a **minimum arcade loop** based on your Dart: Deadly Dodge design.

**Gameplay**

* Dart model with Idle/Run/Death animations.
* Hazards: Spikes, Rolling Boulders, Laser Beams, Moving Blocks.
* Collision = Game Over.
* Scoring = Time survived + near-miss multipliers.

**UI / UX**

* Game flow: Title → Controls → Game → GameOver.
* HUD: Score, Timer, Multiplier.
* Pause Menu: Resume / Controls / Quit.
* Controls screen auto-detects device.

**Assets**

* Neon maze tiles (floor + walls).
* Dart emissive materials.
* Basic hazard prefabs.
* Placeholder SFX + simple synthwave loop.

**Outcome:**

* Fully playable core loop.
* Matches your GDD “MVP” spec.

---

### 🚀 Milestone 3 – **Polish & Optional Features**

Goal: Add replay value, juice, and depth.

**Gameplay**

* Dodge move (ability or power-up).
* Maze Shifts (dynamic reconfiguration).
* Procedural/random maze layouts.
* Pickups (Shield, Dash, Slow-Mo).

**UI / UX**

* Stylized neon UI & callouts (“DEADLY DODGE!”, “MAZE SHIFT!”).
* Animated title screen background.
* Refined menus.

**Assets**

* Dodge animation + flash VFX.
* Trail effects for Dart.
* Hazard impact particles.
* Full synthwave soundtrack + announcer VO.

**Outcome:**

* Juicier, more replayable game.
* Ready for PC/web release.

---

### 🌍 Milestone 4 – **Future Expansions**

Goal: Extend scope for long-term play & platforms.

**Gameplay**

* Multiplayer competitive arenas.
* Boss hazards (crushers, sweeping lasers).
* Themed arenas (Ice Grid, Lava Grid, Corrupted Grid).
* Progression/unlock system for abilities.

**Platforms**

* PC (Steam).
* Mobile (iOS/Android).
* Consoles (Switch, Xbox, PlayStation).

**Assets**

* Additional Dart skins.
* Themed tilesets + hazards.
* Advanced adaptive soundtrack.

**Outcome:**

* Full-featured, cross-platform release.

---
