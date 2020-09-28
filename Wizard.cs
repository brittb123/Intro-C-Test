using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
  public class Wizard : Character
  {
        private int _mana;
        private int _scrolls;
        private string _name;

    public Wizard() : base()
    {
            _mana = 100;
            _scrolls = 5;
            _name = "Wizard";

    }
        public int GetMana()
        {
            return _mana;
        }

        public override float BaseAttack(Character enemy)
        {
            ScrollChoice();
            return base.BaseAttack(enemy);
        }

        public void ScrollChoice()
        {
            Console.WriteLine("Which scroll would you like to use?");
            Console.WriteLine("Press 1 for Fireball scroll to incenrate the enemy");
            Console.WriteLine("Press 2 for Lightning scroll to shock them in both ways!");
            char input = ' ';
            input = Console.ReadKey().KeyChar;
            if(input == '1' && _mana > 4)
            {
                Console.WriteLine("The wizard reads a fiery poem from a scroll and a fireball hits the enemy for " + _damage);
                _mana -= 4; 
            }
            else
            {
                Console.WriteLine("The fire fades as the enemy player laughs at your casting skills!");
            }

            if(input == '2' && _mana > 8)
            {
                Console.WriteLine("The Wizard chants with a thunderous voice a a lightning bolt zaps the enemy dealing " + _damage);
            }
            else
            {
                Console.WriteLine("The thunder calms as the lightning strikes and misses the enemy and weaking the power of the scroll;");
                _damage -= 5;
            }
        }
    }
}
