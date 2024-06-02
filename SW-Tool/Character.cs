using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SW_Tool
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;
        private string _type;
        private string _desc;
        private Species _species;
        private Attribute dexterity = new Attribute("Dexterity", 0);
        private Attribute perception = new Attribute("Perception", 0);
        private Attribute knowledge = new Attribute("Knowledge", 0);
        private Attribute strength = new Attribute("Strength", 0);
        private Attribute mechanical = new Attribute("Mechanical", 0);
        private Attribute technical = new Attribute("Technical", 0);

        private Attribute control = new Attribute("Control", 0);
        private Attribute sense = new Attribute("Sense", 0);
        private Attribute alter = new Attribute("Alter", 0);

        private int move;
        private int ap = 18 * 3;
        private int sp = 7 * 3;
        private int cp = 0;
        private int fp = 1;

        private bool _force = false;
        public bool isLoaded = false;
        private bool showSkills = false;
        private ObservableCollection<Skill> dexList = new ObservableCollection<Skill>();
        private ObservableCollection<Skill> percList = new ObservableCollection<Skill>();
        private ObservableCollection<Skill> knowList = new ObservableCollection<Skill>();
        private ObservableCollection<Skill> strList = new ObservableCollection<Skill>();
        private ObservableCollection<Skill> mechList = new ObservableCollection<Skill>();
        private ObservableCollection<Skill> techList = new ObservableCollection<Skill>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => _name; set { _name = value; RaiseNotifyChanged("Name"); } }
        public string Description
        {
            get => _desc; set
            {
                _desc = value;
                RaiseNotifyChanged("Description");
            }
        }

        public Species Species { get => _species; set { _species = value; if(!isLoaded)UpdateSpeciesValues(_species); RaiseNotifyChanged("Species"); } }
        public Attribute Dexterity
        {
            get => dexterity; set
            {
                dexterity = value;
                RaiseNotifyChanged("Dexterity");
            }
        }
        public Attribute Perception
        {
            get => perception; set
            {
                perception = value; RaiseNotifyChanged("Perception");
            }
        }
        public Attribute Knowledge
        {
            get => knowledge; set
            {
                knowledge = value; RaiseNotifyChanged("Knowledge");
            }
        }
        public Attribute Strength
        {
            get => strength; set
            {
                strength = value; RaiseNotifyChanged("Strength");
            }
        }
        public Attribute Mechanical
        {
            get => mechanical; set
            {
                mechanical = value; RaiseNotifyChanged("Mechanical");
            }
        }
        public Attribute Technical
        {
            get => technical; set
            {
                technical = value; RaiseNotifyChanged("Technical");
            }
        }

        public ObservableCollection<Skill> DexList { get => dexList; set => dexList = value; }
        public ObservableCollection<Skill> PercList { get => percList; set => percList = value; }
        public ObservableCollection<Skill> KnowList { get => knowList; set => knowList = value; }
        public ObservableCollection<Skill> StrList { get => strList; set => strList = value; }
        public ObservableCollection<Skill> MechList { get => mechList; set => mechList = value; }
        public ObservableCollection<Skill> TechList { get => techList; set => techList = value; }
        public int Ap { get => ap; set { ap = value; RaiseNotifyChanged("Ap"); if (ap == 0) ShowSkills = true; } }
        public int Sp { get => sp; set { sp = value; RaiseNotifyChanged("Sp"); } }
        public int Move { get => move; set { move = value; RaiseNotifyChanged("Move"); } }
        public bool Force
        {
            get => _force; set
            {
                _force = value;
                RaiseNotifyChanged("Force");
            }
        }
        public Attribute Control { get => control; set => control = value; }
        public Attribute Sense { get => sense; set => sense = value; }
        public Attribute Alter { get => alter; set => alter = value; }
        public string Type { get => _type; set => _type = value; }
        public int CharacterPoints { get => cp; set => cp = value; }
        public int ForcePoints { get => fp; set => fp = value; }
        public bool ShowSkills
        {
            get => showSkills; set
            {
                showSkills = value;
                RaiseNotifyChanged("ShowSkills");
            }
        }

        public Character(string name, string type, string descr, Species species, bool force)
        {
            _name = name;
            _type = type;
            _desc = descr;
            _species = species;
            _force = force;

            dexList = new ObservableCollection<Skill>();

            if (species != null && !isLoaded)
            {
                UpdateSpeciesValues(species);
            }
        }

        public void UpdateSpeciesValues(Species species)
        {
            Ap = 18 * 3;
            Dexterity.Value = species.DexMin;
            Ap -= species.DexMin;
            Perception.Value = species.PercMin;
            Ap -= species.PercMin;
            Knowledge.Value = species.KnowMin;
            Ap -= species.KnowMin;
            Strength.Value = species.StrMin;
            Ap -= species.StrMin;
            Mechanical.Value = species.MechMin;
            Ap -= species.MechMin;
            Technical.Value = species.TechMin;
            Ap -= species.TechMin;
            Move = species.MoveMin;
            RaiseNotifyChanged("Ap");
        }

        public Character()
        {
            _name = "Give your character a cool name!";
            _type = "What template or character type is the character?";
            _desc = "write a description!";

            dexList = new ObservableCollection<Skill>();
        }

        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
