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
        

      public  Character()
      {
            _health = 100;
            _name = "Chosen One";
            _defense = 10;
            _damage = 10;
            _inventory = new item[4];
      }

      public  Character(float _healthVal, string _nameVal, float _defenseVal, float _damageVal)
      {
            _health = _healthVal;
            _name = _nameVal;
            _defense = _defenseVal;
            _damage = _damageVal;

      }


      public virtual float BaseAttack(Character enemy)
      {
            float damageTotal = TakingDamage(_damage);
            Console.WriteLine("The other player has taken" + damageTotal + "damage");
            return damageTotal;
      }


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
        public item[] GetInventory()
        {
            return _inventory;
        }
   }
}
