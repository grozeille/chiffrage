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

            this.textBoxDealName.Validating += this.ValidateIsRequiredTextBox;
        }

        #region IDealView Members

        public DealViewModel GetDealViewModel()
        {
            return this.InvokeIfRequired(() =>
            {
                if(!dealId.HasValue)
                {
                    return null;
                }

                var dealViewModel = new DealViewModel();
                dealViewModel.Id = dealId.Value;
                dealViewModel.Name = this.textBoxDealName.Text;
                dealViewModel.Reference = this.textBoxReference.Text;
                dealViewModel.StartDate = this.dateTimePickerDealBegin.Value;
                dealViewModel.EndDate = this.dateTimePickerDealEnd.Value;
                dealViewModel.Comment = this.commentUserControl.Rtf;
                
                return dealViewModel;
            });
        }

        public void SetDealViewModel(DealViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                if (viewModel != null)
                {
                    this.dealId = viewModel.Id;
                    this.textBoxDealName.Text = viewModel.Name;
                    this.textBoxReference.Text = viewModel.Reference;
                    this.dateTimePickerDealBegin.Value = viewModel.StartDate;
                    this.dateTimePickerDealEnd.Value = viewModel.EndDate;
                    this.commentUserControl.Rtf = viewModel.Comment;
                }
                else
                {
                    this.dealId = null;
                    this.textBoxDealName.Text = string.Empty;
                    this.textBoxReference.Text = string.Empty;
                    this.dateTimePickerDealBegin.Value = DateTime.Now;
                    this.dateTimePickerDealEnd.Value = DateTime.Now;
                    this.commentUserControl.Rtf = string.Empty;
                }
            });
        }

        #endregion
    }
}