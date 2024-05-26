using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Tool
{
    public class Skill : Attribute
    {
        public Skill(string name, int value) : base(name, value)
        {
        }
    }
}
