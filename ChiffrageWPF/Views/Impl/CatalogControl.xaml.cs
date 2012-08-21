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
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Catalogs.Module.ViewModel;

namespace ChiffrageWPF.Views.Impl
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

        public void Display(CatalogViewModel viewModel)
        {
            
        }

        public CatalogViewModel GetViewModel()
        {
            return null;
        }

        public void AddSupply(CatalogSupplyViewModel result)
        {
            
        }

        public void AddSupplies(IList<CatalogSupplyViewModel> result)
        {
            
        }

        public void UpdateSupply(CatalogSupplyViewModel result)
        {
            
        }

        public void RemoveSupply(CatalogSupplyViewModel result)
        {
            
        }

        public void AddHardware(CatalogHardwareViewModel result)
        {
            
        }

        public void AddHardwares(IList<CatalogHardwareViewModel> result)
        {
            
        }

        public void UpdateHardware(CatalogHardwareViewModel result)
        {
            
        }

        public void RemoveHardware(CatalogHardwareViewModel result)
        {
            
        }

        public void AddHardwareSupply(CatalogHardwareSupplyViewModel result)
        {
            
        }

        public void RemoveSupplies()
        {
            
        }

        public void RemoveAllHardwares()
        {
            
        }

        public void UpdateHardwares(IList<CatalogHardwareViewModel> result)
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
