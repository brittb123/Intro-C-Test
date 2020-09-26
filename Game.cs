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
        public bool _gameOver = false;
        private Wizard wizard;
        private item _longsword;
        private item _Scrolls;
        private item _Bow;
        private item _arrows;


        public void InitalizeItems()
        {
            _longsword.name = "Longsword";
            _longsword.damage = 15;
            _Bow.name = "Bow";
            _Bow.damage = 10;
            _arrows.name = "Arrows";
            _arrows.damage = 5;
           
        }

        public void PrintInventory(item[] inventory)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].damage + wizard.GetInventory());
            }
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
            
            
            InitalizeItems();

        }

        //Repeated until the game ends
        public void Update()
        {
            PrintInventory(wizard.GetInventory());
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
