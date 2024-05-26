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
            if (c.Ap > 0 && c.Dexterity.Value < c.Species.DexMax)
            {
                c.Dexterity.Value++;
                c.Ap--;
            }
            else if(c.Dexterity.Value==c.Species.DexMax)
            {
                MessageBox.Show("You reached the maximum value in this attribute!");
            }
            else
            {
                MessageBox.Show("You do not have enough attribute point to increase the value!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
