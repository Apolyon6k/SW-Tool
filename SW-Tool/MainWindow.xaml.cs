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

        private static void IncreaseAttributeValue(Character c, Attribute at, int max)
        {
            if (c.Ap > 0 && at.Value < max)
            {
                at.Value++;
                c.Ap--;
            }
            else if (at.Value == max)
            {
                MessageBox.Show("You reached the maximum value in this attribute!");
            }
            else
            {
                MessageBox.Show("You do not have enough attribute point to increase the value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private static void ReduceAttributeValue(Character c, Attribute at, int min)
        {
            if (at.Value > min)
            {
                at.Value--;
                c.Ap++;
            }
            else if (at.Value == min)
            {
                MessageBox.Show("You reached the minimum value in this attribute!");
            }
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
    }
}
