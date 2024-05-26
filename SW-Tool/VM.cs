using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SW_Tool
{
    public class VM : INotifyPropertyChanged
    {
        private Character currentChar;
        public List<Character> characters;
        private List<Species> species;
        public List<Skill> dexSkills;
        public List<Skill> percSkills;
        public List<Skill> knowSkills;
        public List<Skill> strSkills;
        public List<Skill> mechSkills;
        public List<Skill> techSkills;

        public Character CurrentChar { get => currentChar; set { currentChar = value; RaiseNotifyChanged("CurrentChar"); } }

        public List<Species> Species
        {
            get => species; set
            {
                species = value;
                RaiseNotifyChanged("Species");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public VM()
        {
            characters = new List<Character>();
            species = new List<Species>();
            dexSkills = new List<Skill>();
            percSkills = new List<Skill>();
            knowSkills = new List<Skill>();
            strSkills = new List<Skill>();
            mechSkills = new List<Skill>();
            techSkills = new List<Skill>();
            currentChar = null;
            species.Add(new Species("Human", "human", new List<string> { ""}, 2 * 3, 4 * 3, 2 * 3, 4 * 3, 6, 12, 6, 12, 6, 12, 6, 12, 10, 12));
        }
    }

    public class IntToDiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "0D";
            else
            {
                string str = value.ToString();
                int num = int.Parse(str);
                int num1 = num/3; 
                int num2 = num%3;

                if(num2==0)
                    str= $"{num1}D";
                else
                    str = $"{num1}D+{num2}";

                return str;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
