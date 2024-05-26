using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Tool
{
    public class Attribute : INotifyPropertyChanged
    {
        string name;
        int _value;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get { return name; } set { name = value; RaiseNotifyChanged("Name"); } }
        public int Value { get { return _value; } set { _value = value; RaiseNotifyChanged("Value"); } }

        public Attribute(string name, int value)
        {
            Name = name;
            Value = value;
        }

        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
