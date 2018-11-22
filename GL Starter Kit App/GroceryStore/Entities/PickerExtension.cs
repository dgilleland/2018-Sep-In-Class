using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Entities
{
    public partial class Picker
    {
        // Could have been coded like this:
        // public string FullName => $"{LastName}, {FirstName}";
        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }
        }
    }
}
