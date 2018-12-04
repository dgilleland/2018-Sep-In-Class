using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattleEngine
{
    public abstract class FederationClassShip : Ship
    {
        // TODO: Federation ships have phasers and torpedoes
        public FederationClassShip(int power, string registry) : base(power, registry)
        {
        }
    }
}
