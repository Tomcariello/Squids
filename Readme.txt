SQUIDS

This is the plan. I'm prioritizing function over form to start with. Once things are working sufficiently I plan to tackle art/sound/etc.
I reserve the right to change priorities as I see fit :-)
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

V.04: Cleanup
    *Large grab item was not collectible by Player
    *Destroy bullets when they collide with floors/ceilings/walls (Script added to bullets)
    *Health items should not be impacted by bullets (Created a "Don't Collide with Bullets" label & adjusted physics accordingly)
    *Health items should not interrupt your jump:
        *Moved Script onto each health drop object (previously was on the playerController)
        *Adjusted RigidBody2d Mass settings to Zero. (NOT kinematic, not a trigger). Updated Health Prefabs
        *Simplified health drop application collide
    *Added GameManager vars for playerFullPower & playerCurrentPower (was playerPower)
    *Don't allow bullets to shoot GREEN

V.05: Cutscene mechanics
    *Update Conversation visuals & content (Moved function into GameManager. Use haveConversation(text, sprite) to call a dialogue box)
    *Click button to close dialogue window.
    *Get Character Image to appear along with text in dialogue text
    *Update haveConversation() to use an ARRAY. This will allow for paging during conversations (Done but not utilized yet)
    *Freeze player during dialogue

    **"Learn to touch the ceiling" cutscene:**
        *Modified dialogue prefab design
        *Improve cutscene interaction.
        *Set cutscene for the grippable ceiling to be flat
        *Make sure cutscene only triggers once
        *Destroy JUMP message after a few seconds
        
        *Fallen rocks destroy the wall to open up a new path forward
        *Kill Player if hit by fallen rock
        *Enhanced DialogueController Script to handle multiple statement/character conversations
        *Improved cutscene markers. Timing is improved, interaction is better
        
        Explain "Grip Ceiling" ability to Player after cutscene.
    

    
    Escort Green to the exit which requires the Ceiling Grip (top right - not created yet)
    Hide Medicine until you talk to GREEN for the first time (Waiting on this until cutscene are sorted out)


V0.1: Fundamentals and cleanup
    Clamp the camera better depending on the level position
    Add boss before you can talk to Green
    Add boss before you can obtain medicine
    Improve player jump mechanics
    When you die the camera loses the player object.
    Create 2-4 additional enemies with different behaviors, attack patterns & power levels
    Add Xbox controller support
    Green is gittery when following Red
    
V.5: Start to make this respectable
    Dialogue Box:
        Create transition for the start of the conversation 
    
    UI elements:
        Inventory, Map, Etc
    
    Additional player ability mechanic:
        *Grip special blocks regardless of gravity
        Flaming ink
        Bio-Luminescence
        Camoflauge


    Improve graphics
    Add Sound effects
    Add music
    Add animations