using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public class GenericWizardSetting<T> : WizardSetting
        where T : UserControl, new()
    {
        public GenericWizardSetting(string title, string description, bool canFinish)
            : base(new T(), title, description, canFinish)
        {
        }


        public virtual void CreateNewPage()
        {
            this.Page = new T();
        }

        public T TypedPage
        {
            get
            {
                return this.Page as T;
            }
        }
    }
}