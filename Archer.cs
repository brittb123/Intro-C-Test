using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Archer : Character
    {
        public int _arrowcount;
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
        private int _knightsDef;
        public int _arrowCount;

        public Archer() : base()
        {
            _arrowQuiver = new item[3];
            _name = "Archer";
            _explosiveArrows.name = "Explosive Tips";
            _explosiveArrows.damage = 25;
            _shockArrows.name = "Electric Tips";
            _shockArrows.damage = 20;
            _iceArrows.name = "Freezing Tips";
            _iceArrows.damage = 15;
            _banditHunter = 5;
            _arrowCount = 15;
            _huntersFocus = 5;
            _huntersPiercing = 5;
            _knightsDef = 5;
           
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
            ArrowTips("1. Explosive", "2. Shocking", "3. Freezing", "Which arrow tip would you like to use?");
            char input = Console.ReadKey().KeyChar;
            if (input == '1')
            {
                totalDamage = _damage + _explosiveArrows.damage + _huntersFocus - _defense;

                if (enemy is Knight)
                  totalDamage = (_explosiveArrows.damage + _huntersFocus + _huntersPiercing) - (_defense + _knightsDef);

                Console.WriteLine("\nThe archer grabs an explosive tipped arrow and lets it fly exploding the enemy for " + totalDamage);
                _ArrowAmount--;
                return enemy.TakingDamage(totalDamage);

            }
            else if (input == '2')
            {
                totalDamage = _damage + _shockArrows.damage + _huntersFocus - _defense;

                if (enemy is Knight)
                    totalDamage = ( _shockArrows.damage + _huntersFocus + _huntersPiercing) - (_defense + _knightsDef);

                Console.WriteLine("\nThe archer knocks an shock arrow and flips while letting the arrow go and dealt " + totalDamage);
                _ArrowAmount--;
                return enemy.TakingDamage(totalDamage);
            }
            else if (input == '3')
            {
                totalDamage = _damage + _iceArrows.damage + _huntersFocus;

                if (enemy is Knight)
                totalDamage = (_iceArrows.damage + _huntersFocus + _huntersPiercing) - (_defense + _knightsDef);

                Console.WriteLine("\nThe archer shoot a ice tipped arrow dealing " + totalDamage + " of freezing");
                _ArrowAmount--;
                return enemy.TakingDamage(totalDamage);
            }

            else
            return enemy.TakingDamage(totalDamage);
        }
    }
}
