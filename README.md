# ❄️ Snow Platformer 2D

A 2D side-scrolling platformer built with **Unity 6** and **C#**. Guide a fox through a snowy pine-forest level: jump across platforms, collect coins, dodge spikes, and reach the flag at the end before you run out of hearts.

<!-- Add a screenshot or GIF of your gameplay here, e.g. -->
<!-- ![Gameplay](docs/gameplay.png) -->

---

## Table of Contents

- [Features](#features)
- [Gameplay](#gameplay)
- [Controls](#controls)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Scripts Overview](#scripts-overview)
- [Tech Stack](#tech-stack)
- [Future Improvements](#future-improvements)
- [Author](#author)
- [License](#license)

---

## Features

- Smooth 2D character movement with variable-height jumping and a short "coyote time" grace window
- Animated fox sprite (idle, run, and jump states)
- Collectible spinning coins with a live coin counter
- Spike hazards and pit falls with a 3-heart health system
- Brief invulnerability with a blinking effect after taking damage
- One-way platforms you can jump up through
- Multi-layer parallax background (sky, mountains, pine forests)
- Smoothing camera that follows the player
- Sound effects generated in code, so no audio files are needed
- Win and game-over screens with instant restart
- Level generated automatically from an editor menu command

## Gameplay

1. Run and jump through the snowy level.
2. Collect coins along the way.
3. Avoid the spikes and don't fall off the map. Each hit costs one heart (you have 3).
4. Reach the flag at the end of the level to win.
5. If you lose all hearts, it's game over. Press `R` to try again.

## Controls

| Action  | Keys                         |
| ------- | ---------------------------- |
| Move    | `A` / `D` or `←` / `→`       |
| Jump    | `Space`, `W`, or `↑`         |
| Restart | `R` (after winning or losing)|

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- **Unity 6** (editor version `6000.3.27f1`; other Unity 6 versions should also work)

### Run the project

1. **Clone the repository**
   ```bash
   git clone https://github.com/rithikaredddy/SnowPlatformer2Dgame.git
   ```
2. **Open it in Unity Hub**: click *Add → Add project from disk* and select the cloned folder.
3. Wait for Unity to import assets and finish compiling.
4. **Build the level** from the top menu: `Snow Platformer → Build Level Scene`.
5. Press **Play**.

> The level scene is created by the editor script `SnowPlatformerBuilder`. If the scene looks empty, re-run the menu command above. The sprites must stay in `Assets/SnowPlatformer/Sprites`.

## Project Structure

```
SnowPlatformer2Dgame/
├── Assets/
│   ├── Scenes/                  # Default Unity scene
│   ├── Settings/                # URP 2D renderer and Input System settings
│   └── SnowPlatformer/
│       ├── Editor/              # SnowPlatformerBuilder (level generator)
│       ├── Scenes/              # SnowLevel scene
│       ├── Scripts/             # Gameplay scripts
│       └── Sprites/             # Fox, coins, spikes, flag, platforms, backgrounds, UI
├── Packages/                    # Unity package manifest
├── ProjectSettings/             # Unity project configuration
└── SnowGame.slnx                # Solution file
```

## Scripts Overview

| Script                    | Purpose                                                              |
| ------------------------- | -------------------------------------------------------------------- |
| `SnowPlayer.cs`           | Player movement, jumping, ground detection, sprite animation         |
| `SnowGame.cs`             | Game state: hearts, coins, respawn, win/lose screens, restart        |
| `SnowItem.cs`             | Coin, hazard, and goal behaviour (one script, selected by `Kind`)    |
| `SnowCamera.cs`           | Follows the player, clamped to the level bounds                      |
| `SnowParallax.cs`         | Scrolls background layers at different speeds                        |
| `SnowSfx.cs`              | Generates jump and coin sounds in code                               |
| `SnowPlatformerBuilder.cs`| Editor tool that builds the level, UI, and player in one click       |

## Tech Stack

- **Engine:** Unity 6 (2D, Universal Render Pipeline)
- **Language:** C#
- **Input:** Unity Input System (with legacy Input fallback)
- **Physics:** Unity 2D physics (`Rigidbody2D`, `PlatformEffector2D`)
- **UI:** Unity UGUI

## Future Improvements

- More levels and a level-select menu
- Moving enemies and power-ups
- Background music and a main menu
- Gamepad and mobile touch controls
- Saved high scores

## Author

**Rithika Anumandla**
GitHub: [@rithikaredddy](https://github.com/rithikaredddy)

## License

No license has been added yet. Add a `LICENSE` file (for example MIT) to state how others may use this project.
