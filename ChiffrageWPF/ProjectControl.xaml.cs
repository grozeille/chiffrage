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
    /// Interaction logic for ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl, IProjectView
    {
        public ProjectControl()
        {
            InitializeComponent();
        }

        public void SetProjectViewModel(Chiffrage.App.ViewModel.ProjectViewModel viewModel)
        {
           
        }

        public void SetSupplies(IList<Chiffrage.App.ViewModel.ProjectSupplyViewModel> supplies)
        {
           
        }

        public void SetHardwares(IList<Chiffrage.App.ViewModel.ProjectHardwareViewModel> hardwares)
        {
           
        }

        public Chiffrage.App.ViewModel.ProjectViewModel GetProjectViewModel()
        {
            return null;
        }

        public void AddSupply(Chiffrage.App.ViewModel.ProjectSupplyViewModel viewModel)
        {
           
        }

        public void RemoveAllSupplies()
        {
           
        }

        public void AddSupplies(IList<Chiffrage.App.ViewModel.ProjectSupplyViewModel> supplies)
        {
           
        }

        public void RemoveSupply(Chiffrage.App.ViewModel.ProjectSupplyViewModel supply)
        {
           
        }

        public void AddHardware(Chiffrage.App.ViewModel.ProjectHardwareViewModel viewModel)
        {
           
        }

        public void RemoveHardware(Chiffrage.App.ViewModel.ProjectHardwareViewModel hardware)
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
