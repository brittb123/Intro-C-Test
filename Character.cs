using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace HelloWorld
{
   public class Character
    {
        protected float _health;
        private string _name;
        private float _defense;
        public float _damage;
        public item[] _inventory;
        private item currentWeapon;
        private item _fists;
        
        

      public  Character()
      {
            
            _health = 100;
            _name = "Player";
            _defense = 5;
            _damage = 10;
            _inventory = new item[4];
            _fists.name = "Fists";
            _fists.damage = 1;
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
            
            Console.WriteLine("The other player has taken" + _damage + "damage");
            return enemy.TakingDamage(_damage);
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
                int _mana = 100;
                _name = "Wizard";
                Console.WriteLine("Chosen Role: " + _name);
                Console.WriteLine("Health: " + _health);
                Console.WriteLine("Mana: " + _mana);
            }

            else if(character is Archer)
            {
                int _arrowcount = 15;
                _name = "Archer";
                Console.WriteLine("Chosen Role: " + _name);
                Console.WriteLine("Health: " + _health);
                Console.WriteLine("Arrows: " + _arrowcount);
            }

     }

        // Takes all damage and subtracts from enemy health
      public virtual float TakingDamage(float _damageVal)
      {
            _damageVal -= _defense;
            _health -= _damageVal;
            if (_health < 0)
            {
                _health = 0;
                
            }
            return _damageVal;
      }
        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }

            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                currentWeapon = _inventory[itemIndex];
            }
        }

        // Adds certain items to the inventory of either player
        public void AddItemToInv(item item, int index)
        {
            _inventory[index] = item;
        }

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_name);
        }
       
        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();
            if (float.TryParse(reader.ReadLine(), out _damage) == false)
            {
                return false;
            }

            if (float.TryParse(reader.ReadLine(), out _health) == false)
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
            return _health > 0;
        }

        // Gets the name of the certain player!
        public string GetName()
        {
            return _name;
        }
        
        
   }
}
