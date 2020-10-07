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

#### Getter Functions
These functions are for getting and return the function thats needed.

StillAlive()
Type: Bool, Visibility: Public,
Description: Returns the health true if players are still alive, and false if the players'
health.

GetInventory()
Type: item[], Visbility: Public,
Description: Returns the players' inventory for changes that needed to be made or added.

GetMana()
Type: Int, Visibility: Public,
Description: Gets the mana and returns for spellcasting to take affect.

GetName()
Type: String, Visbility: Public,
Description: Gets the name for the role in the print stats function.



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
Description: The variable that determines when the game is over. This is used in the battle function
after a player is defeated and the while loop ends.

_currentWeapon
Type: Item, Visibility: Public,
Description: This variable determines the players current weapon and affects the
damage values.

_inventory
Type: item[], Visibilty: Public,
Description: The variable determines the players inventory, whats in that inventory is shown with a for loop.
The damage and name values are from a item struct made in class.

_health
Type: Float, Visibility: Private,
Description: A variable that controls each players health, default is always set to one hundred, as well is the max is 100 health.
If the player exceeds 100 health it is automatically set back to 100.

_damage
Type: Float, Visibility: Public,
Description: Variable that determines the base damage of each player. The higher the damage value the more damage gets
pumped into the enemy for a base attack.

_defense
Type: Float, Visibilty: Public
Description: The variable that controls how much damage the player ignores. The variable is subtracted from _damage to count for the 
players defense.

_arrowCount
Type: Int, Visibility: Public,
Description: The arrow counter for the print stats function and the Archer's damage. Each attack with the Archer lowers the 
arrow by 1, and if you run out you lose damage.

_mana
Type: Int, Visibility: Public,
Description: This variable is the Wizard's magic the more spells casted the lower it gets. If the Wizard runs out of mana, damage will 
be dropped byh more than half of the wizards base!

_knightsFury
Type: Int, Visibility: Public,
Description: The Knight's Attacking specail skill that boosts the attacks by 5 damage. This 
damage is only added if the attacking player is a Knight.

_knightsHonor
Type: Int, Visibility: Public,
Description: The Knight's defensive special skill that blocks an extra 5 damage, only obtained by being 
a Knight.

_huntersFocus
Type: Int, Visibility: Private,
Description: The Archer's Attack ability that adds an extra 5 damage and only if the player attacking is a Archer
and that player is above 80 health.

_hunterPiercing
Type: Int, Visibility: Private,
Description: Arrow tips are given an extra 5 damage to any target if the player is attacking as an Archer.

_arrowQuiver 
Type: item[], Visibility: Private,
Description: This is the array that holds the arrow tips explosive, shock, and ice.

_explosiveArrows
Type: item, Visibility: Private,
Description: A type of damage modifier that changes which arrow chosen. Damage and name is used
from the item struct and used in the arrow quiver inventory.

_shockArrows
Type: item, Visibility: Private,
Description: A type of arrow in arrow quiver that does less than explosive but more than the
frost arrows.

_iceArrows
Type: item, Visibility: Private,
Description: A type of arrow in the arrow quiver that has the least damage modifier.

totalDamage
Type: Float, Visibility: Parameter,
Description: A essential float that adds the damage modifiers then subtracts that sum from the 
defense and abilities of that enemy.

_name
Type: String, Visibility: Public,
Description: The string that displays the role name of the players choice.

_fireballScroll
Type: item, Visibility: Private,
Description: A variable that is given a name and damage value through the struct item.

_manaCount
Type: Int, Visibility: Public,
Description: A wizard only variable that displays the mana and keeps track if spells can be casted.


## Flow of the Game
### Class Selection
The first part is always the two player giving input and selecting their loadouts,
roles, and special skills. The player can branch into three choices, Knight calls Chracter
class and creates the player for whichever decision made

### Battling
Once the player finish the class selection, the battling phase begins with the screen 
clearing and the players' stats are printed to the console with a function. The player can
attack, which calls the players' specific BaseAttack function or the player can also choose 
to heal which leads to calling the Heal() function stated earlier. The player also has a choice
to switch weapons which callse the menu and the function SwitchInventory().

### Switch Inventory
This part can be accesed anytime during

