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
    
V.03: Code Review & 1st Mission parameters
    *Improve jump parameters to adjust the look & feel
    *Fix Camera when at the bottom of the "level". Starting to understand the ActivateLimits function
    *Fixed "lumpy" sections on the floors. Ceiling elements weren't kinematic so were falling to the floor :-(
    *Properly handle death of the player (just returns to main menu)
    *Adjust bounceback parameters to adjust the look & feel

    Create *very* basic level flow. (ie. 30 seconds of running to find a key which opens a new way forward)
        *Find injured green squid (top left cave)
        *Green explains his predicament, needs medicine
        *Find medicine (bottom right cave)
        *Return to Green squid
        *Give him medicine
        *He's healed! Now you need to escort him out of the cave
        *Make Green follow Red 
        *Activate Trigger after healing GREEN
        *Script rocks falling on your way out
        *Create ability to grip some ceilings (tagged: Grippable_Ceiling)
        *Green reveals his ability to grab special blocks from underneath by jumping out of the way of the blocks

    **General Cleanup**
        *Large grab item was not collectible by Player
        *Destroy bullets when they collide with floors/ceilings/walls (Script added to bullets)
        *Health items should not be impacted by bullets (Created a "Don't Collide with Bullets" label & adjusted physics accordingly)
        *Health items should not interrupt your jump:
            *Moved Script onto each health drop object (previously was on the playerController)
            *Adjusted RigidBody2d Mass settings to Zero. (NOT kinematic, not a trigger). Updated Health Prefabs
            *Simplified health drop application collide
        *Added GameManager vars for playerFullPower & playerCurrentPower (was playerPower)
        *Don't allow bullets to shoot GREEN
        *Update Conversation visuals & content (Moved function into GameManager. Use haveConversation(text, sprite) to call a dialogue box)
        *Click button to close window.
        *Get Character Image to appear along with text in dialogue text
        *Update haveConversation() to use an ARRAY. This will allow for paging during conversations (Done but not utilized yet)
        *Freeze player during dialogue

    Improve cutscene interaction. Should this be a movie or interactive?
    Explain "Grip Ceiling" ability to Player after cutscene.
    
    Improve player jump mechanics
    Escort Green to the exit which requires the Ceiling Grip (top right - not created yet)
    Clamp the camera better depending on the level position
    Hide Medicine until you talk to GREEN for the first time (Waiting on this until mechanics are sorted out)


To Do/Fix:
    When you die the camera loses the player object.
    Add Xbox controller support
    Create 2-4 additional enemies with different behaviors, attack patterns & power levels
    

    UI elements:
        Inventory, Map, Etc
    
    Additional player ability mechanic:
        *Grip special blocks regardless of gravity
        Flaming ink
        Bio-Luminescence
        Camoflauge


V.5: Start to make this respectable
    Improve graphics
    Add Sound effects
    Add music
    Add animations