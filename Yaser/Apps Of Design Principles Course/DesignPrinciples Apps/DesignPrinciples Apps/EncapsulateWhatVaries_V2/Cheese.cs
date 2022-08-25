using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrinciples_Apps.EncapsulateWhatVaries_V2
{
    internal class Cheese: Pizza
    {
        public override string Title => $"{base.Title} {nameof(Cheese)}";
        public override decimal Price => base.Price + 2m;

    }

}
