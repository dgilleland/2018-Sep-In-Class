using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattleEngine
{
    public class ShipYard
    {
        public static Ship BuildShip(string Registry)
        {
            int power = Rnd.Next(800, 1000);
            return new Ship(power, Registry);
        }

        public static List<Ship> BuildFleet(FleetType fleet)
        {
            string registryTemplate;
            if (fleet == FleetType.Federation)
                registryTemplate = "NCC%1";
            else
                registryTemplate = "IKS%1";
            int fleetCount = Rnd.Next(10, 15);

            List<Ship> theFleet = new List<Ship>();
            while (fleetCount > 0)
            {
                string reg = registryTemplate.Replace("%1", Rnd.Next(5000, 8000).ToString());
                theFleet.Add(BuildShip(reg));
                fleetCount--;
            }
            return theFleet;
        }
    }// end of ShipYard class
}
