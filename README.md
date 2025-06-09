# RogueLikeGame
 
This project contains some (flawed) implementations of mechanics commonly found in Rogue Like genre games
  
## Controls 
W: Up  
A: Left  
S: Down  
D: Right  

Mouse movement: Aim
Left click: Shoot
Mouse wheel: Weapon change
  
Note: Movement controls use a New Input System  
  
## Rooms  
Upon spawning, 15 rooms are procedurally generated from the spawnpoint, each one contains an enemy spawner that generates 2-4 enemies upon entering the room in a random way.
Also, a boss room is spawned (even though it doesn't generate enemies)  
  
Note: The camera was supposed to be centered in the room the player was standing, but it wasn't working so I had to bypass the problem with the camera following the player.  
  
## Enemies
The game contains 2 types of enemies  

Suicide Enemy (the red one): This enemy approaches the player and once it's close enough, stops for 2 seconds and detonates (no VFX tho')
Turret Enemy (the green one): This enemy approaches the enemy and when it's at a certain range, stops and starts throwing bullets at the player, when player leaves this range, this enemy follows the player  
  
  
## Weapons
The game has 4 weapons for playing  
  
Sniper: This weapon fires a straight bullet very fast
Flamethrower: Creates an area in front of it that damages enemies within it
Grenade Launcher: Throws a projectile that explodes some time after being thrown
Sword: Damages enemies on contact

Note: Sniper instantiates bullets but they instantly despawn. It should not collide with anything else but they still despawn. Also, weapons normal one shot enemies, not because they are overpowered, but because for some reason, enemies get damaged more than once every frame.
Note 2: Couldn't do a store to buy the weapons
