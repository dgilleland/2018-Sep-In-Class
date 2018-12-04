using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattleEngine
{
    public class Ship
    {
        public int Power { get; private set; }
        public int Shields { get; private set; }
        public bool Disabled { get; private set; }
        public string Registry { get; private set; }

        public Ship(int power, string registry)
        {
            Power = power;
            Registry = registry;
        }

        public Ship(int power, string registry, int sheilds, bool disabled)
        {
            Power = power;
            Registry = registry;
            Shields = sheilds;
            Disabled = disabled;
        }

        public void RaiseShields()
        {
            int shieldStrength = Rnd.Next(200);
            if (shieldStrength > Power)
                shieldStrength = Power;
            Shields = shieldStrength;
            Power -= shieldStrength;
        }

        public void FireUpon(Ship victim)
        {
            int powerToUse = Rnd.Next(30, 50);
            if (powerToUse > Power * 2)
                powerToUse = Power / 2;
            victim.TakeDamage(powerToUse);
            Power -= powerToUse / 2;
        }

        public void TakeDamage(int strengthOfHit)
        {
            if (Shields > 0)
            {
                Shields -= Rnd.Next(strengthOfHit);
                if (Shields < 0)
                    Shields = 0;
            }
            else
            {
                // Give them a chance for a luck shot
                if (strengthOfHit > 10 && Rnd.Next(50) == 42)
                {
                    Power = Power / 2;
                    Disabled = true;
                }
                else
                {
                    Power -= Rnd.Next(strengthOfHit * 2);
                    if (Power < 200)
                    {
                        Disabled = true;
                        if (Power < 0)
                            Power = 0;
                    }
                }
            }
        }

        public override string ToString()
        {
            return Registry + " (Power:" + Power.ToString()
                   + ", Shields:" + Shields.ToString()
                   + ", Disabled: " + Disabled.ToString()
                   + ")";
        }

    } // end of Ship class
    public enum FleetType { Federation, Clingon }
}
