using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    public class SkillList : INotifyPropertyChanged
    {
        private ObservableCollection<string> dexSkills;
        private ObservableCollection<string> percSkills;
        private ObservableCollection<string> knowSkills;
        private ObservableCollection<string> strSkills;
        private ObservableCollection<string> mechSkills;
        private ObservableCollection<string> techSkills;

        public ObservableCollection<string> DexSkills
        {
            get => dexSkills; set
            {
                dexSkills = value;
                RaiseNotifyChanged("DexSkills");
            }
        }
        public ObservableCollection<string> PercSkills { get => percSkills; set => percSkills = value; }
        public ObservableCollection<string> KnowSkills { get => knowSkills; set => knowSkills = value; }
        public ObservableCollection<string> StrSkills { get => strSkills; set => strSkills = value; }
        public ObservableCollection<string> MechSkills { get => mechSkills; set => mechSkills = value; }
        public ObservableCollection<string> TechSkills { get => techSkills; set => techSkills = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
