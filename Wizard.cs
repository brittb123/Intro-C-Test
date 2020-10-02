using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

  public class Wizard : Character
  {
        
        private int _scrolls;
        private string _name;
        private item _fireballScroll;
        private item _lightingScroll;
        private int _wizardsDestruction;
        private int _knightsDef;
        public int _manaCount;

    public Wizard() : base()
    {
            //Base item values and initalizing them
            _scrolls = 5;
            _name = "Wizard";
            _wizardsDestruction = 15;
            _knightsDef = 5;
            _fireballScroll.damage = 15;
            _lightingScroll.damage = 20;
            _manaCount = _mana;
    }

        //Allows other ways to lower mana if spell is cast
        public int GetMana()
        {
            return _mana;
        }



        //Overrides the BaseAttack to pick a scroll and lower mana per cast!
        public override float BaseAttack(Character enemy)
        {
            
                GetMana();
                float totaldamage;
               //Asks the player which spell to use for damage
                Console.WriteLine("\nWhich scroll would you like to use?");
                Console.WriteLine("Press 1 for Fireball scroll to incenrate the enemy");
                Console.WriteLine("Press 2 for Lightning scroll to shock them in both ways!");
                char input = ' ';
               //Gets input from players decision
                input = Console.ReadKey().KeyChar;
                if (input == '1' && _mana > 4)
                {
                //if player chooses fire this attack and damage value is taken differently
                    Console.WriteLine("\nThe wizard reads a fiery poem from a scroll and a fireball hits the enemy for " + _damage);
                    _mana -= 4;
                    _damage = 15;

                //If mana is high enough to cast, Deals extra damage
                    if (_mana > 85)
                    {
                        totaldamage = _damage + _fireballScroll.damage - _defense;
                        if (enemy is Knight)
                            totaldamage = (_damage + _wizardsDestruction + _fireballScroll.damage) - (_defense + _knightsDef);

                        Console.WriteLine("The magic in your voice has a powerful force to it and dealt " + totaldamage + " instead!");
                        _mana -= 4;

                      //Health of the enemy drops by the total damage done
                        return enemy.TakingDamage(totaldamage);
                    }
                    return enemy.TakingDamage(_damage);

                }

                  //If mana is too low to cast a fireball spell
                else if (input == '1' && _mana < 4)
                {
               
                    Console.WriteLine("The fire fades as the enemy player laughs at your casting skills!");
                    totaldamage = 0;
                    return enemy.TakingDamage(totaldamage);
                }

                  //If player decides to shock enemy damage values differ
                if (input == '2' && _mana > 8)
                {
                    Console.WriteLine("The Wizard chants with a thunderous voice a a lightning bolt zaps the enemy dealing " + _damage);
                    totaldamage = _damage + _lightingScroll.damage - _defense;

                    if (enemy is Knight)
                        totaldamage = (_damage + _wizardsDestruction + _lightingScroll.damage) - (_defense + _knightsDef);

                   return enemy.TakingDamage(totaldamage);

                }
                 //If mana is high enough it powers damage even more
                if (input == '2' && _mana < 8)
                {
                 //If mana is too low to cast shock
                    Console.WriteLine("The thunder calms as the lightning strikes and misses the enemy and weaking the power of the scroll;");
                    _damage -= 5;
                    totaldamage = 0;
                    return enemy.TakingDamage(totaldamage);
                }

            totaldamage = 0;
                return enemy.TakingDamage(totaldamage);

           
        }

        //The choices between the scroll types of damages 
        
      
    }
}
