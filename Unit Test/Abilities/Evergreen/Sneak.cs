﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.Abilities
{
    class Sneak : Ability
    {
        public Sneak(Unit attachedUnit) : base("Sneak", "Takes half damage from outnumbered enemies", attachedUnit) {
            IsEvergreenMechanic = true;
        }
        public override void BeforeRecieveDamage(Unit attacker, ref int damage)
        {
            if (attacker.isOutnumbered)
                damage /= 2;
        }
    }
}
