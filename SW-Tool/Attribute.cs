using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Tool
{
    public class Attribute
    {
        string name;
        int _value;

        public string Name { get { return name; } set { name = value; } }
        public int Value { get { return _value; } set { _value = value; } }

        public Attribute(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
