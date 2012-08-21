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
using System.Windows.Shapes;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Catalogs.Module.Views;

namespace ChiffrageWPF.Views.Impl
{
    /// <summary>
    /// Interaction logic for ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window, IApplicationView
    {
        public ApplicationWindow()
        {
            InitializeComponent();
        }

        public ApplicationWindow(INavigationView navigationView, IDealView dealView, IProjectView projectView, ICatalogView catalogView, IErrorLogView errorLogView)
            : this()
        {
            this.LeftPanel.Children.Add(navigationView as UserControl);
            (navigationView as UserControl).Margin = new Thickness(0, 0, 0, 0);
            (navigationView as UserControl).BorderBrush = Brushes.LightGray;
            (navigationView as UserControl).BorderThickness = new Thickness(0, 0, 0, 0);

            this.CenterPanel.Children.Add(dealView as UserControl);
            (dealView as UserControl).Margin = new Thickness(0, 0, 0, 0);
            (dealView as UserControl).BorderThickness = new Thickness(0, 0, 0, 0);
            dealView.HideView();

            this.CenterPanel.Children.Add(projectView as UserControl);
            (projectView as UserControl).Margin = new Thickness(0, 0, 0, 0);
            (projectView as UserControl).BorderThickness = new Thickness(0, 0, 0, 0);
            projectView.HideView();

            this.CenterPanel.Children.Add(catalogView as UserControl);
            (catalogView as UserControl).Margin = new Thickness(0, 0, 0, 0);
            (catalogView as UserControl).BorderThickness = new Thickness(0, 0, 0, 0);
            catalogView.HideView();
            
            this.FooterPanel.Children.Add(errorLogView as UserControl);
            (errorLogView as UserControl).Margin = new Thickness(0, 0, 0, 0);
            (errorLogView as UserControl).BorderThickness = new Thickness(0, 0, 0, 0);
        }

        public void SetParent(System.Windows.Forms.Control parent)
        {
            
        }

        public void ShowView()
        {
            this.Show();
        }

        public void HideView()
        {
            this.Hide();
        }
    }
}
