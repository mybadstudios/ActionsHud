### Contextual Actions HUD
Offers context sensitive user interaction for your game. Place the buttons on screen and it will call specific functions on any object that has focus. Provides a visual cue of which actions are available as they become available. Supports both keyboard and mouse inputs

Have a consistent interface throughout the game but have buttons trigger custom actions on whichever game object is currently in range / has focus. I.e. start or stop an elevator, pull a lever, open a chest or unlock a door or whatever else is required

If You enjoy my work, please consider buying me a coffee...

[<img src="bmcbutton.png">](https://www.buymeacoffee.com/mybad)


# How to integrate into your game

1. Simply drop a prefab on your player character to indicate that you wish to measure proximity to that game object

2. Then drop another prefab on each object you want the player to interact with.

3. For each of these interact-able objects you will be presented with an array of actions that you can pick from to say which actions you want to be able to perform on that object. Simply select the choices you want available from here

4. Drop the final prefab onto your canvas and you are setup and ready to go

# More info
Add or remove icons as required for the current game

Call as many functions as you like with one function call per button

The relevant icon will highlight if the focused / in-range object can make use of that particular buttons' function

Toggle button availability per object as bool values in the inspector

Only takes a few minutes to setup at the start of the project and it's good to go...


