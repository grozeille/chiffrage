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
using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Projects.Module.ViewModel;
namespace ChiffrageWPF.Views.Impl
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl, INavigationView
    {
        public NavigationControl()
        {
            InitializeComponent();
        }

        public void Display(NavigationItemViewModel viewModel)
        {
            
        }

        public void UpdateCatalog(CatalogItemViewModel viewModel)
        {
            
        }

        public void UpdateDeal(DealItemViewModel viewModel)
        {
            
        }

        public void AddDeal(DealItemViewModel viewModel)
        {
            
        }

        public void AddCatalog(CatalogItemViewModel viewModel)
        {
            
        }

        public void AddProject(int dealId, ProjectItemViewModel viewModel)
        {
            
        }

        public void UpdateProject(ProjectItemViewModel viewModel)
        {
            
        }

        public void SelectDeal(int dealId)
        {
            
        }

        public void SelectCatalog(int catalogId)
        {
            
        }

        public void SelectProject(int projectId)
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
