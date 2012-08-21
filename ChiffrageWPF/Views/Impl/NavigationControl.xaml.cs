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
            var dealImage = new Image
                {
                    Width=16,
                    Height=16,
                    Stretch = Stretch.Fill,
                    Source = new BitmapImage(new Uri(@"/ChiffrageWPF;component/Resources/user_suit.png"))
                };

            var projectImage = new Image
            {
                Width=16,
                Height=16,
                Stretch = Stretch.Fill,
                Source = new BitmapImage(new Uri(@"/ChiffrageWPF;component/Resources/report.png"))
            };

            
            foreach (var item in viewModel.Catalogs)
            {/*
                var catalogImage = new Image
                {
                    Width=16,
                    Height=16,
                    Stretch = Stretch.Fill,
                    Source = new BitmapImage(new Uri(@"/ChiffrageWPF;component/Resources/book_open.png"))
                };
                var imageAndText = new System.Windows.Controls.StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                imageAndText.Children.Add(dealImage);
                imageAndText.Children.Add(new TextBlock
                    {
                        Text = item.SupplierName,
                        Margin = new Thickness(5,0,0,0)
                    });

                var dataTemplate = new DataTemplate();
                dataTemplate.VisualTree = new FrameworkElementFactory(typeof(StackPanel));
                dataTemplate.VisualTree.AppendChild(imageAndText;
            

                var catalogNodeStyle = new Style(typeof(TreeViewItem));
                catalogNodeStyle.Setters.Add(new Setter
                {
                    Property = "HeaderTemplate",
                    Value = dataTemplate
                });*/

                catalogsNode.Items.Add(new TreeViewItem
                {
                    //Style = catalogNodeStyle
                    Header = item.SupplierName
                });
            }
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
