﻿using System;
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
        private Character player1;
        private Character player2;
        

        public bool _gameOver = false;
        private Wizard wizard;
        private item _longsword;
        private item _fireScrolls;
        private item _Bow;
        private item _arrows;
        private item _shield;
        private item _lightningScroll;
        public string player1Role;
        public string player2Role;

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
            _fireScrolls.name = "Fireball Scrolls";
            _fireScrolls.damage = 10;
            _lightningScroll.name = "Lightning Scrolls";
            _lightningScroll.damage = 20;
        }

        //Gets input for many decisions in combat or loadout selections
        public void GetInput(string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
        }

        //Saves a certain amount of data for later loading and usage
        public void Save()
        {
            StreamWriter writer = new StreamWriter("SaveData.txt");
            player1.Save(writer);
            player2.Save(writer);
            writer.Close();
        }

        //Loads the recent stats the players have left off with
        public void Load()
        {
            StreamReader reader = new StreamReader("SaveData.txt");
            player1.Load(reader);
            player2.Load(reader);
            reader.Close();
        }

        //Prints the players inventory when switching weapons
        public void PrintInventory(item[] inventory)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name);
                Console.WriteLine("Damage: ");
                Console.WriteLine(inventory[i].damage);
                Console.WriteLine();
               
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

                player1 = new Knight();
               
                player1.AddItemToInv(_longsword, 0);
                player1.AddItemToInv(_shield, 1);
            }
            else if (input == '2')
            {
                player1 = new Archer();
                
                player1.AddItemToInv(_fireScrolls, 0);
                player1.AddItemToInv(_lightningScroll, 1);
            }

            else if (input == '3')
            {
                player1 = new Wizard();
               
                player1.AddItemToInv(_fireScrolls, 0);
                player1.AddItemToInv(_lightningScroll, 1);
            }

            GetInput("Knight", "Archer", "Wizard", "Player 2 Choose a loadout: ");
            Console.WriteLine("Knights have a longsword, a shield, and more armor than normal!");
            Console.WriteLine("Archers have a bow, arrows, and a dagger for close quarters!");
            Console.WriteLine("Wizards have supreme scolls of fireballs and lightning and only class with mana!");

             input = Console.ReadKey().KeyChar;
            if (input == '1')
            {

                player2 = new Knight();
              
                player2.AddItemToInv(_longsword, 0);
                player2.AddItemToInv(_shield, 1);
            }
            else if (input == '2')
            {
                player2 = new Archer();
               
                player2.AddItemToInv(_fireScrolls, 0);
                player2.AddItemToInv(_lightningScroll, 1);        
            }

            else if (input == '3')
            {
                player2 = new Wizard();
               
                player2.AddItemToInv(_fireScrolls, 0);
                player2.AddItemToInv(_lightningScroll, 1);
            }

        }

        //Get the name of the players
        public void CreateCharacter()
        {
            string name = " ";
            Console.WriteLine("What is your name player?");
            name = Console.ReadLine();
            
        }

        //Starts Battle between the players till one loses!
        public void StartBattle()
        {
            Console.Clear();
            while(player1.StillAlive() && player2.StillAlive())
            {

                
                Console.WriteLine("Player One: ");
                player1.PrintStats(player1);
                Console.WriteLine("\nPlayer Two: ");
                player2.PrintStats(player2);
                char input = ' ';
              
                Console.WriteLine("\nPlayer One's Turn: ");
                GetInput("Attack", "Change Weapon", "Block", "What is your play");
                input = Console.ReadKey().KeyChar;
                if (input == '1' && player1 is Knight)
                {
                    Console.WriteLine("Player One Charges Player two and deals " + player1._damage);

                    

                }

                else if(input == '1' && player1 is Archer)
                {


                }

                else if (input == '1' && player1 is Wizard)
                {



                }
                


            }
            

        }

        //Run the game
        public void Run()
        {
            Start();
            while (_gameOver = true)
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
            
        }
    }
}
