using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: Klingon, Cargo, BirdOfPrey, BattleCruiser
namespace SpaceBattleEngine
{
    public class Constellation : FederationClassShip
    {
        // TODO: Aft & Fore torpedos and two phaser banks
        public Constellation(int power, string registry) : base(power, registry)
        {
        }
    }
}
