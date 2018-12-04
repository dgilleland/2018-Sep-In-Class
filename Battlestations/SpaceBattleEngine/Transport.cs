using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattleEngine
{
    public class Transport : FederationClassShip
    {
        // TODO: Transport is a "victim" kind of ship...
        public Transport(int power, string registry) : base(power, registry)
        {
        }
    }
}
