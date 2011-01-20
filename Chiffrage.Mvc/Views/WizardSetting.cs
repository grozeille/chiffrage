using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public class WizardSetting
    {
        public WizardSetting(UserControl page, string title, string description, bool canFinish)
        {
            this.Page = page;
            this.CanFinish = canFinish;
            this.Title = title;
            this.Description = description;
        }

        public UserControl Page { get; protected set; }

        public bool CanFinish { get; protected set; }

        public bool Validated { get; set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }
    }
}