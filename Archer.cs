using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Archer : Character
    {
        private int _arrowcount;
        // Does extra damage if above 80 health but lose damage belove 50 health
        private int _huntersFocus;
        // Adds an extra +5 to damage for piercing arrows
        private int _huntersPiercing;
        //Bandits and evil classes take more damage
        private int _banditHunter;
        private string _name;
        private item[] _arrowQuiver;
        private item _explosiveArrows;
        private item _shockArrows;
        private item _iceArrows;

        public Archer() : base()
        {
            _arrowQuiver = new item[3];
            _name = "Archer";
            _explosiveArrows.name = "Explosive Tips";
            _explosiveArrows.damage = 25;
            _shockArrows.name = "Electric Tips";
            _shockArrows.damage = 20;
            _iceArrows.name = "Freezing Tips";
            _banditHunter = 5;
            _arrowcount = 15;
            _huntersFocus = 5;
            _huntersPiercing = 5;
        }

        public void ArrowTips(string option1, string option2, string option3, string Query)
        {
            
            Console.WriteLine(Query);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            
        }

        //Overrides basic Attack with the Archers Special abilities
        public override float BaseAttack(Character enemy)
        {
            float totalDamage = _damage;
            char input = Console.ReadKey().KeyChar;
            ArrowTips("Explosive", "Shocking", "Freezing", "Which arrow tip would you like to use?");
            if(input == '1')
            {
                totalDamage = _damage + _explosiveArrows.damage + _huntersFocus;
                Console.WriteLine("The archer grabs an explosive tipped arrow and lets it fly exploding the enemy for " + totalDamage);
                return enemy.TakingDamage(totalDamage);
            }
            else if (input == '2')
            {
                totalDamage = _damage + _shockArrows.damage + _huntersFocus;
                Console.WriteLine("The archer knocks an shock arrow and flips while letting the arrow go and dealt " + totalDamage);
                return enemy.TakingDamage(totalDamage);
            }
            else if (input == '3')
            {
                totalDamage = _damage + _iceArrows.damage + _huntersFocus;
                Console.WriteLine("The archer shoot a ice tipped arrow dealing " + totalDamage + " of freezing");
                return enemy.TakingDamage(totalDamage);
            }
            return enemy.TakingDamage(totalDamage);
        }
    }
}
