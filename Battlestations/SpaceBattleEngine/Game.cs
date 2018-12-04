using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattleEngine
{
    public class Game
    {
        public List<Ship> StarFleet { get; set; }
        public List<Ship> BadGuys { get; set; }
        public Game()
        {
            this.StarFleet = ShipYard.BuildFleet(FleetType.Federation);
            this.BadGuys = ShipYard.BuildFleet(FleetType.Clingon);
        }

        public void Start()
        {
            // Bad guys are agressors - will start first
            // Raise sheilds on agressors
            foreach (Ship s in BadGuys)
                s.RaiseShields();

            // give an agressor first shot
            Ship shipToAct = BadGuys[Rnd.Next(BadGuys.Count)];
            Ship victim = StarFleet[Rnd.Next(StarFleet.Count)];
            shipToAct.FireUpon(victim);

            // defender raise shields
            foreach (Ship s in StarFleet)
                s.RaiseShields();

            // Alternate, one ship per fleet fires
            while(! IsAWinner())
            {
                DisplayFleets();
                // Klingon attacks
                shipToAct = BadGuys[Rnd.Next(BadGuys.Count)];
                if (!shipToAct.Disabled)
                    if (shipToAct.Shields == 0)
                        shipToAct.RaiseShields();
                    else
                    {
                        victim = StarFleet[Rnd.Next(StarFleet.Count)];
                        bool willDie = victim.Disabled;
                        shipToAct.FireUpon(victim);
                        if (willDie)
                            StarFleet.Remove(victim);
                    }
                // Federation attacks
                shipToAct = StarFleet[Rnd.Next(StarFleet.Count)];
                if (!shipToAct.Disabled)
                    if (shipToAct.Shields == 0)
                        shipToAct.RaiseShields();
                    else
                    {
                        victim = BadGuys[Rnd.Next(BadGuys.Count)];
                        bool willDie = victim.Disabled;
                        shipToAct.FireUpon(victim);
                        if (willDie)
                            BadGuys.Remove(victim);
                    }
                System.Threading.Thread.Sleep(300);
            }
            // run till all disabled or destroyed
        }
        private bool IsAWinner()
        {
            bool aWinner, klingonsLost = true, federationLost = true;
            // Check klingons
            foreach(Ship aShip in BadGuys)
                if (!aShip.Disabled)
                {
                    klingonsLost = false;
                    break;
                }
            // Check federation
            foreach(Ship aShip in StarFleet)
                if (!aShip.Disabled)
                {
                    federationLost = false;
                    break;
                }
            aWinner = klingonsLost || federationLost;
            return aWinner;
        }

        private void DisplayFleets()
        {
            Console.Clear();
            Console.WriteLine("(==Federation==)");
            Console.WriteLine("  Ships: " + StarFleet.Count.ToString());
            foreach (Ship aShip in StarFleet)
                Console.WriteLine(aShip);
            Console.WriteLine(">--Clingons--<");
            Console.WriteLine("  Ships: " + BadGuys.Count.ToString());
            foreach (Ship aShip in BadGuys)
                Console.WriteLine(aShip);
        }
    }
}
