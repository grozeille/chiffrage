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

namespace ChiffrageWPF.Views.Impl
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

        public DealViewModel GetDealViewModel()
        {
            return null;
        }

        public void SetDealViewModel(DealViewModel viewModel)
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


        public void SetCalendarItems(IEnumerable<DealProjectCalendarItemViewModel> calendarItems)
        {
        }
    }
}
