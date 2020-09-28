using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

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
        private item _Scrolls;
        private item _Bow;
        private item _arrows;
        private item _shield;


        public void InitalizeItems()
        {
            _longsword.name = "Longsword";
            _longsword.damage = 15;
            _Bow.name = "Bow";
            _Bow.damage = 10;
            _arrows.name = "Arrows";
            _arrows.damage = 5;
            _shield.name = "shield";
        }

        public void GetInput(string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
        }

        public void PrintInventory(item[] inventory)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].damage + wizard.GetInventory());
            }
        }

        public void SelectLoadouts(Character Knight)
        {
            GetInput("Knight", "Archer", "Wizard", "Choose a loadout:");
            char input = Console.ReadKey().KeyChar;
            if (input == '1')
            {

                player1 = new Knight();
                Knight.AddItemToInv(_longsword, 0);
                Knight.AddItemToInv(_shield, 1);
            }


        }
       
        public void CreateCharacter()
        {
            string name = " ";
            Console.WriteLine("What is your name player?");
            name = Console.ReadLine();

        }


        //Run the game
        public void Run()
        {
            Start();
            while (_gameOver = false)
            {
                Update();
            }
            End();
            
        }

        //Performed once when the game begins
        public void Start()
        {
            SelectLoadouts(player1);

            InitalizeItems();

        }

        //Repeated until the game ends
        public void Update()
        {
            SelectLoadouts(player1);
            PrintInventory(player1.GetInventory());
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
