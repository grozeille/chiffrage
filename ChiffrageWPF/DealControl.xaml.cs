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
    /// Interaction logic for DealControl.xaml
    /// </summary>
    public partial class DealControl : UserControl, IDealView
    {
        public DealControl()
        {
            InitializeComponent();
        }

        public Chiffrage.App.ViewModel.DealViewModel GetDealViewModel()
        {
            return null;
        }

        public void SetDealViewModel(Chiffrage.App.ViewModel.DealViewModel viewModel)
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
