using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class DealUserControl : UserControlView, IDealView
    {
        private int dealId;

        public DealUserControl()
        {
            this.InitializeComponent();
        }

        #region IDealView Members

        public void DisplayDeal(DealViewModel viewModel)
        {
            if (!(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";

            this.dealId = viewModel.Id;
            this.textBoxDealName.Text = viewModel.Name;
            this.textBoxReference.Text = viewModel.Reference;
            this.dateTimePickerDealBegin.Value = viewModel.StartDate;
            this.dateTimePickerDealEnd.Value = viewModel.EndDate;
            this.commentUserControl.Rtf = viewModel.Comment;
        }

        #endregion
    }
}