using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Archer : Character
    {
        private int _arrowcount;
        private int _huntersFocus;
        private int _huntersPiercing;
        private int _banditHunter;
        private string _name;

        public Archer() : base()
        {
            _name = "Archer";
            _banditHunter = 5;
            _arrowcount = 15;
            _huntersFocus = 5;
            _huntersPiercing = 5;
        }

        //Overrides basic Attack with the Archers Special abilities
        public override float BaseAttack(Character enemy)
        {
            _damage += 10;
            if (_health < 50)
            {
                Console.WriteLine("You are in pain and lose focus of your target");
                _damage -= 10;
            }
            if (_health > 95)
            {
                _damage += 5;
            }
            return base.BaseAttack(enemy);
        }
    }
}
