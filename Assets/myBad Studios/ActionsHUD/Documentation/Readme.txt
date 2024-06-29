Usage instructions for the ActionsHUD
=====================================

The ActionsHUD was made to be extremely useful while being insanely easy to use and allows you to
trigger any code you want, visually or via keyboard input, in response to a proximity between your
player character and another object

The system has 3 parts:
1. You need the part in the Canvas that actually shows you the icons
2. You need the part on the objects you want to interact with so you can specify what interactions
   you want to perform on that object
3. You need the part on the player that moves through the world and tests wether or not it is in
   range of anything you want to interact with

So let's explore those three parts in order:

1.A) First is the ActionsHUD.cs component 
=========================================
By far the most simple way to get started is to simply drag the ActionsHUDCompleteSample prefab
onto a Canvas object. If you do not have a Canvas in your scene yet, in the main menu, click on
GameObject->UI and then select any of the objects in there. Unity will then create a canvas for you
and place the object you selected in there. You only wanted the canvas so you can immediately delete
the object you selected from the menu and drag the ActionsHUDCompleteSample prefab onto theCanvas. 

The ActionsHUD.cs component has nothing that you need to configure but the ActionsHUDCompleteSample
prefab has a GridLayoutGroup component in which you can specify wether you want your ActionsHUD
icons to appear horizontally or vertically simply by changing the Constraint value using the drop
down box. Just select Fix Row Count or Fixed Col Count and watch your ActionsHUD update accordingly.
Then simply drag the prefab to where you want it to display on the screen. 

NOTE: I have set the Anchors to keep the icon’s sizes in tact and reposition the ActionsHUD
according to the top left corner of the screen. If you want to change this behavior, please see
Unity’s documentation on how to chance anchors.

From here it is all very straight forward. You can have as many icons as you want. All you have to
do is drag one ActionsHudButton prefab onto the ActionsHUDCompleteSample prefab for every icon you
want. That simple. Want 9 icons? Drag nine ActionHudButton prefabs onto the ActionsHUDCompleteSample
prefab or just drag one and duplicate it 8 times. That simple.

Next we need to configure each of the icons...

1.B) Info: ActionsHUDBase.cs
============================
This is a very important file and yet it is the most simple script you will ever find in any package
 on the Asset Store or elsewhere. This script contains only one enum field called eActionsHudAction.

In here you specify a name for every icon you want to show on screen. This value is for yourself
only so you can call it anything you want. You can call it: Action1, Action2, Action3 or 
Icon0, Icon1, Icon2 or you can call it SpeakTo,Interact,Clobber,Steal,Join....

It honestly doesn't matter one bit what you call it as long as they are each unique and there are
enough of them to match the number of icons you want to show on screen.
By default it comes with 4 values predefined for the ActionsHUDCompleteSample prefab

1.C) Configuring the buttons: ActionsHUDButton.cs
=================================================
Each of those ActionHDButton prefabs that you dragged onto the ActionsHUDCompleteSample prefab has
a few fields that you need to complete. First and foremost, you need to drag the icon you want to use
into the Image component.

Next you move on to the ActionsHUDButton component. 

Under Action_type, select one of the enum values you created in ActionnHUDBase.

Next, Specify the name of a function you want to call when that button is pressed, in the
Action_response field. This is the single most important part of the ActionsHUD kit so you need to 
understand this part really well.

If you created an icon that represents waving your arm, or one that represents speaking to a character
or one that equips your bazooka, the value you enter for Action_response is the function that will be
called on your game object so call it something meaningful like EquipBazooka or WaveHallo.

This is also the one part where the ActionsHUD takes a back seat and relies on you to do some leg work.

Basically, if you want the MushroomPrincess to pluck out her bazooka, the ActionsHUD will tell her:
"Hey, the player told you to pluck out your bazooka by sending you the EquipBazooka message".
It is up to you to make sure that the princess object has a script somewhere on it that HAS a function
called EquipBazooka. As long as the function exists, you are good to continue...

If you look in the demo folder you will notice that I created one script that I placed on multiple
objects in the scene. This is perfectly acceptable. The ActionsHUD does not pass along parameters,
only commands, but by having variables in the script that is shared by multiple objects, you can still
pass along parameters that way if you need to.

Also, notice in the demo folder that I also created specific scripts for specific objects also.
That is also perfectly valid. It doesn't matter where the function resides as long as one of the scripts
on the object (and only one of the scripts on the object) has a function that matches the value you
wrote in the action_response field!

That was the hard part. Not too bad, huh? :D The rest is now a piece of cake!

Action_key
----------
This allows you to specify a keyboard button that will trigger the button also, thereby giving you
the choice of keyboard, mouse or touch interaction.

Action_key_type 
---------------
This currently only works with keyboard input until I find a way to do this using UGUI.
This allows you to specify wether the action you want to perform should happen once only when you press
the button or happen continually while you hold the button down. 

show_keyboard_key
-----------------
The ActionsHUD system allows you to display the keyboard button of each icon on top of the icon to make
it easy for players to play with keyboards. For mobile devices, simply turn this field off and you are
good to go.

And that is that. The buttons are now done.

2. Showing objects that are of interest to you: ActionsHUDObject.cs
===================================================================
Simply drag the ActionsHUDObjectOfInterest prefab onto any game object in your scene then, under Actions,
select how many of your icons you want to enable for that object.

The enum values you defined earlier will appear as a list of drop down boxes so simply select all that
interest you for that particular object. For instance, of you are standing in front of a stone statue,
select LookAt as the only option. If you are facing a small talking frog, select LookAt, SpeakTo and Kiss
but if you are facing a large mutant toad, select Lookat and EquipBazooka...

That is all you have to do. Really simple. The ActionsHUDCompleteSample prefab will take care of showing
the correct icons and calling the appropriate functions. All you have to do is tell it what icons you want
to see and that you do by selecting them from the drop down list. You can even specify them in random
order and later change your mind by adding or removing selections. It doesn't matter and will be
properly handled.

3. Making the player aware of objects it can interact with: ActionsHUDPlayer.cs
=====================================================================================
Just as simple. Drag the ActionsHUDPlayerObject prefab onto your player character and you are done.

There are only two fields that you can set but they usually work pretty well at their default values so
you can really just leave them alone if you want.

The first field is interact distance and determines how close you need to be to an object before you take
an interest in it. 

The second is the look angle. If an object moves behind you, for instance, you will not take any notice
of it but with a look angle of 30, if the object moves within a 30 degree angle of your point of view, you
will take an interest in it. Once you have an interest in it you can turn your back on it if you choose
but in order to notice it in the first instance, you need to make sure it is in your line of sight.

And that is that... That is all there is to it... :D

Go forth and do incredible stuff with it!
Enjoy!

If you have any questions, you are welcome to submit a product support ticket via the website at:
http://www.mybadstudios.com

p.s. Remember to have your invoice number ready as the contact form requires a valid invoice number before
submitting the ticket.

Thank you for supporting my work. It is very much appreciated.