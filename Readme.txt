SQUIDS

This is the plan from my perspective. I'm trying to list in order or priority but feel free to jump around & do things you find interesting.
Once a item is done, '*' that line to indicate the task is completed.

V.01: Scaffolding
    *Create core scenes & navigation
    *Create basic Gameplay elements:
        *Floor
        *Character
        *Enable keyboard control (left/right)
        *Enable Camera panning (Tracks the player. It is working but it is too high.)
    
    *Core player abilities
        *Jump
        *Player can shoot in the direction they are facing
        *Rudimentary movement (faces the correct direction)
        *Rudimentary animations (framework set for better graphics)
        
    *Fix the camera. Why does everything rotate & fall apart when shooting? (Z-positioning had to be locked on the player. This is fixed)

    *Create *one* enemy with behavior, attack pattern & power level.
    *Allow for shooting in 7 directions (every way but down)
    *Destroy bullets when they hit a GROUND object


V.02: Proof of Concept
    *Implement Singleton model for universal game objects (just power so far)
    *Create damage system so shots will kill Enemies
    *Prevent camera tracking until a certain threshold is reached (view link on Discord for metroid style camera)
    *Destroy squid after 3 hits
    *Create Health meter indicating when squid takes damage
    *Create health items (small/medium/large)
    *Create Item spawner to create drops in the death position of the enemy
    *Fill in the gaps of the basic level. Insert walls/floors/etc
    *Set rudimentary pathfinding targeting for Vulture Prefab
    
V.03: Tighten things up
    *Improve jump parameters to adjust the look & feel
    *Fix Camera when at the bottom of the "level". Starting to understand the ActivateLimits function
        
    *Fixed "lumpy" sections on the floors. Ceiling elements weren't kinematic so were falling to the floor :-(
    *Properly handle death of the player (just returns to main menu)
    *Adjust bounceback parameters to adjust the look & feel

    Create *very* basic level flow. (ie. 30 seconds of running to find a key which opens a new way forward)
    

To Do/Fix:
    When you die the camera loses the player object.
    Add Xbox controller support
    Design & implement actual level design with mini quest & behavioral modifiers
    Character animations
    Create 2-4 additonal enemies with different behaviors, attack patterns & power levels
    Clamp the camera better depending on the level position

    UI elements:
        Inventory, Map, Etc
    
    Additional player ability mechanic:
        Grip special blocks regardless of gravity
        Flaming ink
        Bio-Luminescence
        Camoflauge
    
V.5: Start to make this professional
    Improve graphics
    Add Sound effects
    Add music
    Add animations