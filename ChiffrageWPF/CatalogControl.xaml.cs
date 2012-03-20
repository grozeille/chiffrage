using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chiffrage.App.Views;

namespace ChiffrageWPF
{
    /// <summary>
    /// Interaction logic for CatalogControl.xaml
    /// </summary>
    public partial class CatalogControl : UserControl, ICatalogView
    {
        public CatalogControl()
        {
            InitializeComponent();
        }

        public void Display(Chiffrage.App.ViewModel.CatalogViewModel viewModel)
        {
            
        }

        public Chiffrage.App.ViewModel.CatalogViewModel GetViewModel()
        {
            return null;
        }

        public void AddSupply(Chiffrage.App.ViewModel.CatalogSupplyViewModel result)
        {
            
        }

        public void AddSupplies(IList<Chiffrage.App.ViewModel.CatalogSupplyViewModel> result)
        {
            
        }

        public void UpdateSupply(Chiffrage.App.ViewModel.CatalogSupplyViewModel result)
        {
            
        }

        public void RemoveSupply(Chiffrage.App.ViewModel.CatalogSupplyViewModel result)
        {
            
        }

        public void AddHardware(Chiffrage.App.ViewModel.CatalogHardwareViewModel result)
        {
            
        }

        public void AddHardwares(IList<Chiffrage.App.ViewModel.CatalogHardwareViewModel> result)
        {
            
        }

        public void UpdateHardware(Chiffrage.App.ViewModel.CatalogHardwareViewModel result)
        {
            
        }

        public void RemoveHardware(Chiffrage.App.ViewModel.CatalogHardwareViewModel result)
        {
            
        }

        public void AddHardwareSupply(Chiffrage.App.ViewModel.CatalogHardwareSupplyViewModel result)
        {
            
        }

        public void RemoveSupplies()
        {
            
        }

        public void RemoveAllHardwares()
        {
            
        }

        public void UpdateHardwares(IList<Chiffrage.App.ViewModel.CatalogHardwareViewModel> result)
        {
            
        }

        public void SetParent(System.Windows.Forms.Control parent)
        {
            
        }

        public void ShowView()
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }

        public void HideView()
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
