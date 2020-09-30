using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Knight : Character
    {
        private string _name;
        private int _stamina;
        private int _armor;
        private int _KnightsFury;
        //Knights Attack Boost
        private int _KnightsHonor;
        //Knights Defense boost
        private float currentWeapon;
        private item _longsword;

        public Knight() : base()
        {
            _stamina = 5;
            _armor = 5;
            _KnightsFury = 5;
            _KnightsHonor = 5;
            _name = "Knight";
            _longsword.damage = 15;
            currentWeapon = _longsword.damage;
        }

        
        //The players attacks in a special way if they are a knight
        public override float BaseAttack(Character enemy)
        {

            float totaldamage = _damage + _KnightsFury + currentWeapon;
            Console.WriteLine("\nThe knights eyes burn with the fury of a protector amd does more damage!");
            Console.WriteLine("The knight swings at player 2 and gets a swipe dealing " + totaldamage);
            return enemy.TakingDamage(totaldamage);
            
        }

        //Get the amount of damage and subtracts it from health 
        public override float TakingDamage(float _damageVal)
        {
            Console.WriteLine("The knights armor shines with honor!");
            _damageVal -= _KnightsHonor;
            return base.TakingDamage(_damageVal);
        }


    }



}
