using System.Windows.Forms;

namespace Chiffrage
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

        public UserControl Page { get; private set; }

        public bool CanFinish { get; private set; }

        public bool Validated { get; set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
    }
}