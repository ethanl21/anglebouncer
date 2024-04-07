# Introduction

Scribblebounce is a physics-based game where the player has to draw lines to direct a projectile into a goal. It is played by clicking and dragging to draw lines and interacting with buttons to change the type of line being drawn.

# Written Scripts

- `GameScene.cs`
	- Controls each game scene
	- Implements UI functions, level win/lose functionality, etc.
- `Goal.cs`
	- Activates a callback function when an attached trigger collider is triggered
- `LevelSelect.cs`
	- Implements the level select screen's UI elements
	- Loads persistent variables to determine which levels are unlocked
- `Line.cs`
	- Represents a line that the player draws
- `LineGenerator.cs`
	- Creates lines based on user input
- `MainMenu.cs`
	- Implements the Main Menu's UI elements
- `MusicManager.cs`
	- Allows the game to use the same music player on the main menu and options screen so that it's obvious when the user changes the volume
- `OptionsMenu.cs`
	- Accesses and modifies persistent player preferences related to audio volume
- `Projectile.cs`
	- Implements the rolling ball that the player directs into the goal

# Important Game Objects
- `UIDocument` in `OptionsMenu`
	- an attached script saves and loads player preferences
- `BGMPlayer` in `MainMenu`
	- plays music
- `UIDocument` in `LevelSelect`
	- an attached script loads persistent save data regarding which levels are unlocked
- `Boundary` in each level scene
	- Resets the level if the player's projectile contacts the boundary and triggers a loss

# Details

In Scribblebounce, Unity's physics functions are used to direct a ball into a goal. The player is tasked with drawing lines of two types to in order to do this. One of the lines is a normal wall-like surface, and the other makes the projectile bounce. The player interacts with the scenes and gameobjects by drawing lines and starting the level, and the game manages physics and determines if a win or loss has occurred. The game stores volume preferences and unlocked levels as persistent data.

# Attribution

Colorful Crayons Draw by [OpenClipart-Vectors @ Pixabay](https://pixabay.com/vectors/colorful-crayons-draw-various-1296465/)

Backgrounds by [Incompetech](https://incompetech.com/graphpaper/)

Rolling Ball Assets by [Kenney](https://kenney.nl/assets/rolling-ball-assets)

Music by <a href="https://pixabay.com/users/geoffharvey-9096471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=169603">Geoff Harvey</a> from <a href="https://pixabay.com/music//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=169603">Pixabay</a> (The Hairy Orange Spider)

Music by <a href="https://pixabay.com/users/geoffharvey-9096471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=140001">Geoff Harvey</a> from <a href="https://pixabay.com/music//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=140001">Pixabay</a> (Solve the Riddle)

Music by <a href="https://pixabay.com/users/geoffharvey-9096471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=174360">Geoff Harvey</a> from <a href="https://pixabay.com/music//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=174360">Pixabay</a>(Candy Club)

[EasyTransitions](https://assetstore.unity.com/packages/tools/gui/easy-transitions-225607) @ Unity Asset Store