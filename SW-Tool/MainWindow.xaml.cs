using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SW_Tool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public VM currentViewModel = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = currentViewModel;
        }

        private void btnNewChar_Click(object sender, RoutedEventArgs e)
        {
            currentViewModel.CurrentChar = new Character();
            //DataContext = currentViewModel;
        }

        private void cbSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Species species = (Species)cbSpecies.SelectedItem;
            if(species != null)
            {
                currentViewModel.CurrentChar.Species = species;
            }
            currentViewModel.CurrentChar.Description=$"{currentViewModel.CurrentChar.Name} is {species.Description}";
        }

        private void btnDexAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Dexterity, c.Species.DexMax);
        }

        private static void IncreaseAttributeValue(Character c, Attribute at, int max, int increase = 1)
        {
            if (c.Ap > 0 && at.Value+increase <= max)
            {
                at.Value += increase;
                c.Ap -= increase;
            }
            else if (at.Value == max)
            {
                MessageBox.Show("You reached the maximum value in this attribute!");
            }
            else
            {
                MessageBox.Show("You do not have enough attribute points to increase the value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDexSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Dexterity, c.Species.DexMin);
        }

        private void btnPercAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Perception, c.Species.PercMax);
        }

        private void btnPercSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Perception, c.Species.PercMin);
        }

        private static void ReduceAttributeValue(Character c, Attribute at, int min, int reduction = 1)
        {
            if (at.Value - reduction >= min)
            {
                at.Value -= reduction;
                c.Ap += reduction;
            }
            else if (at.Value == min)
            {
                MessageBox.Show("You reached the minimum value in this attribute!");
            }
            else
                MessageBox.Show("The reduction is not possible.");
        }

        private void btnKnowAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Knowledge, c.Species.KnowMax);
        }

        private void btnKnowSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Knowledge, c.Species.KnowMin);
        }

        private void btnStrAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Strength, c.Species.StrMax);
        }

        private void btnStrSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Strength, c.Species.StrMin);
        }

        private void btnMechAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Mechanical, c.Species.MechMax);
        }

        private void btnMechSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Mechanical, c.Species.MechMin);
        }

        private void btnTechAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Technical, c.Species.TechMax);
        }

        private void btnTechSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Technical, c.Species.TechMin);
        }

        private void cbForce_Checked(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            c.Force = !c.Force;
        }

        private void btnDexSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Dexterity, c.Species.DexMin,3);
        }

        private void btnDexAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Dexterity, c.Species.DexMax,3);
        }

        private void btnPercAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Perception, c.Species.PercMax, 3);
        }

        private void btnPercSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Perception, c.Species.PercMin, 3);
        }

        private void btnKnowSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Knowledge, c.Species.KnowMin, 3);
        }

        private void btnStrSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Strength, c.Species.StrMin, 3);
        }

        private void btnMechSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Mechanical, c.Species.MechMin, 3);
        }

        private void btnTechSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            ReduceAttributeValue(c, c.Technical, c.Species.TechMin, 3);
        }

        private void btnKnowAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Knowledge, c.Species.KnowMax, 3);
        }

        private void btnStrAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Strength, c.Species.StrMax, 3);
        }

        private void btnMechAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Mechanical, c.Species.MechMax, 3);
        }

        private void btnTechAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            IncreaseAttributeValue(c, c.Technical, c.Species.TechMax, 3);
        }

        private void btnSaveList_Click(object sender, RoutedEventArgs e)
        {
            currentViewModel.SaveCharacters();
        }

        private void btnAddDexSkill_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            if (cbSkillsDex.SelectedValue != null)
            {
                string skillName = cbSkillsDex.Text;
                if (c.DexList == null)
                    c.DexList = new System.Collections.ObjectModel.ObservableCollection<Skill>();

                if (c.DexList.Count==0 || c.DexList.FirstOrDefault(x => x.Name == skillName) == null)
                {
                    c.DexList.Add(new Skill(skillName, c.Dexterity.Value));
                }
                else 
                    MessageBox.Show($"{skillName} already in list.");
            }
        }

        private void btnDexSkillSub_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            Button button = sender as Button;
            int index = lbSkillsDex.Items.IndexOf(button.DataContext);
            ReduceSkillValue(c, c.DexList[index], c.Dexterity.Value);
        }

        private void btnDexSkillSubD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            Button button = sender as Button;
            int index = lbSkillsDex.Items.IndexOf(button.DataContext);
            ReduceSkillValue(c, c.DexList[index], c.Dexterity.Value,3);
        }

        private void btnDexSkillAdd_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            Button button = sender as Button;
            int index = lbSkillsDex.Items.IndexOf(button.DataContext);
            IncreaseSkillValue(c, c.DexList[index], c.Species.DexMax);
        }

        private void btnDexSkillAddD_Click(object sender, RoutedEventArgs e)
        {
            Character c = currentViewModel.CurrentChar;
            Button button = sender as Button;
            int index = lbSkillsDex.Items.IndexOf(button.DataContext);
            IncreaseSkillValue(c, c.DexList[index], c.Species.DexMax,3);
        }

        private static void ReduceSkillValue(Character c, Skill sk, int min, int reduction = 1)
        {
            if (sk.Value - reduction >= min)
            {
                sk.Value -= reduction;
                c.Sp += reduction;
            }
            else if (sk.Value == min)
            {
                MessageBox.Show("You reached the minimum value in this skill!");
            }
            else
                MessageBox.Show("The reduction is not possible.");
        }

        private static void IncreaseSkillValue(Character c, Skill sk, int max, int increase = 1)
        {
            if (c.Sp > 0 && sk.Value + increase <= max)
            {
                sk.Value += increase;
                c.Sp -= increase;
            }
            else if (sk.Value == max)
            {
                MessageBox.Show("You reached the maximum value in this skill!");
            }
            else
            {
                MessageBox.Show("You do not have enough skill points to increase the value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lbChars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lbChars.SelectedIndex;
            currentViewModel.CurrentChar = currentViewModel.Characters[index];
            currentViewModel.CurrentChar.isLoaded = true;
            int sIndex = -1;
            for (int i = 0; i < currentViewModel.Species.Species.Count; i++)
            {
                if (currentViewModel.Species.Species[i].Name==currentViewModel.CurrentChar.Species.Name)
                {
                    sIndex = i; 
                }
            }
            cbSpecies.SelectedIndex = sIndex;
        }
    }
}
