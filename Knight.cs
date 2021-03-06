﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Knight : Character
    {
        private string _name;
      
        private int _armor;
        //Knights Attack Boost
        private int _KnightsFury;
        //Knights Defense boost
        private int _KnightsHonor;
        
       
        private item _longsword;

        public Knight() : base()
        {
            
            _armor = 5;
            _KnightsFury = 5;
            _KnightsHonor = 5;
            _name = "Knight";
            _longsword.damage = 15;
            
        }

        
        //The players attacks in a special way if they are a knight
        public override float BaseAttack(Character enemy)
        {
            _defense = 5;
          
            float totaldamage = _damage + _KnightsFury + _currentWeapon.damage - _defense;
            if(enemy is Knight)
            {
                totaldamage = _damage + _KnightsFury + _currentWeapon.damage - ( _defense + _KnightsHonor);
            }
            if (totaldamage < 5)
            {
              totaldamage = 0;
            }
            Console.WriteLine("\nThe knights eyes burn with the fury of a protector amd does more damage!");
            Console.WriteLine("The knight swings at player 2 and gets a swipe dealing " + totaldamage);
            return enemy.TakingDamage(totaldamage);
            
        }

        //Get the amount of damage and subtracts it from health 
        public override float TakingDamage(float _damageVal)
        {
            Console.WriteLine("The knights armor shines with honor!");
            
           
            return base.TakingDamage(_damageVal);
        }



    }



}
