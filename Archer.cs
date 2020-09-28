﻿using System;
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
