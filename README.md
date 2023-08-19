# BurgerKings
Burger King group with Izabelle, Shaun and Shawn

Unity ReadME File

Chase Game Controls:
A = Strafe Left
D = Strafe Right
Space = Jump

Boss Fight Controls:
Upon entering boss fight room, left mouse click to get rid of cursor.
Mouse 0 = Fire 1 bullet.
W = Move Forward
S = Move Backward
A = Strafe Left
D = Strafe Right
Space = Jump

Limitations and Bugs:
Chase Game:
Player can technically run in between the lanes and avoid all obstacles. To counter this limitation in the code, we made it so the player will never win the game unless he collects 100 leafs. 
Cutscenes will play before and after the chase. Cutscene does not very smoothly transition into the chase game.

Boss Fight:
All bosses do not exit the kitchen only chase within that small area in the kitchen. 
Bosses healthbar rotates with the boss and may be hard to see at times.
Leaf bullets are registered using colliders, and shot out at a certain speed travelling in the air, so when clicked too fast, the leaf bullets may collide with each other and destroy each other instead and the boss does not take damage. 
There is a Debug.Log of what the player is hitting, so the trick is to tap one by one at a controlled pace.
Bosses projectiles shot at you can be dodged by moving about.

Answers to puzzles:
Chase Game:
Trick to clear it safely is to focus on one lane, and usually the left lane is a lot easier than the other lanes, though it is slower as more coins are placed in the middle and the right lane, the left lane has lesser obstacles.
However, if the player wants to clear it fast they can go to other lanes.

Boss Fight:
Trick to kill the boss is tap one by one but fast, NOT THE FASTEST YOU CAN as bullets will collide into one another.
Player can also strafe left and right will shooting and dodge the bosses' projectiles.

Credits:

Mixamo for using the Mousey character as the running model in the chase game, that is the only model we took from Mixamo.
All other models were made by us, animations were auto rigged and taken from Mixamo as well.

BGM: Pokemon Little Root Town Lofi

SFX: Coin Collect and Cartoon Slip

Fonts: Who asks satan, Charmelade, Varela Round

Substance Community Assets was used for Unity Terrain, as well as all texturing of models.

Shaun: Coding the bosses attack pattern, VFX, Chase Game and Linking of Scenes

Shawn: Assembly of Boss Room, Coding bosses states, VFX, and Scene Management

Izabelle: Coding bosses states, Cutscenes, VFX, BGM, SFX, and Assembly of Chase Game
