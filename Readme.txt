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
    *Kill bullets when they hit a GROUND object


    Fix the camera. Why is everything so small in the editor?
    Fix the camera. Prevent camera tracking until a certain threshold is reached (ie. don't move the camera the instant the squid jumps)
    
        

V.02: Proof of Concept
    
    Create Health meter indicating when squid takes damage
    Create damage system so shots will kill Enemies
    Create 2-4 additonal enemies with different behaviors, attack patterns & power levels
    Create *very* basic level flow. (ie. 30 seconds of running to find an object) for a proof of concept
    
    UI elements:
        Inventory, Map, Etc

V.03: Tighten things up
    Fix jump parameters to adjust the look & feel
    Fix bounceback parameters to adjust the feel



For later:
    Implement Singleton model for universal game objects
    Flesh out initial level design
    Character animations
    
    Additional player ability mechanic:
        Grip special blocks regardless of gravity
        Flaming ink
        Bio-Luminescence
        Camoflauge
    

V.5: Make this professional
    Improve graphics
    Add Sound effects
    Add music