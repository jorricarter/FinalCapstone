# FinalCapstone

## To run this code:

  You will need to download Unity(Free). 

  After opening Unity, click 'Open'. It should ask you where the project is.
  
  Download this project from the repo.
  
  If the project is in a Zip file, you will probably need to unZip it.
  
  After you download the project and it is unZipped, go back to Unity.
  
  Unity should still be wanting you to navigate to the project.
  
  Find the project folder, select it and try to open it.
  
  If this fails or unity says 'This is not a Unity project folder', navigate to the child (the folder within the project folder) and select that folder instead.
  
  If it gives the same error, navigate to the grandchild folder.
  
  Once the project opens, turn off 'Baked Global Illumination' or it might take hours to load the game.
  
  To do this, at the top of the window, select 'Window' > 'Lighting' > 'Settings', scroll down to 'Mixed Lighting', and uncheck, 'Baked Global Illumination'.
  
  There should be 2 navigation panes on the left.
  
  The top navigation pane, should navigate to items in the current scene(level or view).
  
  The bottom navigation pane, should explicitly appear to navigate through folders(like a standard file-explorer).
  
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



## Description:

  With this project, my goal was to demonstrate that I have learned the skills needed to become a successful developer.
My initial project was to build a 2D shooting game with enemies and multiple rooms and you said that was enough.
After seeing how easy Unity was to use, I decided to try for a 3D version instead.

Before showing you the game, I would like to let you know which parts I did not make.
I tried rewriting the built-in default scripts with my own logic after I looked up some documentation, but the mouse wasn't moving the character correctly so after 3 days of trying, I copied the mouse tilt from the built in, but the rest of the movement code is mine.
Other than that, I wrote all of the game logic and scripts. I decided, making textures and drawing 3D enemies would take too much time and would not help demonstrate my programming capabilities so I used free assets from the Unity store to stand in as my art for the player, enemies, walls, and background ambience.
The assets I loaded were from older versions of unity and I had to rewrite a little code to get them to work so it's not like they were easy to use anyway.
I also created the level using free walls, ceilings and lights.

## Known Bugs:
  
  When I downloaded to another computer, pink squares came out when I started shooting. The particle (type of graphic animation) became corrupt in the process of uploading/downloading/loading.
  
  When I downloaded to another computer, the weapon display in the lower-Right came out of its position. To fix this, I select it in the heirarchy, click 'snap to lower right' in the 'rect' component, then adjust the coordinates. (this was a resolution problem, but it's fixed now.)
  
  When I downloaded to another computer, the crosshair animation stopped working. I haven't looked into it because it is entirely aesthetic.
  
  You can damage enemies by shooting their 'detection fields' if they haven't detected you yet. I didn't find this out until the day before finishing so I left it alone, but I could just have the shooting mechanism check what type of collider it is and ignore it if it's a 'sphere' or 'trigger' collider.
  
  Enemies can shoot you through walls. This bug was intentional since I did not have enough time to complete the shooting detection logic.

  The drones (first enemy) don't have death animation, they just disappear. This is because the drones I used are from an older version of unity that isn't entirely compatible with the version I used. (I think I disabled all enemy death animations since it wasn't fully tested and earlier bugs realted to those scripts made the level untestable.)
  
  Difficulty picking up the weapon. This isn't frequent. I am 99% sure this is because I said the player has to be looking at the weapon and a certain distance from it so I probably have to adjust the distance in my script. (Unity default is usually pressing 'enter' to pick up.)





## Features:
  
Vision/Movement/Background/Ambience/Controller:
I programmed the game to interperet arrow keys as directions related to the camera's view using the position and direction of the camera. It sounds so simple, but it took a few days.
I rewrote the viewing script multiple times because of things like turning the camera moves the player, but turning the player moves the camera in the opposite direction.
I created the map and got free footstep sounds from youtube.
I got this mostly working on a controller, but one joystick doesn't work.

Animation:
I blended animations and made algorithyms for what speeds and motions would trigger which animations and to what degree.
I set variables and formulas for individual graphics like shooting graphic when 'shooting' is true or running blend when speed is between 0 and 1.
I couldn't get the drone death animation working so they just disappear after death. 
I think I disable all enemy death animations because they weren't fully tested and I didn't want them to cause problems during presentation.

Bullet/Particle/Sound:
I made the logical bullet fire from the player's perspective while the visual bullet fires from the gun.
I made the bullet myself from scratch using a cyllinder and adding some metallic reflection effects.
I created pooling logic for bullets to avoid lag that comes when instantiating hundreds of bullets for machine guns.
Pooling logic is where I load 200 bullets when the game starts and when the game needs a bullet, instead of creating a hundreds of bullets at once, it takes the already-made bullets tells them where to start, which direction to move and at what speed. If the game uses more bullets than what is in the pool, the pool will create more and add them to the pool for reuse.
I made multiple effects for when I shoot such as sparks, smoke, sound, visual bullets, and the logic involved in where and how to make these graphics appear.

Colliders/Chasing:
I created colliders in enemies, alligned them with the visual appearance of the enemies and created logic on how to handle collisions with walls, bullets, too close to character. (bullet holes and 'personalSpace' don't work.)
Each type of enemy has it's own parameters to handle the logic for chasing the player from speed to how to handle obstacles. This was necessary to make animations look more realistic and make floating enemies work.
The ground tiles I used from the free asset wouldn't let the player or enemies move after adding a navigation mesh so I made the floor tiles incorporeal, Then I created a new invisible floor that he walks on instead of the crooked visible one. It turns out the tiles were slightly crooked.
Enemies emit particles/sounds/bullets when shooting and have their own 'firepoint' and, sounds.
I fixed enemies shooting the instant they see you.
Enemies can pass through walls, but you can't. They can only do this when chasing you. I decided to get more functional things done instead of focus on animations for phasing through walls.

Components:
Half of my work you can't see is in the component settings like how with each character, you have to choose the position, height, rotation using parents, size, collider shapes, navmesh, animation blending, health, AI logic/detection, rewards, set up sounds, shooting graphics, firepoints, damage, and such.
I applied variations of animations to each enemy so identical enemies wouldn't have identical 'idle' motions.
randomize attackrate a little so enemies dont all shoot in the same pattern.

Crosshair/Ammo/Health/Death:
I made an HUD with icons, health, weapon display, ammo, crosshair, and death animation.
The crosshair is on a canvas saparate from the rest of the display with its own properties like how it interacts with objects. It doesn't appear to be targeting the user when looking down and it will vanish when the player is looking at a game object. It phases into the wall at a close distance. 
I made the crosshair image myself, created the animation for it frame-by-frame. It animates when you shooting by animating the canvas it's on.
Ammo and Health display updates every frame. The health animates its size.
Can't shoot if ammo is zero and if you get more than 100 ammo, you only carry 100 at a time.
I made another canvas for the gameover screen because it looked much better than my original gameover screen.
For gameover, I disable player movement after death, but can still look around like in some games.
if you see redundant things like 2 gameover screens or 2 different kinds of shooting scripts for the player it's because I rewrote a lot of my code after adding more advanced components and thinking of better was to have the components interact.

Weapon/Display/Automatic:
I added a weapon you can pickup.
When you look at a weapon, an HUD appears telling you stats about it like its name, firepower, firerate, and how its stats match up to your current weapon.
I added weapon names/icons. long names change the text format as well as the font size.
The new gun appears in your hands.
made guns iterable so if I made more, I could loop through them to see which ones are active(equiped) and store that in temp variable before deactivating and using other logic.
I made default messages show errors with details and this helped me notice problems behind the scenes like when ammo counters stopped loading.
The new weapon has different stats, a different style of shooting, and slightly different animations.
I changed gun shooting styles to fit automatic. Also made it so when new gun is disabled, stats go back to previous gun.
The new-weapon logic is a little wonky because I never planned on adding it, but I would make it more modular if I could go back and do it again.

Summarized list:

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
  
  There is a min and max ammo. You can't shoot with 0 ammo and you can only carry 100 ammo at a time.
  
  There are easy to understand icons for things like health, ammo, weapon and on graphics for weapons you can pick up.
  
  Enemies have varying attack patterns so they won't all attack you in synchronization.
  
  There are additional weapons that you can look at stats for and pick up in the game.
  
  When you look at a weapon, a display appears telling you stats like firepower, firerate, and how it compares to your current weapon.
  
  The weapon display in the lower-right auto adjusts the font-size and position of text when you switch weapons.
  
  Your display, stats, the graphic of the weapon you're holding, and shooting effects all change when you pick up a new weapon.
  
  The default gun requires a click each time you shoot, but you can pick up automatic weapons that fire while the trigger is held down.
  
![capture](https://user-images.githubusercontent.com/30512957/39795690-87c31ec4-5317-11e8-839e-fe0faeeb6797.PNG)
![capture1](https://user-images.githubusercontent.com/30512957/39795691-87d6c410-5317-11e8-935b-b8975a8bd05d.PNG)
![capture2](https://user-images.githubusercontent.com/30512957/39795692-87f22818-5317-11e8-85cd-393805ac2692.PNG)
![capture3](https://user-images.githubusercontent.com/30512957/39795693-8803212c-5317-11e8-80e5-ced717553e6b.PNG)

  
## Grading

If you look in the bottom navagation pane, it should be very organized to make everything easy to find. To navigate to scripts I think it's something like 'Jorri Assets' > 'Logic' > 'Scripts'. The other half of my work is in the settings for each image, animation, and component like the variations in the enemies' animations, AI, shooting, health, damage, detection field, reward for killing, and such.
