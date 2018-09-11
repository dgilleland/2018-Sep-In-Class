using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    // The Gun class "implements" the IInflictDamage interface
    public class Gun : IInflictDamage
    {
        private static Random Rnd = new Random();
        public Gun()
        {
            MinimumDamage = 10;
            MaximumDamage = 25;
            HasSplashDamage = false;
        }
        #region IInflictDamage Implementations
        public int MaximumDamage { get; private set; }
        public int MinimumDamage { get; private set; }
        public bool HasSplashDamage { get; private set; }

        public void Attack()
        {
            var damage = Rnd.Next(MinimumDamage, MaximumDamage + 1);
            Console.WriteLine($"BANG! You got hit with {damage} damage");
        }
        #endregion
    }
}
