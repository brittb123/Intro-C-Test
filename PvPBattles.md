# Starting off:
First thing that came to mind while making this possible was be to create the main
variables and main classes that are essential such as Player, Character, and a few Role 
Classes. A list of all variables and functions that are essential above the Flow
of Game section.

## Input and Controls:

####  NumKey 1:
Selects the Knight Role, Attacks in battle, Selects Archer's explosive arrow, selects 
Wizard's Fireball spell while attacking, and switchs weapon to intended item at slot 1.

#### NumKey 2:
Selects Archer's Role, Opens switch inventory menu, Selects Archer's shock arrow 
while attacking, Selects Wizard's lightning spell while in battle, and switches weapon 
to intended item at slot 2.

#### NumKey 3:
Selects the Wizard role, Heals the caster for 10 health, Selects Archer's freezing arrows
while attacking.

## Essential Functions, Variables, and Classes
This is a list of all functions and variables declared and used to run the gam. If a function
will have a paramater, that parameter will next to the name. Each function and variable will have a type, 
visibility, and description with it. Classes will have a description, visibility, and a list of containing
functions and variables. Overloaded functions will be shown again with the different parameters.

### Essential Functions:
GetInput(string option1, string option2, string option3, string query)
Type: Void, Visibility: Public,
Description: This function will print the query string, which is usually a question, 
to the console. Next the three string options are printed to the console, which leads to 
the declaration of input. After all options printed and input is defined, a Console read 
key is used to get the input of the player.

GetInput(string option1, string option2, string query)
Type: Void, Visibility: Public,
Description: This function is an overloaded function of GetInput() for menus and gameplay that only 
needs two options displayed. It prints the query on the screen, and the two options are printed following
the query. Input is redefined to default value if needed and a console readkey is placed to equal
the value of input.

InitializeItems() 
Type: Void, Visibility: Public,
Description: This function is used to gives the weapons and other items values for later use.
Each weapon and item has a damage and name. For example, the weapon _bow was not given a value when
declaring it, in this function it gives _bow a name and damage with the struct item variables name and cost.

PrintInventory(item[] inventory)
Type: Void, Visibilty: Public,
Description: This inventory is used to print a selected players inventory using a for loop. The
parameter is used to specify which inentory to acces such as player 1 or player 2. First a for loop 
is used as i is set to 0 and as long as i is less than inventory.length, then add 1.
For each item a message is sent to the console with i being the index of the inventory with the name.
A second message is printed under the item name that states the damage.

SwitchInventory(Character character)
Type: Void, Visibility: Public, 
Description: This function opens the switch weapons menu, which is determined by which player with the parameter.
The function will print the inventory of the selected players inventory with the PrintInventory() function.
The GetInput() function is called with three parameters, the two string options and the string query, and prints
the options to the console. A ReadKey is set to the value of input to receive players decision and a if function 
is set with two branches. The branches are if the player pressed NumKey 1 or 2, the EquipItem() function would be called
with the index of the player's decision. 

SelectLoadouts(Character character)
Type: Void, Visibility: Public, 
Description: This function utiziles many smaller functions to operate, first to start off is a 
GetInput() function with four string parameters. The three options will be set to the names of the 
three main roles: Knight, Archer, and Wizard. A console ReadKey equal to input and a if statement is after.
The ReadKey gets the input for the if statement, depending on which role player chosen, the player will be created 
with the role specific constructor. The AddItemToInv() function is called to place the certain items
in the player inventory. Once the first half is completed it is repeated for player two's choice.
The currentWeapon variable is also set to the default hands weapon for each class.

StartBattle()
Type: Void, Visibility: Public,
Description: The function that runs the entire battle system for the game using functions and some arrays.
The function begins with a Console Clear to tidy up the screen then opening a while loop with the 
conditions of the character function, StillAlive(), which checks if the player are still alive during combat.
Once the loop is opened the function PrintStats(), which prints stats for each player, will be called to show players
the neccessary information such as health, armor, arrow count, and mana.
A GetInput() with four string parameters is inserted with attack, heal, and change weapon option. 
A conditional is set up for the input of the player for the three main actions, Attack, Heal, Change Weapon.
If player decides to attack the attacking player will call their BaseAttack() function that takes the damage
from the enemy and displays the damage output. The player can choose to heal which calls the Heal(Character character), 
a function that heals the player by 10, if their health is not at 100.The player can also choose the Change Weapon option,
a option that calls the SwitchInventory() function for the player.

AddItemToInv(item item, int index)
Type: Void, Visibility: Public,
Description: A small function that takes the players inventory array and sets the item in the specific
index as specified.

Heal()
Type: Float, Visibility: Public,
Description: A simple function that takes the player's health and adds 10 to the value.
If the player is already at full health, 100 health, the health is automatically set back to 100 
for certain limit can not be passed. The health is then returned with a return.

TakingDamage(float _damageVal)
Type: (Virtual) Float, Visibility: Public,
Description: A essential but basic function that grabs the health of the enemy subtracts and returns.
First the damageVal variable, which is set an value in BaseAttack(), is subtracted from the enemy health.
A conditional is then placed to make sure that if health is below zero, it will be set back to 0. The 
damageVal variable is then returned.

BaseAttack(Character enemy)
Type: (Virtual) Float, Visibility: Public,
Description: The function is a virtual function with three overrided versions of it for each role. The 
basic function first creates a float that equals all damage from sources and subtract it from the defense
of the enemy. A WriteLine is ussed to print how much damage was done in that attack, then
returns the TakingDamage() function for the enemy.

StillAlive()
Type: Bool, Visibility: Public,
Description: A small function that checks if the players health is above 0 then returns health.

PrintStats()
Type: Void, Visibility: Public,
Description: The function that prints the players' stats at the beginning of each turn.
A conditional statement is made for each role a player can possibly be. Each role has a 
WriteLine to print the name of the role and health. The Knight is the only role with Armor 
The Archer has a stat that only that class has arrowCount. Wizard is the only class withe 
the WriteLine for mana.

Contains(int itemIndex)
Type: Bool, Visibility: Public,
Description: A function that checks if the player inventory contains that item. A conditional
is set that the itemIndex parameter is greater or equal to zero and that its less than the inventory
length. If all the requirements are met, the function returns true, else the function returns false.

EquipItem()
Type: Void, Visibility: Public,
Description: A function that will equip a certain item to current weapon. The function first callse
the Contains() function to check that item is in the players' inventory. If the check is true,
the current weapon damage is changed to be the new selected weapon.

ArrowTips(string option1, string option2, string option3, string query)
Type: Void, Visibility: Public,
Description: A function identical to the GetInput() function. The query string is printed asking to 
pick a kind of arrow, three options are printed out asking the player to choose from one. A console readkey
is set to equal input to gather the players decision and select the right base attack function.

Save()
Type: Void, Visibility: Public,
Description: A function that saves the wins for each player to load the scoreboard. The functions
creates a new writer to a file, and prints the number of each players wins to that file for loading later
when player want to see their wins.

Load()
Type: (Virtual) Bool, Visibility: Public,
Description: The function that loads the leaderboards of the players' wins. Two variables, player1victories and
player2Victories are set to the value of 0, and a conditonal is made to check if the file exists that contains the
saved data. If the saved data is there, it checks if the data can be converted to a int. The if statement returns true
if the saved data converted to int else it returns false.

### Essential Variables

player1
Type: Character, Visibility: Private,
Description: The character of player one that comes from the basic character class.

player2
Type: Character, Visibility: Private,
Description: The character variable for player two that comes from the base Class, Character.

_longsword 
Type: item, Visibility: Private,
Description: A variable of a weapon that uses a struct to get damage and name.

_bow
Type: item, Visibility: Private,
Description: A variable of the Archer's weapon that a struct gives the name and damage to.

_gameOver
Type: Bool, Visibility: Private,
Description: the variable that determines when the game is over. This is used in the battle function
after a player is defeated and the while loop ends.