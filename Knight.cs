using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Knight : Character
    {
        private int _stamina;
        private int _armor;
        private int _KnightsFury;
        //Knights Attack Boost
        private int _KnightsHonor;
        //Knights Defense boost

        public Knight() : base()
        {
            _stamina = 5;
            _armor = 5;
            _KnightsFury = 5;
            _KnightsHonor = 5;
            
        }
        //The players attack if they are a knight
        public override float BaseAttack(Character enemy)
        {
            _damage += _KnightsHonor;
            Console.WriteLine("The knights eyes burn with the fury of a protector amd does more damage!");
            return base.BaseAttack(enemy);
        }

        //Get the amount of damage and subtracts it from health 
        public override float TakingDamage(float _damageVal)
        {
            Console.WriteLine("The knights armor shines as it absorbs some damage making the attack weaker");
            _damageVal -= _KnightsHonor;
            return base.TakingDamage(_damageVal);
        }


    }



}
