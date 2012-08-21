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
using Chiffrage.Projects.Module.Views;
using Chiffrage.Projects.Module.ViewModel;

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

        public void ShowView()
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }

        public void HideView()
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        public void SetProjectViewModel(ProjectViewModel viewModel)
        {
            
        }

        public void SetSupplies(IList<ProjectSupplyViewModel> supplies)
        {
            
        }

        public void SetHardwares(IList<ProjectHardwareViewModel> hardwares)
        {
            
        }

        public void SetFrames(IList<ProjectFrameViewModel> frames)
        {
            
        }

        public void SetSummaryItems(IList<ProjectSummaryItemViewModel> summaryItems)
        {
            
        }

        public ProjectViewModel GetProjectViewModel()
        {
            return null;
        }

        public void AddSupply(ProjectSupplyViewModel viewModel)
        {
            
        }

        public void AddSupplies(IList<ProjectSupplyViewModel> supplies)
        {
            
        }

        public void RemoveAllSupplies()
        {
            
        }

        public void RemoveSupply(ProjectSupplyViewModel supply)
        {
            
        }

        public void UpdateSupply(ProjectSupplyViewModel supply)
        {
            
        }

        public void AddHardware(ProjectHardwareViewModel viewModel)
        {
            
        }

        public void RemoveHardware(ProjectHardwareViewModel hardware)
        {
            
        }

        public void UpdateHardware(ProjectHardwareViewModel hardware)
        {
            
        }

        public void AddFrame(ProjectFrameViewModel frame)
        {
            
        }

        public void AddFrames(IList<ProjectFrameViewModel> frames)
        {
            
        }

        public void RemoveFrame(ProjectFrameViewModel frame)
        {
            
        }

        public void SetParent(System.Windows.Forms.Control parent)
        {
            
        }
    }
}
