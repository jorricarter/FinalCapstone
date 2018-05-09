# FinalCapstone

To run this code:

  You will need to download Unity(Free). 

  After opening Unity, click 'Open'. It should ask you where the project is.
  
  Download this project from the repo.
  
  If the project is in a Zip file, you will probably need to unZip it.
  
  If you do not have an unZip tool, I recommend you download 7zip from 'www.cnet.com' since they check their downloads for viruses.
  
  You should be able to right-click the Zip file and select 'Extract All'.
  
  After you download the project and it is unZipped, go back to Unity.
  
  Unity should still be wanting you to navigate to the project.
  
  Find the project folder, select it and try to open it.
  
  If this fails or unity says 'This is not a Unity project folder', navigate to the child (the folder within the project folder) and select that folder instead.
  
  If it gives the same error, navigate to the grandchild folder.
  
  Once the project opens, turn off 'Baked Global Illumination' or it might take hours to load the game. 
  
  To do this, at the top of the window, select 'Window' > 'Lighting' > 'Settings', scroll down to 'Mixed Lighting', and uncheck, 'Baked Global Illumination'.
  
  There should be 2 navigation panes on the left.
  
  The top one, should navigate to items in the current scene(level or view).
  
  The bottom one, should explicitly appear to navigate through folders(like a standard file-explorer).
  
  Use the folder-browser to navigate to 'Assets > Jorri Assets > Logic > Scenes > '
  
  Inside that folder should be 2 'level 1' objects. (Unfortunately, the navmesh names its folder the same as the 'scene' object)
  
  Double-click the 'Level 1' icon that is not a folder.
  
  For my game to run, it requires 2 or 3 built-in assets.
  
  To import these, at the top of the window, select 'Assets' > 'Import Package' > 'Characters'.
  
  Then 'Assets' > 'Import Package' > 'CrossPlatformInput'.
  
  If you get 'compiler' errors before running the game then follow similar steps to import the 'Utility' asset.
  
  Before starting, in the lower-right corner, you should see a progress bar showing something like '5/11 159 jobs'.
  
  You don't have to wait for this to finish if you are okay with colors and lighting being messed up or very dark.
  
  Since I made you disable 'Baked Global Illumination' earlier, you will have a darker version of the game than the version I intended.





Known Bugs:
  
  When I downloaded to another computer, pink squares came out when I started shooting. The particle (type of graphic animation) became corrupt in the process of uploading/downloading/loading.
  
  When I downloaded to another computer, the weapon display in the lower-Right came out of its position. To fix this, I select it in the heirarchy, click 'snap to lower right' in the 'rect' component, then adjust the coordinates. (this was a resolution problem, but it's fixed now.)
  
  When I downloaded to another computer, the crosshair animation stopped working. I haven't looked into it because it is entirely aesthetic.
  
  You can damage enemies by shooting their 'detection fields' if they haven't detected you yet. I didn't find this out until the day before finishing so I left it alone, but I could just have the shooting mechanism check what type of collider it is and ignore it if it's a 'sphere' or 'trigger' collider.
  
  Enemies can chase you through walls. This bug is because the navmesh (navigation logic) thinks they can go outside. I just have to recreate the floor and exclude the outside from the logic or use scripts to replace the navmesh. scripts wont overrule the collisions in the walls.
  
  The drones (first enemy) don't have death animation, they just disappear. This is because the drones I used are from an older version of unity that isn't entirely compatible with the version I used.
  
  Difficulty picking up the weapon. This isn't frequent. I am 99% sure this is because I said the player has to be looking at the weapon and a certain distance from it so I probably have to adjust that in my script.





Features:
  
  This game was meant to be kind-of a second-person shooter. First-person shooters fall short by not giving you the peripheral view of a real first-person experience so I aimed for a half-way between first person and third person.
  
  I made arrow keys move relative to the player's perspective.
  
  I added lighting and reflective effects on metallic surfaces.
  
  There are separate animations for running, idle, shooting and dying.
  
  Enemies also have their own animations.
  
  Each enemy has their own animation cycles even if they are the same type of enemy.
  
  There are 3 different types of enemies with varying senses of discovery, differing healthpoints, damage and firerates.
  
  There are sound effects for the player and for enemies.
  
  Player and enemies have shooting effects such as flashes, smoke, and bullets firing off into the distance.
  
  This game works on a gaming controller.
  
  There is a crosshair, graphical HUD display with health, ammo and weapon display.
  
  The health animates when it goes up and down, the crosshair animates when you shoot, and the ammo count keeps track of your ammo.
  
  Each enemy has fairly accurate colliders that I made to make sure your shot is detected if you hit them.
  
  There is game music and walking sound-effects to fill the whitenoise.
  
  Enemies chase and shoot you when you walk into a room.
  
  Most of them have death animations when you kill them.
  
  There is a game-over screen with death animation when you run out of health.
  
  When you kill an enemy, you get rewarded with ammo replenishments that are different depending on the type of enemy you kill.
  
  There is a minimum and maximum ammo so if you have less than 1 ammo, you can't shoot and if you have more than 100, you can only carry 100 with you.
  
  There are easy to understand icons for things like health, ammo, weapon and on graphics for weapons you can pick up.
  
  Enemies have varying attack patterns so they won't all attack you in synchronization.
  
  There are additional weapons that you can look at stats for and pick up in the game.
  
  When you look at a weapon, a display appears telling you stats about it like its name, firepower, firerate, and how its stats match up to your current weapon.
  
  The weapon display in the lower-right auto adjusts the font-size and position of text when you switch weapons.
  
  Your display, stats, the graphic of the weapon you're holding, and shooting effects all change when you pick up a new weapon.
  
  The default gun requires you to 'pull the trigger' each time you want to shoot, but you can pick up an automatic weapon that keeps firing when you hold down the 'trigger'.
