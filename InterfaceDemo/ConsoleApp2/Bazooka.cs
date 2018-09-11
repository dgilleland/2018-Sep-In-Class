using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bazooka : IInflictDamage
    {
        private static Random Rnd = new Random();
        public double MaxSplashRadius { get; private set; }
        public Bazooka()
        {
            MinimumDamage = 10;
            MaximumDamage = 100;
            MaxSplashRadius = 5.5;
            HasSplashDamage = true;
        }
        #region IInflictDamage Implementations
        public int MaximumDamage { get; private set; }
        public int MinimumDamage { get; private set; }
        public bool HasSplashDamage { get; private set; }

        public void Attack()
        {
            var damage = Rnd.Next(MinimumDamage, MaximumDamage + 1);
            var radius = Rnd.NextDouble() * MaxSplashRadius;
            Console.WriteLine($"BOOM! You got hit with {damage} damage over an area of {radius} meters");
        }
        #endregion
    }
}
