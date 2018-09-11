using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IInflictDamage> weaponsCache;
            weaponsCache = new List<IInflictDamage>();
            weaponsCache.Add(new Gun());
            weaponsCache.Add(new Bazooka());
        }
    }
}
