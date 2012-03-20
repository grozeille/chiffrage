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
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl, INavigationView
    {
        public NavigationControl()
        {
            InitializeComponent();
        }

        public void Display(Chiffrage.App.ViewModel.NavigationItemViewModel viewModel)
        {
            
        }

        public void UpdateCatalog(Chiffrage.App.ViewModel.CatalogItemViewModel viewModel)
        {
            
        }

        public void UpdateDeal(Chiffrage.App.ViewModel.DealItemViewModel viewModel)
        {
            
        }

        public void AddDeal(Chiffrage.App.ViewModel.DealItemViewModel viewModel)
        {
            
        }

        public void AddCatalog(Chiffrage.App.ViewModel.CatalogItemViewModel viewModel)
        {
            
        }

        public void AddProject(int dealId, Chiffrage.App.ViewModel.ProjectItemViewModel viewModel)
        {
            
        }

        public void UpdateProject(Chiffrage.App.ViewModel.ProjectItemViewModel viewModel)
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
