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

namespace ChiffrageWPF.Views.Impl
{
    /// <summary>
    /// Interaction logic for ErrorControl.xaml
    /// </summary>
    public partial class ErrorControl : UserControl, IErrorLogView
    {
        public ErrorControl()
        {
            InitializeComponent();
        }

        public void AppendLog(Chiffrage.App.ViewModel.LogItemViewModel logItem)
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
