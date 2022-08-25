using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrinciples_Apps.EncapsulateWhatVaries_V2
{
    internal class Vegeterian: Pizza
    {
        public override string Title => $"{base.Title} {nameof(Vegeterian)}";
        public override decimal Price => base.Price + 6m;
    }
    /*
     * هون ضفنا نوع جديد عشان نجرب نعدل عالقائمة 
     * 
    */
}
