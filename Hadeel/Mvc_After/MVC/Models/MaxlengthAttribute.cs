using System;

namespace MVC.Models
{
    internal class MaxlengthAttribute : Attribute
    {
        private int v;

        public MaxlengthAttribute(int v)
        {
            this.v = v;
        }
    }
}