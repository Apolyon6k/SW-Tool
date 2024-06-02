using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Data;

using Newtonsoft.Json;

namespace SW_Tool
{
    public class VM : INotifyPropertyChanged
    {
        private Character currentChar;
        private ObservableCollection<Character> characters;
        private SpeciesList species;
        private SkillList skills;

        public Character CurrentChar { get => currentChar; set { currentChar = value; RaiseNotifyChanged("CurrentChar"); if (!characters.Contains(currentChar)) characters.Add(currentChar); RaiseNotifyChanged("Characters"); } }

        public SpeciesList Species
        {
            get => species; set
            {
                species = value;
                RaiseNotifyChanged("Species");
            }
        }

        public ObservableCollection<Character> Characters { get => characters; set { characters = value; RaiseNotifyChanged("Characters"); } }

        public SkillList Skills { get => skills; set => skills = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseNotifyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void SaveCharacters()
        {
            var options = new JsonSerializerSettings();
            options.Formatting = Formatting.Indented;

            var jsonString = JsonConvert.SerializeObject(characters, options);
            File.WriteAllText("characters.json", jsonString);
        }

        public VM()
        {
            characters = new ObservableCollection<Character>();
            species = new SpeciesList();
            skills = new SkillList();
            currentChar = null;

            string skillsJson = File.ReadAllText("skills.json");
            skills = JsonConvert.DeserializeObject<SkillList>(skillsJson);
            string speciesJson = File.ReadAllText("Spezies.json");
            species = JsonConvert.DeserializeObject<SpeciesList>(speciesJson);
            if (File.Exists("characters.json"))
            {
                string charsJson = File.ReadAllText("characters.json");
                characters = JsonConvert.DeserializeObject<ObservableCollection<Character>>(charsJson);
            }
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
                int num1 = num / 3;
                int num2 = num % 3;

                if (num2 == 0)
                    str = $"{num1}D";
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
