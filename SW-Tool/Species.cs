using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Tool
{
    public class Species : INotifyPropertyChanged
    {
        private string _name;
        private string _desc;
        private List<string> _specialAbilities;

        private int _dexMin, _dexMax;
        private int _percMin, _percMax;
        private int _knowMin, _knowMax;
        private int _strMin, _strMax;
        private int _mechMin, _mechMax;
        private int _techMin, _techMax;
        private int _moveMin, _moveMax;

        public Species(string name, string description, List<string> specialAbilities, int dexMin, int dexMax, int percMin, int percMax, int knowMin, int knowMax, int strMin, int strMax, int mechMin, int mechMax, int techMin, int techMax, int moveMin, int moveMax)
        {
            _name = name;
            _desc = description;
            _specialAbilities = specialAbilities;
            _dexMin = dexMin;
            _dexMax = dexMax;
            _percMin = percMin;
            _percMax = percMax;
            _knowMin = knowMin;
            _knowMax = knowMax;
            _strMin = strMin;
            _strMax = strMax;
            _mechMin = mechMin;
            _mechMax = mechMax;
            _techMin = techMin;
            _techMax = techMax;
            _moveMin = moveMin;
            _moveMax = moveMax;
        }

        public string Name { get => _name; set { _name = value; RaiseNotifyChanged("Name"); } }
        public string Description
        {
            get => _desc; set
            {
                _desc = value;
            }
        }
        public List<string> SpecialAbilities { get => _specialAbilities; set => _specialAbilities = value; }
        public int DexMin { get => _dexMin; set => _dexMin = value; }
        public int DexMax { get => _dexMax; set => _dexMax = value; }
        public int PercMin { get => _percMin; set => _percMin = value; }
        public int PercMax { get => _percMax; set => _percMax = value; }
        public int KnowMin { get => _knowMin; set => _knowMin = value; }
        public int KnowMax { get => _knowMax; set => _knowMax = value; }
        public int StrMin { get => _strMin; set => _strMin = value; }
        public int StrMax { get => _strMax; set => _strMax = value; }
        public int MechMin { get => _mechMin; set => _mechMin = value; }
        public int MechMax { get => _mechMax; set => _mechMax = value; }
        public int TechMin { get => _techMin; set => _techMin = value; }
        public int TechMax { get => _techMax; set => _techMax = value; }
        public int MoveMin { get => _moveMin; set => _moveMin = value; }
        public int MoveMax { get => _moveMax; set => _moveMax = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
