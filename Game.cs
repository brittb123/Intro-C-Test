using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;

namespace HelloWorld
{

    public struct item
    {
        public string name;
        public int damage;
    }
    class Game
    {
       //All important items and and players created
        private Character player1;
        private Character player2;
        private Wizard wizard;
        private item _longsword;
        private item _fireScrolls;
        private item _Bow;
        private item _arrows;
        private item _shield;
        private item _lightningScroll;
        public string player1Role;
        public string player2Role;
        public int curretWeaponBoost;
        public bool _gameOver;

        //Gives items names and damage values
        public void InitalizeItems()
        {
            _longsword.name = "Longsword";
            _longsword.damage = 15;
            _Bow.name = "Bow";
            _Bow.damage = 10;
            _arrows.name = "Arrows";
            _arrows.damage = 5;
            _shield.name = "shield";
            _shield.damage = 5;
            _fireScrolls.name = "Fireball Scrolls";
            _fireScrolls.damage = 10;
            _lightningScroll.name = "Lightning Scrolls";
            _lightningScroll.damage = 20;
            _gameOver = false;
        }

        //Gets input for many decisions in combat or loadout selections
        public void GetInput(string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
        }

        //Overloads the first input for only 2 options
        public void GetInput(string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
           
        }

        //Saves a certain amount of data for later loading and usage
        public void Save()
        {
            //Creates a new writer
            StreamWriter writer = new StreamWriter("SaveData.txt");
            player1.Save(writer);
            player2.Save(writer);
            writer.Close();
        }

        //Loads the recent stats the players have left off with
        public void Load()
        {
            //Creates a new reader and a file
            StreamReader reader = new StreamReader("SaveData.txt");
            //Loads the data from the file above and prints
            player1.Load(reader);
            player2.Load(reader);
            //Closes the reader
            reader.Close();
        }

        //Prints the players inventory when switching weapons
        public void PrintInventory(item[] inventory)
        {
            Console.WriteLine("\nHere are your choices");
            for (int i = 0; i < inventory.Length; i++)
            {
               
                Console.WriteLine((i + 1) + ". " + inventory[i].name);
                Console.WriteLine("Damage: ");
                Console.WriteLine(inventory[i].damage);
                Console.WriteLine();
               
            }
        }
        public void SwitchInventory(Character character)
        {
            
            PrintInventory(character._inventory);
            char input2 = Console.ReadKey().KeyChar;
            switch (input2)
            {
                case '1':
                    {
                        //Swaps current weapon to selected item
                        character.EquipItem(0);
                        break;
                    }
                case '2':
                    {
                        //Swaps current weapon to selected item
                        character.EquipItem(1);
                        break;
                    }
            }

        }
        //Select loadouts for each player to begin battles
        public void SelectLoadouts(Character character)
        {
            GetInput("Knight", "Archer", "Wizard", "Player 1 Choose a loadout:");
            Console.WriteLine("Knights have a longsword, a shield, and more armor than normal!");
            Console.WriteLine("Archers have a bow, arrows, and a dagger for close quarters!");
            Console.WriteLine("Wizards have supreme scolls of fireballs and lightning and only class with mana!");

            char input = Console.ReadKey().KeyChar;
            if (input == '1')
            {
                //Adds player with the knight class and a Knight's Inventory
                player1 = new Knight();

                player1.AddItemToInv(_longsword, 0);
                player1.AddItemToInv(_shield, 1);
                curretWeaponBoost = _longsword.damage;
            }
            else if (input == '2')
            {
                //Adds player with the Archer Class and with archery items
                player1 = new Archer();

                player1.AddItemToInv(_Bow, 0);
                player1.AddItemToInv(_shield, 1);
            }

            else if (input == '3')
            {
                //Add player with the wizard class with magic items
                player1 = new Wizard();

                player1.AddItemToInv(_fireScrolls, 0);
                player1.AddItemToInv(_lightningScroll, 1);
            }

            GetInput("Knight", "Archer", "Wizard", "\nPlayer 2 Choose a loadout: ");
            Console.WriteLine("Knights have a longsword, a shield, and more armor than normal!");
            Console.WriteLine("Archers have a bow, arrows, and a dagger for close quarters!");
            Console.WriteLine("Wizards have supreme scolls of fireballs and lightning and only class with mana!");

            input = Console.ReadKey().KeyChar;
            if (input == '1')
            {
                //Creates the player 2 if knight selected also sets their current weapon to their main choice!
                player2 = new Knight();
                curretWeaponBoost = _longsword.damage;
                player2.AddItemToInv(_longsword, 1);
                player2.AddItemToInv(_shield, 2);
            }
            else if (input == '2')
            {
                //Creates player 2 as Archer if chosen!
                player2 = new Archer();
                curretWeaponBoost = _Bow.damage;
                player2.AddItemToInv(_Bow, 0);
                player2.AddItemToInv(_shield, 1);
            }

            else if (input == '3')
            {
                //Creates player 2 to be a Wizard if chosen!
                player2 = new Wizard();
                curretWeaponBoost = _fireScrolls.damage;
                player2.AddItemToInv(_fireScrolls, 0);
                player2.AddItemToInv(_lightningScroll, 1);
            }

        }

        
        

        //Starts Battle between the players till one loses!
        public void StartBattle()
        {
            Console.Clear();
            while(player1.StillAlive() && player2.StillAlive())
            {

                //Prints stats of player each round
                Console.WriteLine("Player One: ");
                player1.PrintStats(player1);
                Console.WriteLine("\nPlayer Two: ");
                player2.PrintStats(player2);
                char input = ' ';
              
                Console.WriteLine("\nPlayer One's Turn: ");
                GetInput("Attack", "Change Weapon", "Heal", "What is your play");
                input = Console.ReadKey().KeyChar;
                //If player attacks as a Knight Attack with knight abilites
                if (input == '1')
                {
                    player1.BaseAttack(player2);
                   
                }

                //Opens the inventory and able to switch the weapon using!
                if (input == '2')
                {
                    SwitchInventory(player1);
                }

                if(input == '3')
                {
                  player1.Heal(player1);
                  Console.WriteLine("Player 2 is tending their wounds " + 10 + " health restored");
                }
                
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                //Clears screen for player two's turn
                if (player2.StillAlive())
                {
                    Console.Clear();
                    Console.WriteLine("\nPlayer One:");
                    player1.PrintStats(player1);
                    Console.WriteLine("\nPlayer 2");
                    player2.PrintStats(player2);
                    //Player Twos turn starts and asks for a decision!
                    input = ' ';
                    Console.WriteLine("\nPlayer Two, Now is the time to attack!");

                    GetInput("Attack", "Change Weapon", "Heal", "What is your play");

                    input = Console.ReadKey().KeyChar;
                    if (input == '1')
                    {
                        player2.BaseAttack(player1);
                    }


                    //Player 2 inventory and switch weapon functions!
                    if (input == '2')
                    {
                        SwitchInventory(player2);
                    }
                    //Blocks extra damage with defense for the turn!
                    if (input == '3')
                    {
                        Console.WriteLine("Player 2 is tending their wounds " + 10 + " health restored");
                        player2.Heal(player2);
                    }
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();

                }
                
            }
            Console.Clear();
            _gameOver = true;
        }

        //Run the game
        public void Run()
        {
            Start();
            while (_gameOver == false)
            {
                Update();
            }
            End();
            
        }

        //Performed once when the game begins
        public void Start()
        {
            InitalizeItems();
            
        }

        //Repeated until the game ends
        public void Update()
        {
            
                SelectLoadouts(player1);
                StartBattle();
           
        }

        //Performed once when the game ends
        public void End()
        {

            if (player1.StillAlive())
            {
                Console.WriteLine("Player one wins the battle and glory!");
                player1.player1Wins++;
            }
            if (player2.StillAlive())
            {
                Console.WriteLine("Player two shows the might they had by being victorious");
                player2.player2Wins++;
            }
            Save();
            
        }
    }
}
