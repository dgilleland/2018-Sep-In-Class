using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    // An Interface defines the method and
    // property "signatures" that a class
    // would have to implement.
    public interface IInflictDamage
    {
        int MaximumDamage { get; }
        int MinimumDamage { get; }
        bool HasSplashDamage { get; }
        void Attack(); // a method signature
    }
}
