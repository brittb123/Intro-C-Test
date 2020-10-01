using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace HelloWorld
{
   public class Character
    {
        public float _health;
        private string _name;
        protected float _defense;
        public float _damage;
        public item[] _inventory;
        private item _currentWeapon;
        private item _fists;
        private int _mana;
        public int player1Wins;
        public int player2Wins;
        public int _ArrowAmount;
       
        
        

      public  Character()
      {
            
            _health = 100;
            _name = "Player";
            _defense = 5;
            _damage = 15;
            _inventory = new item[2];
            _fists.name = "Fists";
            _fists.damage = 1;
            _mana = 100;
            _ArrowAmount = 15;
      }

      public  Character(float _healthVal, string _nameVal, float _defenseVal, float _damageVal)
      {
            _health = _healthVal;
            _name = _nameVal;
            _defense = _defenseVal;
            _damage = _damageVal;

      }

        //Base attack for all players and classes
      public virtual float BaseAttack(Character enemy)
      {
            float totalDamage = _damage + _currentWeapon.damage; 
            Console.WriteLine("\nThe other player has taken " + totalDamage + " damage");
            return enemy.TakingDamage(totalDamage);
      }

        //Prints Player stats depending on their Chosen Specialty
     public void PrintStats(Character character)
     {
            if(character is Knight)
            {
                _name = "Knight";
                Console.WriteLine("Chosen Role: " + _name);
                Console.WriteLine("Health: " + _health);
                Console.WriteLine("Armor: " + _defense);
                
            }
            else if(character is Wizard)
            {
                
                _name = "Wizard";
                Console.WriteLine("Chosen Role: " + _name);
                Console.WriteLine("Health: " + _health);
                Console.WriteLine("Mana: " + _mana);
                
            }

            else if(character is Archer)
            {
              
                _name = "Archer";
                Console.WriteLine("Chosen Role: " + _name);
                Console.WriteLine("Health: " + _health);
                Console.WriteLine("Arrows: " + character._ArrowAmount);
            }

     }

        // Takes all damage and subtracts from enemy health
      public virtual float TakingDamage(float _damageVal)
      {
           
            _health -= _damageVal;
            if (_health < 0)
            {
                _health = 0;
                
            }
            return _damageVal;
      }
        //Checks to see if inventory as so said item!
        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }

            return false;
        }

        //Equip an item to current loadout
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

       

        // Adds certain items to the inventory of either player
        public void AddItemToInv(item item, int index)
        {
            _inventory[index] = item;
        }

        //Saves both players stats to use after game reloads
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine("Times player 1 won:" + player1Wins);
            writer.WriteLine("Times player 2 won:" + player2Wins);

        }
       //Loads characters from a previous match
        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();
            if (int.TryParse(reader.ReadLine(), out player1Wins) == false)
            {
                return false;
            }

            if (int.TryParse(reader.ReadLine(), out player2Wins) == false)
            {
                return false;
            }
            return true;
        }

        // Grabs players inventory for modification
        public item[] GetInventory()
        {
            return _inventory;
        }

        // Checks to make sure both players are alive in battle;
        public bool StillAlive()
        {
            return _health > 1;
        }

        // Gets the name of the certain player!
        public string GetName()
        {
            return _name;
        }

        public virtual float Block()
        {
            _defense += 5;
            if (_defense > 10)
                _defense = 5;
            return _defense;
        }


    }
}
