using System;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class DealUserControl : UserControlView, IDealView
    {
        private int? dealId;

        public DealUserControl()
        {
            this.InitializeComponent();
        }

        #region IDealView Members

        public void Display(DealViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                if (viewModel.Comment == null || !(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                    viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";

                this.dealId = viewModel.Id;
                this.textBoxDealName.Text = viewModel.Name;
                this.textBoxReference.Text = viewModel.Reference;

                if (viewModel.StartDate == DateTime.MinValue)
                {
                    viewModel.StartDate = DateTime.Now;
                }

                this.dateTimePickerDealBegin.Value = viewModel.StartDate;

                if (viewModel.EndDate == DateTime.MinValue)
                {
                    viewModel.EndDate = DateTime.Now;
                }

                this.dateTimePickerDealEnd.Value = viewModel.EndDate;
                this.commentUserControl.Rtf = viewModel.Comment;
            });
        }

        public DealViewModel GetViewModel()
        {
            return this.InvokeIfRequired(() =>
            {
                if(!this.dealId.HasValue)
                {
                    return null;
                }

                var viewModel = new DealViewModel();

                viewModel.Id = this.dealId.Value;
                viewModel.Name = this.textBoxDealName.Text;
                viewModel.Reference = this.textBoxReference.Text;
                viewModel.StartDate = this.dateTimePickerDealBegin.Value;
                viewModel.EndDate = this.dateTimePickerDealEnd.Value;
                viewModel.Comment = this.commentUserControl.Rtf;

                return viewModel;
            });
        }

        #endregion

        public override void HideView()
        {
            this.dealId = null;
            base.HideView();
        }
    }
}